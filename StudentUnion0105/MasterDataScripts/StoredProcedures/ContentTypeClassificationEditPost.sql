CREATE PROCEDURE ContentTypeClassificationEditPost (@Id int, @StatusId int)
AS
UPDATE dbContentTypeClassification 
SET dbContentTypeClassification.StatusId = @StatusId 
WHERE dbContentTypeClassification.Id = @Id