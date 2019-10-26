CREATE PROCEDURE ProjectDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbProjectLanguage 
WHERE dbProjectLanguage.ProjectId = @Id;

DELETE FROM dbProject
WHERE dbProject.Id = @Id
COMMIT TRANSACTION