CREATE PROCEDURE OrganizationLanguageIndexSelect (@Id int)
AS 
SELECT dbOrganizationLanguage.Id
	, dbOrganization.Id
	, dbLanguage.LanguageName
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbOrganization.CreatedDate
	, dbOrganization.ModifiedDate
FROM dbOrganization
JOIN dbOrganizationLanguage
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
JOIN dbLanguage
	ON dbLanguage.Id = dbOrganizationLanguage.LanguageId
JOIN AspNetUsers Creator
	ON CAST( dbOrganization.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbOrganization.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbOrganizationLanguage.OrganizationId = @Id
ORDER BY 
dbOrganizationLanguage.Name




