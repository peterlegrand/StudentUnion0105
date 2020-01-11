CREATE PROCEDURE Menu2 (@LanguageId int)
AS 
SELECT
	dbMenu2.Id OId
	, dbMenu1.Id PId
	, CASE WHEN dbMenu2.MenuTypeId = 1 THEN ''                       -- Nothing
		WHEN dbMenu2.MenuTypeId = 2 THEN '/FrontClassificationPage/FirstLevel/' + CONVERT(NVARCHAR, ClassificationTable.DefaultClassificationPageId)	 -- Classification
		WHEN dbMenu2.MenuTypeId = 3 THEN '/' + dbMenu2.Controller + '/' + dbMenu1.Action + '/' + CONVERT(NVARCHAR, dbMenu2.DestinationId)		     -- Controller / action / Id
		WHEN dbMenu2.MenuTypeId = 4 THEN '/' + dbMenu2.Controller 		                     -- Feature
		END DestinationURL
	, CASE WHEN dbMenu2.MenuTypeId = 1 THEN dbMenu2Language.MenuName
		WHEN dbMenu2.MenuTypeId = 2 THEN ClassificationTable.MenuName
		WHEN dbMenu2.MenuTypeId = 3 THEN dbMenu2Language.MenuName
		WHEN dbMenu2.MenuTypeId = 4 THEN dbMenu2Language.MenuName
		END MenuName
FROM dbMenu1 
JOIN dbMenu2
	ON dbMenu2.Menu1Id = dbMenu1.Id
JOIN dbMenu2Language 
	ON dbMenu2.Id = dbMenu2Language.Menu2Id 
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
	AND dbMenu1.MenuTypeId IN (1,3,4)
--ORDER BY dbMenu1.Sequence, dbMenu2.Sequence

UNION ALL

SELECT 
	ClassificationValue.Id OId
	, dbMenu1.Id PId
	, '/FrontClassificationPage/NextLevel/' + CONVERT(NVARCHAR, DbClassification.DefaultClassificationPageId)	 -- Classification
	, ClassificationValue.MenuName
FROM dbMenu1 
JOIN (
	SELECT 
		DbClassificationValue.Id
		, DbClassificationValueLanguage.MenuName
	FROM DbClassificationValue
	JOIN DbClassificationValueLanguage
		ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId
	WHERE DbClassificationValue.ParentValueId IS NULL
		AND DbClassificationValueLanguage.LanguageId = @LanguageId
	) ClassificationValue
	ON ClassificationValue.Id = dbMenu1.ClassificationId
JOIN DbClassificationLevel
	ON dbMenu1.ClassificationId = DbClassificationLevel.ClassificationId
JOIN DbClassification
	ON dbMenu1.ClassificationId = DbClassification.Id
WHERE 	dbMenu1.MenuTypeId =2
	AND DbClassificationLevel.InMenu = 1
	AND DbClassificationLevel.Sequence = 1