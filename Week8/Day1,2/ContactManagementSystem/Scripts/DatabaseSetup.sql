-- Create Database
CREATE DATABASE ContactDb;
GO

USE ContactDb;
GO

-- Create Company Table
CREATE TABLE Company (
    CompanyId INT IDENTITY PRIMARY KEY,
    CompanyName NVARCHAR(100) NOT NULL
);
GO

-- Create Department Table
CREATE TABLE Department (
    DepartmentId INT IDENTITY PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);
GO

-- Create ContactInfo Table
CREATE TABLE ContactInfo (
    ContactId INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    EmailId NVARCHAR(100) NOT NULL,
    MobileNo BIGINT NOT NULL,
    Designation NVARCHAR(50) NOT NULL,
    CompanyId INT NOT NULL,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId),
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);
GO

-- Insert Sample Companies
INSERT INTO Company (CompanyName) VALUES ('TCS');
INSERT INTO Company (CompanyName) VALUES ('Infosys');
INSERT INTO Company (CompanyName) VALUES ('Wipro');
INSERT INTO Company (CompanyName) VALUES ('HCL Technologies');
INSERT INTO Company (CompanyName) VALUES ('Tech Mahindra');
GO

-- Insert Sample Departments
INSERT INTO Department (DepartmentName) VALUES ('HR');
INSERT INTO Department (DepartmentName) VALUES ('IT');
INSERT INTO Department (DepartmentName) VALUES ('Finance');
INSERT INTO Department (DepartmentName) VALUES ('Marketing');
INSERT INTO Department (DepartmentName) VALUES ('Sales');
GO

-- Insert Sample Contacts
INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES ('Rahul', 'Sharma', 'rahul.sharma@tcs.com', 9876543210, 'Software Engineer', 1, 2);

INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES ('Priya', 'Patel', 'priya.patel@infosys.com', 9876543211, 'Project Manager', 2, 2);

INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES ('Amit', 'Verma', 'amit.verma@wipro.com', 9876543212, 'Senior Developer', 3, 2);

INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES ('Neha', 'Gupta', 'neha.gupta@hcl.com', 9876543213, 'HR Manager', 4, 1);

INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES ('Suresh', 'Reddy', 'suresh.reddy@techm.com', 9876543214, 'Sales Head', 5, 5);
GO

-- Verify Data
SELECT * FROM Company;
SELECT * FROM Department;
SELECT * FROM ContactInfo;
GO