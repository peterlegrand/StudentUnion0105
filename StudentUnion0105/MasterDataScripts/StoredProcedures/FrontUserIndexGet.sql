CREATE PROCEDURE FrontUserIndexGet 
AS
SELECT 
	AspNetUsers.Id UserId
	, AspNetUsers.UserName
	, ISNULL(AspNetUsers.Email,'') Email 
	, ISNULL(AspNetUsers.PhoneNumber,'') PhoneNumber 
	, ISNULL(DbLanguage.LanguageName,'') Language
	, ISNULL(DbCountry.Name,'')  Country
FROM AspNetUsers
LEFT JOIN DbLanguage 
	ON AspNetUsers.DefaultLanguageId = DbLanguage.Id
LEFT JOIN DbCountry
	ON AspNetUsers.CountryId=DbCountry.Id
ORDER BY AspNetUsers.UserName