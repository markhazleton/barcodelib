# DevSpark v4 Workflow

This repository runs DevSpark in multi-app mode. Commands that operate on a
single app should pass `--app <id>`. Repository-wide work should pass
`--repo-scope`.

## Scope IDs

- `barcode-standard`
- `barcode-web`
- `barcode-standard-tests`

## Routing

- Current truth: `.knowledge/`
- In-flight work: `.devspark.work/`
- Archived historical material: `.archive/`
- Framework files: `.devspark/`
- Team command overrides: `.knowledge/overrides/commands/`
- Team script overrides: `.knowledge/overrides/scripts/{powershell|bash}/`

## Practice

Use `/devspark.specify`, `/devspark.plan`, `/devspark.tasks`, and
`/devspark.implement` for non-trivial changes. Use `/devspark.quickfix` for
small fixes where behavioral intent and evidence are already clear.
