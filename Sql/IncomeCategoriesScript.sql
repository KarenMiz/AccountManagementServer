IF OBJECT_ID('dbo.IncomeCategories', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.IncomeCategories (
        IncomeCategoryId INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL
    );
END

INSERT INTO dbo.IncomeCategories (Name) VALUES 
('FirstSalary'),
('SecondSalary'),
('Allowance'),
('RentalFees'),
('Other');
