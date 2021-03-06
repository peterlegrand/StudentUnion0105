CREATE PROCEDURE [dbo].[UserProjectTypeSelectAll] (@LanguageId int) 
AS  
SELECT  
dbUserProjectType.Id
, ISNULL(dbUserProjectTypeLanguage.Name,dbUserProjectType.Name) Name 
FROM dbUserProjectType
JOIN dbUserProjectTypeLanguage
	ON dbUserProjectType.Id = dbUserProjectTypeLanguage.TypeId
WHERE  dbUserProjectTypeLanguage.LanguageId = @LanguageId
ORDER BY dbUSerProjectTypeLanguage.Name
