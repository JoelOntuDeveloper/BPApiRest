CREATE TABLE [dbo].[Movimiento]
(
	[MovimientoID] INT IDENTITY NOT NULL PRIMARY KEY, 
    [NumeroCuenta] VARCHAR(15) NOT NULL, 
    [Fecha] DATETIME NOT NULL, 
    [TipoMovimiento] VARCHAR(15) NOT NULL, 
    [Valor] DECIMAL(10, 4) NOT NULL, 
    [Saldo] DECIMAL(10, 4) NOT NULL, 
    CONSTRAINT [FK_MovimientoCuenta] FOREIGN KEY ([NumeroCuenta]) REFERENCES [dbo].[Cuenta]([NumeroCuenta])
)
