CREATE PROCEDURE ContentEditGetClassifications (@Id int)
AS 
SELECT dbContentTypeClassification.ClassificationId intValue 
FROM dbContentTypeClassification
JOIN DbContent
	ON dbContentTypeClassification.ContentTypeId = DbContent.ContentTypeId
WHERE dbContentTypeClassification.StatusId <> 1
	AND dbContent.Id = @Id

