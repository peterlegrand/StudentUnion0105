CREATE PROCEDURE ClassificationLevelLanguageEditGet (@LId int)
AS
SELECT
	dbClassificationLevel.Id OId
	, Creator.UserName Creator
	, dbClassificationLevelLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationLevelLanguage.ModifiedDate
	, dbClassificationLevelLanguage.Id LId
	, ISNULL(dbClassificationLevelLanguage.Name,'') Name
	, ISNULL(dbClassificationLevelLanguage.Description,'') Description
	, ISNULL(dbClassificationLevelLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationLevelLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbClassificationLevel.ClassificationId PId
FROM dbClassificationLevelLanguage
JOIN dbClassificationLevel
	ON dbClassificationLevel.Id = dbClassificationLevelLanguage.ClassificationLevelId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationLevel.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationLevel.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLevelLanguage.LanguageId
WHERE dbClassificationLevelLanguage.Id=@LId

