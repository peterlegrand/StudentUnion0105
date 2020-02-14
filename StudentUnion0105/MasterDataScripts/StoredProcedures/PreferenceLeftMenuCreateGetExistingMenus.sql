CREATE PROCEDURE PreferenceLeftMenuCreateGetExistingMenus (@CurrentUser nvarchar(50))
AS 
DECLARE @LanguageId int
SELECT @LanguageId = DefaultLanguageId FROM AspNetUsers WHERE Id = @CurrentUser

SELECT 
	dbLeftMenuUser.Sequence Id
	, dbLeftMenuLanguage.Name
FROM dbLeftMenuLanguage 
JOIN dbLeftMenuUser
	ON dbLeftMenuLanguage.LeftMenuId = dbLeftMenuUser.LeftMenuId
WHERE dbLeftMenuLanguage.LanguageId = @LanguageId
	AND dbLeftMenuUser.UserId = @CurrentUser
ORDER BY dbLeftMenuUser.Sequence