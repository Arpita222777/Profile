-- Run this script while connected as UPMS_ADMIN.
-- WARNING: This recreates the UPMS_ADMIN schema objects used by the app.
-- Existing data in these 11 tables will be dropped.

BEGIN EXECUTE IMMEDIATE 'DROP TABLE payroll_transaction CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE payroll_audit_log CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE faculty_phone CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE faculty CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE department CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE dean_phone CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE dean CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE payroll_staff_phone CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE payroll_staff CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE finance_officer_phone CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP TABLE finance_officer CASCADE CONSTRAINTS'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -942 THEN RAISE; END IF; END;
/

BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_dean'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_dean_phone'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_department'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_faculty'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_faculty_phone'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_payroll_staff'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_payroll_staff_phone'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_finance_officer'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_finance_officer_phone'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_payroll_transaction'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/
BEGIN EXECUTE IMMEDIATE 'DROP SEQUENCE seq_payroll_audit_log'; EXCEPTION WHEN OTHERS THEN IF SQLCODE != -2289 THEN RAISE; END IF; END;
/

CREATE SEQUENCE seq_dean START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_dean_phone START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_department START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_faculty START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_faculty_phone START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_payroll_staff START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_payroll_staff_phone START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_finance_officer START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_finance_officer_phone START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_payroll_transaction START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;
CREATE SEQUENCE seq_payroll_audit_log START WITH 1 INCREMENT BY 1 NOCACHE NOCYCLE;

CREATE TABLE dean (
  dean_id NUMBER PRIMARY KEY,
  dean_name VARCHAR2(100) NOT NULL,
  dean_email VARCHAR2(100) NOT NULL UNIQUE
);

CREATE TABLE dean_phone (
  dean_phone_id NUMBER PRIMARY KEY,
  dean_id NUMBER NOT NULL,
  phone VARCHAR2(20) NOT NULL,
  CONSTRAINT uq_dean_phone UNIQUE (dean_id, phone),
  CONSTRAINT fk_dean_phone_dean FOREIGN KEY (dean_id) REFERENCES dean(dean_id)
);

CREATE TABLE department (
  department_id NUMBER PRIMARY KEY,
  department_name VARCHAR2(100) NOT NULL UNIQUE,
  payroll_budget NUMBER(12,2) NOT NULL,
  dean_id NUMBER NOT NULL UNIQUE,
  CONSTRAINT chk_department_budget CHECK (payroll_budget >= 0),
  CONSTRAINT fk_department_dean FOREIGN KEY (dean_id) REFERENCES dean(dean_id)
);

CREATE TABLE faculty (
  faculty_id NUMBER PRIMARY KEY,
  faculty_name VARCHAR2(100) NOT NULL,
  designation VARCHAR2(60) NOT NULL,
  academic_rank VARCHAR2(50) NOT NULL,
  faculty_email VARCHAR2(100) NOT NULL UNIQUE,
  bank_info VARCHAR2(150) NOT NULL,
  research_allowance NUMBER(10,2) DEFAULT 0,
  department_id NUMBER NOT NULL,
  CONSTRAINT chk_research_allowance CHECK (research_allowance >= 0),
  CONSTRAINT fk_faculty_department FOREIGN KEY (department_id) REFERENCES department(department_id)
);

CREATE TABLE faculty_phone (
  faculty_phone_id NUMBER PRIMARY KEY,
  faculty_id NUMBER NOT NULL,
  phone VARCHAR2(20) NOT NULL,
  CONSTRAINT uq_faculty_phone UNIQUE (faculty_id, phone),
  CONSTRAINT fk_faculty_phone_faculty FOREIGN KEY (faculty_id) REFERENCES faculty(faculty_id)
);

CREATE TABLE payroll_staff (
  payroll_staff_id NUMBER PRIMARY KEY,
  staff_name VARCHAR2(100) NOT NULL,
  staff_email VARCHAR2(100) NOT NULL UNIQUE
);

CREATE TABLE payroll_staff_phone (
  staff_phone_id NUMBER PRIMARY KEY,
  payroll_staff_id NUMBER NOT NULL,
  phone VARCHAR2(20) NOT NULL,
  CONSTRAINT uq_staff_phone UNIQUE (payroll_staff_id, phone),
  CONSTRAINT fk_staff_phone_staff FOREIGN KEY (payroll_staff_id) REFERENCES payroll_staff(payroll_staff_id)
);

CREATE TABLE finance_officer (
  finance_officer_id NUMBER PRIMARY KEY,
  officer_name VARCHAR2(100) NOT NULL,
  officer_email VARCHAR2(100) NOT NULL UNIQUE
);

