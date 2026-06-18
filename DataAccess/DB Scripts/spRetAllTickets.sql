USE [cenfocinemas-db]
GO
/****** Objeto: StoredProcedure [dbo].[RET_ALL_TICKETS_PR] Fecha de script: 6/11/2026 8:55:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[RET_ALL_TICKETS_PR] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Created, Price, Schedule, Date, Type, MovieId
	FROM dbo.tblTickets
END
