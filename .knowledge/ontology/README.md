---
id: barcodelib-ontology
name: BarcodeLib Knowledge Ontology
kind: knowledge-model
summary: Entry point for the repository ontology, taxonomy, entity index, and relation map.
relations:
  - type: describes
    object: barcodelib-repo
  - type: supports
    object: barcode-domain
owner: Make Bold Solutions
lifecycle: current
root: .knowledge/ontology
managed_by: human
required_layers:
  - taxonomy.md
  - entity-index.md
  - relation-map.md
evidence:
  - type: schema
    ref: .devspark/templates/schemas/devspark-entity.schema.json
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/entities/application-registry/registry.json
    verified_by: inspection
    last_verified: 2026-08-30
---

# BarcodeLib Knowledge Ontology

This ontology initializes DevSpark v4 current truth for BarcodeLib.

Use these layers together:

- `taxonomy.md` defines the knowledge categories, relation vocabulary, and evidence policy.
- `entity-index.md` lists current entities and their owning files.
- `relation-map.md` describes how repository, application, domain, workflow, and evidence entities connect.

The ontology is intentionally source-grounded. Entity documents cite current code,
tests, governance, or schema evidence instead of historical migration material.
