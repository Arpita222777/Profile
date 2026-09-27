Recommended Oracle setup order:

1. Connect as SYS, SYSTEM, or another DBA account.
   Run: 01_create_oracle_users_roles.sql

2. Connect as UPMS_ADMIN with password admin123.
   Run: 02_recreate_upms_admin_schema_and_sample_data.sql

3. Stay connected as UPMS_ADMIN.
   Run: 03_grants_for_login_users.sql

The C# project expects these defaults in appsettings.json:
Host: 127.0.0.1
Port: 1521
Database: XE
ConnectType: SID
SchemaOwner: UPMS_ADMIN
AdminUser: upms_admin
AdminPassword: admin123

If your VS Code Oracle connection uses a service name such as XEPDB1 or FREEPDB1,
change appsettings.json:
"Database": "XEPDB1",
"ConnectType": "SERVICE"
