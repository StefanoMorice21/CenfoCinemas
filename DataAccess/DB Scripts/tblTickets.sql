CREATE TABLE tblTickets
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Created DATETIME NOT NULL DEFAULT GETDATE(),

    Price FLOAT NOT NULL,
    Schedule DATETIME NOT NULL,
    Date DATETIME NOT NULL,
    Type NVARCHAR(50) NOT NULL,

    MovieId INT NOT NULL,

    CONSTRAINT FK_tblShows_tblMovies
        FOREIGN KEY (MovieId)
        REFERENCES dbo.tblMovies(Id)
);