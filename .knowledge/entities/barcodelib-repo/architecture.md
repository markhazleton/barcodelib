# BarcodeLib Repository

This repository contains a .NET solution with three registered DevSpark apps:

- `BarcodeStandard`: the package-producing library project.
- `Barcode.Web`: an ASP.NET Core MVC sample and product-facing web experience.
- `BarcodeStandardTests`: the MSTest regression suite.

The repository root owns shared build policy, DevSpark framework installation,
current knowledge, governance, and app scope resolution.

## Current Boundaries

- Framework payload: `.devspark/`
- Current durable knowledge: `.knowledge/`
- In-flight workflow state: `.devspark.work/`
- Human archive for obsolete/completed material: `.archive/`
- App-local knowledge roots: `{app.path}/.knowledge/`
