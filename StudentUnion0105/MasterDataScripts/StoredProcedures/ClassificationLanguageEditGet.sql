CREATE PROCEDURE ClassificationLanguageEditGet (@LId int)
AS
SELECT
	dbClassification.Id OId
	, Creator.UserName Creator
	, dbClassificationLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationLanguage.ModifiedDate
	, dbClassificationLanguage.Id LId
	, ISNULL(dbClassificationLanguage.Name,'') Name
	, ISNULL(dbClassificationLanguage.Description,'') Description
	, ISNULL(dbClassificationLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbClassificationLanguage
JOIN dbClassification
	ON dbClassification.Id = dbClassificationLanguage.ClassificationId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassification.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassification.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbClassificationLanguage.Id=@LId

