CREATE PROCEDURE ProcessTemplateDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateLanguage 
WHERE dbProcessTemplateLanguage.ProcessTemplateId = @Id;

DELETE FROM dbProcessTemplate
WHERE dbProcessTemplate.Id = @Id
COMMIT TRANSACTION