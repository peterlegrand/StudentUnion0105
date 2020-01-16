CREATE PROCEDURE PartialLeftMenu ( @CurrentUserId nvarchar(50))
AS
SELECT 
	dbLeftMenuUser.Id
	, IsNull(dbLeftMenuLanguage.MainName, dbLeftMenu.MenuName) MenuName  
	, dbLeftMenuUser.MenuShow
	, dbLeftMenuUser.MenuAddShow
	, dbLeftMenuUser.SearchShow
	, dbLeftMenuUser.AdvancedSearchShow
	, dbLeftMenu.HasMenu
	, dbLeftMenu.HasAdd
	, dbLeftMenu.HasSearch
	, dbLeftMenu.HasAdvancedSearch
	, dbLeftMenu.MainController
	, dbLeftMenu.MainAction
	, dbLeftMenu.AddController
	, dbLeftMenu.AddAction
	, ISNULL(dbleftMenuLanguage.AddName, dbLeftMenu.MenuName) AddName
	, '/Images/Icons/'+ dbLeftMenu.ImageName ImageName
FROM 
	dbLeftMenuUser
JOIN dbLeftMenu
	ON dbLeftMenuUser.LeftMenuId = dbLeftMenu.Id
JOIN dbLeftMenuLanguage
	ON dbLeftMenuLanguage.LeftMenuId = dbLeftMenu.Id
JOIN AspNetUsers
	ON dbLeftMenuUser.UserId = AspNetUsers.Id
	AND dbLeftMenuLanguage.LanguageId = AspNetUsers.DefaultLanguageId
WHERE dbLeftMenuUser.UserId = @CurrentUserId
ORDER BY dbLeftMenuUser.Sequence