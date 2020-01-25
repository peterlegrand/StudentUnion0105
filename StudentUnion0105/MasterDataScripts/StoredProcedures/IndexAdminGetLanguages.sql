CREATE PROCEDURE IndexAdminGetLanguages 
AS
SELECT LanguageName FROM DbLanguage 
LEFT JOIN (
	SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting 
	ON Setting.IntValue = DbLanguage.Id
ORDER BY IIF(IntValue IS NULL,languagename, '1')
