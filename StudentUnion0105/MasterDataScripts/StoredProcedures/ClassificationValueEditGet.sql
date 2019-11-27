CREATE PROCEDURE ClassificationValueEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbClassificationValue.Id  OId
	, dbClassificationValue.ClassificationId  PId
	, dbClassificationValue.ParentValueId ParentId
	, ISNULL(dbClassificationValue.DateFrom, '1900-01-01') FromDate
	, ISNULL(dbClassificationValue.DateTo, '1900-01-01') ToDate
	, ISNULL(dbClassificationValue.ParentValueId, 0) ParentValueId
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
	, 0 "DateLevel"
	, CAST(0 as bit) "InDropDown"
FROM dbClassificationValueLanguage
JOIN dbClassificationValue 
	ON dbClassificationValueLanguage.ClassificationValueId = dbClassificationValue.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassificationValue.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassificationValue.ModifierId) = Modifier.Id
WHERE dbClassificationValueLanguage.LanguageId = @LanguageId
	AND dbClassificationValue.Id = @Id


