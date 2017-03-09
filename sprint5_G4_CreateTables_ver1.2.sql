--ContactTypes
CREATE TABLE [ContactTypes]
(
    [ContactTypeId] int IDENTITY(1,1) PRIMARY KEY,
    [TypeName] varchar(50) NOT NULL,
);

--ContactPerson
CREATE TABLE [ContactPersons]
(
    [ContactPersonId] int IDENTITY(1,1) PRIMARY KEY,
    [ContactPersonNumber] int NOT NULL UNIQUE,
    [ContactTypeId] int NOT NULL FOREIGN KEY REFERENCES ContactTypes(ContactTypeId),
    [FirstName] varchar(50) NOT NULL,
    [LastName] varchar(50) NOT NULL,
    [Email] varchar(50),
    [PhoneNumber] varchar(50) NOT NULL,
);

--Club 
CREATE TABLE [Clubs]
(
    [ClubId] int IDENTITY(1,1) PRIMARY KEY,
    [ContactPersonId] int NOT NULL FOREIGN KEY REFERENCES ContactPersons(ContactPersonId),
    [ClubName] varchar(50) NOT NULL UNIQUE,
    [Description] varchar(255),
    [PhoneNumber] varchar(50) NOT NULL,
    [Email] varchar(50) NOT NULL,
    [RegistrationDateTime] DateTime NOT NULL DEFAULT GETDATE(),
    [LogoUrl] varchar(255) NOT NULL,
    [WebSiteUrl] varchar(255),
);

--ContactAddress
CREATE TABLE [ContactAddresses]
(
    [ContactAddressId] int IDENTITY(1,1) PRIMARY KEY,
    [ContactAddressNumber] int NOT NULL UNIQUE,
    [ClubId] int NOT NULL FOREIGN KEY REFERENCES Clubs(CLubId),
    [City] varchar(50) NOT NULL,
    [Country] varchar(50) NOT NULL,
    [ContactAddressType] varchar(50),
    [Street] varchar(50) NOT NULL,
    [ZipCode] int NOT NULL,
);

--Regattas
CREATE TABLE [Regattas]
(
    [RegattaId] int IDENTITY(1,1) PRIMARY KEY,
    [ClubId] int NOT NULL FOREIGN KEY REFERENCES [Clubs](ClubId),
    [ContactAddressId] int NOT NULL FOREIGN KEY REFERENCES [ContactAddresses](ContactAddressId),
    [ContactPersonId] int NOT NULL FOREIGN KEY REFERENCES [ContactPersons](ContactPersonId),
    [RegattaName] varchar(50) NOT NULL,
    [StartDateTime] DateTime NOT NULL,
    [EndDateTime] DateTime NOT NULL,
    [RegattaFee] int NOT NULL DEFAULT 0,
    [RegattaDescription] varchar(50) NOT NULL,
    [MaxAmountOfEntries] int NULL

    CONSTRAINT uc_rName_StartDT UNIQUE (RegattaName, StartDateTime)
);

CREATE TABLE [Users]
(
	[UserId]			int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Email]				varchar(50) NOT NULL,
	[DateOfBirth]		datetime NOT NULL,
	[Password]			varchar(100) NOT NULL,
	[FirstName]			varchar(50) NOT NULL,
	[LastName]			varchar(50) NOT NULL,
	[PhoneNumber]		varchar(50) NOT NULL,
	[ContactPersonId]	int FOREIGN KEY REFERENCES ContactPersons(ContactPersonId) NOT NULL

	CONSTRAINT uc_Email UNIQUE(Email)
);

CREATE TABLE [Boats]
(
	[BoatId]		int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[SailNumber]	int UNIQUE NOT NULL,
	[BoatName]		varchar(50) NOT NULL,
	[Hcp]			float NOT NULL,
	[Description]	varchar(100) NULL,
	[BoatType]		varchar(50) NOT NULL
);

CREATE TABLE [Entries]
(
	[EntryId]			int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[EntryNumber]		int UNIQUE NOT NULL,
	[EntryName]			varchar(50) NOT NULL,
	[RegistrationDate]	datetime NOT NULL DEFAULT GETDATE(),
	[AmountPaid]		float NOT NULL DEFAULT 0,
	[UserId]	        int FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
	[ClubId]			int FOREIGN KEY REFERENCES Clubs(ClubId) NOT NULL,
	[BoatId]			int FOREIGN KEY REFERENCES Boats(BoatId) NULL
);

CREATE TABLE [RegisteredUsers]
(
	[RegisteredUserId] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserId]		int FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
	[EntryId]		int FOREIGN KEY REFERENCES Entries(EntryId) NOT NULL,
	[AmountPaid]	float NOT NULL DEFAULT 0

	CONSTRAINT uc_UserIdEntryId UNIQUE (UserId, EntryId)
);


