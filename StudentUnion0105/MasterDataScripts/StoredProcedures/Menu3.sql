CREATE PROCEDURE Menu3 (@LanguageId int)
AS 
SELECT
	dbMenu3.Id OId
	, dbMenu2.Id PId
	, dbMenu1.Id PPId
	, CASE WHEN dbMenu3.MenuTypeId = 1 THEN ''                       -- Nothing
		WHEN dbMenu3.MenuTypeId = 2 THEN '/FrontClassificationPage/FirstLevel/' + CONVERT(NVARCHAR, ClassificationTable.DefaultClassificationPageId)	 -- Classification
		WHEN dbMenu3.MenuTypeId = 3 THEN '/' + dbMenu3.Controller + '/' + dbMenu1.Action + '/' + CONVERT(NVARCHAR, dbMenu3.DestinationId)		     -- Controller / action / Id
		WHEN dbMenu3.MenuTypeId = 4 THEN '/' + dbMenu3.Controller 		                     -- Feature
		END DestinationURL
	, CASE WHEN dbMenu3.MenuTypeId = 1 THEN dbMenu3Language.MenuName
		WHEN dbMenu3.MenuTypeId = 2 THEN ClassificationTable.MenuName
		WHEN dbMenu3.MenuTypeId = 3 THEN dbMenu3Language.MenuName
		WHEN dbMenu3.MenuTypeId = 4 THEN dbMenu3Language.MenuName
		END MenuName
FROM dbMenu1 
JOIN dbMenu2
	ON dbMenu2.Menu1Id = dbMenu1.Id
JOIN dbMenu3
	ON dbMenu3.Menu2Id = dbMenu2.Id
JOIN dbMenu3Language 
	ON dbMenu3.Id = dbMenu3Language.Menu3Id 
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
	ON ClassificationTable.Id = dbMenu2.ClassificationId
WHERE LanguageId = @LanguageId
	AND dbMenu1.MenuTypeId IN (1,3,4)
	AND dbMenu2.MenuTypeId IN (1,3,4)
--ORDER BY dbMenu1.Sequence, dbMenu3.Sequence

UNION ALL

SELECT 
	ClassificationValue.Id OId
	, dbMenu2.Id PId
	, dbMenu1.Id PPId
	, '/FrontClassificationPage/NextLevel/' + CONVERT(NVARCHAR, DbClassification.DefaultClassificationPageId)	 -- Classification
	, ClassificationValue.MenuName
FROM dbMenu1 
JOIN dbMenu2
	ON dbmenu1.Id = dbmenu2.Menu1Id
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
	ON ClassificationValue.Id = dbMenu2.ClassificationId
JOIN DbClassificationLevel
	ON dbMenu2.ClassificationId = DbClassificationLevel.ClassificationId
JOIN DbClassification
	ON dbMenu2.ClassificationId = DbClassification.Id
WHERE 	dbMenu1.MenuTypeId <> 2
	AND 	dbMenu2.MenuTypeId = 2
	AND DbClassificationLevel.InMenu = 1

UNION ALL

SELECT 
	ClassificationValue.OId 
	, ClassificationValue.PId 
	, dbMenu1.Id PPId
	, '/FrontClassificationPage/NextLevel/' + CONVERT(NVARCHAR, DbClassification.DefaultClassificationPageId)	 -- Classification
	, ClassificationValue.MenuName
FROM dbMenu1 
JOIN (
	SELECT 
		Value1.Id PId
		, Value2.Id OId
		, DbClassificationValueLanguage.MenuName
		, value1.ClassificationId
	FROM DbClassificationValue Value1
	JOIN DbClassificationValue Value2
		ON Value1.Id = value2.ParentValueId
	JOIN DbClassificationValueLanguage
		ON Value2.Id = DbClassificationValueLanguage.ClassificationValueId
	WHERE Value1.ParentValueId IS NULL
		AND DbClassificationValueLanguage.LanguageId = @LanguageId
	) ClassificationValue
	ON ClassificationValue.ClassificationId = dbMenu1.ClassificationId
JOIN DbClassificationLevel
	ON dbMenu1.ClassificationId = DbClassificationLevel.ClassificationId
JOIN DbClassification
	ON dbMenu1.ClassificationId = DbClassification.Id
WHERE 	dbMenu1.MenuTypeId = 2
	AND DbClassificationLevel.InMenu = 1
	
	AND DbClassificationLevel.Sequence = 2