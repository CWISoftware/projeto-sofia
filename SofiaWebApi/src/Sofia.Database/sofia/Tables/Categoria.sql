CREATE TABLE [sofia].[Categoria] (
    [Id]				INT				IDENTITY (1, 1) NOT NULL,
    [Nome]				VARCHAR (50)	NOT NULL,	
	[QtdTecnologias]	INT				NOT NULL CONSTRAINT [DF_Categoria_QtdTecnologias] DEFAULT 0,
	[RowVersion]		TIMESTAMP		NOT NULL
    CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED ([Id] ASC)
);

