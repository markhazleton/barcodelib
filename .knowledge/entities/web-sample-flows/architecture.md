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
