namespace Core;

public sealed class DemoService
{
    public string Name { get; set; } = "";
    public bool Healthy { get; set; } = true;
    public int LatencyMs { get; set; } = 42;
    public int Version { get; set; } = 1;
}
public sealed class Incident
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "";
    public string Status { get; set; } = "Investigating";
    public DateTimeOffset Opened { get; set; } = DateTimeOffset.UtcNow;
}
public sealed record AuditEvent(DateTimeOffset At, string Level, string Message);
public sealed class Operations
{
    public string ActiveRegion { get; set; } = "Prod";
    public bool DrHealthy { get; set; } = true;
    public bool ReplicationCurrent { get; set; } = true;
    public bool NewCheckout { get; set; }
    public List<DemoService> Services { get; set; } = [new() { Name="Family API", LatencyMs=38 }, new() { Name="Identity", LatencyMs=24 }, new() { Name="Notification worker", LatencyMs=87 }];
    public List<Incident> Incidents { get; set; } = [];
    public List<AuditEvent> Logs { get; set; } = [];
    public List<AuditEvent> Deployments { get; set; } = [];
    public bool CanSwitch => ActiveRegion == "Prod" ? DrHealthy && ReplicationCurrent : Services.All(x=>x.Healthy) && ReplicationCurrent;
    public void Switch(string confirmation)
    {
        if (!CanSwitch) throw new InvalidOperationException("Target region must be healthy and replication current.");
        if (confirmation != "SWITCH") throw new InvalidOperationException("Type SWITCH to confirm the simulated change.");
        ActiveRegion = ActiveRegion == "Prod" ? "DR" : "Prod";
        Log("NOTICE", $"Simulated traffic switched to {ActiveRegion}; no infrastructure was changed.");
    }
    public void Check()
    {
        Log("INFO", $"Synthetic check: {(ActiveRegion == "DR" ? (DrHealthy ? 3 : 0) : Services.Count(x=>x.Healthy))}/3 services healthy in {ActiveRegion}.");
    }
    public void ToggleFailure(DemoService service)
    {
        service.Healthy = !service.Healthy;
        Log(service.Healthy ? "INFO" : "ERROR", $"Prod / {service.Name}: {(service.Healthy ? "recovered" : "simulated timeout")}");
    }
    public void Deploy(DemoService service)
    {
        service.Version++;
        var entry = new AuditEvent(DateTimeOffset.UtcNow,"DEPLOY",$"Simulated {service.Name} v1.0.{service.Version} rollout to Prod completed.");
        Deployments.Insert(0,entry); if(Deployments.Count>50) Deployments.RemoveAt(50);
        Log(entry.Level,entry.Message);
    }
    public void Log(string level,string message)
    {
        Logs.Insert(0,new(DateTimeOffset.UtcNow,level,message));
        if (Logs.Count > 200) Logs.RemoveAt(200);
    }
}
