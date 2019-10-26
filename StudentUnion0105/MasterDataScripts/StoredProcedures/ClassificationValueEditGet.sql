CREATE PROCEDURE ClassificationValueEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbClassificationValue.Id 
	, dbClassificationValue.ClassificationId
	, dbClassificationValue.DateFrom
	, dbClassificationValue.DateTo
	, dbClassificationValue.ParentValueId
	, Creator.UserName Creator
	, dbClassificationValue.CreatedDate
	, Modifier.UserName Modifier
	, dbClassificationValue.ModifiedDate
	, dbClassificationValueLanguage.Id LId
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.Description
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
	, dbClassificationValueLanguage.DropDownName
	, dbClassificationValueLanguage.HeaderName
	, dbClassificationValueLanguage.HeaderDescription
	, dbClassificationValueLanguage.PageName
	, dbClassificationValueLanguage.PageDescription
	, dbClassificationValueLanguage.TopicName
FROM dbClassificationValueLanguage
JOIN dbClassificationValue 
	ON dbClassificationValueLanguage.ClassificationValueId = dbClassificationValue.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationValue.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationValue.ModifierId) = Modifier.Id
WHERE dbClassificationValueLanguage.LanguageId = @LanguageId
	AND dbClassificationValue.Id = @Id


