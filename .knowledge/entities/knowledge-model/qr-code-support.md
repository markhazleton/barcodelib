---
id: qr-code-support
name: QR Code Support
kind: knowledge-model
summary: QR Code matrix encoding, rendering, and scanability model.
relations:
  - type: extends
    object: symbology-catalog
  - type: uses
    object: rendering-contracts
  - type: validated_by
    object: test-evidence-model
owner: Make Bold Solutions
lifecycle: current
root: BarcodeStandard/Symbologies/QrEncoding
managed_by: human
evidence:
  - type: code
    ref: BarcodeStandard/Symbologies/QRCode.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandard/Symbologies/QrEncoding/QrCode.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: test
    ref: BarcodeStandardTests/Symbologies/QrCodeTests.cs
    verified_by: execution
    test_attempted: true
    last_verified: 2026-08-30
---

# QR Code Support

QR Code is the repository's matrix symbology. It is exposed as `TYPE.QRCODE`,
implemented through `IMatrixBarcode`, and rendered from `EncodedMatrix`.

## Current Behavior

- QR encoding produces a two-dimensional boolean module grid.
- `EncodedMatrix` is the public inspection API for matrix output.
- `EncodedValue` throws for matrix symbologies because a linear bar/space string
  is not meaningful for QR Code.
- SVG and raster renderers draw dark modules from the matrix and preserve a
  square symbol with quiet-zone modules.

## Evidence Rule

QR changes must preserve scanability. The strongest local signal is an
independent decoder round trip in `QrCodeTests`.
