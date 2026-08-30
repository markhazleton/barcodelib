# AGENTS.md

## DevSpark

- DevSpark framework files live in `.devspark/`.
- DevSpark v4 current truth lives in `.knowledge/`.
- Legacy audit/history artifacts may remain in `.documentation/`; preserve them unless the user explicitly requests migration or cleanup.
- Codex prompt shims resolve through the first existing file:
  1. `.knowledge/overrides/{git-user}/commands/devspark.{name}.md`
  2. `.knowledge/overrides/commands/devspark.{name}.md`
  3. `.devspark/defaults/commands/devspark.{name}.md`
- Runtime script overrides use `.knowledge/overrides/scripts/{powershell|bash}/` before `.devspark/scripts/`.
- Preserve user work in `.documentation/` and `.knowledge/`; upgrades refresh `.devspark/` only.
