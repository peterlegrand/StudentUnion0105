CREATE PROCEDURE ProcessTemplateFieldTypeDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateFieldTypeLanguage 
WHERE dbProcessTemplateFieldTypeLanguage.FieldTypeId = @Id;

DELETE FROM dbProcessTemplateFieldType
WHERE dbProcessTemplateFieldType.Id = @Id
COMMIT TRANSACTION