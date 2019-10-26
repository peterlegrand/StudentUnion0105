CREATE PROCEDURE ClassificationValueLanguageEditGet (@Id int)
AS
SELECT
	dbClassificationValue.Id 
	, Creator.UserName Creator
	, dbClassificationValueLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationValueLanguage.ModifiedDate
	, dbClassificationValueLanguage.Id LId
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.Description
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
FROM dbClassificationValueLanguage
JOIN dbClassificationValue
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationValue.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationValue.ModifierId) = Modifier.Id
WHERE dbClassificationValueLanguage.Id=@Id

