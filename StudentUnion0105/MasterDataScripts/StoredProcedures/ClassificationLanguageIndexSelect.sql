CREATE PROCEDURE ClassificationLanguageIndexSelect (@Id int)
AS 
SELECT dbClassificationLanguage.Id
	, dbClassification.Id
	, dbLanguage.LanguageName
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbClassification.CreatedDate
	, dbClassification.ModifiedDate
FROM dbClassification
JOIN dbClassificationLanguage
	ON dbClassification.Id = dbClassificationLanguage.ClassificationId
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbClassification.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbClassification.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbClassificationLanguage.ClassificationId = @Id
ORDER BY 
dbClassificationLanguage.Name