CREATE TABLE finance_officer_phone (
  officer_phone_id NUMBER PRIMARY KEY,
  finance_officer_id NUMBER NOT NULL,
  phone VARCHAR2(20) NOT NULL,
  CONSTRAINT uq_officer_phone UNIQUE (finance_officer_id, phone),
  CONSTRAINT fk_officer_phone_officer FOREIGN KEY (finance_officer_id) REFERENCES finance_officer(finance_officer_id)
);

CREATE TABLE payroll_transaction (
  transaction_id NUMBER PRIMARY KEY,
  payment_date DATE NOT NULL,
  base_salary NUMBER(10,2) NOT NULL,
  allowances NUMBER(10,2) DEFAULT 0,
  deductions NUMBER(10,2) DEFAULT 0,
  tax NUMBER(10,2) DEFAULT 0,
  net_salary NUMBER(10,2) NOT NULL,
  faculty_id NUMBER NOT NULL,
  payroll_staff_id NUMBER NOT NULL,
  finance_officer_id NUMBER NOT NULL,
  CONSTRAINT chk_base_salary CHECK (base_salary >= 0),
  CONSTRAINT chk_allowances CHECK (allowances >= 0),
  CONSTRAINT chk_deductions CHECK (deductions >= 0),
  CONSTRAINT chk_tax CHECK (tax >= 0),
  CONSTRAINT chk_net_salary CHECK (net_salary >= 0),
  CONSTRAINT fk_pt_faculty FOREIGN KEY (faculty_id) REFERENCES faculty(faculty_id),
  CONSTRAINT fk_pt_staff FOREIGN KEY (payroll_staff_id) REFERENCES payroll_staff(payroll_staff_id),
  CONSTRAINT fk_pt_finance FOREIGN KEY (finance_officer_id) REFERENCES finance_officer(finance_officer_id)
);

CREATE TABLE payroll_audit_log (
  log_id NUMBER PRIMARY KEY,
  action_name VARCHAR2(100) NOT NULL,
  table_name VARCHAR2(50) NOT NULL,
  action_time DATE DEFAULT SYSDATE,
  remarks VARCHAR2(200)
);

INSERT INTO dean (dean_id, dean_name, dean_email) VALUES (seq_dean.NEXTVAL, 'Dr. Arpita Barua', 'arpita.barua@university.edu');
INSERT INTO dean (dean_id, dean_name, dean_email) VALUES (seq_dean.NEXTVAL, 'Dr. Abani Barua', 'abani.barua@university.edu');
INSERT INTO dean (dean_id, dean_name, dean_email) VALUES (seq_dean.NEXTVAL, 'Dr. Koel Barua', 'koel.barua@university.edu');
INSERT INTO dean (dean_id, dean_name, dean_email) VALUES (seq_dean.NEXTVAL, 'Dr. Shathi', 'shathi.x@university.edu');
INSERT INTO dean (dean_id, dean_name, dean_email) VALUES (seq_dean.NEXTVAL, 'Dr. Kironmoy', 'kironmoy.y@university.edu');

INSERT INTO dean_phone (dean_phone_id, dean_id, phone) VALUES (seq_dean_phone.NEXTVAL, 1, '01711111111');
INSERT INTO dean_phone (dean_phone_id, dean_id, phone) VALUES (seq_dean_phone.NEXTVAL, 2, '01722222222');
INSERT INTO dean_phone (dean_phone_id, dean_id, phone) VALUES (seq_dean_phone.NEXTVAL, 3, '01733333333');
INSERT INTO dean_phone (dean_phone_id, dean_id, phone) VALUES (seq_dean_phone.NEXTVAL, 4, '01744444444');
INSERT INTO dean_phone (dean_phone_id, dean_id, phone) VALUES (seq_dean_phone.NEXTVAL, 5, '01755555555');

INSERT INTO department (department_id, department_name, payroll_budget, dean_id) VALUES (seq_department.NEXTVAL, 'Computer Science', 500000, 1);
INSERT INTO department (department_id, department_name, payroll_budget, dean_id) VALUES (seq_department.NEXTVAL, 'Electrical Engineering', 450000, 2);
INSERT INTO department (department_id, department_name, payroll_budget, dean_id) VALUES (seq_department.NEXTVAL, 'Business Admin', 400000, 3);
INSERT INTO department (department_id, department_name, payroll_budget, dean_id) VALUES (seq_department.NEXTVAL, 'Mechanical Eng', 420000, 4);
INSERT INTO department (department_id, department_name, payroll_budget, dean_id) VALUES (seq_department.NEXTVAL, 'Mathematics', 300000, 5);

