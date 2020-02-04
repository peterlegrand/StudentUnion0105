CREATE PROCEDURE ContentEditPostInsertValue  (@Id int, @ValueId int)
AS
INSERT INTO DbContentClassificationValue (ContentId, ClassificationValueId) VALUES (
@Id, @ValueId)