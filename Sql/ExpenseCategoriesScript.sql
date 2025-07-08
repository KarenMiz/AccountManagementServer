IF OBJECT_ID('dbo.ExpenseCategories', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ExpenseCategories (
        ExpenseCategoryId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL
    );
END

INSERT INTO dbo.ExpenseCategories (Name) VALUES 
('Shopping'),
('Car'),
('Insurances'),
('Grocery'),
('Rent'),
('ApartmentBills'),
('Savings'),
('ChildCare'),
('TvServices'),
('InternetServices'),
('PhoneServices'),
('Fun'),
('Other');
