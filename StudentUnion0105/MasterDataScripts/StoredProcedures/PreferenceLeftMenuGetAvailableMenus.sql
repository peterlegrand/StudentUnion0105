CREATE PROCEDURE PreferenceLeftMenuGetAvailableMenus (@CurrentUser nvarchar(50))
AS 
SELECT 
	dbLeftMenu.Id
	, dbLeftMenu.MainController
	, dbLeftMenu.MainAction
	, dbLeftMenu.AddController
	, dbLeftMenu.AddAction
	, dbLeftMenu.HasMenu
	, dbLeftMenu.HasAdd
	, dbLeftMenu.HasSearch
	, dbLeftMenu.HasAdvancedSearch
	, dbLeftMenu.ImageName
	, dbLeftMenuLanguage.Name
	, dbLeftMenuLanguage.Description
	, dbLeftMenuLanguage.MainName
	, dbLeftMenuLanguage.MainMouseOver
	, dbLeftMenuLanguage.AddName
	, dbLeftMenuLanguage.AddMouseOver
	FROM dbLeftMenu 
JOIN dbLeftMenuLanguage
	ON dbLeftMenu.Id = dbLeftMenuLanguage.LeftMenuId 

WHERE dbLeftMenu.Id NOT IN (SELECT dbLeftMenuUser.LeftMenuId FROM dbLeftMenuUser WHERE dbLeftMenuUser.UserId = @CurrentUser)
ORDER BY dbLeftMenuLanguage.Name
