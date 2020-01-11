CREATE PROCEDURE Menu1 (@LanguageId int)
AS 
SELECT 
	dbMenu1.Id
	, CASE WHEN dbMenu1.MenuTypeId = 1 THEN ''                       -- Nothing
		WHEN dbMenu1.MenuTypeId = 2 THEN '/FrontClassificationPage/FirstLevel/' + ClassificationTable.DefaultClassificationPageId	 -- Classification
		WHEN dbMenu1.MenuTypeId = 3 THEN '/' + dbMenu1.Controller + '/' + dbMenu1.Action + '/' + dbMenu1.DestinationId		     -- Controller / action / Id
		WHEN dbMenu1.MenuTypeId = 4 THEN '/' + dbMenu1.Controller 		                     -- Feature
		END DestinationURL
	, CASE WHEN dbMenu1.MenuTypeId = 1 THEN dbMenu1Language.MenuName
		WHEN dbMenu1.MenuTypeId = 2 THEN ClassificationTable.MenuName
		WHEN dbMenu1.MenuTypeId = 3 THEN dbMenu1Language.MenuName
		WHEN dbMenu1.MenuTypeId = 4 THEN dbMenu1Language.MenuName
		END MenuName
FROM dbMenu1 
JOIN dbMenu1Language 
	ON dbMenu1.Id = dbMenu1Language.Menu1Id 
LEFT JOIN (
	SELECT 
		DbClassification.Id
		, DbClassification.DefaultClassificationPageId 
		, DbClassificationLanguage.MenuName
	FROM DbClassification 
	JOIN DbClassificationLanguage 
		ON DbClassification.Id = DbClassificationLanguage.ClassificationId
	WHERE DbClassificationLanguage.LanguageId = @LanguageId
	) ClassificationTable	
	ON ClassificationTable.Id = dbMenu1.ClassificationId
WHERE LanguageId = @LanguageId
ORDER BY dbMenu1.Sequence

