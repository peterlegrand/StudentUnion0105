CREATE PROCEDURE Menu2 (@LanguageId int)
AS
SELECT 
	dbMenu2.Menu1Id PId
	, 'M' MenuType
	, dbMenu2.Id
	,  dbMenu2Language.MenuName
FROM dbMenu2 
JOIN dbMenu2Language
	ON dbMenu2.Id = dbMenu2Language.Menu2Id 
WHERE dbMenu2Language.LanguageId = @LanguageId

UNION 
SELECT 
	dbMenu1.Id PId
	, 'C'
	, DbClassificationValue.Id
	, DbClassificationValueLanguage.MenuName
FROM DbClassificationValue
JOIN DbClassificationValueLanguage
	ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId
JOIN dbMenu1
	ON dbMenu1.ClassificationId = DbClassificationValue.ClassificationId
WHERE  DbClassificationValueLanguage.LanguageId = @LanguageId
	AND ParentValueId IS NULL

