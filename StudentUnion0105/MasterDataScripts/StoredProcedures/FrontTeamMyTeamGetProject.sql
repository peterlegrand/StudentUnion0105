CREATE PROCEDURE FrontTeamMyTeamGetProject (@CurrentUserId nvarchar(50))
AS
SELECT
	DbProjectLanguage.ProjectId Id
	, DbProjectLanguage.Name Projectame
	, DbUserProjectTypeLanguage.Name UserProjectTypeName
FROM dbUserProject
JOIN DbProjectLanguage
	ON dbUserProject.ProjectId = DbProjectLanguage.ProjectId
JOIN DbUserProjectTypeLanguage
	ON DbUserProjectTypeLanguage.TypeId = DbUserProject.TypeId
JOIN AspNetUsers
	ON AspNetUsers.Id = DbUserProject.UserId
	AND AspNetUsers.DefaultLanguageId = DbProjectLanguage.LanguageId
	AND AspNetUsers.DefaultLanguageId = DbUserProjectTypeLanguage.LanguageId