INSERT INTO faculty (faculty_id, faculty_name, designation, academic_rank, faculty_email, bank_info, research_allowance, department_id) VALUES (seq_faculty.NEXTVAL, 'Juena Ahmed Noshin', 'Professor', 'Senior', 'juena@uni.edu', 'Bank A-101', 500, 1);
INSERT INTO faculty (faculty_id, faculty_name, designation, academic_rank, faculty_email, bank_info, research_allowance, department_id) VALUES (seq_faculty.NEXTVAL, 'Tanvir Ahmed', 'Professor', 'Junior', 'tanvir@uni.edu', 'Bank B-202', 2000, 1);
INSERT INTO faculty (faculty_id, faculty_name, designation, academic_rank, faculty_email, bank_info, research_allowance, department_id) VALUES (seq_faculty.NEXTVAL, 'Tohedul Islam', 'Asst. Professor', 'Mid', 'tohedu@uni.edu', 'Bank C-303', 1000, 2);
INSERT INTO faculty (faculty_id, faculty_name, designation, academic_rank, faculty_email, bank_info, research_allowance, department_id) VALUES (seq_faculty.NEXTVAL, 'Rifat Tasnim Anayya', 'Lecturer', 'Junior', 'rifat@uni.edu', 'Bank A-404', 500, 3);
INSERT INTO faculty (faculty_id, faculty_name, designation, academic_rank, faculty_email, bank_info, research_allowance, department_id) VALUES (seq_faculty.NEXTVAL, 'Tonny Kor', 'Professor', 'Senior', 'tonny@uni.edu', 'Bank D-505', 2500, 4);

INSERT INTO faculty_phone (faculty_phone_id, faculty_id, phone) VALUES (seq_faculty_phone.NEXTVAL, 1, '01811111111');
INSERT INTO faculty_phone (faculty_phone_id, faculty_id, phone) VALUES (seq_faculty_phone.NEXTVAL, 2, '01822222222');
INSERT INTO faculty_phone (faculty_phone_id, faculty_id, phone) VALUES (seq_faculty_phone.NEXTVAL, 3, '01833333333');
INSERT INTO faculty_phone (faculty_phone_id, faculty_id, phone) VALUES (seq_faculty_phone.NEXTVAL, 4, '01844444444');
INSERT INTO faculty_phone (faculty_phone_id, faculty_id, phone) VALUES (seq_faculty_phone.NEXTVAL, 5, '01855555555');

INSERT INTO payroll_staff (payroll_staff_id, staff_name, staff_email) VALUES (seq_payroll_staff.NEXTVAL, 'Staff A', 'a@payroll.edu');
INSERT INTO payroll_staff (payroll_staff_id, staff_name, staff_email) VALUES (seq_payroll_staff.NEXTVAL, 'Staff B', 'b@payroll.edu');
INSERT INTO payroll_staff (payroll_staff_id, staff_name, staff_email) VALUES (seq_payroll_staff.NEXTVAL, 'Staff C', 'c@payroll.edu');
INSERT INTO payroll_staff (payroll_staff_id, staff_name, staff_email) VALUES (seq_payroll_staff.NEXTVAL, 'Staff D', 'd@payroll.edu');
INSERT INTO payroll_staff (payroll_staff_id, staff_name, staff_email) VALUES (seq_payroll_staff.NEXTVAL, 'Staff E', 'e@payroll.edu');

INSERT INTO payroll_staff_phone (staff_phone_id, payroll_staff_id, phone) VALUES (seq_payroll_staff_phone.NEXTVAL, 1, '01911111111');
INSERT INTO payroll_staff_phone (staff_phone_id, payroll_staff_id, phone) VALUES (seq_payroll_staff_phone.NEXTVAL, 2, '01922222222');
INSERT INTO payroll_staff_phone (staff_phone_id, payroll_staff_id, phone) VALUES (seq_payroll_staff_phone.NEXTVAL, 3, '01933333333');
INSERT INTO payroll_staff_phone (staff_phone_id, payroll_staff_id, phone) VALUES (seq_payroll_staff_phone.NEXTVAL, 4, '01944444444');
INSERT INTO payroll_staff_phone (staff_phone_id, payroll_staff_id, phone) VALUES (seq_payroll_staff_phone.NEXTVAL, 5, '01955555555');

