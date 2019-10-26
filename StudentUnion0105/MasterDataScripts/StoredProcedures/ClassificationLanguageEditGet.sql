CREATE PROCEDURE ClassificationLanguageEditGet (@Id int)
AS
SELECT
	dbClassification.Id 
	, Creator.UserName Creator
	, dbClassificationLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationLanguage.ModifiedDate
	, dbClassificationLanguage.Id LId
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
FROM dbClassificationLanguage
JOIN dbClassification
	ON dbClassification.Id = dbClassificationLanguage.ClassificationId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassification.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassification.ModifierId) = Modifier.Id
WHERE dbClassificationLanguage.Id=@Id

