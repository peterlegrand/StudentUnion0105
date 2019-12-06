CREATE PROCEDURE ProjectLanguageEditGet (@LId int)
AS
SELECT
	dbProject.Id OId
	, Creator.UserName Creator
	, dbProjectLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbProjectLanguage.ModifiedDate
	, dbProjectLanguage.Id LId
	, ISNULL(dbProjectLanguage.Name,'') Name
	, ISNULL(dbProjectLanguage.Description,'') Description
	, ISNULL(dbProjectLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProjectLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, ISNULL(dbProject.ParentProjectId, 0) PId
FROM dbProjectLanguage
JOIN dbProject
	ON dbProject.Id = dbProjectLanguage.ProjectId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProjectLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProjectLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbProjectLanguage.LanguageId
WHERE dbProjectLanguage.Id=@LId

