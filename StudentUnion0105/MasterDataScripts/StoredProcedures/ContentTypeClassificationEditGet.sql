CREATE PROCEDURE ContentTypeClassificationEditGet (@LanguageId int, @Id int)
AS
SELECT 
	 dbContentTypeClassification.Id
	, dbContentTypeClassification.ContentTypeId
	, dbContentTypeClassification.ClassificationId
	, dbContentTypeClassification.StatusId
	, ISNULL(DbClassificationLanguage.Name, '') ClassificationName
FROM dbContentTypeClassification 
JOIN DbClassificationLanguage
	ON DbClassificationLanguage.ClassificationId = dbContentTypeClassification.ClassificationId
JOIN dbContentTypeClassificationStatusLanguage
	ON dbContentTypeClassification.StatusId = dbContentTypeClassificationStatusLanguage.ContentTypeClassificationStatusId 
WHERE dbContentTypeClassification.Id = @Id
	AND DbClassificationLanguage.LanguageId = @LanguageId
	AND dbContentTypeClassificationStatusLanguage.LanguageId = @LanguageId
ORDER BY DbClassificationLanguage.Name
