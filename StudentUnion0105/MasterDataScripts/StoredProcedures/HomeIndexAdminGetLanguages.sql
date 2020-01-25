CREATE PROCEDURE HomeIndexAdminGetLanguages 
AS
SELECT Id, LanguageName FROM DbLanguage 
LEFT JOIN (
	SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting 
	ON Setting.IntValue = DbLanguage.Id
WHERE DbLanguage.Active= 1
ORDER BY IIF(IntValue IS NULL,languagename, '1')
