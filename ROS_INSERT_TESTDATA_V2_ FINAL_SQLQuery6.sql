INSERT INTO [ContactTypes]
([TypeName])
VALUES
('TestType 1')


INSERT INTO [ContactTypes]
([TypeName])
VALUES
('TestType 2')

INSERT INTO [ContactPersons]
([ContactPersonNumber], [ContactTypeId], [FirstName], [LastName], [Email], [PhoneNUmber])
VALUES
(1, 1, 'CP1', 'CP1Lastname', 'CP1@mail.se', '111111111');

INSERT INTO [ContactPersons]
([ContactPersonNumber], [ContactTypeId], [FirstName], [LastName], [Email], [PhoneNUmber])
VALUES
(2, 2, 'CP2', 'CP2Lastname', 'CP2@mail.se', '222222222');



INSERT INTO [Clubs] 
([ContactPersonId],[ClubName], [Description], [PhoneNumber], [Email], [LogoUrl], [WebSiteUrl])
VALUES 
(1,'TestClub1', 'Första testklubben', '031111111', 'testklubb1@email.se', 'www.logotestklubb1.se', 'www.websitetestklubb1.se');

INSERT INTO [Clubs] 
([ContactPersonId], [ClubName], [Description], [PhoneNumber], [Email], [LogoUrl], [WebSiteUrl])
VALUES 
(2, 'TestClub2', 'Andra testklubben', '031222222', 'testklubb2@email.se', 'www.logotestklubb2.se', 'www.websitetestklubb2.se');

INSERT INTO [ContactAddresses]
([ContactAddressNumber],[ClubId], [City], [Country], [ContactAddressType], [Street], [ZipCode])
VALUES
(1, 1, 'CACity1', 'CACountry1', 'CAType1', 'CAStreet1', 11111);

INSERT INTO [ContactAddresses]
([ContactAddressNumber], [ClubId], [City], [Country], [ContactAddressType], [Street], [ZipCode])
VALUES
(2, 2, 'CACity2', 'CACountry2', 'CAType2', 'CAStreet2', 22222);

INSERT INTO [Regattas]
([ClubId], [ContactAddressId], [ContactPersonId], [RegattaName], [StartDateTime], [EndDateTime], [RegattaFee], [RegattaDescription], [MaxAmountOfEntries])
VALUES
(1, 1, 1, 'Regatta1', '2017-04-01', '2017-04-10', 1111, 'Första regattan', 111);

INSERT INTO [Regattas]
([ClubId], [ContactAddressId], [ContactPersonId], [RegattaName], [StartDateTime], [EndDateTime], [RegattaFee], [RegattaDescription], [MaxAmountOfEntries])
VALUES
(2, 2, 2, 'Regatta2', '2017-05-02', '2017-05-20', 2222, 'Andra regattan', 222);

INSERT INTO [Events]
([RegattaId], [ContactAddressId], [EventName], [Description], [StartDateTime], [EndDateTime], [EventFee], [MaxAmountOfParticipants])
VALUES
(1, 1, 'Event1', 'Första eventet', '2017-04-01', '2017-04-10', 1111, 111);

INSERT INTO [Events]
([RegattaId], [ContactAddressId], [EventName], [Description], [StartDateTime], [EndDateTime], [EventFee], [MaxAmountOfParticipants])
VALUES
(2, 2, 'Event2', 'Andra eventet', '2017-05-02', '2017-05-20', 2222, 222);

INSERT INTO [RaceEvents]
([RaceEventId],[MaxRaceHcp], [MinRaceHcp])
VALUES
(1, 0.1, 1.0);

INSERT INTO [RaceEvents]
([RaceEventId],[MaxRaceHcp], [MinRaceHcp])
VALUES
(2, 2.0, 2.2);

INSERT INTO [SocialEvents]
([SocialEventId], [SocialEventType])
VALUES
(1, 'SocialEvent 1');

INSERT INTO [SocialEvents]
([SocialEventId], [SocialEventType])
VALUES
(2, 'SocialEvent 2');

INSERT INTO Boats([SailNumber], [BoatName], [Hcp], [Description], [BoatType])
VALUES
(1, 'FörstaBåtensNamn', 1.1, 'Båt No 1', 'TypBåt1')

INSERT INTO Boats([SailNumber], [BoatName], [Hcp], [Description], [BoatType])
VALUES
(2, 'AndraBåtensNamn', 2.2, 'Båt No 2', 'TypBåt2') --Klara

INSERT INTO Users(Email, DateOfBirth, [Password], FirstName, LastName, PhoneNumber, ContactPersonId)
VALUES
('u1@u.se', '2013-03-03', 'pw1', 'u1', 'u1', '073320905', 1)

INSERT INTO Users(Email, DateOfBirth, [Password], FirstName, LastName, PhoneNumber, ContactPersonId)
VALUES
('u2@u.se', '2013-02-02', 'pw2', 'u2', 'u2', '073322222', 2) --klara


INSERT INTO Entries(EntryNumber, EntryName, UserId, ClubId, BoatId)
VALUES
(11111,'e1', 1, 1, 1)

INSERT INTO Entries(EntryNumber, EntryName, UserId, ClubId, BoatId)
VALUES
(22222,'e2', 2, 2, 2) -- Klara

INSERT INTO RegisteredUsers([UserId], [EntryId], [AmountPaid])
VALUES
(1, 3, 111.00)

INSERT INTO RegisteredUsers([UserId], [EntryId], [AmountPaid])
VALUES
(2, 4, 222.00) --Klara


INSERT INTO Teams(TeamNumber, EntryId, SkipperId) VALUES
(1111, 3, 3) 

INSERT INTO Teams(TeamNumber, EntryId, SkipperId) VALUES
(2222, 4, 4) --klara 

INSERT INTO RegisteredTeamUsers([RegisteredUserId], [TeamId])
VALUES
(3, 14)

INSERT INTO RegisteredTeamUsers([RegisteredUserId], [TeamId])
VALUES
(4, 15) --Klara

INSERT INTO ClubUsers([ClubId], [UserId])
VALUES
(1, 1)

INSERT INTO ClubUsers([ClubId], [UserId])
VALUES
(2, 2) --klara

INSERT INTO RaceEventTeams([TeamId], [RaceEventId], [StartLocation], [EndLocation])
VALUES 
(14, 1, 'FörstastartLocation', 'FörstaSlutDestination')

INSERT INTO RaceEventTeams([TeamId], [RaceEventId], [StartLocation], [EndLocation])
VALUES 
(15, 2, 'AndrastartLocation', 'AndraSlutDestination') --Klara

INSERT INTO RegattaEntries([EntryId], [RegattaId])
VALUES
(3, 1)

INSERT INTO RegattaEntries([EntryId], [RegattaId])
VALUES
(4, 2) --Klara

INSERT INTO RegisteredUserSocialEvents([RegisteredUserId], [SocialEventId], [AmountOfFriends])
VALUES
(3, 1, 1)

INSERT INTO RegisteredUserSocialEvents([RegisteredUserId], [SocialEventId], [AmountOfFriends])
VALUES
(4, 2, 22) -- Klara




