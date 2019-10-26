CREATE PROCEDURE OrganizationTypeLanguageDeletePost (@Id int)
AS
DELETE FROM dbOrganizationTypeLanguage 
WHERE dbOrganizationTypeLanguage.Id = @Id;
