CREATE PROCEDURE [dbo].[LanguageSelectAll] 
AS  
SELECT  
dbLanguage.Id 
, ISNULL(dbLanguage.LanguageName,'') Name 
FROM dbLanguage 
ORDER BY dbLanguage.LanguageName 
