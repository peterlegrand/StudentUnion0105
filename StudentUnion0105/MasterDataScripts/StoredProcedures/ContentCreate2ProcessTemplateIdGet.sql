CREATE PROCEDURE ContentCreate2ProcessTemplateIdGet (@Id int)
AS
SELECT DbContentType.ProcessTemplateId IntValue
FROM DbContentType 
WHERE DbContentType.Id = @Id