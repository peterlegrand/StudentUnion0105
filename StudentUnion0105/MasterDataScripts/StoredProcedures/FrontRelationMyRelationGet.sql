CREATE PROCEDURE FrontRelationMyRelationGet (@CurrentUserId nvarchar(50))
AS
SELECT
	dbUserRelation.Id
	, Relation.UserName
	, DbUserRelationTypeLanguage.FromIsOfToName RelationName
FROM dbUserRelation
JOIN AspNetUsers Relation
	ON dbUserRelation.ToUserId = Relation.Id 
JOIN DbUserRelationTypeLanguage
	ON DbUserRelationTypeLanguage.TypeId = DbUserRelation.TypeId
JOIN AspNetUsers CurrentUser
	ON CurrentUser.Id = DbUserRelation.FromUserId
	AND CurrentUser.DefaultLanguageId = DbUserRelationTypeLanguage.LanguageId
	AND CurrentUser.Id = @CurrentUserId
UNION ALL

SELECT
	dbUserRelation.Id
	, Relation.UserName
	, DbUserRelationTypeLanguage.ToIsOfFromName RelationName
FROM dbUserRelation
JOIN AspNetUsers Relation
	ON dbUserRelation.FromUserId = Relation.Id 
JOIN DbUserRelationTypeLanguage
	ON DbUserRelationTypeLanguage.TypeId = DbUserRelation.TypeId
JOIN AspNetUsers CurrentUser
	ON CurrentUser.Id = DbUserRelation.ToUserId
	AND CurrentUser.DefaultLanguageId = DbUserRelationTypeLanguage.LanguageId
	AND CurrentUser.Id = @CurrentUserId
