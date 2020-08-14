﻿DROP TABLE IF EXISTS FeedbackAns;
DROP TABLE IF EXISTS User_has_Event;
DROP TABLE IF EXISTS Events;
DROP TABLE IF EXISTS AppUser;
DROP TABLE IF EXISTS Email;
DROP TABLE IF EXISTS CompanyType;

CREATE TABLE Email
(
	Email VARCHAR(50) NOT NULL,
	EmailStatus BINARY,
	PRIMARY KEY (Email)
);

INSERT INTO Email(Email, EmailStatus) VALUES
('Jacob@ABC.com', 0), 
('John@JohnFoods.com', 0), 
('Sushma@TribeA.com', 0);

CREATE TABLE AppUser
(
	UserName VARCHAR(50) NOT NULL,
	User_PW VARBINARY(50) NOT NULL,
	RepName VARCHAR(50) NOT NULL,
	Contact_Num INT NOT NULL,
	CompanyName VARCHAR(50) NOT NULL,
	CompanyWebsite VARCHAR(50) NOT NULL,
	CompanyIndustry VARCHAR(50) NOT NULL,
	CompanySize VARCHAR(50) NOT NULL,
	CompanyType INT NOT NULL,
	Email VARCHAR(50) NOT NULL,
	PRIMARY KEY (UserName),
	FOREIGN KEY (Email) REFERENCES Email(Email)
);

CREATE TABLE CompanyType
(
	CompanyTypeId INT NOT NULL,
	TypeDesc VARCHAR(20) NOT NULL,
	PRIMARY KEY (CompanyTypeId)
);
INSERT INTO CompanyType(CompanyTypeId, TypeDesc) VALUES 
(1, 'Admin'), 
(2, 'Current'), 
(3, 'Alumni'),
(4, 'Current, Alumni');




INSERT INTO AppUser(UserName, User_PW, RepName, Contact_Num, CompanyName, CompanyWebsite, CompanyIndustry, CompanySize, CompanyType, Email) VALUES 
('ABC', HASHBYTES('SHA1', 'password0'), 'Jacob', 98540091, 'ABC Company', 'www.ABCTech.com', 'HealthTech', '1-10', 2, 'Jacob@ABC.com'), 
('JohnFoods', HASHBYTES('SHA1', 'password2'), 'John', 98772301, 'John Foods', 'www.JohnFoods.com', 'F&B', '11-50', 2, 'John@JohnFoods.com'),
('TribeA', HASHBYTES('SHA1', 'secret0'), 'Sushma', 91629540, 'Tribe Accelerator', 'www.tribeaccelerator.com', 'IT', '11-50', 1, 'Sushma@TribeA.com');

CREATE TABLE Events
(
   event_id     		INT IDENTITY(1,1) NOT NULL,
   event_name   		VARCHAR(70) NOT NULL,
   event_description    VARCHAR(450) NOT NULL,
   venue    			VARCHAR(75) NOT NULL,
   category				VARCHAR(25) NOT NULL,
   start_dt   			DATETIME NOT NULL,
   end_dt	     		DATETIME NOT NULL,
   docName				VARCHAR(150) NULL,
   status				Varchar(10) NOT NULL,
   repeatOnNo			INT NULL,
   repeatOnType			VARCHAR(15) NULL,
   occurence			INT NULL,
   CompanyType			INT NOT NULL
   PRIMARY KEY (event_id),
   FOREIGN KEY (CompanyType) REFERENCES CompanyType(CompanyTypeId)
);
SET IDENTITY_INSERT Events ON;
INSERT INTO Events(event_id, event_name, event_description, venue, category, start_dt, end_dt, docName, status, repeatOnNo, repeatOnType, occurence, CompanyType) VALUES
(1, 'Singapore OpenGov Leadership Forum',	'The Singapore OpenGov Leadership Forum provides the attendees with the opportunity to join the forum and come to hear, engage, learn, and be a part of the journey towards embracing digital disruption. the attendees get the chance to set sail for the adventure of creative disruption with us embrace change today for a better tomorrow.'
,	'Sands Expo and Convention Centre, Singapore',	'Masterclass',			'2020-06-20 12:00', '2020-06-20 14:00', NULL,'Past', NULL, NULL, NULL, 2 ),
(2, 'Singapore Smart Cities Summit',	'Singapore Smart Cities Summit is a ground-up initiative to support Singapore and the region’s evolution towards becoming smart cities. The Summit is focused on deal closure for participants and showcasing the best, latest and most surprising smart cities technologies.'
,	'Singapore',	'Networking',			'2020-10-26 13:00', '2020-10-26 15:00', NULL, 'Upcoming', NULL, NULL, NULL, 3),
(3, 'DevOps Talks Conference (DOTC)',	'The DevOps Talks Conference brings together DevOps leaders, engineers, and architects who are implementing DevOps principles and practices in Start Ups and in Leading Enterprise companies. They run technical and cultural DevOps complex transformation for large and medium organizations.'
,	'392 Havelock Rd 169663',		'Panels/Fireside Chat',	'2020-03-13 12:00', '2020-03-13 17:00', NULL, 'Past', NULL, NULL, NULL, 4),
(4, 'AI and Robotics in Hospital and Healthcare Conference',	'AI and Robotics in Hospital and Healthcare Conference will cover topics like Harnessing Data Science and AI to Improve Management of Chronic Diseases, Pioneering The Future Of Patient Care With AI: A Case Study Of Woodlands Health Campus, Best Practices on AI in Rehabilitation Care, How AI Helps in Epidemic Prediction, Harnessing AI to Halt Cancer, Breakthrough Case Study From NUS.'
,	' Sheraton Towers Singapore, Singapore',		'Consultations',		'2020-08-08 15:00', '2020-08-08 17:00', NULL, 'Upcoming', NULL, NULL, NULL, 2);
SET IDENTITY_INSERT Events OFF;



CREATE TABLE User_has_Event
(
	UHE_id INT IDENTITY(1,10),
	UserName VARCHAR(50) NOT NULL,
	event_id INT NOT NULL,
	feedback_id INT NOT NULL,
	PRIMARY KEY (UHE_id),
	FOREIGN KEY (UserName) REFERENCES AppUser(UserName),
	FOREIGN KEY (event_id) REFERENCES Events(event_id)
);


CREATE TABLE FeedbackAns
(
	Fb_ans_id INT NOT NULL,
	answer1 VARCHAR NULL,
	answer2 VARCHAR NULL,
	answer3 VARCHAR NULL,
	answer4 VARCHAR NULL,
	answer5 VARCHAR NULL,
	answer6 VARCHAR NULL,
	answer7 VARCHAR NULL,
	answer8 VARCHAR NULL,
	answer9 VARCHAR NULL,
	answer10 VARCHAR NULL,
	answer11 VARCHAR NULL,
	answer12 VARCHAR NULL,
	answer13 VARCHAR NULL,
	answer14 VARCHAR NULL,
	answer15 VARCHAR NULL,
	answer16 VARCHAR NULL,
	answer17 VARCHAR NULL,
	answer18 VARCHAR NULL,
	answer19 VARCHAR NULL,
	answer20 VARCHAR NULL,
	answer21 VARCHAR NULL,
	answer22 VARCHAR NULL,
	UHE_id INT NOT NULL,
	PRIMARY KEY (Fb_ans_id),
	FOREIGN KEY (UHE_id) REFERENCES User_has_Event(UHE_id)
);