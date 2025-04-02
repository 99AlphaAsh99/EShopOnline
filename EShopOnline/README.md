# Deployment Instructions

Follow these steps to set up the project on a new device:

## 1. Database Connection String

Change the database connection string in `appsettings.json` to your local database.

## 2. Delete Existing Migrations

Delete the Migrations folder from the project to ensure a clean setup.

## 3. Accept NuGet Packages

Restore and accept all NuGet packages required by the project.

## 4. Add Initial Migration

Run the following command to create a new initial migration:

```
Add-Migration InitialCreate
```

## 5. Update Database

Apply the migration to create the database schema:

```
Update-Database
```

## 6. Run Data Import Script

Run the deployment SQL script to populate your database with the initial required data:

### Required Data

The script will populate:
- **Customers Table** - One test customer account (until login functionality is implemented)
- **Categories Table** - Three categories in the following order:
  - Clothing (will be assigned CategoryID 1)
  - Electronics (will be assigned CategoryID 2)
  - HomeKitchen (will be assigned CategoryID 3)
- **Products Table** - Six products (two per category)

**Important**: Run the script in the given order to ensure CategoryIDs are assigned correctly.