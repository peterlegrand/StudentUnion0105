CREATE PROCEDURE ClassificationIndexSelect (@LanguageId int)
AS 
SELECT dbClassification.Id
	, dbClassificationLanguage.LanguageId
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
JOIN AspNetUsers Creator
	ON CAST( dbClassification.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbClassification.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbClassificationLanguage.LanguageId = @LanguageId
ORDER BY 
dbClassificationLanguage.Name




