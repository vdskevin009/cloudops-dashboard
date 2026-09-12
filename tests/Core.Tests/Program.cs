using Core;
static void Check(bool ok,string message){if(!ok)throw new Exception(message);}
var ops=new Operations();
try{ops.Switch("yes");throw new Exception("Missing confirmation accepted");}catch(InvalidOperationException){}
ops.DrHealthy=false; Check(!ops.CanSwitch,"Unhealthy DR blocks switch");
ops.DrHealthy=true;ops.ReplicationCurrent=false;Check(!ops.CanSwitch,"Replication lag blocks switch");
ops.ReplicationCurrent=true;ops.Switch("SWITCH");Check(ops.ActiveRegion=="DR","Failover");
ops.ToggleFailure(ops.Services[0]);Check(!ops.CanSwitch,"Unhealthy Prod blocks failback");
ops.ToggleFailure(ops.Services[0]);ops.Switch("SWITCH");Check(ops.ActiveRegion=="Prod","Failback");
ops.Deploy(ops.Services[0]);Check(ops.Services[0].Version==2 && ops.Deployments.Count==1,"Deployment version and history");
for(int i=0;i<250;i++)ops.Check();Check(ops.Logs.Count==200,"Bounded audit history");
Console.WriteLine("PASS: confirmation, health, replication, failover, failback, deployment and bounded logs (8 checks)");
