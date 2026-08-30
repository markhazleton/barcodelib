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
