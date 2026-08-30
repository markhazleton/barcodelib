---
id: adr-0001-devspark-v4-knowledge-boundary
name: DevSpark v4 Knowledge Boundary
kind: repository-configuration
summary: Establishes `.knowledge` as current truth and separates it from framework, work-state, and archive locations.
status: current
governs:
  - barcodelib-repo
  - application-registry
relations:
  - type: describes
    object: barcodelib-repo
  - type: supports
    object: devspark-v4-documentation-routing
owner: Make Bold Solutions
lifecycle: current
root: .knowledge/governance
managed_by: human
evidence:
  - type: doc
    ref: .devspark/templates/README.md
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/governance/constitution.md
    verified_by: inspection
    last_verified: 2026-08-30
  - type: doc
    ref: .knowledge/entities/application-registry/registry.json
    verified_by: inspection
    last_verified: 2026-08-30
last_verified: 2026-08-30
---

# ADR 0001: DevSpark v4 Knowledge Boundary

## Decision

Use `.knowledge/` as the DevSpark v4 current-truth root for this repository.
Retain `.documentation/` as legacy history and audit material.

## Context

The repository was bootstrapped with DevSpark `v2.8.0`, then updated to
DevSpark `v4.0.0`. The v4 framework scripts and prompts resolve governance,
application registry data, runtime overrides, and feature lifecycle artifacts
from `.knowledge/`.

The existing `.documentation/` tree contains a historical constitution and a
Copilot audit report. Those files are useful evidence, but they are not the
runtime paths used by the v4 scripts.

## Consequences

- New specs, governance, registry data, and team runtime overrides belong under
  `.knowledge/`.
- Historical `.documentation/` files are not command inputs after v4 migration.
  Once reviewed, they may be moved out of active repository documentation.
- Framework updates may refresh `.devspark/` but must not overwrite either
  `.knowledge/` or `.documentation/`.
