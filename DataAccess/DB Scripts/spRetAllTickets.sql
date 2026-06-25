USE [cenfocinemas-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_ALL_TICKETS_PR
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Created, TicketCode, MovieId, UserId, ShowDateTime, SeatNumber, Price, Status
    FROM dbo.tblTickets
END
GO
