CREATE TABLE [sofia].[Colaborador] (
    [Id]				INT          IDENTITY (1, 1) NOT NULL,
    [PrimeiroNome]      VARCHAR (50) NOT NULL,
	[SegundoNome]       VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Colaborador] PRIMARY KEY CLUSTERED ([Id] ASC)
);

