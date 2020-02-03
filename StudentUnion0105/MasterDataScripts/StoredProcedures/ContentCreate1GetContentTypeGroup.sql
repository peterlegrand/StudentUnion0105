CREATE PROCEDURE ContentCreate1GetContentTypeGroup (@LanguageId int) 
AS
SELECT 
	Id 
	, Name
FROM DbContentTypeGroupLanguage
WHERE LanguageId = @LanguageId
ORDER BY Name