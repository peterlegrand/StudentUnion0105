CREATE PROCEDURE ClassificationLanguageEditGet (@Id int)
AS
SELECT
	dbClassification.Id OId
	, Creator.UserName Creator
	, dbClassificationLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationLanguage.ModifiedDate
	, dbClassificationLanguage.Id LId
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
	, dbLanguage.LanguageName Language
FROM dbClassificationLanguage
JOIN dbClassification
	ON dbClassification.Id = dbClassificationLanguage.ClassificationId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassification.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassification.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbClassificationLanguage.Id=@Id

