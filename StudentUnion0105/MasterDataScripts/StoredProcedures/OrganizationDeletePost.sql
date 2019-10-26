CREATE PROCEDURE OrganizationDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbOrganizationLanguage 
WHERE dbOrganizationLanguage.OrganizationId = @Id;

DELETE FROM dbOrganization
WHERE dbOrganization.Id = @Id
COMMIT TRANSACTION