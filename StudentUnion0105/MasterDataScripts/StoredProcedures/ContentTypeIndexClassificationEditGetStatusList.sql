CREATE PROCEDURE ContentTypeIndexClassificationEditGetStatusList (@LanguageId int)
AS
SELECT 
	dbContentTypeClassificationStatusLanguage.Id
	, dbContentTypeClassificationStatusLanguage.Name
FROM dbContentTypeClassificationStatus
JOIN dbContentTypeClassificationStatusLanguage
	ON dbContentTypeClassificationStatus.Id = dbContentTypeClassificationStatusLanguage.ContentTypeClassificationStatusId
WHERE dbContentTypeClassificationStatusLanguage.LanguageId = @LanguageId
ORDER BY dbContentTypeClassificationStatusLanguage.Name