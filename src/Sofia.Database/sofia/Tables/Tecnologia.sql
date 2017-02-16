CREATE TABLE [sofia].[Tecnologia] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [IdCategoria] INT          NOT NULL,
    CONSTRAINT [PK_Tecnologia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Categoria_Tecnologia_IdCategoria] FOREIGN KEY ([IdCategoria]) REFERENCES [sofia].[Categoria] ([Id])
);

