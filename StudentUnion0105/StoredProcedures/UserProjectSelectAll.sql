CREATE PROCEDURE [dbo].[UserProjectSelectAll] (@User varchar(450), @LanguageId int) 
AS  
SELECT  
dbUserProject.ProjectId 
, ISNULL(dbProjectLanguage.Name,'') Name 
FROM dbUserProject
JOIN dbProject
	ON dbUserProject.ProjectId = dbProject.Id
JOIN dbProjectLanguage
	ON dbProject.Id = dbProjectLanguage.ProjectId
WHERE dbUserProject.UserId = @User
	AND dbProjectLanguage.LanguageId = @LanguageId
ORDER BY dbProjectLanguage.Name
