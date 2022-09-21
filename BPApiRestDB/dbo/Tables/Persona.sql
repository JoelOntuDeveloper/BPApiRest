CREATE TABLE [dbo].[Persona] (
    [PersonaID]       INT IDENTITY NOT NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [Genero]         VARCHAR (15)  NOT NULL,
    [Edad]           INT           NULL,
    [Direccion]      VARCHAR (200) NULL,
    [Telefono]       VARCHAR (15)  NULL,
    [Identificacion] VARCHAR(15) NOT NULL, 
    PRIMARY KEY CLUSTERED ([PersonaID] ASC)
);

