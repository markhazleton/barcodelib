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
