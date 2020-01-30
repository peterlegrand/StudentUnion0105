CREATE PROCEDURE OrganizatonCreateGetStatusList
AS
SELECT Id, Name Text FROM DbOrganizationStatus
ORDER BY Name