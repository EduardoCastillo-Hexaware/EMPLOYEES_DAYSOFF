CREATE DATABASE employees
GO

USE employees
GO

	CREATE TABLE dbo.gender(
		id int PRIMARY KEY IDENTITY(1,1),
		gender varchar(20) 
	)
	GO

	INSERT dbo.gender(gender) VALUES('Male') 
	GO
	INSERT dbo.gender(gender) VALUES('Female') 
	GO

	CREATE TABLE dbo.employee(
		id int PRIMARY KEY IDENTITY(1,1),
		[name] varchar(50) ,
		firstLastName varchar(50) ,
		secLastName varchar(50) ,
		age int ,
		email varchar(50) ,
		phoneNumber bigint,
		genderId int ,
		dateOfJoin date ,
		CONSTRAINT fk_genderId FOREIGN KEY (genderId) REFERENCES gender(id)
	)
	GO

	INSERT dbo.employee(name,firstLastName,secLastName,age,email,phoneNumber,genderId,dateOfJoin)
	VALUES ('Eduardo','Castillo','Carlos',27,'eduardo@hotmail.com',8443131217,1, GETDATE()-100) 
	GO
	INSERT dbo.employee(name,firstLastName,secLastName,age,email,phoneNumber,genderId,dateOfJoin)
	VALUES ('Leo','Perez','Dini',45,'leo@hotmail.com',8443135134,1, GETDATE()-300) 
	GO
	INSERT dbo.employee(name,firstLastName,secLastName,age,email,phoneNumber,genderId,dateOfJoin)
	VALUES ('Fernanda','Casas','Perez',20,'thomas@hotmail.com',8443134879,2, GETDATE()-600) 
	GO
	INSERT dbo.employee(name,firstLastName,secLastName,age,email,phoneNumber,genderId,dateOfJoin)
	VALUES ('Leo','Perez','Dini',45,'leo@hotmail.com',8443135134,1, GETDATE()-250) 
	GO

	CREATE TABLE dbo.roles(
		id int PRIMARY KEY IDENTITY(1,1),
		rolev varchar(50) 
	)
	GO

	INSERT dbo.roles(rolev) VALUES('admin') 
	GO
	INSERT dbo.roles(rolev) VALUES('HR') 
	GO
	INSERT dbo.roles(rolev) VALUES('supervisor') 
	GO
	INSERT dbo.roles(rolev) VALUES('operator') 
	GO


	CREATE TABLE users(
		id int PRIMARY KEY IDENTITY(1,1),
		userName varchar(50) ,
		[password] varchar(50) ,
		employeeId int ,
		roleId int ,
		CONSTRAINT fk_employeeId FOREIGN KEY (employeeId) REFERENCES employee(id),
		CONSTRAINT fk_roleId FOREIGN KEY (roleId) REFERENCES roles(id)
	)
	GO

	INSERT dbo.users (userName,[password],employeeId,roleId) VALUES('admin','admin',1,1) 
	GO
	INSERT dbo.users (userName,[password],employeeId,roleId) VALUES('HR','HR',2,2) 
	GO
	INSERT dbo.users (userName,[password],employeeId,roleId) VALUES('sup','sup',3,3) 
	GO
	INSERT dbo.users (userName,[password],employeeId,roleId) VALUES('op','op',4,4) 
	GO

	CREATE TABLE absenceTypes(
		id int PRIMARY KEY IDENTITY(1,1),
		absence varchar(50) ,
	)
	GO

	INSERT dbo.absenceTypes (absence) VALUES('Vacation') 
	GO
	INSERT dbo.absenceTypes (absence) VALUES('Marriage') 
	GO
	INSERT dbo.absenceTypes (absence) VALUES('Compensation') 
	GO
	INSERT dbo.absenceTypes (absence) VALUES('No paid leave') 
	GO

	CREATE TABLE states(
		id int PRIMARY KEY IDENTITY(1,1),
		[state] varchar(50) 
	)
	GO

	INSERT dbo.states(state) VALUES('Active') 
	GO
	INSERT dbo.states(state) VALUES('Approved') 
	GO
	INSERT dbo.states(state) VALUES('Denied') 
	GO
	INSERT dbo.states(state) VALUES('Completed') 
	GO


	CREATE TABLE absenceRequest(
		id int PRIMARY KEY IDENTITY(1,1),
		absenceTypeId int,
		stateId int,
		startDate date,
		endDate date,
		requestDate date,
		CONSTRAINT fk_absenceTypeId FOREIGN KEY (absenceTypeId) REFERENCES absenceTypes(id),
		CONSTRAINT fk_stateId FOREIGN KEY (stateId) REFERENCES states(id)
	)
	GO
