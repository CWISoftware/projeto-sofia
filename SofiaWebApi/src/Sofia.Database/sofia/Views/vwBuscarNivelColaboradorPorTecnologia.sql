CREATE VIEW [sofia].[vwBuscarNivelColaboradorPorTecnologia] 
AS
 SELECT
	Colaborador.Id ColaboradorId
	, Colaborador.Nome ColaboradorNome
	, Tecnologia.Nome TecnologiaNome
	, Tecnologia.Icone TecnologiaIcone
	, Avaliacao.Nivel TecnologiaNivel
	FROM  
		[sofia].[Avaliacao] Avaliacao WITH(NOLOCK)
			INNER JOIN [sofia].[Tecnologia] Tecnologia  WITH(NOLOCK)
				ON Avaliacao.IdTecnologia = Tecnologia.Id
			INNER JOIN [sofia].[Colaborador] Colaborador  WITH(NOLOCK)
				ON Avaliacao.IdColaborador = Colaborador.Id