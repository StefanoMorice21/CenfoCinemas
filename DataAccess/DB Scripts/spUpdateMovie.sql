USE [cenfocinemas-db]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPD_MOVIE_PR]
    @P_ID INT,
    @P_TITLE NVARCHAR(255),
    @P_SINOPSIS NVARCHAR(MAX),
    @P_GENRE NVARCHAR(100),
    @P_DURATION INT,
    @P_CLASIFICATION NVARCHAR(50),
    @P_IMAGE NVARCHAR(500),
    @P_STATUS NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblMovies
    SET
        Updated = GETDATE(),
        Title = @P_TITLE,
        Sinopsis = @P_SINOPSIS,
        Genre = @P_GENRE,
        Duration = @P_DURATION,
        Clasification = @P_CLASIFICATION,
        Image = @P_IMAGE,
        Status = @P_STATUS
    WHERE Id = @P_ID;
END
GO
