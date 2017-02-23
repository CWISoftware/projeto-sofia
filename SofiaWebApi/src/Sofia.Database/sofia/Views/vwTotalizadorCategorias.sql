CREATE VIEW [sofia].[vwTotalizadorCategorias]
AS
SELECT 
	TOP 4 
		Nome, 
		QtdTecnologias 
	FROM [sofia].[Categoria] 
	ORDER BY QtdTecnologias DESC