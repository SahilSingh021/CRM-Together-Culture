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
    tagName VARCHAR(50) NOT NULL
);

CREATE TABLE UserTag (
    userId VARCHAR(36),
	tagId VARCHAR(36),
	userTagCreationDate DATETIME DEFAULT GETDATE(),
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
	joiningFee DECIMAL(10, 2),
    duration VARCHAR(20) NOT NULL
);

CREATE TABLE MemberBenefits (
    memberBenefitsId VARCHAR(36) PRIMARY KEY,
    benefitsDescription TEXT NOT NULL,
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
	keyIntrestName TEXT NOT NULL
);

CREATE TABLE Member (
    memberId VARCHAR(36) PRIMARY KEY,
    userId VARCHAR(36) NOT NULL,
	membershipTypeId VARCHAR(36) NOT NULL,
    FOREIGN KEY (userId) REFERENCES Users(userId),
	FOREIGN KEY (membershipTypeId) REFERENCES MembershipType(membershipTypeId),
);

CREATE TABLE MemberKeyIntrest (
	memberId VARCHAR(36),
	intrestId VARCHAR(36),
	memberKeyIntrestDate DATETIME DEFAULT GETDATE(),
	PRIMARY KEY (memberId, intrestId),
	FOREIGN KEY (memberId) REFERENCES Member(memberId),
	FOREIGN KEY (intrestId) REFERENCES KeyIntrest(intrestId)
);

-- Users Table Inserts
INSERT INTO Users (userId, username, password, email, bIsAdmin, bIsBanned, bIsMember)
VALUES 
    ('7E15881D-243B-49EB-8A80-EB7445F90982', 'Sahil', '111111', 'sahil@admin.com', 1, 0, 1),
    ('86C89165-9CD2-4B2D-91CB-8D19731DC5C1', 'Kai', '111111', 'kai@admin.com', 1, 0, 1),
    ('180C3802-A27A-4C7F-B60F-ED73F6E46F1F', 'Sam', '111111', 'sam@admin.com', 1, 0, 1),
    ('8B6157DF-1330-492A-A410-5A599DF91694', 'Jordan', 'Smith2103', 'jordan@example.com', 0, 0, 1),
	('F439C28D-B7A1-479E-B9FB-FE65B0CF96CD', 'Lewis', 'LewisQWERTY', 'lewis@example.com', 0, 1, 0),
    ('D46C7718-20C6-4578-B412-745CD6C42DE8', 'Taylor', 'Swift5052', 'taylor@example.com', 0, 0, 0),
	('1C55E361-A275-4ACB-996E-618D82DB58F7', 'James', 'Cathy202', 'james@example.com', 0, 0, 0),
	('8783AC43-8558-4633-93A7-3BB543504430', 'Kelly', 'Fire0200', 'kelly@example.com', 0, 0, 0)

-- IntrestTag Table Inserts
INSERT INTO IntrestTag (tagId, tagName)
VALUES 
    ('B2BB353B-E23C-4D22-BB49-59F271ABB740', 'Games'),
	('8781B6ED-3477-4AB3-858F-4AA2F896FFB0', 'Shopping'),
	('31E89AF4-29AF-4814-889E-8C75002EAE8E', 'Cafe'),
	('5B6D90A2-A202-42F9-8764-A72D52A3C8D6', 'Art'),
	('E3A13AEE-BAC8-45B8-A63A-D7E931CD69D1', 'Sports'),
	('A3139461-42B4-45D1-80CC-85AF1A266AD9', 'Sculpting'),
	('0FD26B2E-0012-4192-B7CD-8DFBBDB73A62', 'Networking'),
	('C4604527-63F9-48DA-A676-624649EA20A3', 'Movies'),
	('AD929823-47B4-4C59-8EAB-4AA71F1BC6FF', 'Writing'),
	('2C75402E-CB18-4BAF-8512-B6B552FFD52A', 'Singing'),
	('0876FE02-5A8B-4F4B-9F56-6AAE00F34C9B', 'Languages')

-- Admin Table Inserts
INSERT INTO Admin (adminId, userId)
VALUES
    ('385F047E-2575-49F6-8600-ADBBE1ADB244', (SELECT userId FROM Users WHERE username = 'Sahil')),
    ('0ECD7803-3956-4075-B3BA-ECAAC40275ED', (SELECT userId FROM Users WHERE username = 'Kai')),
    ('24B25A5F-A6EB-47E6-A2EC-F27412054145', (SELECT userId FROM Users WHERE username = 'Sam'))

-- AdminRequests Table Inserts
INSERT INTO AdminRequests (adminRequestId, userId, requestDescription)
VALUES
    ('C5A2D5EA-2A8C-4B8F-ABC3-5962454B1507', '1C55E361-A275-4ACB-996E-618D82DB58F7', 'Request to become a member.'),
	('71FBCDD2-9E77-4EE7-9A73-EE78DCAA1AD5', '8783AC43-8558-4633-93A7-3BB543504430', 'Request to become a member.')

