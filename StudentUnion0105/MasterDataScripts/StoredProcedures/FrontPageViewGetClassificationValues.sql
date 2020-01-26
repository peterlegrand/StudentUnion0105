CREATE PROCEDURE FrontPageViewGetClassificationValues (	@Id int
	, @CurrentUser nvarchar(50))
AS
DECLARE @SecurityLevel int;
DECLARE @LanguageID int;
SELECT @SecurityLevel = SecurityLevel, @LanguageId = DefaultLanguageId FROM AspNetUsers WHERE Id = @CurrentUser
SELECT 
	DbClassificationValueLanguage.ClassificationValueId  Id
	, DbClassificationValueLanguage.Name ValueName
	, DbClassificationLanguage.Name ClassificationName
FROM DbContentClassificationValue
JOIN DbContent 
	ON DbContent.Id = DbContentClassificationValue.ContentId
JOIN DbClassificationValueLanguage
	ON DbContentClassificationValue.ClassificationValueId = DbClassificationValueLanguage.ClassificationValueId
JOIN DbClassificationValue
	ON DbClassificationValueLanguage.ClassificationValueId = DbClassificationValue.Id
JOIN DbClassificationLanguage
	ON DbClassificationLanguage.ClassificationId = DbClassificationValue.ClassificationId
WHERE DbClassificationValueLanguage.LanguageId = @LanguageId
	AND DbContentClassificationValue.Id = @Id
	AND DbContent.SecurityLevel <= @SecurityLevel