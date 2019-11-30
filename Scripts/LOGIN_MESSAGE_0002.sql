﻿CREATE TABLE INTERACTIVE_MESSAGES.dbo.LOGIN_MESSAGES(
    ID BIGINT NOT NULL IDENTITY PRIMARY KEY,
    ACTIVE BIT NOT NULL,
    ANDROID_VERSION NVARCHAR(64),
    ANDROID_MESSAGE NVARCHAR(1000),
    IOS_VERSION NVARCHAR(64),
    IOS_MESSAGE NVARCHAR(1000),
    TYPE INT NOT NULL,
    IOS_BLOCKED BIT NOT NULL,
    ANDROID_BLOCKED BIT NOT NULL,
    STARTTIME DATETIME,
    ENDTIME DATETIME,
    CREATED DATETIME NOT NULL,
    MODIFIED DATETIME NOT NULL
);