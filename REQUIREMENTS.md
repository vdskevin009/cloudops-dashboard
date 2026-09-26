# CloudOps Dashboard — Canonical Requirements

> **Source of truth for product requirements.** Read this file before changing behavior. Update it whenever scope, product intent, implementation status, or a design decision changes.

## Baseline

- **Repository:** `vdskevin009/cloudops-dashboard`
- **Default branch:** `main`
- **Baseline verified:** 2026-09-26
- **Code reference:** `6445e288ef28b2bdd9879755d9c9ad323fefc967`

## Requirement lifecycle

Statuses: `Proposed`, `Accepted`, `In progress`, `Implemented`, `Verified`, `Deferred`, `Superseded`, `Rejected`.

Rules:
1. Add each new user requirement here before or with implementation.
2. Do not mark requirements implemented from discussion alone; confirm code behavior.
3. Mark `Verified` only after relevant checks/acceptance succeed.
4. Preserve superseded decisions for traceability.
5. Do not misrepresent simulated data or actions as real production operations.

## Product requirements

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| COD-001 | CloudOps Dashboard is a safe operations/resilience simulation for a .NET/Azure portfolio. | Verified | Current product scope. |
| COD-002 | Service health, deployments, incidents, feature flags, logs and Prod/DR switching must remain explicitly simulated unless a future requirement adds real read-only integrations. | Verified | Current limitation. |
| COD-003 | The product must not imply that a real service, deployment, environment or DR switch was modified when only simulation state changed. | Accepted | Core trust requirement. |
| COD-004 | Incident workflow should support investigation, mitigation and resolution states. | Implemented | MVP behavior. |
| COD-005 | Prod/DR switch and failback must be guarded rather than accidental one-click state changes. | Implemented | Current MVP includes guarded switching. |
| COD-006 | Logs must be searchable and bounded; current history limits are acceptable product constraints. | Implemented | Current app caps logs/history. |

## Delivery / architecture

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| COD-TECH-001 | Active stack is Blazor WebAssembly with domain logic in `src/Core` and UI in `src/Web`. | Verified | Current repository layout. |
| COD-TECH-002 | CI must build, run the executable domain test harness and publish the site before deployment. | Verified | Current delivery contract. |
| COD-TECH-003 | GitHub Pages is the deployment target; no server, database or paid AI API is required for the current MVP. | Verified | Current architecture. |
| COD-TECH-004 | .NET 11 prerelease SDK/package versions must be updated together and tested before adoption. | Accepted | Stability constraint. |
| COD-TECH-005 | Browser storage must not be treated as a secure boundary for sensitive production data. | Verified | Current limitation. |

## Roadmap requirements

| ID | Requirement | Status | Implementation notes |
|---|---|---|---|
| COD-RM-001 | Consider read-only OpenTelemetry and health ingestion without turning simulated write controls into real production actions by default. | Proposed | Roadmap. |
| COD-RM-002 | Consider real deployment metadata, environment-scoped flags, incident timelines and infrastructure-as-code demonstrations. | Proposed | Roadmap. |

## Open questions / Needs confirmation

- Any move from simulation to real system integration must be captured as explicit requirements with read/write boundaries and safety constraints before implementation.

## Decision log

| Date | Decision | Result |
|---|---|---|
| 2026-09-26 | Establish `REQUIREMENTS.md` as the canonical requirement source. | Accepted |
| 2026-09-26 | Baseline against `6445e288ef28b2bdd9879755d9c9ad323fefc967`. | Accepted |

## Maintenance checklist

Before implementation: read this file, identify affected IDs, add new requirements and record conflicts.

After implementation: update statuses/notes, run build/tests, update the code reference after merge, and keep README/docs aligned.
