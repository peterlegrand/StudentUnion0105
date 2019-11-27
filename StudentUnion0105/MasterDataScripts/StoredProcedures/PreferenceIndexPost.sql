CREATE PROCEDURE PreferenceIndexPost (@UserId nvarchar(45), @LanguageId int, @CountryId int)
AS
UPDATE  AspNetUsers 
SET DefaultLanguageId = @LanguageId
, CountryId = @CountryId
WHERE Id = @UserId
	

