CREATE PROCEDURE [dbo].[UserProjectSelectBasedOnUser] (@Id int, @LanguageId int) 
AS  
SELECT  
dbUserProject.ProjectId Id
, ISNULL(dbProjectLanguage.Name,'') Name 
FROM dbUserProject
JOIN dbProject
	ON dbUserProject.ProjectId = dbProject.Id
JOIN dbProjectLanguage
	ON dbProject.Id = dbProjectLanguage.ProjectId
WHERE dbUserProject.Id  = @Id
	AND dbProjectLanguage.LanguageId = @LanguageId
ORDER BY dbProjectLanguage.Name
