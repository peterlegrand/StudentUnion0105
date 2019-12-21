CREATE PROCEDURE UserRelationTypeLanguageDeleteGet (@LanguageId int, @Id int)
AS
SELECT
	dbUserRelationTypeLanguage.Id LId
	, dbUserRelationTypeLanguage.FromIsOfToName
	, dbUserRelationTypeLanguage.ToIsOfFromName
	, dbUserRelationTypeLanguage.FromIsOfToDescription
	, dbUserRelationTypeLanguage.ToIsOfFromDescription
	, dbUserRelationTypeLanguage.FromIsOfToMouseOver
	, dbUserRelationTypeLanguage.ToIsOfFromMouseOver
	, dbUserRelationTypeLanguage.FromIsOfToMenuName
	, dbUserRelationTypeLanguage.ToIsOfFromMenuName
	, DbLanguage.LanguageName Language
	, Creator.UserName Creator
	, dbUserRelationTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbUserRelationTypeLanguage.ModifiedDate
FROM dbUserRelationTypeLanguage
JOIN DbLanguage
	ON DbLanguage.Id = DbUserRelationTypeLanguage.LanguageId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbUserRelationTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbUserRelationTypeLanguage.ModifierId) = Modifier.Id
WHERE dbUserRelationTypeLanguage.LanguageId = @LanguageId
	AND dbUserRelationTypeLanguage.TypeId = @Id

