CREATE TABLE [dbo].[Persona] (
    [Identificacion] VARCHAR (15)  NOT NULL,
    [Nombre]         VARCHAR (100) NOT NULL,
    [Genero]         VARCHAR (15)  NOT NULL,
    [Edad]           INT           NULL,
    [Direccion]      VARCHAR (200) NOT NULL,
    [Telefono]       VARCHAR (15)  NULL,
    PRIMARY KEY CLUSTERED ([Identificacion] ASC)
);

