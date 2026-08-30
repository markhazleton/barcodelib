---
id: barcode-domain
name: Barcode Domain Model
kind: knowledge-model
summary: Domain model for encoding data into barcode raster images, SVG documents, and matrix outputs.
relations:
  - type: describes
    object: barcodelib-repo
  - type: supports
    object: symbology-catalog
  - type: supports
    object: rendering-contracts
owner: Make Bold Solutions
lifecycle: current
root: BarcodeStandard
managed_by: human
evidence:
  - type: code
    ref: BarcodeStandard/BarcodeLib.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: README.md
    verified_by: inspection
    last_verified: 2026-08-30
---

# Barcode Domain Model

BarcodeLib converts caller-provided string data into barcode output for multiple
symbologies. The central domain object is `BarcodeLib.Barcode`, which stores raw
data, selected symbology, generated encoded representation, rendering settings,
image output, and encoding timing.

## Core Concepts

- Raw data: caller-supplied payload to encode.
- Symbology: selected barcode type from `BarcodeLib.TYPE`.
- Encoded value: linear bar/space string for 1D symbologies.
- Encoded matrix: boolean module grid for QR Code.
- Rendered output: raster image, SVG document, image bytes, XML, or JSON.
- Rendering options: colors, dimensions, label options, alignment, rotation,
  quiet-zone enforcement, bar width, aspect ratio, and image format.

## Current Domain Rule

Linear symbologies expose `EncodedValue`. Matrix symbologies expose
`EncodedMatrix`; `EncodedValue` is intentionally unsupported for matrix output.
