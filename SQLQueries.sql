CREATE TABLE Users (
    userId VARCHAR(36) PRIMARY KEY,
    username VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	password VARCHAR(255) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
	bIsAdmin BIT NOT NULL DEFAULT 0
);

CREATE TABLE Admin (
    adminId VARCHAR(36) PRIMARY KEY,
    userId VARCHAR(36) NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userId)
);

CREATE TABLE AdminRequests (
    adminRequestId VARCHAR(36) PRIMARY KEY,
    userId VARCHAR(36) NOT NULL,
	requestDescription VARCHAR(MAX) NOT NULL,
	requestTime DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (userId) REFERENCES Users(userId)
);

CREATE TABLE MemberBenefits (
    memberBenefitsId VARCHAR(36) PRIMARY KEY,
    benefitsDescription TEXT NOT NULL,
    usedBenefits BIT NOT NULL, 
);

CREATE TABLE MembershipType (
    membershipTypeId VARCHAR(36) PRIMARY KEY,
	memberBenefitsId VARCHAR(36),
    typeName VARCHAR(100) NOT NULL,
    description TEXT,
    cost DECIMAL(10, 2) NOT NULL,
    duration INT NOT NULL,
    accessLevel INT NOT NULL,
    FOREIGN KEY (memberBenefitsId) REFERENCES MemberBenefits(memberBenefitsId)
);

CREATE TABLE Member (
    memberId VARCHAR(36) PRIMARY KEY,
    userId VARCHAR(36) NOT NULL,
	membershipId VARCHAR(36) NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userId),
	FOREIGN KEY (membershipId) REFERENCES MembershipType(membershipTypeId)
);


SELECT * FROM Users
SELECT * FROM Admin
SELECT * FROM AdminRequests
SELECT * FROM MemberBenefits
SELECT * FROM MembershipType
SELECT * FROM Member

