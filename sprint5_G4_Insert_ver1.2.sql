
INSERT INTO ContactTypes(TypeName) VALUES ('ContactType1')

INSERT INTO ContactPersons(ContactPersonNumber, ContactTypeId, FirstName, LastName, Email, PhoneNumber)
VALUES
(1111, 1, 'cp1', 'cp1', 'cp1@cp.se', '08323232')

INSERT INTO Users(Email, DateOfBirth, [Password], FirstName, LastName, PhoneNumber, ContactPersonId)
VALUES
('u1@u.se', '2013-03-03', 'pw1', 'u1', 'u1', '073320905', 1)

INSERT INTO Entries(EntryNumber, EntryName, UserId, ClubId, BoatId)
VALUES
(11111,'e1', 1, 1)

INSERT INTO Teams(TeamNumber, EntryId, SkipperId) VALUES
(1111, 1, 1) 