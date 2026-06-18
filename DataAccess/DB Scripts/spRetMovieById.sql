USE [cenfocinemas-db]
GO
/****** Objeto: StoredProcedure [dbo].[RET_MOVIE_BY_ID_PR] Fecha de script: 6/11/2026 8:18:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[RET_MOVIE_BY_ID_PR]
    @P_ID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Created,
        Title,
        Sinopsis,
        Genre,
        Duration,
        Clasification,
        Image,
        Status
    FROM dbo.tblMovies
    WHERE Id = @P_ID;
END
