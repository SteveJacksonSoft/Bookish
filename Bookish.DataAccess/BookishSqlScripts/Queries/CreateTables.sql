CREATE TABLE Users (
	Id int IDENTITY(0,1) PRIMARY KEY,
	UserName varchar(50)  NOT NULL
);

CREATE TABLE Books (
	Id int IDENTITY(0,1) PRIMARY KEY,
	Isbn varchar(13) NOT NULL,
	Title varchar(100),
	Author varchar(100)
);

CREATE TABLE Loans (
	Id int IDENTITY(0,1) PRIMARY KEY,
	BookId int FOREIGN KEY REFERENCES Books(Id),
	BorrowerId int FOREIGN KEY REFERENCES Users(Id),
	DateBorrowed date,
	DateDue date,
	Returned bit DEFAULT 0
);

