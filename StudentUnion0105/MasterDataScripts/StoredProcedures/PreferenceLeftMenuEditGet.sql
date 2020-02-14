CREATE PROCEDURE PreferenceLeftMenuEditGet (@Id int, @languageId int)
AS 
SELECT 
	dbLeftMenuUser.Id
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
	, dbLeftMenuUser.MenuShow
	, dbLeftMenuUser.MenuAddShow
	, dbLeftMenuUser.SearchShow
	, dbLeftMenuUser.AdvancedSearchShow
	, dbLeftMenuUser.MenuName
	, dbLeftMenuUser.MenuURL
	, dbLeftMenuUser.Sequence
	, dbLeftMenuUser.Id UserMenuId
FROM dbLeftMenu 
JOIN dbLeftMenuLanguage
	ON dbLeftMenu.Id = dbLeftMenuLanguage.LeftMenuId 
JOIN dbLeftMenuUser
	ON dbLeftMenu.Id = dbLeftMenuUser.LeftMenuId
WHERE 	dbLeftMenuUser.Id = @Id
	AND dbLeftMenuLanguage.LanguageId = @languageId
ORDER BY dbLeftMenuUser.Sequence



