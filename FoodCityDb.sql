CREATE DATABASE FoodCityDb;

USE FoodCityDb;

CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY(1,1),
ProductName NVARCHAR(100) NOT NULL,
Price DECIMAL(10,2) NOT NULL,
Quantity INT NOT NULL

);

INSERT INTO Products (ProductName, Price, Quantity)
VALUES ('Rice', 1200.00, 50),
		('Milk', 60.00, 100),
		('Bread', 45.00, 80),
		('Sugar', 110.00, 60),
		('Tea', 250.00, 40);

SELECT * FROM Products;