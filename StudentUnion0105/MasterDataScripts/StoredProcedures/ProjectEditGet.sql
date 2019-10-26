CREATE PROCEDURE ProjectEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProject.Id 
	, dbProject.ProjectStatusId
	, dbProject.ParentProjectId
	, Creator.UserName Creator
	, dbProject.CreatedDate
	, Modifier.UserName Modifier
	, dbProject.ModifiedDate
	, dbProjectLanguage.Id LId
	, dbProjectLanguage.Name
	, dbProjectLanguage.Description
	, dbProjectLanguage.MouseOver
	, dbProjectLanguage.MenuName
FROM dbProjectLanguage
JOIN dbProject 
	ON dbProjectLanguage.ProjectId = dbProject.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProject.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProject.ModifierId) = Modifier.Id
WHERE dbProjectLanguage.LanguageId = @LanguageId
	AND dbProject.Id = @Id

