CREATE PROCEDURE ClassificationLevelLanguageIndexSelect (@Id int)
AS 
SELECT dbClassificationLevelLanguage.Id
	, dbClassificationLevel.Id
	, dbLanguage.LanguageName
	, dbClassificationLevelLanguage.Name
	, dbClassificationLevelLanguage.MouseOver
	, dbClassificationLevelLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbClassificationLevel.CreatedDate
	, dbClassificationLevel.ModifiedDate
FROM dbClassificationLevel
JOIN dbClassificationLevelLanguage
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLevelLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbClassificationLevel.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbClassificationLevel.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbClassificationLevelLanguage.ClassificationLevelId = @Id
ORDER BY 
dbClassificationLevelLanguage.Name




