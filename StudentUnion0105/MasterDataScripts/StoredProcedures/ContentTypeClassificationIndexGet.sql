CREATE PROCEDURE ContentTypeClassificationIndexGet (@LanguageId int, @Id int)
AS
SELECT 
	dbContentTypeClassification.Id
	, dbContentTypeClassification.ContentTypeId
	, dbContentTypeClassification.ClassificationId
	, ISNULL(dbContentTypeClassificationStatusLanguage.Name,'') StatusName
	, ISNULL(DbClassificationLanguage.Name, '') ClassificationName
FROM dbContentTypeClassification 
JOIN DbClassificationLanguage
	ON DbClassificationLanguage.ClassificationId = dbContentTypeClassification.ClassificationId
JOIN dbContentTypeClassificationStatusLanguage
	ON dbContentTypeClassification.StatusId = dbContentTypeClassificationStatusLanguage.ContentTypeClassificationStatusId 
WHERE dbContentTypeClassification.ContentTypeId = @Id
	AND DbClassificationLanguage.LanguageId = @LanguageId
	AND dbContentTypeClassificationStatusLanguage.LanguageId = @LanguageId
ORDER BY DbClassificationLanguage.Name