INSERT INTO finance_officer (finance_officer_id, officer_name, officer_email) VALUES (seq_finance_officer.NEXTVAL, 'Officer X', 'x@finance.edu');
INSERT INTO finance_officer (finance_officer_id, officer_name, officer_email) VALUES (seq_finance_officer.NEXTVAL, 'Officer Y', 'y@finance.edu');
INSERT INTO finance_officer (finance_officer_id, officer_name, officer_email) VALUES (seq_finance_officer.NEXTVAL, 'Officer Z', 'z@finance.edu');
INSERT INTO finance_officer (finance_officer_id, officer_name, officer_email) VALUES (seq_finance_officer.NEXTVAL, 'Officer W', 'w@finance.edu');
INSERT INTO finance_officer (finance_officer_id, officer_name, officer_email) VALUES (seq_finance_officer.NEXTVAL, 'Officer V', 'v@finance.edu');

INSERT INTO finance_officer_phone (officer_phone_id, finance_officer_id, phone) VALUES (seq_finance_officer_phone.NEXTVAL, 1, '01611111111');
INSERT INTO finance_officer_phone (officer_phone_id, finance_officer_id, phone) VALUES (seq_finance_officer_phone.NEXTVAL, 2, '01622222222');
INSERT INTO finance_officer_phone (officer_phone_id, finance_officer_id, phone) VALUES (seq_finance_officer_phone.NEXTVAL, 3, '01633333333');
INSERT INTO finance_officer_phone (officer_phone_id, finance_officer_id, phone) VALUES (seq_finance_officer_phone.NEXTVAL, 4, '01644444444');
INSERT INTO finance_officer_phone (officer_phone_id, finance_officer_id, phone) VALUES (seq_finance_officer_phone.NEXTVAL, 5, '01655555555');

INSERT INTO payroll_transaction (transaction_id, payment_date, base_salary, allowances, deductions, tax, net_salary, faculty_id, payroll_staff_id, finance_officer_id) VALUES (seq_payroll_transaction.NEXTVAL, SYSDATE, 5000, 500, 200, 100, 5200, 1, 1, 1);
INSERT INTO payroll_transaction (transaction_id, payment_date, base_salary, allowances, deductions, tax, net_salary, faculty_id, payroll_staff_id, finance_officer_id) VALUES (seq_payroll_transaction.NEXTVAL, SYSDATE, 8000, 1000, 400, 200, 8400, 2, 1, 2);
INSERT INTO payroll_transaction (transaction_id, payment_date, base_salary, allowances, deductions, tax, net_salary, faculty_id, payroll_staff_id, finance_officer_id) VALUES (seq_payroll_transaction.NEXTVAL, SYSDATE, 6000, 600, 300, 150, 6150, 3, 2, 3);
INSERT INTO payroll_transaction (transaction_id, payment_date, base_salary, allowances, deductions, tax, net_salary, faculty_id, payroll_staff_id, finance_officer_id) VALUES (seq_payroll_transaction.NEXTVAL, SYSDATE, 4500, 400, 200, 90, 4610, 4, 3, 4);
INSERT INTO payroll_transaction (transaction_id, payment_date, base_salary, allowances, deductions, tax, net_salary, faculty_id, payroll_staff_id, finance_officer_id) VALUES (seq_payroll_transaction.NEXTVAL, SYSDATE, 9000, 1200, 500, 300, 9400, 5, 4, 5);

INSERT INTO payroll_audit_log (log_id, action_name, table_name, action_time, remarks) VALUES (seq_payroll_audit_log.NEXTVAL, 'INSERT', 'DEAN', SYSDATE, 'Initial data load');
INSERT INTO payroll_audit_log (log_id, action_name, table_name, action_time, remarks) VALUES (seq_payroll_audit_log.NEXTVAL, 'INSERT', 'FACULTY', SYSDATE, 'Initial faculty records');
INSERT INTO payroll_audit_log (log_id, action_name, table_name, action_time, remarks) VALUES (seq_payroll_audit_log.NEXTVAL, 'UPDATE', 'DEPARTMENT', SYSDATE, 'Budget updated');
INSERT INTO payroll_audit_log (log_id, action_name, table_name, action_time, remarks) VALUES (seq_payroll_audit_log.NEXTVAL, 'INSERT', 'PAYROLL_TRANSACTION', SYSDATE, 'Monthly payroll processed');
INSERT INTO payroll_audit_log (log_id, action_name, table_name, action_time, remarks) VALUES (seq_payroll_audit_log.NEXTVAL, 'DELETE', 'DEAN_PHONE', SYSDATE, 'Removed old contact');

COMMIT;
