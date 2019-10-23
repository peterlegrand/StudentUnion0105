CREATE PROCEDURE ClassificationLevelIndexSelect (@LanguageId int)
AS 
SELECT dbClassificationLevel.Id
	, dbClassificationLevelLanguage.LanguageId
	, dbClassificationLevel.ClassificationId
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
JOIN AspNetUsers Creator
	ON CAST( dbClassificationLevel.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbClassificationLevel.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbClassificationLevelLanguage.LanguageId = @LanguageId
ORDER BY 
dbClassificationLevelLanguage.Name