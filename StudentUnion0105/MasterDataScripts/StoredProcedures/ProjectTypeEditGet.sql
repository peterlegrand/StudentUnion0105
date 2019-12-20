CREATE PROCEDURE ProjectTypeEditGet (@LanguageId int, @Id int)
AS
SELECT
	dbProjectType.Id 
	, Creator.UserName Creator
	, dbProjectType.CreatedDate
	, Modifier.UserName Modifier
	, dbProjectType.ModifiedDate
	, dbProjectTypeLanguage.Id LId
	, ISNULL(dbProjectTypeLanguage.Name,'') Name
	, ISNULL(dbProjectTypeLanguage.Description,'') Description
	, ISNULL(dbProjectTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbProjectTypeLanguage.MenuName,'') MenuName
FROM dbProjectTypeLanguage
JOIN dbProjectType
	ON dbProjectTypeLanguage.ProjectTypeId = dbProjectType.Id
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbProjectType.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbProjectType.ModifierId) = Modifier.Id
WHERE dbProjectTypeLanguage.LanguageId = @LanguageId
	AND dbProjectType.Id = @Id

