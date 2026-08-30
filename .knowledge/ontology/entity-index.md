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
| `barcodelib-repo` | `.knowledge/entities/barcodelib-repo/architecture.md` | Repository shape and app boundaries. |
| `application-registry` | `.knowledge/entities/application-registry/registry.json` | DevSpark v4 multi-app scope registry. |
| `devspark-v4-documentation-routing` | `.knowledge/entities/devspark-v4-documentation-routing/architecture.md` | Routing of legacy documentation into v4 destinations. |
| `tracked-vendor-artifacts` | `.knowledge/entities/tracked-vendor-artifacts/architecture.md` | Tracked third-party package and web library posture. |

## Knowledge Models

| Entity | File | Purpose |
|--------|------|---------|
| `barcode-domain` | `.knowledge/entities/barcode-domain/architecture.md` | Core product/domain model. |
| `barcodelib-public-api` | `.knowledge/entities/barcodelib-public-api/architecture.md` | Public BarcodeLib API and compatibility surface. |
| `symbology-catalog` | `.knowledge/entities/symbology-catalog/architecture.md` | Supported barcode symbologies and enum catalog. |
| `rendering-contracts` | `.knowledge/entities/rendering-contracts/architecture.md` | Raster, SVG, label, alignment, and quiet-zone contracts. |
| `qr-code-support` | `.knowledge/entities/qr-code-support/architecture.md` | QR Code matrix support and scanability evidence. |
| `web-sample-flows` | `.knowledge/entities/web-sample-flows/architecture.md` | ASP.NET Core MVC demo and export flows. |
| `test-evidence-model` | `.knowledge/entities/test-evidence-model/architecture.md` | Test suite coverage and verification rules. |

## Contributor Practice

| Entity | File | Purpose |
|--------|------|---------|
| `devspark-v4-workflow` | `.knowledge/entities/devspark-v4-workflow/architecture.md` | DevSpark v4 command, scope, and verification practice. |
