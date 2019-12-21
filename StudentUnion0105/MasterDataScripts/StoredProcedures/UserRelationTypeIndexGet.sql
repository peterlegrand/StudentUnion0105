CREATE PROCEDURE UserRelationTypeIndexGet (@LanguageId int)
AS
SELECT 
	dbUserRelationTypeLanguage.TypeId OId
	, dbUserRelationTypeLanguage.FromIsOfToName
	, dbUserRelationTypeLanguage.FromIsOfToDescription
	, dbUserRelationTypeLanguage.FromIsOfToMouseOver
	, dbUserRelationTypeLanguage.FromIsOfToMenuName
	, dbUserRelationTypeLanguage.ToIsOfFromName
	, dbUserRelationTypeLanguage.ToIsOfFromDescription
	, dbUserRelationTypeLanguage.ToIsOfFromMouseOver
	, dbUserRelationTypeLanguage.ToIsOfFromMenuName
FROM dbUserRelationTypeLanguage
WHERE dbUserRelationTypeLanguage.LanguageId = @LanguageId
ORDER BY dbUserRelationTypeLanguage.FromIsOfToName