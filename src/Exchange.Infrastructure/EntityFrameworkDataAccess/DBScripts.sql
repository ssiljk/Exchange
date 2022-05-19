USE BDPRUEBA
GO

--CREATE TABLE transactions (
--    ID INT PRIMARY KEY IDENTITY (1, 1),
--    userID VARCHAR (50) NOT NULL,
--    Amount DECIMAL(6,3),
--    CurrencyName VARCHAR (50) NOT NULL,
--    TransactionDate DATETIME
--);

CREATE TABLE currencies (
   Id INT PRIMARY KEY IDENTITY (1, 1),
   Name VARCHAR (10) NOT NULL,
   Url VARCHAR (2000) NOT NULL,
   MaxLimit DECIMAL(6,0)
);
GO

insert into currencies (Name, Url, MaxLimit)
       values('dolar', 'https://www.bancoprovincia.com.ar/Principal/Dolar', 200);

insert into currencies (Name, Url, MaxLimit)
       values('real', 'https://www.bancoprovincia.com.ar/Principal/Dolar', 300);
GO
