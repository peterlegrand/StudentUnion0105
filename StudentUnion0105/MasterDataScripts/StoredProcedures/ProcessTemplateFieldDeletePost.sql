CREATE PROCEDURE ProcessTemplateFieldDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateFieldLanguage 
WHERE dbProcessTemplateFieldLanguage.ProcessTemplateFieldId = @Id;

DELETE FROM dbProcessTemplateField
WHERE dbProcessTemplateField.Id = @Id
COMMIT TRANSACTION