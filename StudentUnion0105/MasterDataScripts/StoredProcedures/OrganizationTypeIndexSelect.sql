CREATE PROCEDURE OrganizationTypeIndexSelect (@LanguageId int)
AS 
SELECT dbOrganizationType.Id
	, dbOrganizationTypeLanguage.LanguageId
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
JOIN AspNetUsers Creator
	ON CAST( dbOrganizationType.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbOrganizationType.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbOrganizationTypeLanguage.LanguageId = @LanguageId
ORDER BY 
dbOrganizationTypeLanguage.Name