-- MembershipType Table Inserts
INSERT INTO MembershipType(membershipTypeId, typeName, description, cost, joiningFee, duration)
VALUES
    ('51B6C680-EFBC-4AFC-B499-CDAEA034E3CA', 'Community', 'Basic membership.', 18.50, 00.00, 'MONTH'),
	('ED3CAFD8-020C-479D-95D3-DD9A7AACC40F', 'KeyAccess', 'Basic membership with key access.', 45.00, 100.00, 'MONTH'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', 'WorkplacePart-Time', 'Workplace part-time membership.', 70.00, 100.00, 'MONTH'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', 'WorkplaceFull-Time', 'Workplace full-time membership.', 100.00, 100.00, 'MONTH'),
	('A7576A23-EEAA-435D-8D0B-E5670913F26B', 'Student', 'Student membership.', 00.00, 00.00, 'MONTH'),
	('B59331CE-F435-4589-A158-2D561145082D', 'SmallBusiness', 'Businesses less than 20 people.', 375.00, 00.00, 'MONTH'),
	('160175F1-F38F-4436-9D61-0A9F3D144D07', 'MediumBusiness', 'Businesses with 21 - 50 people.', 750.00, 00.00, 'MONTH'),
	('278AA19B-44A9-4282-8D8B-9AE4A16B462F', 'LargeBusiness', 'Businesses with more than 50 people.', 1500.00, 00.00, 'MONTH'),
	('3BBF0AF3-7F8F-49F0-90C1-EC91DBBDF2E1', 'SmallNon-Profit', 'Non-Profit with less than 100 people.', 375.00, 00.00, 'MONTH'),
	('135BAC11-6DBA-4561-981A-9A32AF7A3974', 'LargeNon-Profit', 'Non-Profit greater than 100 people.', 750.00, 00.00, 'MONTH')

-- MemberBenefits Table Inserts
INSERT INTO MemberBenefits (memberBenefitsId, benefitsDescription)
VALUES 
    ('42BC41E5-B934-4BF4-A5CB-4151DBA0BC63', 'Free or Discounted tickets to all events.'),
	('0E7438AC-241D-4A62-A998-39AE3ED2A8C0', 'Collaborative and creative skills development workshops.'),
	('208922D7-5BBB-4B4C-A7CF-B095ABD2CC18', 'Participation in the annual Citizens� Studio.'),
	('19453026-4D9D-421C-AAA6-4EFCE1E02100', 'A voice in decision about new social enterprises developed in Together Culture�s incubator.'),
	('FFD8B9F5-E29A-4D03-A8F6-FE2785AF4261', 'Access to the space.'),
	('2B8E6F74-7392-4B2F-939F-67FB339F7BF2', '24/7 access to Together Culture Fitzroy.'),
	('22B45B1C-6BB6-423C-9F9B-13EA835557F1', 'A dedicated workspace and storage space.'),
	('A222DA79-C9AB-4EBC-8EBA-2F325C59C6F0', 'A cohort of Workspace Members with which to build collaborative relationships.'),
	('D67BFD1D-5351-4DC6-8B53-65799EC3D38D', 'Part-Time access to Together Culture Fitzroy.'),
	('EAAAEBCE-4420-42B8-992E-D7000173B26D', '3 inclusive spaces in all Together Culture events, workshops and courses.'),
	('FC803E66-F951-4614-A503-0072D7E43E27', '25% discount on access to events, workshops, and courses for the rest of your team.'),
	('0038E240-85AA-4EB0-9D23-45695972A8F8', '3 passes to use Fitzroy Street during opening hours.'),
	('92667BAE-6738-420F-952F-32B28DB8A3BD', '25% discount on Together Culture co-creation, facilitation, marketing, and team building serviceS.'),
	('A198779D-7284-48EF-9A94-D7F67B82E7E4', 'Name credit on our supporters� page on our website and in our annual yearbook.'),
	('F6C91F15-5B64-4AC6-9BCC-2A73D1F5D61D', '5 inclusive spaces in all Together Culture events, workshops and courses.'),
	('A98BF2F6-0D68-4380-A476-2D7235BA7EFC', '5 passes to use Fitzroy Street during opening hours.'),
	('4D58EEC5-92D5-4A38-A5BB-BA6967DA1033', '10 inclusive spaces in all Together Culture events, workshops and courses.'),
	('44827D57-D071-4D1A-B763-3B3208BFB02B', '10 passes to use Fitzroy Street during opening hours.')

