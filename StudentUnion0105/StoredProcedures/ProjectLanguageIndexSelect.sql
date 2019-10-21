CREATE PROCEDURE ProjectLanguageIndexSelect (@Id int)
AS 
SELECT dbProjectLanguage.Id
	, dbProject.Id
	, dbLanguage.LanguageName
	, dbProjectLanguage.Name
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbProjectLanguage.CreatedDate
	, dbProjectLanguage.ModifiedDate
FROM dbProject
JOIN dbProjectLanguage
	ON dbProject.Id = dbProjectLanguage.ProjectId
JOIN dbLanguage
	ON dbLanguage.Id = dbProjectLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbProjectLanguage.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbProjectLanguage.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbProjectLanguage.ProjectId = @Id
ORDER BY 
dbProjectLanguage.Name




