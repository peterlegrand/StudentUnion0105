CREATE PROCEDURE [dbo].[UserOrganizationTypeSelectLanguage] (@Id int)
AS
SELECT *
FROM dbUserOrganizationTypeLanguage
WHERE dbUserOrganizationTypeLanguage.TypeId = @Id
