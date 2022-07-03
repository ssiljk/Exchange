DECLARE @db_id INT;
SET @db_id = DB_ID(N'BDPRUEBA');
IF @db_id IS NULL   
BEGIN;  
    PRINT N'Creating BDPRUEBA database';  
    GO
    CREATE DATABASE BDPRUEBA;
    GO
    USE BDPRUEBA;
    GO
    PRINT N'Creating transactions and currency tables';
    GO 
    CREATE TABLE transactions (ID INT PRIMARY KEY IDENTITY (1, 1),userID VARCHAR (50) NOT NULL, Amount DECIMAL(6,3),CurrencyName VARCHAR (50) NOT NULL,TransactionDate DATETIME);
    GO
    CREATE TABLE currencies (Id INT PRIMARY KEY IDENTITY (1, 1), Name VARCHAR (10) NOT NULL,Url VARCHAR (2000) NOT NULL,MaxLimit DECIMAL(6,0));
    GO
    insert into currencies (Name, Url, MaxLimit) values('dolar', 'https://www.bancoprovincia.com.ar/', 200);
    GO
    insert into currencies (Name, Url, MaxLimit) values('real', 'https://www.bancoprovincia.com.ar/', 300);
    GO
END;
ELSE
BEGIN;
    PRINT N'BDPRUEBA database already existed';
END;  