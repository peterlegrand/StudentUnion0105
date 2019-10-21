CREATE PROCEDURE OrganizationTypeLanguageIndexSelect (@Id int)
AS 
SELECT dbOrganizationTypeLanguage.Id
	, dbOrganizationType.Id
	, dbLanguage.LanguageName
	, dbOrganizationTypeLanguage.Name
	, dbOrganizationTypeLanguage.MouseOver
	, dbOrganizationTypeLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbOrganizationType.CreatedDate
	, dbOrganizationType.ModifiedDate
FROM dbOrganizationType
JOIN dbOrganizationTypeLanguage
	ON dbOrganizationType.Id = dbOrganizationTypeLanguage.OrganizationTypeId
JOIN dbLanguage
	ON dbLanguage.Id = dbOrganizationTypeLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbOrganizationType.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbOrganizationType.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbOrganizationTypeLanguage.OrganizationTypeId = @Id
ORDER BY 
dbOrganizationTypeLanguage.Name




