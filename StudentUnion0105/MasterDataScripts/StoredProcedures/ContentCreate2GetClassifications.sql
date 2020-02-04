CREATE PROCEDURE ContentCreate2GetClassifications (@Id int, @CurrentUser nvarchar(50))
AS 
SELECT dbContentTypeClassification.ClassificationId intValue 
FROM dbContentTypeClassification
JOIN DbContentType
	ON dbContentTypeClassification.ContentTypeId = DbContentType.Id
JOIN AspNetUsers
	ON AspNetUsers.SecurityLevel >= DbContentType.SecurityLevel
WHERE dbContentTypeClassification.StatusId <> 1
	AND dbContentTypeClassification.ContentTypeId = @Id
	AND AspNetUsers.Id = @CurrentUser


