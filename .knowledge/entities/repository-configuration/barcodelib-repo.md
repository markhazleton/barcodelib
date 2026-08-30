---
id: barcodelib-repo
name: BarcodeLib Repository
kind: repository-configuration
summary: Repository-level configuration and scope model for the BarcodeLib solution.
relations:
  - type: uses
    object: application-registry
  - type: uses
    object: devspark-v4-workflow
  - type: supports
    object: barcode-domain
owner: Make Bold Solutions
lifecycle: current
root: .
managed_by: human
evidence:
  - type: code
    ref: Barcode.sln
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: Directory.Build.props
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: README.md
    verified_by: inspection
    last_verified: 2026-08-30
---

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
