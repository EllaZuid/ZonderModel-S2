CREATE TABLE [Gebruiker] (
  [ID] int,
  [Naam] NCHAR(30),
  [Wachtwoord] NCHAR(50),
  [Email] NCHAR(30),
  [Geslacht] NCHAR(5),
  [Lengte] FLOAT,
  [Gewicht] decimal(6,2),
  [GemiddeldeTijd(s)] int,
  PRIMARY KEY ([ID])
);

CREATE TABLE [Loopmoment] (
  [ID] int,
  [Gebruiker] int,
  [Playlist] int,
  [Route] int,
  [Tijd] int,
  [Datum] date,
  [Afstand] int,
  [GemiddeldeSnelheid] decimal(7,3),
  PRIMARY KEY ([ID])
);

CREATE INDEX [FK] ON  [Loopmoment] ([Gebruiker], [Playlist], [Route]);
