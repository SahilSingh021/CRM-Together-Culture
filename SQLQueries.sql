CREATE TABLE Users (
    userID INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE Admin (
    adminId INT PRIMARY KEY IDENTITY(1,1),
    userId INT NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userID)
);

CREATE TABLE MemberBenefits (
    MemberBenefitsID INT PRIMARY KEY IDENTITY(1,1),
    BenefitsDescription TEXT NOT NULL,
    UsedBenefits BIT NOT NULL, 
);

CREATE TABLE MembershipType (
    MembershipTypeID INT PRIMARY KEY IDENTITY(1,1),
	MemberBenefitsID INT,
    TypeName VARCHAR(100) NOT NULL,
    Description TEXT,
    Cost DECIMAL(10, 2) NOT NULL,
    Duration INT NOT NULL,
    AccessLevel INT NOT NULL,
    FOREIGN KEY (MemberBenefitsID) REFERENCES MemberBenefits(MemberBenefitsID)
);

CREATE TABLE Member (
    memberId INT PRIMARY KEY IDENTITY(1,1),
    userId INT NOT NULL,
	membershipId INT NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userID),
	FOREIGN KEY (membershipId) REFERENCES MembershipType(MembershipTypeID)
);


SELECT * FROM Users
SELECT * FROM Admin
SELECT * FROM MemberBenefits
SELECT * FROM MembershipType
SELECT * FROM Member
