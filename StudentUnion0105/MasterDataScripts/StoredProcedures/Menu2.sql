CREATE PROCEDURE Menu2 (@LanguageId int)
AS
SELECT 
	dbMenu2.Menu1Id PId
	, 'M' MenuType
	, dbMenu2.Id
	,  dbMenu2Language.MenuName
	, ISNULL(menu3.NoOfMenu3, 0) NoOfMenus3
	, ISNULL(Classifications.NoOfClassifications,0) NoOfClassifications
FROM dbMenu2 
JOIN dbMenu2Language
	ON dbMenu2.Id = dbMenu2Language.Menu2Id 
LEFT JOIN (SELECT Menu2Id, COUNT(*) NoOfMenu3 FROM dbmenu3 GROUP BY Menu2Id) Menu3
	ON Menu3.Menu2Id = dbMenu2.Id
LEFT JOIN (
SELECT ClassificationId, COUNT(*) NoOfClassifications FROM DbClassificationValue GROUP BY ClassificationId)
Classifications 
ON Classifications.ClassificationId = dbMenu2.ClassificationId
WHERE dbMenu2Language.LanguageId = @LanguageId

UNION 
SELECT 
	dbMenu1.Id PId
	, 'C'
	, DbClassificationValue.Id
	, DbClassificationValueLanguage.MenuName
	, 0 NoOfMenu
	, ISNULL(SubClass.NoOfClassifications,0) NoOfClass
FROM DbClassificationValue
JOIN DbClassificationValueLanguage
	ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId
JOIN dbMenu1
	ON dbMenu1.ClassificationId = DbClassificationValue.ClassificationId
LEFT JOIN (	SELECT ParentValueId, COUNT(*) NoOfClassifications
	FROM DbClassificationValue
	GROUP BY ParentValueId) SubClass
	ON SubClass.ParentValueId = DbClassificationValue.Id
WHERE  DbClassificationValueLanguage.LanguageId = @LanguageId
	AND DbClassificationValue.ParentValueId IS NULL


