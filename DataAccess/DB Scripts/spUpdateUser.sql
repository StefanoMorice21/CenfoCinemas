USE [cenfocinemas-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPD_USER_PR]
    @P_ID INT,
    @P_USER_CODE NVARCHAR(25),
    @P_NAME NVARCHAR(50),
    @P_EMAIL NVARCHAR(30),
    @P_PASSWORD NVARCHAR(20),
    @P_BIRTH_DATE DATETIME,
    @P_PHONE_NUMBER INT,
    @P_STATUS NVARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblUsers
    SET
        Updated = GETDATE(),
        UserCode = @P_USER_CODE,
        Name = @P_NAME,
        Email = @P_EMAIL,
        Password = @P_PASSWORD,
        Birthday = @P_BIRTH_DATE,
        Phone = @P_PHONE_NUMBER,
        Status = @P_STATUS
    WHERE Id = @P_ID;
END
GO
