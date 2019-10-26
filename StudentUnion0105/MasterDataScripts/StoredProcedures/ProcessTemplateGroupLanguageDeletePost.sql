CREATE PROCEDURE faProcessTemplateGroupLanguageDeletePost (@Id int)
AS
DELETE FROM dbProcessTemplateGroupLanguage 
WHERE dbProcessTemplateGroupLanguage.Id = @Id;
