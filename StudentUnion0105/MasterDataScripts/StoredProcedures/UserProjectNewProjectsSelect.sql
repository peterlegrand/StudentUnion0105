CREATE PROCEDURE [dbo].[UserProjectNewProjectsSelect] (@UserId varchar(450), @LanguageId int) 
AS  
SELECT dbProject.Id , dbProjectLanguage.Name
FROM dbProject 
JOIN dbProjectLanguage
	ON dbProject.Id = dbProjectLanguage.ProjectId
WHERE dbProject.Id NOT IN (SELECT ProjectId FROM dbUserProject WHERE UserId = @UserId)
	AND dbProject.ProjectStatusId = 1
	AND dbProjectLanguage.LanguageId = @LanguageId
ORDER BY dbProjectLanguage.Name