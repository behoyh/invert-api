CREATE TABLE INTERACTIVE_MESSAGES.dbo.MESSAGES(
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    Type INT NOT NULL,
    Active BIT NOT NULL,
    Urgent BIT  NOT NULL,
    IsTargeted BIT NOT NULL,
    Title NVARCHAR(1000),
    Body NVARCHAR(MAX),
    Link NVARCHAR(256),
    BlobId BIGINT,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Created DATETIME NOT NULL,
    Modified DATETIME NOT NULL  
);

CREATE TABLE INTERACTIVE_MESSAGES.dbo.TARGET_MESSAGES(
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    Acknowledged_Date DATETIME,
    Acknowledged BIT,
    Uid NVARCHAR(512) NOT NULL,
    MessageId BIGINT NOT NULL,
    Created DATETIME NOT NULL,
    Modified DATETIME NOT NULL
);