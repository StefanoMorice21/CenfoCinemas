USE [cenfocinemas-db]
GO
/****** Objeto: StoredProcedure [dbo].[CRE_MOVIE_PR] Fecha de script: 6/9/2026 3:03:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[CRE_MOVIE_PR]
	@P_TITLE NVARCHAR(255),
	@P_SINOPSIS NVARCHAR(MAX),
	@P_GENRE NVARCHAR(100),
	@P_DURATION INT,
	@P_CLASIFICATION NVARCHAR(50),
	@P_IMAGE NVARCHAR(500),
	@P_STATUS NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO tblMovies
	(
		Created,
		Title,
		Sinopsis,
		Genre,
		Duration,
		Clasification,
		Image,
		Status
	)
	VALUES
	(
		GETDATE(),
		@P_TITLE,
		@P_SINOPSIS,
		@P_GENRE,
		@P_DURATION,
		@P_CLASIFICATION,
		@P_IMAGE,
		@P_STATUS
	);
END
