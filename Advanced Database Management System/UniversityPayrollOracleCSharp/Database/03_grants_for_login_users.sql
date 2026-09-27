-- Run as UPMS_ADMIN after 02_recreate_upms_admin_schema_and_sample_data.sql.
-- The C# app uses UPMS_ADMIN for data access after login, but these grants keep
-- UPMS_OPERATOR and UPMS_AUDITOR useful from SQL Developer / VS Code too.

GRANT SELECT, INSERT, UPDATE, DELETE ON dean TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON dean_phone TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON department TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON faculty TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON faculty_phone TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON payroll_staff TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON payroll_staff_phone TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON finance_officer TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON finance_officer_phone TO upms_operator;
GRANT SELECT, INSERT, UPDATE, DELETE ON payroll_transaction TO upms_operator;
GRANT SELECT, INSERT ON payroll_audit_log TO upms_operator;

GRANT SELECT ON seq_dean TO upms_operator;
GRANT SELECT ON seq_dean_phone TO upms_operator;
GRANT SELECT ON seq_department TO upms_operator;
GRANT SELECT ON seq_faculty TO upms_operator;
GRANT SELECT ON seq_faculty_phone TO upms_operator;
GRANT SELECT ON seq_payroll_staff TO upms_operator;
GRANT SELECT ON seq_payroll_staff_phone TO upms_operator;
GRANT SELECT ON seq_finance_officer TO upms_operator;
GRANT SELECT ON seq_finance_officer_phone TO upms_operator;
GRANT SELECT ON seq_payroll_transaction TO upms_operator;
GRANT SELECT ON seq_payroll_audit_log TO upms_operator;

GRANT SELECT ON dean TO upms_auditor;
GRANT SELECT ON dean_phone TO upms_auditor;
GRANT SELECT ON department TO upms_auditor;
GRANT SELECT ON faculty TO upms_auditor;
GRANT SELECT ON faculty_phone TO upms_auditor;
GRANT SELECT ON payroll_staff TO upms_auditor;
GRANT SELECT ON payroll_staff_phone TO upms_auditor;
GRANT SELECT ON finance_officer TO upms_auditor;
GRANT SELECT ON finance_officer_phone TO upms_auditor;
GRANT SELECT ON payroll_transaction TO upms_auditor;
GRANT SELECT ON payroll_audit_log TO upms_auditor;

COMMIT;
