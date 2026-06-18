SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RET_ALL_MOVIE_PR
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
    FROM dbo.tblMovies;
END
GO