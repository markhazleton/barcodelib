# Entity Relations

| Subject | Type | Object |
|---|---|---|
| `application-registry` | describes | `barcodelib-repo` |
| `barcode-domain` | describes | `barcodelib-repo` |
| `barcode-domain` | supports | `symbology-catalog` |
| `barcode-domain` | supports | `rendering-contracts` |
| `barcodelib-public-api` | extends | `barcode-domain` |
| `barcodelib-public-api` | uses | `symbology-catalog` |
| `barcodelib-public-api` | uses | `rendering-contracts` |
| `barcodelib-public-api` | validated_by | `test-evidence-model` |
| `barcodelib-repo` | uses | `application-registry` |
| `barcodelib-repo` | uses | `devspark-v4-workflow` |
| `barcodelib-repo` | supports | `barcode-domain` |
| `devspark-v4-documentation-routing` | describes | `barcodelib-repo` |
| `devspark-v4-workflow` | describes | `barcodelib-repo` |
| `devspark-v4-workflow` | uses | `application-registry` |
| `devspark-v4-workflow` | supports | `test-evidence-model` |
| `qr-code-support` | extends | `symbology-catalog` |
| `qr-code-support` | uses | `rendering-contracts` |
| `qr-code-support` | validated_by | `test-evidence-model` |
| `rendering-contracts` | extends | `barcode-domain` |
| `rendering-contracts` | supports | `barcodelib-public-api` |
| `rendering-contracts` | validated_by | `test-evidence-model` |
| `symbology-catalog` | extends | `barcode-domain` |
| `symbology-catalog` | supports | `barcodelib-public-api` |
| `symbology-catalog` | validated_by | `test-evidence-model` |
| `test-evidence-model` | validates | `barcodelib-public-api` |
| `test-evidence-model` | validates | `symbology-catalog` |
| `test-evidence-model` | validates | `rendering-contracts` |
| `test-evidence-model` | validates | `qr-code-support` |
| `tracked-vendor-artifacts` | describes | `barcodelib-repo` |
| `tracked-vendor-artifacts` | supports | `devspark-v4-workflow` |
| `web-sample-flows` | uses | `barcodelib-public-api` |
| `web-sample-flows` | uses | `qr-code-support` |
| `web-sample-flows` | supports | `barcode-domain` |
