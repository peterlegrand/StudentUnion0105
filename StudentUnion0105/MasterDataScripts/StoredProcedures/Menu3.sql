CREATE PROCEDURE Menu3 (@LanguageId int)
AS
SELECT 
	dbMenu3.Menu2Id PId
	, 'M' MenuType
	, dbMenu3.Id
	,  dbMenu3Language.MenuName
FROM dbMenu3 
JOIN dbMenu3Language
	ON dbMenu3.Id = dbMenu3Language.Menu3Id 
WHERE dbMenu3Language.LanguageId = @LanguageId

UNION 
SELECT 
	dbMenu2.Id PId
	, 'MC'
	, DbClassificationValue.Id
	, DbClassificationValueLanguage.MenuName
FROM DbClassificationValue
JOIN DbClassificationValueLanguage
	ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId
JOIN dbMenu2
	ON dbMenu2.ClassificationId = DbClassificationValue.ClassificationId
WHERE  DbClassificationValueLanguage.LanguageId = @LanguageId
	AND ParentValueId IS NULL


SELECT 
	DbClassificationValue.ParentValueId PId
	,'MC'
	, DbClassificationValue.Id
	, DbClassificationValueLanguage.MenuName
FROM DbClassificationValue 
JOIN DbClassificationValueLanguage
	ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId
WHERE DbClassificationValue.ParentValueId 
IN (
	SELECT DbClassificationValue.Id 
	FROM DbClassificationValue 
	JOIN dbMenu1 
		ON dbMenu1.ClassificationId =  DbClassificationValue.ClassificationId 
	WHERE DbClassificationValue.ParentValueId IS NULL 
	)
	AND  DbClassificationValueLanguage.LanguageId = @LanguageId

