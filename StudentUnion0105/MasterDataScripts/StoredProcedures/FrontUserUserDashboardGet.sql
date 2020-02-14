CREATE PROCEDURE FrontUserUserDashboardGet (@UserId nvarchar(50))
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
WHERE AspNetUsers.Id = @UserId