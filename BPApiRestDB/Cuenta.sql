CREATE TABLE [dbo].[Cuenta]
(
	[NumeroCuenta] NCHAR(15) NOT NULL PRIMARY KEY, 
    [ClienteID] INT NOT NULL, 
    [TipoCuenta] NCHAR(20) NOT NULL, 
    [SaldoInicial] DECIMAL(10, 4) NOT NULL, 
    [Estado] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_CuentaCliente] FOREIGN KEY ([ClienteID]) REFERENCES [dbo].[Cliente]([ClienteID])
)
