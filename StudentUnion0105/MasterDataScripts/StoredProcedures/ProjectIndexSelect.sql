CREATE PROCEDURE ProjectIndexSelect (@LanguageId int)
AS 
SELECT dbProject.Id
	, dbProjectLanguage.LanguageId
	, dbProject.ParentProjectId
	, dbProjectLanguage.Name
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
	, dbProjectStatus.Name Status
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProject.CreatedDate
	, dbProject.ModifiedDate
FROM dbProject
JOIN dbProjectLanguage
	ON dbProject.Id = dbProjectLanguage.ProjectId
JOIN dbProjectStatus
	ON dbProject.ProjectStatusId = dbProjectStatus.Id
JOIN AspNetUsers Creator
	ON CAST( dbProject.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProject.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProjectLanguage.LanguageId = @LanguageId
ORDER BY 
dbProjectLanguage.Name


