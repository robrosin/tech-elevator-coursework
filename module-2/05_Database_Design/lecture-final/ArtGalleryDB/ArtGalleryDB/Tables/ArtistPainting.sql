CREATE TABLE [dbo].[ArtistPainting]
(
    [ArtistId] INT NOT NULL , 
    [PaintingId] INT NOT NULL, 
    CONSTRAINT [PK_ArtistPainting] PRIMARY KEY ([ArtistId], [PaintingId]), 
    CONSTRAINT [FK_ArtistPainting_Artist] FOREIGN KEY (ArtistId) REFERENCES Artist(ArtistId), 
    CONSTRAINT [FK_ArtistPainting_Painting] FOREIGN KEY (PaintingId) REFERENCES Painting(PaintingId)
)
