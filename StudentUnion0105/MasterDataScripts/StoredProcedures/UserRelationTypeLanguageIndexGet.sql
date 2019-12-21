CREATE PROCEDURE UserRelationTypeLanguageIndexGet (@OId int)
AS
SELECT 
	dbUserRelationTypeLanguage.Id LId
	, dbUserRelationTypeLanguage.TypeId OId
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToName,'') FromIsOfToName
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromName,'') ToIsOfFromName
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToDescription,'') FromIsOfToDescription
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromDescription,'') ToIsOfFromDescription
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToMouseOver,'') FromIsOfToMouseOver
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromMouseOver,'') ToIsOfFromMouseOver
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToMenuName,'') FromIsOfToMenuName
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromMenuName,'') ToIsOfFromMenuName
	, dbLanguage.Id LanguageId
	, ISNULL(dbLanguage.LanguageName,'') LanguageName
FROM dbUserRelationTypeLanguage
JOIN dbLanguage 
	ON dbUserRelationTypeLanguage.LanguageId = dbLanguage.Id
WHERE dbUserRelationTypeLanguage.TypeId = @OId
ORDER BY dbLanguage.LanguageName
