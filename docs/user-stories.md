# User Stories

# Overview
This file contains user stories that illustrate how different users interact with the system. Each story describes a specific scenario, the user's goals, and the steps they take to achieve those goals.

**Author:** Web Applications Development Team
**License**: See [LICENSE.md](../LICENSE.md) for details.

## US001: Create a Purchase Order
As a procurement manager, I want to create a purchase order for a supplier so that I can order goods.

### Scenario: Successfully create a purchase order
- **Given** a supplier with code "SUP001", name "Supplier Inc.", and address "Supplier St, 123, SupplierCity, SC, 12345, United States"
- **When** the procurement manager creates a purchase order with order number "PO001" for supplier ID "SUP001" on August 28, 2025, in USD
- **Then** the purchase order is created with the correct order number, supplier ID, order date, and currency.

