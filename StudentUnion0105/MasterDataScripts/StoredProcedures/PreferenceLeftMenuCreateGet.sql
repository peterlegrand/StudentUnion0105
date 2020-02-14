CREATE PROCEDURE PreferenceLeftMenuCreateGetAvailableMenus (@CurrentUser nvarchar(50))
AS 
DECLARE @LanguageId int
SELECT @LanguageId = DefaultLanguageId FROM AspNetUsers WHERE Id = @CurrentUser

SELECT * 
FROM dbLeftMenuLanguage 
WHERE dbLeftMenuLanguage.LeftMenuId NOT IN (
	SELECT dbLeftMenuUser.LeftMenuId 
	FROM dbLeftMenuUser 
	WHERE dbLeftMenuUser.UserId = @CurrentUser
	)
	AND dbLeftMenuLanguage.LanguageId = @LanguageId
ORDER BY dbLeftMenuLanguage.Name