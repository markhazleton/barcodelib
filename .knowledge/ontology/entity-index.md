---
id: barcodelib-entity-index
name: BarcodeLib Entity Index
kind: knowledge-model
summary: Index of initialized DevSpark v4 knowledge entities for this repository.
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
    ref: .knowledge/ontology/taxonomy.md
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/entities/application-registry/registry.json
    verified_by: inspection
    last_verified: 2026-08-30
---

# BarcodeLib Entity Index

## Repository Configuration

| Entity | File | Purpose |
|--------|------|---------|
| `barcodelib-repo` | `.knowledge/entities/repository-configuration/barcodelib-repo.md` | Repository shape and app boundaries. |
| `application-registry` | `.knowledge/entities/application-registry/registry.json` | DevSpark v4 multi-app scope registry. |
| `devspark-v4-documentation-routing` | `.knowledge/entities/repository-configuration/devspark-v4-documentation-routing.md` | Routing of legacy documentation into v4 destinations. |
| `tracked-vendor-artifacts` | `.knowledge/entities/repository-configuration/tracked-vendor-artifacts.md` | Tracked third-party package and web library posture. |

## Knowledge Models

| Entity | File | Purpose |
|--------|------|---------|
| `barcode-domain` | `.knowledge/entities/knowledge-model/barcode-domain.md` | Core product/domain model. |
| `barcodelib-public-api` | `.knowledge/entities/knowledge-model/barcodelib-public-api.md` | Public BarcodeLib API and compatibility surface. |
| `symbology-catalog` | `.knowledge/entities/knowledge-model/symbology-catalog.md` | Supported barcode symbologies and enum catalog. |
| `rendering-contracts` | `.knowledge/entities/knowledge-model/rendering-contracts.md` | Raster, SVG, label, alignment, and quiet-zone contracts. |
| `qr-code-support` | `.knowledge/entities/knowledge-model/qr-code-support.md` | QR Code matrix support and scanability evidence. |
| `web-sample-flows` | `.knowledge/entities/knowledge-model/web-sample-flows.md` | ASP.NET Core MVC demo and export flows. |
| `test-evidence-model` | `.knowledge/entities/knowledge-model/test-evidence-model.md` | Test suite coverage and verification rules. |

## Contributor Practice

| Entity | File | Purpose |
|--------|------|---------|
| `devspark-v4-workflow` | `.knowledge/entities/contributor-practice/devspark-v4-workflow.md` | DevSpark v4 command, scope, and verification practice. |
