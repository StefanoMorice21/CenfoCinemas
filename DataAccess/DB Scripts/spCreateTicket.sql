USE [cenfocinemas-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE CRE_TICKET_PR
    @P_TICKET_CODE NVARCHAR(25),
    @P_MOVIE_ID INT,
    @P_USER_ID INT,
    @P_SHOW_DATE_TIME DATETIME,
    @P_SEAT_NUMBER NVARCHAR(10),
    @P_PRICE FLOAT,
    @P_STATUS NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.tblTickets
    (
        Created,
        TicketCode,
        MovieId,
        UserId,
        ShowDateTime,
        SeatNumber,
        Price,
        Status
    )
    VALUES
    (
        GETDATE(),
        @P_TICKET_CODE,
        @P_MOVIE_ID,
        @P_USER_ID,
        @P_SHOW_DATE_TIME,
        @P_SEAT_NUMBER,
        @P_PRICE,
        @P_STATUS
    );
END
GO
