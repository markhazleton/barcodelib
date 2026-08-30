---
id: barcodelib-public-api
name: BarcodeLib Public API
kind: knowledge-model
summary: Public API and compatibility surface for the BarcodeLib package.
relations:
  - type: extends
    object: barcode-domain
  - type: uses
    object: symbology-catalog
  - type: uses
    object: rendering-contracts
  - type: validated_by
    object: test-evidence-model
owner: Make Bold Solutions
lifecycle: current
root: BarcodeStandard
managed_by: human
evidence:
  - type: code
    ref: BarcodeStandard/BarcodeLib.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandard/Barcode.Properties.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: BarcodeStandard/Barcode.StaticEncode.cs
    verified_by: inspection
    last_verified: 2026-08-30
---

# BarcodeLib Public API

The public package contract centers on `BarcodeLib.Barcode` plus supporting
enums and serialized data types.

## Public Surface

- Constructors: `Barcode()`, `Barcode(string)`, `Barcode(string, TYPE)`.
- Encoding overloads: `Encode(TYPE, string)`, dimension overloads, and color
  overloads.
- Static convenience methods: `Barcode.DoEncode(...)`.
- Rendered output: `EncodedImage`, `Encoded_Image_Bytes`, `GetSvg()`,
  `GetImageData(...)`, XML, and JSON serialization.
- State and options: `RawData`, `EncodedType`, `EncodedValue`,
  `EncodedMatrix`, `ForeColor`, `BackColor`, `IncludeLabel`,
  `AlternateLabel`, `LabelPosition`, `Alignment`, `RotateFlipType`,
  `BarWidth`, `AspectRatio`, `EnforceGS1QuietZone`, and `ImageFormat`.

## Compatibility Rule

Do not remove enum values, constructors, public properties, encoding overloads,
or serialization fields without a breaking-change specification and versioning
plan.
