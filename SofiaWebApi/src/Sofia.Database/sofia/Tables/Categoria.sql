CREATE TABLE [sofia].[Categoria] (
    [Id]				INT				IDENTITY (1, 1) NOT NULL,
    [Nome]				VARCHAR (50)	NOT NULL,
	[Versao]			VARBINARY(16)	NOT NULL CONSTRAINT [DF_Categoria_Versao] DEFAULT (CAST(ABS(CHECKSUM(NewId())) % 14 AS VARBINARY)),
	[QtdTecnologias]	INT				NOT NULL CONSTRAINT [DF_Categoria_QtdTecnologias] DEFAULT 0
    CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED ([Id] ASC)
);

