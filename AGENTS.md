# CloudOps

Read `REQUIREMENTS.md` first and treat it as the canonical source for product intent and requirement status. For every user-requested change, identify affected requirement IDs or add new stable IDs, update status/implementation notes with the code, preserve superseded requirements, record ambiguity instead of inventing behavior, and update the requirement code reference after merge/verification.

Use .NET 11 and Blazor. Read README.md and docs/ARCHITECTURE.md first.
Keep calculations and state transitions in src/Core, UI in src/Web.
Run dotnet run --project tests/Core.Tests and dotnet publish src/Web -c Release.
Work on a feature branch and open a PR with behavior, validation and limitations.
Never commit secrets, real family information or financial account data. No paid services without Kevin's approval.
Keep the static app deployable to GitHub Pages under /cloudops-dashboard/. Preserve local data schema compatibility.
Do not represent simulated operations or deterministic templates as live integrations or AI calls.
