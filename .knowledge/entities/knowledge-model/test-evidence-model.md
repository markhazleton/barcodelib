---
id: test-evidence-model
name: Test Evidence Model
kind: knowledge-model
summary: Test suite and verification model for BarcodeLib behavior.
relations:
  - type: validates
    object: barcodelib-public-api
  - type: validates
    object: symbology-catalog
  - type: validates
    object: rendering-contracts
  - type: validates
    object: qr-code-support
owner: Make Bold Solutions
lifecycle: current
root: BarcodeStandardTests
managed_by: human
evidence:
  - type: test
    ref: dotnet test Barcode.sln --no-restore
    verified_by: execution
    test_attempted: true
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandardTests/Symbologies
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandardTests/Rendering
    verified_by: inspection
    last_verified: 2026-08-30
---

# Test Evidence Model

The test suite is the primary executable evidence source for BarcodeLib behavior.
It currently includes focused tests for symbology behavior, QR scanability,
quiet-zone behavior, and SVG rendering geometry.

## Verification Commands

```powershell
dotnet test Barcode.sln --no-restore
npx --yes markdownlint-cli2 "**/*.md"
dotnet list Barcode.sln package --vulnerable --include-transitive
dotnet list Barcode.sln package --outdated
```

## Evidence Rule

Behavioral fixes must include tests or a clear reason why executable evidence is
not possible. Metrics alone are not sufficient proof.
