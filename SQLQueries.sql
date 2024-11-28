CREATE TABLE Users (
    userId VARCHAR(36) PRIMARY KEY,
    username VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
	password VARCHAR(255) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
	bIsAdmin BIT NOT NULL DEFAULT 0,
	bIsBanned BIT NOT NULL DEFAULT 0,
	bIsMember BIT NOT NULL DEFAULT 0
);

CREATE TABLE IntrestTag (
    tagId VARCHAR(36) PRIMARY KEY,
    tagName VARCHAR(50) NOT NULL,
    tagCreationDate DATETIME DEFAULT GETDATE(),
);

CREATE TABLE UserTag (
    userId VARCHAR(36),
	tagId VARCHAR(36),
	PRIMARY KEY (userId, tagId),
	FOREIGN KEY (userId) REFERENCES Users(userId),
	FOREIGN KEY (tagId) REFERENCES IntrestTag(tagId)
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

CREATE TABLE MembershipType (
    membershipTypeId VARCHAR(36) PRIMARY KEY,
    typeName VARCHAR(100) NOT NULL,
    description TEXT,
    cost DECIMAL(10, 2) NOT NULL,
    duration VARCHAR(20) NOT NULL
);

CREATE TABLE MemberBenefits (
    memberBenefitsId VARCHAR(36) PRIMARY KEY,
	membershipTypeId VARCHAR(36),
    benefitsDescription TEXT NOT NULL,
	FOREIGN KEY (membershipTypeId) REFERENCES MembershipType(membershipTypeId)
);

CREATE TABLE MembershipTypeBenefits (
    membershipTypeId VARCHAR(36),
	memberBenefitsId VARCHAR(36),
	PRIMARY KEY (membershipTypeId, memberBenefitsId),
	FOREIGN KEY (membershipTypeId) REFERENCES MembershipType(membershipTypeId),
	FOREIGN KEY (memberBenefitsId) REFERENCES MemberBenefits(memberBenefitsId)
);

CREATE TABLE KeyIntrest (
	intrestId VARCHAR(36) PRIMARY KEY,
	keyIntrestDescription TEXT NOT NULL,
	intrestDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Member (
    memberId VARCHAR(36) PRIMARY KEY,
    userId VARCHAR(36) NOT NULL,
	membershipTypeId VARCHAR(36) NOT NULL,
	intrestId VARCHAR(36) NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userId),
	FOREIGN KEY (membershipTypeId) REFERENCES MembershipType(membershipTypeId),
	FOREIGN KEY (intrestId) REFERENCES KeyIntrest(intrestId)
);

CREATE TABLE MemberKeyIntrest (
	memberId VARCHAR(36),
	intrestId VARCHAR(36),
	PRIMARY KEY (memberId, intrestId),
	FOREIGN KEY (memberId) REFERENCES Member(memberId),
	FOREIGN KEY (intrestId) REFERENCES KeyIntrest(intrestId)
);

SELECT * FROM Users
SELECT * FROM IntrestTag
SELECT * FROM UserTag

SELECT * FROM Admin
SELECT * FROM AdminRequests

SELECT * FROM MembershipType
SELECT * FROM MemberBenefits
SELECT * FROM MembershipTypeBenefits
SELECT * FROM KeyIntrest
SELECT * FROM Member
SELECT * FROM MemberKeyIntrest

INSERT INTO MembershipType VALUES ('127CA6E6-85CA-471D-9879-A991B48BB413','Community','Community descirption',18.50, 'MONTH')
INSERT INTO KeyIntrest (intrestId, keyIntrestDescription) VALUES ('47D0994E-2DEE-4866-8553-449ED97701C1', 'Key interest Description')
INSERT INTO Member VALUES ('C374FA7C-B7DF-4BD8-AD5D-D10DA79CF56E','2390D947-5431-4571-A1F2-146705E9DBFD','127CA6E6-85CA-471D-9879-A991B48BB413','47D0994E-2DEE-4866-8553-449ED97701C1')
