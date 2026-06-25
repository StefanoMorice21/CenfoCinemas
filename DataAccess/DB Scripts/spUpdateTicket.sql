USE [cenfocinemas-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPD_TICKET_PR]
    @P_ID INT,
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

    UPDATE tblTickets
    SET
        TicketCode = @P_TICKET_CODE,
        MovieId = @P_MOVIE_ID,
        UserId = @P_USER_ID,
        ShowDateTime = @P_SHOW_DATE_TIME,
        SeatNumber = @P_SEAT_NUMBER,
        Price = @P_PRICE,
        Status = @P_STATUS
    WHERE Id = @P_ID;
END
GO
