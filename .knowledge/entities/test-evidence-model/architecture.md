# Test Evidence Model

The test suite is the primary executable evidence source for BarcodeLib behavior.
It currently includes focused tests for symbology behavior, QR scanability,
quiet-zone behavior, and SVG rendering geometry.

## Verification Commands

```powershell
dotnet test Barcode.sln --no-restore
npx --yes markdownlint-cli2 "**/*.md"
dotnet list Barcode.sln package --vulnerable --include-transitive
dotnet list Barcode.sln package --outdated
```

## Evidence Rule

Behavioral fixes must include tests or a clear reason why executable evidence is
not possible. Metrics alone are not sufficient proof.
