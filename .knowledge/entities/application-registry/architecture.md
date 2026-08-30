# Application Registry

The application registry declares the repository as a DevSpark v4 multi-app
workspace. It records the app ids, source paths, inherited profile rules,
runtime tags, ownership, criticality, and dependency ordering used by DevSpark
scope resolution.

## Registered Apps

- `barcode-standard` maps to `BarcodeStandard` and owns the BarcodeLib package
  source.
- `barcode-web` maps to `Barcode.Web` and depends on `barcode-standard`.
- `barcode-standard-tests` maps to `BarcodeStandardTests` and depends on
  `barcode-standard`.

## Profile Rules

The registry defines profiles for .NET library, ASP.NET Core MVC web, and MSTest
test-suite work. Those profiles keep command routing aligned with package
compatibility, sample-web behavior, and regression-test expectations.
