CREATE PROCEDURE ClassificationEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbClassification.Id 
	, dbClassification.ClassificationStatusId
	, dbClassification.DefaultClassificationPageId
	, dbClassification.HasDropDown
	, dbClassification.DropDownSequence
	, Creator.UserName Creator
	, dbClassification.CreatedDate
	, Modifier.UserName Modifier
	, dbClassification.ModifiedDate
	, dbClassificationLanguage.Id LId
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
FROM dbClassificationLanguage
JOIN dbClassification 
	ON dbClassificationLanguage.ClassificationId = dbClassification.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassification.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassification.CreatorId) = Modifier.Id
WHERE dbClassificationLanguage.LanguageId = @LanguageId
	AND dbClassification.Id = @Id


