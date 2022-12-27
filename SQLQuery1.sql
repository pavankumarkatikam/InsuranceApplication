

create database CustomerDB

CREATE TABLE Customers (
    CustomerID int PRIMARY KEY,
    FirstName varchar(255),
    Email varchar(255),
	Password varchar(255),
	ConfirmPassword varchar(255),
    Address varchar(255),
    Contact varchar(255),
	NomineeName varchar(255),
	RelationshipwithNominee varchar(255)
);

Insert into dbo.Customers values(1001,'Shruthi', 'shruthi@test.com','Test@123','Test@123', 'Hyderabad', '23673462324' , 'testnominee', 'mother')

select * from dbo.Customers