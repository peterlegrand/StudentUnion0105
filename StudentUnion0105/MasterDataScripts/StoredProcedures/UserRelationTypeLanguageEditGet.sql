CREATE PROCEDURE UserRelationTypeLanguageEditGet (@LId int)
AS
SELECT
	dbUserRelationType.Id OId
	, Creator.UserName Creator
	, dbUserRelationTypeLanguage.CreatedDate
	, Modifier.UserName Modifier
	, dbUserRelationTypeLanguage.ModifiedDate
	, dbUserRelationTypeLanguage.Id LId
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToName,'') FromIsOfToName
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromName,'') ToIsOfFromName
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToDescription,'') FromIsOfToDescription
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromDescription,'') ToIsOfFromDescription
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToMouseOver,'') FromIsOfToMouseOver
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromMouseOver,'') ToIsOfFromMouseOver
	, ISNULL(dbUserRelationTypeLanguage.FromIsOfToMenuName,'') FromIsOfToMenuName
	, ISNULL(dbUserRelationTypeLanguage.ToIsOfFromMenuName,'') ToIsOfFromMenuName
	, ISNULL(dbLanguage.LanguageName,'') Language
	, 0 PId
FROM dbUserRelationTypeLanguage
JOIN dbUserRelationType
	ON dbUserRelationType.Id = dbUserRelationTypeLanguage.TypeId
JOIN AspNetUsers Creator
	ON convert(nvarchar(50), dbUserRelationTypeLanguage.CreatorId) = Creator.Id
JOIN AspNetUsers Modifier
	ON convert(nvarchar(50), dbUserRelationTypeLanguage.ModifierId) = Modifier.Id
JOIN dbLanguage
	ON dbLanguage.Id = dbUserRelationTypeLanguage.LanguageId
WHERE dbUserRelationTypeLanguage.Id=@LId

