---
id: web-sample-flows
name: Web Sample Flows
kind: knowledge-model
summary: ASP.NET Core MVC flows that demonstrate BarcodeLib encoding, image output, SVG output, JSON import/export, and product QR links.
relations:
  - type: uses
    object: barcodelib-public-api
  - type: uses
    object: qr-code-support
  - type: supports
    object: barcode-domain
owner: Make Bold Solutions
lifecycle: current
root: Barcode.Web
managed_by: human
evidence:
  - type: code
    ref: Barcode.Web/Controllers/BarCodeController.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: Barcode.Web/Controllers/HomeController.cs
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: Barcode.Web/Models/BarcodeViewModel.cs
    verified_by: inspection
    last_verified: 2026-08-30
---

# Web Sample Flows

`Barcode.Web` demonstrates the library through an ASP.NET Core MVC application.
It uses the library directly rather than wrapping it behind another service
layer.

## Flow Model

- Interactive barcode form renders a preview model and reports encode errors.
- Image endpoint returns PNG output.
- SVG endpoint returns `image/svg+xml`.
- Download endpoint returns selected image formats.
- JSON export/import demonstrates serialization compatibility.
- Sample gallery builds QR and Code 128 examples from product/digital-link data.
- Home/demo endpoints expose representative SVG and raster outputs.

## Contract

The web sample must remain aligned with the library's supported symbologies and
must keep user-provided barcode values validated through the library encode
path.
