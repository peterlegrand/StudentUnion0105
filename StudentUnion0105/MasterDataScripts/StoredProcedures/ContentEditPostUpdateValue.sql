CREATE PROCEDURE ContentEditPostUpdateValue (@Id int, @ValueId int)
AS
UPDATE DbContentClassificationValue SET DbContentClassificationValue.ClassificationValueId = @ValueId
WHERE DbContentClassificationValue.Id = @Id