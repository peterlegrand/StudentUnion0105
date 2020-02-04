CREATE PROCEDURE ContentEditPostDeleteValue (@Id int)
AS
DELETE FROM  DbContentClassificationValue WHERE DbContentClassificationValue.Id = @Id