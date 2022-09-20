CREATE TABLE [dbo].[Cliente]
(
	[ClienteID] INT NOT NULL PRIMARY KEY, 
    [Identificacion] VARCHAR(15) NOT NULL, 
    [Contrasenia] VARCHAR(20) NOT NULL, 
    [Estado] VARCHAR(20) NOT NULL, 
    CONSTRAINT [FK_ClientePersona] FOREIGN KEY ([Identificacion]) REFERENCES [dbo].[Persona]([Identificacion])
    )
