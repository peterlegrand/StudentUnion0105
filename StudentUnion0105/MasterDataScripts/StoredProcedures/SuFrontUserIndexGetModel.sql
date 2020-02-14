CREATE PROCEDURE SuFrontUserIndexGetModel 
AS
SELECT 
	AspNetUsers.Id
	, AspNetUsers.UserName
	, ISNULL(AspNetUsers.Email,'') Email 
	, ISNULL(AspNetUsers.PhoneNumber,'') PhoneNumber 
	, ISNULL(DbLanguage.LanguageName,'') LanguageName
	, ISNULL(DbCountry.Name,'')  CountryName
FROM AspNetUsers
LEFT JOIN DbLanguage 
	ON AspNetUsers.DefaultLanguageId = DbLanguage.Id
LEFT JOIN DbCountry
	ON AspNetUsers.CountryId=DbCountry.Id
ORDER BY AspNetUsers.UserName