---
id: barcodelib-relation-map
name: BarcodeLib Relation Map
kind: knowledge-model
summary: High-level map of relationships between repository, apps, domain model, contracts, and evidence.
relations:
  - type: extends
    object: barcodelib-ontology
  - type: describes
    object: barcodelib-repo
owner: Make Bold Solutions
lifecycle: current
root: .knowledge/ontology
managed_by: human
evidence:
  - type: doc
    ref: .knowledge/entities/application-registry/registry.json
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/ontology/entity-index.md
    verified_by: inspection
    last_verified: 2026-08-30
---

# BarcodeLib Relation Map

```text
barcodelib-repo
├── uses application-registry
├── governed by .knowledge/governance/constitution.md
├── scopes barcode-standard
│   ├── uses barcode-domain
│   ├── exposes barcodelib-public-api
│   ├── implements symbology-catalog
│   ├── implements rendering-contracts
│   └── extends qr-code-support
├── scopes barcode-web
│   ├── uses barcodelib-public-api
│   └── describes web-sample-flows
├── scopes barcode-standard-tests
│   ├── validates symbology-catalog
│   ├── validates rendering-contracts
│   └── validates qr-code-support
└── uses devspark-v4-workflow
```

## Dependency Edges

- `barcode-web` depends on `barcode-standard`.
- `barcode-standard-tests` depends on `barcode-standard`.
- `qr-code-support` extends `symbology-catalog` and uses `rendering-contracts`.
- `test-evidence-model` validates `barcodelib-public-api`, `rendering-contracts`, and `qr-code-support`.
- `tracked-vendor-artifacts` supports repository audit interpretation by separating project-owned code from vendored files.
