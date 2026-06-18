SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_TICKET_BY_ID_PR 
	@P_ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Created, Schedule, Date, Type,MovieId
	FROM dbo.tblTickets WHERE Id = @P_ID;
END
GO