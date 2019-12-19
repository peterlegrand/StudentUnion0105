CREATE PROCEDURE UserProjectTypeLanguageEditGet (@LId int)
AS
SELECT
	dbUserProjectType.Id OId
	, Creator.UserName Creator
	, dbUserProjectTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbUserProjectTypeLanguage.ModifiedDate
	, dbUserProjectTypeLanguage.Id LId
	, ISNULL(dbUserProjectTypeLanguage.Name,'') Name
	, ISNULL(dbUserProjectTypeLanguage.Description,'') Description
	, ISNULL(dbUserProjectTypeLanguage.MouseOver,'') MouseOver
	, ISNULL(dbUserProjectTypeLanguage.MenuName,'') MenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbUserProjectTypeLanguage
JOIN dbUserProjectType
	ON dbUserProjectType.Id = dbUserProjectTypeLanguage.TypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbUserProjectTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbUserProjectTypeLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbUserProjectTypeLanguage.LanguageId
WHERE dbUserProjectTypeLanguage.Id=@LId

