CREATE PROCEDURE UserRelationTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbUserRelationTypeLanguage.TypeId OId
	, dbUserRelationTypeLanguage.FromIsOfToName
	, dbUserRelationTypeLanguage.ToIsOfFromName
	, dbUserRelationTypeLanguage.FromIsOfToDescription
	, dbUserRelationTypeLanguage.ToIsOfFromDescription
	, dbUserRelationTypeLanguage.FromIsOfToMouseOver
	, dbUserRelationTypeLanguage.ToIsOfFromMouseOver
	, dbUserRelationTypeLanguage.FromIsOfToMenuName
	, dbUserRelationTypeLanguage.ToIsOfFromMenuName
FROM dbUserRelationTypeLanguage
WHERE dbUserRelationTypeLanguage.LanguageId = @LanguageId
ORDER BY dbUserRelationTypeLanguage.FromIsOfToName