CREATE PROCEDURE [dbo].[UserProjectSelectAll] (@User varchar(450), @LanguageId int) 
AS  
SELECT  
dbUserProject.ProjectId Id
, ISNULL(dbProjectLanguage.Name,'') Name 
, ISNULL(dbUserProjectTypeLanguage.Name,'') Description
FROM dbUserProject
JOIN dbProject
	ON dbUserProject.ProjectId = dbProject.Id
JOIN dbProjectLanguage
	ON dbProject.Id = dbProjectLanguage.ProjectId
JOIN dbUserProjectTypeLanguage
	ON dbUserProject.TypeId = dbUserProjectTypeLanguage.TypeId
WHERE dbUserProject.UserId = @User
	AND dbProjectLanguage.LanguageId = @LanguageId
	AND dbUserProjectTypeLanguage.LanguageId = @LanguageId
ORDER BY dbProjectLanguage.Name



