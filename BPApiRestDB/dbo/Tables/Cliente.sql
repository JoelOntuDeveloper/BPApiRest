CREATE TABLE [dbo].[Cliente]
(
	[ClienteID] INT IDENTITY NOT NULL PRIMARY KEY, 
    [PersonaID] INT NOT NULL, 
    [Contrasenia] VARCHAR(20) NOT NULL, 
    [Estado] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_ClientePersona] FOREIGN KEY ([PersonaID]) REFERENCES [dbo].[Persona]([PersonaID])
    )
