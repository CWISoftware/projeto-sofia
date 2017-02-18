CREATE TABLE [sofia].[Colaborador] (
    [Id]				INT          IDENTITY (1, 1) NOT NULL,
    [Nome]				VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Colaborador] PRIMARY KEY CLUSTERED ([Id] ASC)
);

