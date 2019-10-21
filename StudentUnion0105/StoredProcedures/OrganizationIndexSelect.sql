CREATE PROCEDURE OrganizationIndexSelect (@LanguageId int)
AS 
SELECT dbOrganization.Id
	, dbOrganizationLanguage.LanguageId
	, dbOrganization.ParentOrganizationId
	, dbOrganizationLanguage.Name
	, dbOrganizationLanguage.MouseOver
	, dbOrganizationLanguage.MenuName
	, dbOrganizationTypeLanguage.Name Type
	, dbOrganizationStatus.Name Status
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbOrganization.CreatedDate
	, dbOrganization.ModifiedDate
FROM dbOrganization
JOIN dbOrganizationLanguage
	ON dbOrganization.Id = dbOrganizationLanguage.OrganizationId
JOIN dbOrganizationTypeLanguage 
	ON dbOrganization.OrganizationTypeId = dbOrganizationTypeLanguage.OrganizationTypeId
JOIN dbOrganizationStatus
	ON dbOrganization.OrganizationStatusId = dbOrganizationStatus.Id
JOIN AspNetUsers Creator
	ON CAST( dbOrganization.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbOrganization.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbOrganizationLanguage.LanguageId = @LanguageId
ORDER BY 
dbOrganizationLanguage.Name


