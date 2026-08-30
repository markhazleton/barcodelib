---
id: rendering-contracts
name: Rendering Contracts
kind: knowledge-model
summary: Raster and SVG rendering contracts for barcode images, labels, alignment, quiet zones, and matrix geometry.
relations:
  - type: extends
    object: barcode-domain
  - type: supports
    object: barcodelib-public-api
  - type: validated_by
    object: test-evidence-model
owner: Make Bold Solutions
lifecycle: current
root: BarcodeStandard
managed_by: human
evidence:
  - type: code
    ref: BarcodeStandard/Barcode.Rendering.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandard/SvgRenderer.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: test
    ref: BarcodeStandardTests/Rendering
    verified_by: execution
    test_attempted: true
    last_verified: 2026-08-30
---

# Rendering Contracts

BarcodeLib renders encoded barcode data as raster images and SVG documents.
Raster and SVG rendering share geometry rules where practical so output formats
remain behaviorally aligned.

## Contracts

- `EnforceGS1QuietZone` defaults to true for GS1-aware quiet-zone geometry.
- Alignment affects how linear bar sequences sit inside available width.
- Matrix rendering preserves a square symbol and adds quiet-zone modules.
- Labels may be generic or standardized for selected UPC/EAN outputs.
- ITF-14 includes bearer-bar behavior.
- PostNet renders full-height bars for one bits and shorter marks for zero bits.

## Verification Expectation

Rendering changes must prove geometry, label, or scanability behavior with
focused tests rather than relying on visual inspection alone.
