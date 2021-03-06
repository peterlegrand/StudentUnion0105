CREATE PROCEDURE UserRelationSelectAll (@User varchar(450), @LanguageId int) 
AS  
BEGIN
SELECT * FROM (
SELECT  
AspNetUsers.Id  Id
, ISNULL(DbUserRelationTypeLanguage.FromIsOfToName,'') Name 
, ISNULL(DbUserRelationTypeLanguage.FromIsOfToDescription,'') Description 
, ISNULL(DbUserRelationTypeLanguage.FromIsOfToMouseOver,'') MouseOver 
, ISNULL(DbUserRelationTypeLanguage.FromIsOfToMenuName,'') MenuName 
, AspNetUsers.UserName
, AspNetUsers.Email
FROM DbUserRelation
JOIN AspNetUsers
	ON DbUserRelation.ToUserId = AspNetUsers.Id
JOIN DbUserRelationTypeLanguage
	ON DbUserRelation.TypeId = DbUserRelationTypeLanguage.TypeId
WHERE DbUserRelation.FromUserId = @User
	AND DbUserRelationTypeLanguage.LanguageId = @LanguageId


UNION ALL

SELECT  
AspNetUsers.Id  Id
, ISNULL(DbUserRelationTypeLanguage.ToIsOfFromName,'') Name 
, ISNULL(DbUserRelationTypeLanguage.ToIsOfFromDescription,'') Description 
, ISNULL(DbUserRelationTypeLanguage.ToIsOfFromMouseOver,'') MouseOver 
, ISNULL(DbUserRelationTypeLanguage.ToIsOfFromMenuName,'') MenuName 
, AspNetUsers.UserName
, AspNetUsers.Email
FROM DbUserRelation
JOIN AspNetUsers
	ON DbUserRelation.FromUserId = AspNetUsers.Id
JOIN DbUserRelationTypeLanguage
	ON DbUserRelation.TypeId = DbUserRelationTypeLanguage.TypeId
WHERE DbUserRelation.ToUserId = @User
	AND DbUserRelationTypeLanguage.LanguageId = @LanguageId
	) AS AllRelations
ORDER BY Name
END
