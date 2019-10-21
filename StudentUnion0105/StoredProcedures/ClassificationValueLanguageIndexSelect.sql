CREATE PROCEDURE ClassificationValueLanguageIndexSelect (@Id int)
AS 
SELECT dbClassificationValueLanguage.Id
	, dbClassificationValue.Id
	, dbLanguage.LanguageName
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbClassificationValue.CreatedDate
	, dbClassificationValue.ModifiedDate
FROM dbClassificationValue
JOIN dbClassificationValueLanguage
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationValueLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbClassificationValue.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbClassificationValue.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbClassificationValueLanguage.ClassificationValueId = @Id
ORDER BY 
dbClassificationValueLanguage.Name




