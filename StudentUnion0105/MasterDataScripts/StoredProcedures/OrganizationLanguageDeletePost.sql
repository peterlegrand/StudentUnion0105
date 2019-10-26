CREATE PROCEDURE OrganizationLanguageDeletePost (@Id int)
AS
DELETE FROM dbOrganizationLanguage 
WHERE dbOrganizationLanguage.Id = @Id;
