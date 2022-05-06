create database BuyData_db

use BuyData_db




CREATE TABLE "Customers" (
	"IDCustomer" int primary key IDENTITY (1,1) NOT NULL,
    "CustomerName" nvarchar (100) NOT NULL ,
	"CompanyName" nvarchar (100) NOT NULL ,
	"ContactName" nvarchar (100) NULL ,
	"ContactTitle" nvarchar (100) NULL ,
	"Address" nvarchar (100) NULL ,
	"City" nvarchar (100) NULL ,
	"Region" nvarchar (100) NULL ,
	"PostalCode" nvarchar (100) NULL ,
	"Country" nvarchar (100) NULL ,
	"Phone" nvarchar (100) NULL ,
	"Fax" nvarchar (100) NULL ,

)


Insert into Customers(CustomerName,CompanyName,ContactName,ContactTitle,[Address],City,Region,PostalCode,Country,Phone,Fax)
values
('CustomerName_1','CompanyName_1','ContactName_1','ContactTitle_1','Address_1','City_1','Region_1','PostalCode_1','Country_1','Phone_1','Fax_1'),
('CustomerName_2','CompanyName_2','ContactName_2','ContactTitle_2','Address_2','City_2','Region_2','PostalCode_2','Country_2','Phone_2','Fax_2')


CREATE TABLE "Orders" (
	"IDOrder" int primary key IDENTITY (1,1) NOT NULL,
	"CustomerIDinOrders" int NOT NULL,

	"OrderDate" "datetime" NULL ,
	"RequiredDate" "datetime" NULL ,
	"ShippedDate" "datetime" NULL ,
	"ShipVia" "int" NULL ,
	"Freight" "money" NULL DEFAULT (0),
	"ShipName" nvarchar (100) NULL ,
	"ShipAddress" nvarchar (100) NULL ,
	"ShipCity" nvarchar (100) NULL ,
	"ShipRegion" nvarchar (100) NULL ,
	"ShipPostalCode" nvarchar (100) NULL ,
	"ShipCountry" nvarchar (100) NULL ,

    CONSTRAINT "FK_Orders_Customers" FOREIGN KEY ("CustomerIDinOrders") REFERENCES "Customers" (IDCustomer) On Delete CASCADE On Update CASCADE
)


Insert into Orders(CustomerIDinOrders,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry)
values
(1,CAST('2015-12-25 15:32:06.427' AS DateTime),CAST('2015-12-25 15:32:06.427' AS DateTime),CAST('2015-12-25 15:32:06.427' AS DateTime),1,100,'ShipName_1','ShipAddress_1','ShipCity_1','ShipRegion_1','ShipPostalCode_1','ShipCountry_1'),
(2,CAST('2018-12-25 15:32:06.427' AS DateTime),CAST('2018-1-25 15:32:06.427' AS DateTime),CAST('2018-12-25 15:32:06.427' AS DateTime),1,100,'ShipName_2','ShipAddress_2','ShipCity_2','ShipRegion_2','ShipPostalCode_2','ShipCountry_2')




select *from Customers

select *from Orders 

select *from
Orders
Inner Join
Customers
On
Customers.IDCustomer=Orders.CustomerIDinOrders

DELETE FROM Orders WHERE "IDOrder"=24;