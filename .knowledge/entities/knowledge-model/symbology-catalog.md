---
id: symbology-catalog
name: Symbology Catalog
kind: knowledge-model
summary: Supported barcode symbologies and implementation locations.
relations:
  - type: extends
    object: barcode-domain
  - type: supports
    object: barcodelib-public-api
  - type: validated_by
    object: test-evidence-model
owner: Make Bold Solutions
lifecycle: current
root: BarcodeStandard/Symbologies
managed_by: human
evidence:
  - type: code
    ref: BarcodeStandard/BarcodeLib.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandard/Symbologies
    verified_by: inspection
    last_verified: 2026-08-30
  - type: test
    ref: BarcodeStandardTests/Symbologies
    verified_by: execution
    test_attempted: true
    last_verified: 2026-08-30
---

# Symbology Catalog

The `BarcodeLib.TYPE` enum declares the public symbology surface. Current values
include UPC, EAN, two-of-five variants, Code 39, Codabar, PostNet, Bookland,
ISBN, JAN13, MSI variants, Modified Plessey, Code 11, USD8, UCC, LOGMARS,
Code 128 variants, ITF-14, Code 93, Telepen, FIM, Pharmacode, and QR Code.

## Implementation Model

Linear symbologies implement `IBarcode` and produce an encoded bar/space string.
QR Code implements `IMatrixBarcode` and produces a boolean module matrix.

## Verification Expectation

Every symbology behavior change should include targeted tests in
`BarcodeStandardTests/Symbologies/` or rendering tests when geometry changes.
