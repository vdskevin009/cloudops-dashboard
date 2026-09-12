# CloudOps Dashboard

A safe operations and resilience simulation for a .NET/Azure portfolio.

[Open the app](https://vdskevin009.github.io/cloudops-dashboard/) · [CI](https://github.com/vdskevin009/cloudops-dashboard/actions) · [Phone workflow](docs/PHONE-WORKFLOW.md)

## MVP features

Synthetic service health; failure/recovery controls; deployment version simulation and history; incident investigation/mitigation/resolution; feature flag with audit trail; searchable logs; guarded Prod/DR switch and failback.

## Run locally

Install the SDK pinned in global.json: .NET 11 RC1 (11.0.100-rc.1.26425.128). This is a prerelease SDK; update the SDK and ASP.NET package versions together after testing.

```sh
dotnet run --project src/Web
# Meaningful domain tests, using a dependency-free executable harness:
dotnet run --project tests/Core.Tests -c Release
dotnet publish src/Web -c Release -o artifacts/site
```

The harness exits nonzero on a failed assertion. It is deliberately run with **dotnet run**, not dotnet test.

## Repository layout

- src/Core: domain rules and calculations
- src/Web: responsive Blazor WebAssembly UI, persistence adapter and PWA assets
- tests/Core.Tests: executable domain tests
- docs: architecture, roadmap and phone instructions
- .github/workflows/ci.yml: PR checks and main-branch deployment
- scripts/setup.sh: Linux cloud environment setup

## Hosting and delivery

Public GitHub repository + GitHub Pages. No server, database, paid AI API or paid infrastructure. Standard public-repository GitHub-hosted runners are used. Changes on a feature branch go through a PR; merge to main builds, tests and deploys. Manual redeploy: Actions → Build, test and deploy → Run workflow → main.

Pages source must be **GitHub Actions** in Settings → Pages. The build changes the base href before publishing so offline integrity hashes match the Pages subpath. Rollback by reverting the problematic merge in a new PR; the revert deployment replaces the current build.

## Honest limitations

All metrics, checks, deployments, environments and switches are simulated. No real service is monitored or modified. Logs are limited to 200 entries and deployment history to 50.

Browser storage is scoped to the origin and profile, not a security boundary between apps on the same github.io origin. Do not store sensitive production data. There are no analytics or third-party scripts. Offline assets are cached after a successful first load; close all app tabs and reopen after a new deployment to activate the waiting service worker.

## Next steps

Read-only OpenTelemetry and health ingestion; real deployment metadata; environment-scoped flags; incident timelines; infrastructure-as-code demo.

See [architecture](docs/ARCHITECTURE.md).
