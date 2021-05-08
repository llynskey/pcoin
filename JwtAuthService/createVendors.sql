SELECT * FROM "Penistone";
CREATE TABLE Vendors(
	VendorId int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(20),
	LastName varchar(20),
	emailAddress varchar(20),
	streetAddress varchar(60),
	PRIMARY KEY (VendorId)

);
