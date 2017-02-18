CREATE TABLE [sofia].[Avaliacao] (
    [Id]				INT          IDENTITY (1, 1) NOT NULL,
    [IdColaborador]		INT			 NOT NULL,
    [IdTecnologia]		INT          NOT NULL,
	[Nivel]				SMALLINT     NOT NULL,
	[AvaliadoEm]		DATETIME     NOT NULL,
    CONSTRAINT [PK_Avaliacao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Colaborador_Avaliacao_IdColaborador] FOREIGN KEY ([IdColaborador]) REFERENCES [sofia].[Colaborador] ([Id]),
	CONSTRAINT [FK_Tecnologiar_Avaliacao_IdTecnologia] FOREIGN KEY ([IdTecnologia]) REFERENCES [sofia].[Tecnologia] ([Id]),
	CONSTRAINT [UQ_Avaliacao_IdColaborador_IdTecnologia] UNIQUE ([IdColaborador],[IdTecnologia])
);

