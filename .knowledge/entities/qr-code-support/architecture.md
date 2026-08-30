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
