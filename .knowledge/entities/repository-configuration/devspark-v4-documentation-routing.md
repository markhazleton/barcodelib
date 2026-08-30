---
id: devspark-v4-documentation-routing
name: DevSpark v4 Documentation Routing
kind: repository-configuration
summary: Routes legacy `.documentation` artifacts into v4 current truth, transient work state, or human archive.
relations:
  - type: describes
    object: barcodelib-repo
  - type: supports
    object: adr-0001-devspark-v4-knowledge-boundary
owner: Make Bold Solutions
lifecycle: current
root: .knowledge
managed_by: human
evidence:
  - type: doc
    ref: .knowledge/governance/decisions/adr-0001-devspark-v4-knowledge-boundary.md
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/governance/constitution.md
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .devspark/templates/command-preamble-contract.md
    verified_by: inspection
    last_verified: 2026-08-30
---

# DevSpark v4 Documentation Routing

## Taxonomy

- `.knowledge/` holds durable current truth: governance, entity metadata,
  decisions, specifications, and team-owned overrides.
- `.devspark.work/` holds temporary work state: in-flight specs, audit working
  notes, PR reviews, quickfix records, and generated run output.
- `.archive/` holds obsolete or completed historical material after current
  value has been assimilated into code, governance, or entity knowledge.

## Reviewed Legacy Inputs

The former `.documentation` tree contained a legacy constitution, one historical
Copilot audit, and a folder README created during the v4 migration review. None
of those files are active DevSpark v4 command inputs.

## Assimilated Current Truth

- Repository governance is represented by `.knowledge/governance/constitution.md`.
- The v4 knowledge boundary is represented by
  `.knowledge/governance/decisions/adr-0001-devspark-v4-knowledge-boundary.md`.
- Application scope is represented by
  `.knowledge/entities/application-registry/registry.json`.
- Future work must use `.knowledge/specs/` for durable specs and
  `.devspark.work/` for transient workflow state.
