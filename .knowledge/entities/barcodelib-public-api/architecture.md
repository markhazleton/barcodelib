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
