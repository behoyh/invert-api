﻿CREATE TABLE INTERACTIVE_MESSAGES.dbo.BLOBS(
    ID BIGINT NOT NULL IDENTITY PRIMARY KEY,
    ACTIVE BIT NOT NULL,
    PATH NVARCHAR(1000) NOT NULL,
    NAME NVARCHAR(1000) NOT NULL,
    BLOB_TYPE INT NOT NULL,
    CREATED DATETIME NOT NULL,
    MODIFIED DATETIME NOT NULL
);