CREATE TABLE [Teams]
(
	[TeamId]		int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TeamNumber]	int NOT NULL,
	[EntryId]		int FOREIGN KEY REFERENCES Entries(EntryId) NOT NULL,
	[SkipperId]		int FOREIGN KEY REFERENCES RegisteredUsers(RegisteredUserId) NOT NULL,

	CONSTRAINT uc_TeamNumberEntryId UNIQUE(TeamNumber, EntryId)
);


CREATE TABLE [Events]
(
	[EventId]					int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[RegattaId]					int FOREIGN KEY REFERENCES Regattas(RegattaId) NOT NULL,
	[ContactAddressId]			int FOREIGN KEY REFERENCES ContactAddresses(ContactAddressId) NOT NULL,
	[EventName]					varchar(50) NOT NULL,
	[Description]				varchar(100) NOT NULL,
	[StartDateTime]				datetime NOT NULL,
	[EndDateTime]				datetime NOT NULL,
	[EventFee]					int NOT NULL DEFAULT 0,
	[MaxAmountOfParticipants]	int NULL

	CONSTRAINT uc_EventNameStartDateTime UNIQUE(EventName, StartDateTime)
)


CREATE TABLE [SocialEvents]
(
	[SocialEventId]		int PRIMARY KEY FOREIGN KEY REFERENCES [Events](EventId),
	[SocialEventType]	varchar(50) NOT NULL
);

CREATE TABLE [RaceEvents]
(
	[RaceEventId]		int PRIMARY KEY FOREIGN KEY REFERENCES [Events](EventId) NOT NULL,
	[MaxRaceHcp]		float NOT NULL,
	[MinRaceHcp]		float NOT NULL
)


--Kopplingstabell
CREATE TABLE [RegisteredTeamUsers]
(
	[TeamId]			int FOREIGN KEY REFERENCES Teams(TeamId) NOT NULL,
	[RegisteredUserId]	int FOREIGN KEY REFERENCES RegisteredUsers(RegisteredUserId) NOT NULL

	CONSTRAINT pk_TeamIdRegisteredUserId PRIMARY KEY (TeamId, RegisteredUserId)
);


--Kopplingstabell
CREATE TABLE [RegisteredUserSocialEvents]
(
	[SocialEventId]		int FOREIGN KEY REFERENCES SocialEvents(SocialEventId) NOT NULL,
	[RegisteredUserId]	int FOREIGN KEY REFERENCES RegisteredUsers(RegisteredUserId) NOT NULL,
	[AmountOfFriends]	int NULL

	CONSTRAINT pk_EventIdRegisteredUserId PRIMARY KEY (SocialEventId, RegisteredUserId)
);


--Kopplingstabell
CREATE TABLE [RegattaEntries]
(
	[RegattaEntryId]	int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[EntryId]			int FOREIGN KEY REFERENCES Entries(EntryId) NOT NULL,
	[RegattaId]			int FOREIGN KEY REFERENCES Regattas(RegattaId) NOT NULL,
);

--Kopplingstabell
CREATE TABLE [RaceEventTeams]
(
	[TeamId]		int FOREIGN KEY REFERENCES Teams(TeamId) NOT NULL,
	[RaceEventId]	int FOREIGN KEY REFERENCES RaceEvents(RaceEventId) NOT NULL,
	[StartLocation] varchar(50) NOT NULL,
	[EndLocation]	varchar(50) NOT NULL

	CONSTRAINT pk_TeamIdRaceEventId PRIMARY KEY (TeamId, RaceEventId)
);

--Kopplingstabell
CREATE TABLE [ClubUsers]
(
	[UserId] int FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
	[ClubId] int FOREIGN KEY REFERENCES Clubs(ClubId) NOT NULL

	CONSTRAINT pk_UserIdClubId PRIMARY KEY (UserId, ClubId)
);


CREATE TABLE [Results]
(
	[ResultId] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[RaceEventId] int FOREIGN KEY REFERENCES RaceEvents(RaceEventId) NOT NULL,
	[TeamId] int FOREIGN KEY REFERENCES Teams(TeamId) NOT NULL,
	[BoatId] int FOREIGN KEY REFERENCES Boats(BoatId) NOT NULL,
	[ResultTime] varchar(50) NOT NULL,
	[CalculatedResultTime] varchar(50) NOT NULL,
	[ResultDistance] float NOT NULL,
	[CalculatedResultDistance] float NOT NULL,
	[Rank] int NOT NULL,
	[Penalty] int NULL,
	[IsDisqualified] bit NULL

	CONSTRAINT uc_RankRaceEventIdTeamId UNIQUE([Rank], RaceEventId, TeamId)
)


