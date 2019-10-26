CREATE PROCEDURE ProcessTemplateGroupDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProcessTemplateGroupLanguage 
WHERE dbProcessTemplateGroupLanguage.ProcessTemplateGroupId = @Id;

DELETE FROM dbProcessTemplateGroup
WHERE dbProcessTemplateGroup.Id = @Id
COMMIT TRANSACTION