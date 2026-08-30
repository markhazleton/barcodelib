---
id: tracked-vendor-artifacts
name: Tracked Vendor Artifacts
kind: repository-configuration
summary: Documents tracked third-party package, web library, and artifact folders that affect audit interpretation.
relations:
  - type: describes
    object: barcodelib-repo
  - type: supports
    object: devspark-v4-workflow
owner: Make Bold Solutions
lifecycle: current
root: .
managed_by: human
evidence:
  - type: code
    ref: .gitignore
    verified_by: inspection
    last_verified: 2026-08-30
  - type: code
    ref: Barcode.Web/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js
    verified_by: inspection
    last_verified: 2026-08-30
  - type: test
    ref: dotnet list Barcode.sln package --vulnerable --include-transitive
    verified_by: execution
    test_attempted: true
    last_verified: 2026-08-30
---

# Tracked Vendor Artifacts

The repository currently tracks third-party or generated-distribution material
under package, artifact, and web-library paths. These files can dominate broad
audit scans because they include large JavaScript files, source maps, NuGet
package cache contents, and published web output.

## Audit Interpretation

Treat findings in vendored or generated-distribution paths separately from
project-owned source findings. Promote a finding only when it affects the
runtime application contract, dependency posture, or shipped package behavior.

## Current Guidance

- Security findings in project-owned C# code should be prioritized over scanner
  matches inside vendored JavaScript.
- Package vulnerability posture should be verified with NuGet tooling.
- Cleanup of tracked package or artifact caches should be spec-backed because it
  changes repository contents and possibly historical build assumptions.
