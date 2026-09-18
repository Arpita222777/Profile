University Payroll Management System - C# ASP.NET Core + Oracle

This package is a C# replacement for the old PHP/XAMPP project.
It uses ASP.NET Core MVC and Oracle.ManagedDataAccess.Core, so it does NOT need PHP OCI8.

REQUIREMENTS
1. .NET 8 SDK or Visual Studio 2022 with ASP.NET workload.
2. Oracle Database running locally or on your server.
3. The Oracle users/tables/sequences from the SQL scripts in the Database folder.

DATABASE SETUP
Use the scripts in this order:

1. Database/01_create_oracle_users_roles.sql
   Run as SYS, SYSTEM, or another DBA account.

2. Database/02_recreate_upms_admin_schema_and_sample_data.sql
   Run as UPMS_ADMIN.
   Warning: this recreates the UPMS_ADMIN schema tables used by this project.

3. Database/03_grants_for_login_users.sql
   Run as UPMS_ADMIN.

APP CONFIGURATION
Open appsettings.json and match the same Oracle connection that works in VS Code.

Default for old Oracle XE SID:
"Database": "XE",
"ConnectType": "SID"

Common Oracle XE pluggable database service:
"Database": "XEPDB1",
"ConnectType": "SERVICE"

Common Oracle Free pluggable database service:
"Database": "FREEPDB1",
"ConnectType": "SERVICE"

RUNNING THE PROJECT
Open a terminal in this folder and run:

dotnet restore
dotnet run

Then open:
http://localhost:5098

Oracle connection test page:
http://localhost:5098/Test/Oracle

LOGIN ACCOUNTS
Admin:
upms_admin / admin123
Role: Admin

Payroll Staff:
upms_operator / operator123
Role: Payroll Staff

Auditor:
upms_auditor / auditor123
Role: Auditor

IMPORTANT DESIGN CHOICE
The login page validates the Oracle username/password/role by opening a real Oracle connection.
After login, the app uses the configured UPMS_ADMIN connection for table operations.
This avoids failures from missing sequence grants for UPMS_OPERATOR or UPMS_AUDITOR.

FILES TO EDIT MOST OFTEN
- appsettings.json: Oracle host, port, database, SID/service, schema owner, admin credentials.
- Services/PayrollRepository.cs: SQL queries and CRUD logic.
- Views: Razor pages.
- wwwroot/css and wwwroot/js: styling and client-side behavior.
