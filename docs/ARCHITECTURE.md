# Architecture

## Decision

Use standalone Blazor WebAssembly and .NET 11 for C# domain logic with zero-server hosting. This favors low operating cost and an easy portfolio deployment. Server-dependent features are deferred explicitly rather than embedding credentials in the client.

## Components

Operations is a deterministic state machine. CanSwitch enforces target-region health and current replication; Switch additionally checks the typed confirmation. Real monitoring should be a separate read-only backend collector, with credentials in server-side secret storage. Any future real failover adapter needs independent permissions, approval gates, idempotency and rollback.

Browser UI → C# domain → browser storage. Downloaded backups and issue links are user-initiated data exits. Domain code has no network dependencies.

## Privacy and persistence

All metrics, checks, deployments, environments and switches are simulated. No real service is monitored or modified. Logs are limited to 200 entries and deployment history to 50.

Local storage is best-effort, subject to quotas and browser deletion. Errors surface in the UI. App-specific storage keys and cache prefixes avoid accidental collisions, but all apps on one github.io origin can access the same origin storage. Future sensitive data requires an authenticated backend and server-side authorization.

## Testing

The executable harness tests domain boundaries and known scenarios. Release publish verifies Razor compilation, trimming and static assets. Browser smoke checks cover the primary workflow. Tests and publish run before the deploy job; pull requests cannot deploy.

## Deployment

GitHub Actions builds a versioned Pages artifact. A separate job uses pages:write and id-token:write only after build success. Main deploys through the github-pages environment. Pull requests get read-only permissions. Dependency versions are pinned; review updates to .NET RC versions before merging.

## Roadmap

1. Read-only OpenTelemetry and health ingestion
2. real deployment metadata
3. environment-scoped flags
4. incident timelines
5. infrastructure-as-code demo.

No paid hosting or external AI calls without Kevin's approval.