-- MembershipTypeBenefits Table Inserts
INSERT INTO MembershipTypeBenefits (membershipTypeId, memberBenefitsId)
VALUES 
	-- Community
    ('51B6C680-EFBC-4AFC-B499-CDAEA034E3CA', '42BC41E5-B934-4BF4-A5CB-4151DBA0BC63'),
	('51B6C680-EFBC-4AFC-B499-CDAEA034E3CA', '0E7438AC-241D-4A62-A998-39AE3ED2A8C0'),
	('51B6C680-EFBC-4AFC-B499-CDAEA034E3CA', '208922D7-5BBB-4B4C-A7CF-B095ABD2CC18'),
	('51B6C680-EFBC-4AFC-B499-CDAEA034E3CA', '19453026-4D9D-421C-AAA6-4EFCE1E02100'),
	('51B6C680-EFBC-4AFC-B499-CDAEA034E3CA', 'FFD8B9F5-E29A-4D03-A8F6-FE2785AF4261'),

	-- Student
	('A7576A23-EEAA-435D-8D0B-E5670913F26B', '42BC41E5-B934-4BF4-A5CB-4151DBA0BC63'),
	('A7576A23-EEAA-435D-8D0B-E5670913F26B', '0E7438AC-241D-4A62-A998-39AE3ED2A8C0'),
	('A7576A23-EEAA-435D-8D0B-E5670913F26B', '208922D7-5BBB-4B4C-A7CF-B095ABD2CC18'),
	('A7576A23-EEAA-435D-8D0B-E5670913F26B', '19453026-4D9D-421C-AAA6-4EFCE1E02100'),
	('A7576A23-EEAA-435D-8D0B-E5670913F26B', 'FFD8B9F5-E29A-4D03-A8F6-FE2785AF4261'),

	-- Key Access
	('ED3CAFD8-020C-479D-95D3-DD9A7AACC40F', '42BC41E5-B934-4BF4-A5CB-4151DBA0BC63'),
	('ED3CAFD8-020C-479D-95D3-DD9A7AACC40F', '0E7438AC-241D-4A62-A998-39AE3ED2A8C0'),
	('ED3CAFD8-020C-479D-95D3-DD9A7AACC40F', '208922D7-5BBB-4B4C-A7CF-B095ABD2CC18'),
	('ED3CAFD8-020C-479D-95D3-DD9A7AACC40F', '19453026-4D9D-421C-AAA6-4EFCE1E02100'),
	('ED3CAFD8-020C-479D-95D3-DD9A7AACC40F', '2B8E6F74-7392-4B2F-939F-67FB339F7BF2'),

	-- WorkplacePart-Time
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', '42BC41E5-B934-4BF4-A5CB-4151DBA0BC63'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', '0E7438AC-241D-4A62-A998-39AE3ED2A8C0'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', '208922D7-5BBB-4B4C-A7CF-B095ABD2CC18'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', '19453026-4D9D-421C-AAA6-4EFCE1E02100'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', '2B8E6F74-7392-4B2F-939F-67FB339F7BF2'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', '22B45B1C-6BB6-423C-9F9B-13EA835557F1'),
	('7505CC85-23CA-4538-84CC-D13CB5FED5A3', 'A222DA79-C9AB-4EBC-8EBA-2F325C59C6F0'),

	-- WorkplaceFull-Time
	('E551B104-A0B0-42A6-9941-EFF8B005E549', '42BC41E5-B934-4BF4-A5CB-4151DBA0BC63'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', '0E7438AC-241D-4A62-A998-39AE3ED2A8C0'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', '208922D7-5BBB-4B4C-A7CF-B095ABD2CC18'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', '19453026-4D9D-421C-AAA6-4EFCE1E02100'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', '2B8E6F74-7392-4B2F-939F-67FB339F7BF2'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', '22B45B1C-6BB6-423C-9F9B-13EA835557F1'),
	('E551B104-A0B0-42A6-9941-EFF8B005E549', 'A222DA79-C9AB-4EBC-8EBA-2F325C59C6F0'),

	-- SmallBusiness
	('B59331CE-F435-4589-A158-2D561145082D', 'EAAAEBCE-4420-42B8-992E-D7000173B26D'),
	('B59331CE-F435-4589-A158-2D561145082D', 'FC803E66-F951-4614-A503-0072D7E43E27'),
	('B59331CE-F435-4589-A158-2D561145082D', '0038E240-85AA-4EB0-9D23-45695972A8F8'),
	('B59331CE-F435-4589-A158-2D561145082D', '92667BAE-6738-420F-952F-32B28DB8A3BD'),
	('B59331CE-F435-4589-A158-2D561145082D', 'A198779D-7284-48EF-9A94-D7F67B82E7E4'),

	-- MediumBusiness
	('160175F1-F38F-4436-9D61-0A9F3D144D07', 'F6C91F15-5B64-4AC6-9BCC-2A73D1F5D61D'),
	('160175F1-F38F-4436-9D61-0A9F3D144D07', 'A98BF2F6-0D68-4380-A476-2D7235BA7EFC'),
	('160175F1-F38F-4436-9D61-0A9F3D144D07', 'FC803E66-F951-4614-A503-0072D7E43E27'),
	('160175F1-F38F-4436-9D61-0A9F3D144D07', '92667BAE-6738-420F-952F-32B28DB8A3BD'),
	('160175F1-F38F-4436-9D61-0A9F3D144D07', 'A198779D-7284-48EF-9A94-D7F67B82E7E4'),
	
	-- LargeBusiness
	('278AA19B-44A9-4282-8D8B-9AE4A16B462F', '4D58EEC5-92D5-4A38-A5BB-BA6967DA1033'),
	('278AA19B-44A9-4282-8D8B-9AE4A16B462F', 'FC803E66-F951-4614-A503-0072D7E43E27'),
	('278AA19B-44A9-4282-8D8B-9AE4A16B462F', '44827D57-D071-4D1A-B763-3B3208BFB02B'),
	('278AA19B-44A9-4282-8D8B-9AE4A16B462F', '92667BAE-6738-420F-952F-32B28DB8A3BD'),
	('278AA19B-44A9-4282-8D8B-9AE4A16B462F', 'A198779D-7284-48EF-9A94-D7F67B82E7E4'),

	-- SmallNon-Profit
	('3BBF0AF3-7F8F-49F0-90C1-EC91DBBDF2E1', 'F6C91F15-5B64-4AC6-9BCC-2A73D1F5D61D'),
	('3BBF0AF3-7F8F-49F0-90C1-EC91DBBDF2E1', 'FC803E66-F951-4614-A503-0072D7E43E27'),
	('3BBF0AF3-7F8F-49F0-90C1-EC91DBBDF2E1', 'A98BF2F6-0D68-4380-A476-2D7235BA7EFC'),
	('3BBF0AF3-7F8F-49F0-90C1-EC91DBBDF2E1', '92667BAE-6738-420F-952F-32B28DB8A3BD'),
	('3BBF0AF3-7F8F-49F0-90C1-EC91DBBDF2E1', 'A198779D-7284-48EF-9A94-D7F67B82E7E4'),

	-- LargeNon-Profit
	('135BAC11-6DBA-4561-981A-9A32AF7A3974', '4D58EEC5-92D5-4A38-A5BB-BA6967DA1033'),
	('135BAC11-6DBA-4561-981A-9A32AF7A3974', 'FC803E66-F951-4614-A503-0072D7E43E27'),
	('135BAC11-6DBA-4561-981A-9A32AF7A3974', '44827D57-D071-4D1A-B763-3B3208BFB02B'),
	('135BAC11-6DBA-4561-981A-9A32AF7A3974', '92667BAE-6738-420F-952F-32B28DB8A3BD'),
	('135BAC11-6DBA-4561-981A-9A32AF7A3974', 'A198779D-7284-48EF-9A94-D7F67B82E7E4')


-- KeyIntrest Table Inserts
INSERT INTO KeyIntrest(intrestId, keyIntrestName)
VALUES
    ('E632BE72-000B-4CEA-9D3E-1CDBE839BD5B', 'Sharing'),
	('AC42A1B9-9B24-4172-9EC6-89D0F13F19C0', 'Learning'),
	('9B64F4C1-4F8D-4317-A48A-09A562A16740', 'Working'),
	('5C40A6B1-E3BF-42A0-AF53-AC077AF4DFA7', 'Caring'),
	('D1CEB407-55CB-45DE-87D4-B7D40CD6EA0A', 'Happening')
	
-- Member Table Inserts
INSERT INTO Member(memberId, userId, membershipTypeId)
VALUES
    ('91DC41C2-B596-4D0A-9A08-F2C97F2A713C', '180C3802-A27A-4C7F-B60F-ED73F6E46F1F', 'A7576A23-EEAA-435D-8D0B-E5670913F26B'),
	('618AEABA-FF94-4F97-B7C7-7CA13ADB2F97', '7E15881D-243B-49EB-8A80-EB7445F90982', '278AA19B-44A9-4282-8D8B-9AE4A16B462F'),
	('59347610-2E3C-4F18-99E2-D3B5089DB88E', '86C89165-9CD2-4B2D-91CB-8D19731DC5C1', '135BAC11-6DBA-4561-981A-9A32AF7A3974'),
    ('2C3EAB65-9C4C-46E3-9DF1-2747FF58D026', '8B6157DF-1330-492A-A410-5A599DF91694', '51B6C680-EFBC-4AFC-B499-CDAEA034E3CA')


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
