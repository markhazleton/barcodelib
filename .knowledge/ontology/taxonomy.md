---
id: barcodelib-taxonomy
name: BarcodeLib Knowledge Taxonomy
kind: knowledge-model
summary: Taxonomy for organizing BarcodeLib repository, domain, workflow, and evidence knowledge.
relations:
  - type: extends
    object: barcodelib-ontology
  - type: describes
    object: barcode-domain
owner: Make Bold Solutions
lifecycle: current
root: .knowledge/ontology
managed_by: human
evidence:
  - type: schema
    ref: .devspark/templates/schemas/devspark-entity.schema.json
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/governance/constitution.md
    verified_by: inspection
    last_verified: 2026-08-30
---

# BarcodeLib Knowledge Taxonomy

## Entity Categories

| Category | Directory | Purpose |
|----------|-----------|---------|
| Repository configuration | `.knowledge/entities/repository-configuration/` | Repo shape, DevSpark routing, platform, tracked artifact posture. |
| Knowledge model | `.knowledge/entities/knowledge-model/` | Barcode domain, public API, rendering, QR, tests, and web flow models. |
| Contributor practice | `.knowledge/entities/contributor-practice/` | Development workflow and verification expectations. |
| Application registry | `.knowledge/entities/application-registry/` | Multi-app registry consumed by DevSpark v4 scope resolution. |

## Relation Vocabulary

Use the DevSpark v4 relation names from the entity schema:

- `describes`: entity summarizes a repo, app, feature area, or contract.
- `supports`: entity contributes evidence or operational context to another entity.
- `uses`: entity depends on another entity at runtime or workflow time.
- `validates`: entity provides checks for another entity.
- `validated_by`: inverse relation to executable or documented evidence.
- `scopes`: entity limits where rules or knowledge apply.
- `derives_from`: entity was created from current source, tests, docs, or governance.
- `extends`: entity specializes a broader model.
- `generated_for`: generated or derived artifact supports a target entity.

## Evidence Policy

Durable knowledge must cite current evidence:

- Use `code` for source files, project files, manifests, and CI definitions.
- Use `test` for executable verification commands or test files.
- Use `doc` for README, governance, and current knowledge documents.
- Use `schema` for DevSpark schema files.

Avoid using archived or temporary paths as durable evidence. Archive paths can be
referenced from `.devspark.work/` notes, but current `.knowledge/` should point
to active code, current governance, current schemas, or stable public docs.

## Work-State Routing

| Destination | Meaning |
|-------------|---------|
| `.knowledge/` | Assimilated current truth and team-owned overrides. |
| `.devspark.work/` | In-flight DevSpark work packages, audits, PR reviews, quickfix state, and temporary review notes. |
| `.archive/` | Completed or obsolete historical material after durable value has been assimilated. |
