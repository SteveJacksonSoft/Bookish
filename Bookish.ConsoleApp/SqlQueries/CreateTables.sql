Use Bookish;

CREATE TABLE Users (
	Id int PRIMARY KEY,
	UserName nvarchar NOT NULL
);

INSERT INTO Users VALUES (0, '_NotBorrowed');

CREATE TABLE Books (
	Id int PRIMARY KEY ,
	Isbn int NOT NULL,
	Title nvarchar,
	Author nvarchar,
	BorrowerId int FOREIGN KEY REFERENCES Users(Id) DEFAULT 0,
	DueDate date
);