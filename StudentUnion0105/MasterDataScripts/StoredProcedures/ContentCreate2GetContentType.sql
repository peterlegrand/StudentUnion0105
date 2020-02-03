CREATE PROCEDURE ContentCreate2GetContentType (@CurrentUser nvarchar(50), @Id int)
AS
DECLARE @SecurityLevel int;
DECLARE @LanguageId int;
SELECT @LanguageId = AspNetUsers.DefaultLanguageId , @SecurityLevel = SecurityLevel FROM AspNetUsers WHERE Id = @CurrentUser;

SELECT 
	DbContentTypeLanguage.ContentTypeId
	, DbClassificationLanguage.Name 
	, dbContentTypeClassification.ClassificationId
	, dbContentTypeClassification.StatusId
FROM DbContentType
JOIN DbContentTypeLanguage
	ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId
JOIN dbContentTypeClassification
	ON DbContentTypeLanguage.ContentTypeId =  dbContentTypeClassification.ContentTypeId
JOIN DbClassificationLanguage
	ON DbClassificationLanguage.ClassificationId = dbContentTypeClassification.ClassificationId
WHERE dbContentTypeClassification.StatusId <> 1
	AND DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentTypeLanguage.LanguageId = @LanguageId
	AND DbContentType.Id = @Id

	