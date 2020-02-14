CREATE PROCEDURE PreferenceLeftMenuEditGetOtherMenus (@CurrentUser nvarchar(50), @languageId int)
AS 
SELECT 
	dbLeftMenuUser.Sequence Id 
	, dbLeftMenuLanguage.Name
FROM dbLeftMenuUser 
JOIN dbLeftMenuLanguage
	ON dbLeftMenuLanguage.LeftMenuId = dbLeftMenuUser.LeftMenuId
WHERE dbLeftMenuLanguage.LanguageId = @LanguageId
	AND dbLeftMenuUser.UserId = @CurrentUser
ORDER BY dbLeftMenuUser.Sequence