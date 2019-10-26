CREATE PROCEDURE ProjectLanguageEditGet (@Id int)
AS
SELECT
	dbProject.Id 
	, Creator.UserName Creator
	, dbProjectLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProjectLanguage.ModifiedDate
	, dbProjectLanguage.Id LId
	, dbProjectLanguage.Name
	, dbProjectLanguage.Description
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
FROM dbProjectLanguage
JOIN dbProject
	ON dbProject.Id = dbProjectLanguage.ProjectId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProjectLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProjectLanguage.ModifierId) = Modifier.Id
WHERE dbProjectLanguage.Id=@Id

