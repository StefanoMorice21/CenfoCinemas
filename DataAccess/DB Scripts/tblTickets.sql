USE [cenfocinemas-db]
GO

CREATE TABLE tblTickets
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Created DATETIME NOT NULL DEFAULT GETDATE(),

    TicketCode NVARCHAR(25) NOT NULL,
    MovieId INT NOT NULL,
    UserId INT NOT NULL,
    ShowDateTime DATETIME NOT NULL,
    SeatNumber NVARCHAR(10) NOT NULL,
    Price FLOAT NOT NULL,
    Status NVARCHAR(50) NOT NULL,

    CONSTRAINT FK_tblTickets_tblMovies
        FOREIGN KEY (MovieId)
        REFERENCES dbo.tblMovies(Id),

    CONSTRAINT FK_tblTickets_tblUsers
        FOREIGN KEY (UserId)
        REFERENCES dbo.tblUsers(Id)
);
