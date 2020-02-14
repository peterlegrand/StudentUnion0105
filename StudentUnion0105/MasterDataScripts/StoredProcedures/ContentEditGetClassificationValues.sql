CREATE PROCEDURE ContentEditGetClassificationValues (@Id int)
AS
SELECT 
	ISNULL(ClassificationValues.ClassificationValueId,0) ValueId
	, dbContentTypeClassification.ClassificationId
FROM DbContent
JOIN dbContentTypeClassification
	ON DbContent.ContentTypeId = dbContentTypeClassification.ContentTypeId
LEFT JOIN (
	SELECT DbContentClassificationValue.ContentId
		, DbContentClassificationValue.ClassificationValueId
		, DbClassificationValue.ClassificationId
		, DbContentClassificationValue.Id
	FROM DbContentClassificationValue 
	JOIN DbClassificationValue 
		ON DbContentClassificationValue.ClassificationValueId = DbClassificationValue.Id 
		) ClassificationValues
	ON DbContent.Id = ClassificationValues.ContentId
	AND ClassificationValues.ClassificationId = dbContentTypeClassification.ClassificationId
WHERE DbContent.Id = @Id
