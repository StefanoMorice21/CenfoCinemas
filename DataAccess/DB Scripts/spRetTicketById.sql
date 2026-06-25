USE [cenfocinemas-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_TICKET_BY_ID_PR
    @P_ID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Created, TicketCode, MovieId, UserId, ShowDateTime, SeatNumber, Price, Status
    FROM dbo.tblTickets
    WHERE Id = @P_ID;
END
GO
