﻿CREATE TABLE INTERACTIVE_MESSAGES.dbo.BLOBS(
    Id BIGINT NOT NULL IDENTITY PRIMARY KEY,
    Active BIT NOT NULL,
    Path NVARCHAR(1000) NOT NULL,
    Name NVARCHAR(1000) NOT NULL,
    BlobType INT NOT NULL,
    Created DATETIME NOT NULL,
    Modified DATETIME NOT NULL
);
