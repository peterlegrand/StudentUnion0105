CREATE PROCEDURE FrontProjectMyProjectGet (@CurrentUserId nvarchar(50))
AS
SELECT
	DbProjectLanguage.Id
	, DbProjectLanguage.Name ProjectName
	, DbProjectLanguage.CreatedDate
	, DbUserProjectTypeLanguage.Name RelationName
FROM DbUserProject 
JOIN DbUserProjectTypeLanguage
	ON DbUserProject.TypeId = DbUserProjectTypeLanguage.TypeId
JOIN DbProjectLanguage
	ON DbUserProject.ProjectId = DbProjectLanguage.ProjectId
JOIN AspNetUsers
	ON AspNetUsers.DefaultLanguageId = DbProjectLanguage.LanguageId
	AND AspNetUsers.DefaultLanguageId = DbUserProjectTypeLanguage.LanguageId
WHERE AspNetUsers.Id = @CurrentUserId