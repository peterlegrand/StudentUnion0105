CREATE PROCEDURE ClassificationValueLanguageEditGet (@LId int)
AS
SELECT
	dbClassificationValue.Id  OId
	, Creator.UserName Creator
	, dbClassificationValueLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationValueLanguage.ModifiedDate
	, dbClassificationValueLanguage.Id LId
	, ISNULL(dbClassificationValueLanguage.Name,'') Name
	, ISNULL(dbClassificationValueLanguage.Description,'') Description
	, ISNULL(dbClassificationValueLanguage.MouseOver,'') MouseOver
	, ISNULL(dbClassificationValueLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, dbClassificationValue.ParentValueId PId
FROM dbClassificationValueLanguage
JOIN dbClassificationValue
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationValue.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationValue.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbClassificationLanguage.LanguageId
WHERE dbClassificationValueLanguage.Id=@LId

