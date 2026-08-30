# BarcodeLib Constitution

## Project Profile

- Project name: BarcodeLib
- Repository: `MakeBoldSolutions/barcodelib`
- Technology stack: .NET 10, C#, ASP.NET Core MVC, MSTest, NuGet packaging
- Primary outputs: `BarcodeLib` package, sample web application, regression tests

## Core Principles

### I. Public API Compatibility

Barcode generation APIs, enum values, rendering defaults, package identity, and supported symbologies must remain backward compatible unless a breaking change is explicit, documented, versioned, and covered by migration guidance.

### II. Barcode Correctness and Standards

Encoding and rendering behavior must preserve barcode semantics, checksum rules, quiet zones, readable labels, SVG output, raster output, and QR behavior. Any change to a symbology requires targeted regression evidence.

### III. Cross-Platform Runtime Safety

The library and web sample must work on supported .NET platforms without relying on undocumented OS behavior. Platform-specific dependencies, especially image rendering behavior, must be isolated and verified.

### IV. Spec-Driven Scope Control

Non-trivial changes must start with a DevSpark spec or quick-spec, then plan, then implementation tasks. One-off fixes are allowed only when the behavioral intent and verification evidence are clear.

### V. Testable Behavior

Every bug fix and feature must include executable evidence unless the change is documentation-only. Metric improvements are supporting evidence only; verification must prove the user-visible behavior or contract that changed.

### VI. Package and Dependency Discipline

NuGet metadata, release notes, package assets, dependency versions, and SourceLink behavior must stay aligned with the repository's published package contract. Dependency updates must be routine, scoped, and tested.

### VII. Documentation Quality

Committed markdown must remain lint-clean under the repository markdownlint configuration. Public documentation must describe current APIs and supported symbologies accurately.

## Development Workflow

- Use `.knowledge/specs/` for durable DevSpark specs and work-package artifacts.
- Use `.devspark.work/` only for ephemeral in-flight state.
- Use `.knowledge/entities/application-registry/registry.json` for explicit app scope.
- Use `.knowledge/overrides/` for team-owned DevSpark overrides.
- Keep framework-owned files under `.devspark/` separate from repository-owned knowledge.

## Governance

This constitution is authoritative for repository work. Application-level rules may add stricter requirements but must not weaken these principles.

**Version**: 1.0.0 | **Ratified**: 2026-08-30 | **Last Amended**: 2026-08-30
