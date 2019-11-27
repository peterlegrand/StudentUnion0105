CREATE PROCEDURE PreferenceIndexGet (@UserId nvarchar(45))
AS
SELECT 
	Id
	, ISNULL(AspNetUsers.PhoneNumber,'') PhoneNumber 
	, AspNetUsers.DefaultLanguageId
	, AspNetUsers.CountryId
FROM AspNetUsers
WHERE @UserId = Id

