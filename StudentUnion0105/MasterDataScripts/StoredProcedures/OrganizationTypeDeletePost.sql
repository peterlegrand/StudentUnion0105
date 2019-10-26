CREATE PROCEDURE OrganizationTypeDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbOrganizationTypeLanguage 
WHERE dbOrganizationTypeLanguage.OrganizationTypeId = @Id;

DELETE FROM dbOrganizationType
WHERE dbOrganizationType.Id = @Id
COMMIT TRANSACTION