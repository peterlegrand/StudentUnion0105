CREATE PROCEDURE ClassificationSelectOne (@Id int, @LanguageId int)
AS
SELECT 
	dbClassification.Id
	, dbClassificationLanguage.LanguageId
	, 0 ParentId
	, dbClassificationLanguage.Name
	, dbClassificationLanguage.Description
	, dbClassificationLanguage.MouseOver
	, dbClassificationLanguage.MenuName
	, dbClassificationStatus.Name Status
	, dbClassification.DropDownSequence Int1
	, 0 Int2
	, dbClassification.HasDropDown Bool1
	, CAST(1 as bit) Bool2
	, 0 IntNull1
	, 0 IntNull2
	, Creator.UserName Creator
	, Modifier.UserName Modifier
FROM dbClassification
JOIN dbClassificationLanguage
	ON dbClassification.Id = dbClassificationLanguage.ClassificationId
JOIN dbLanguage
	ON dbClassificationLanguage.LanguageId = dbLanguage.Id
JOIN dbClassificationStatus
	ON dbClassificationStatus.Id = dbClassification.ClassificationStatusId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbClassification.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbClassification.CreatorId) = Modifier.Id
WHERE dbClassification.Id = @Id AND dbClassificationLanguage.LanguageId = @LanguageId
