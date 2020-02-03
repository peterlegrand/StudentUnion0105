CREATE PROCEDURE ContentCreate1GetContentTypeGroup (@CurrentUser nvarchar(50)) 
AS
SELECT 
	DbContentTypeGroupLanguage.ContentTypeGroupId Id
	, Name
FROM DbContentTypeGroupLanguage
JOIN AspNetUsers	
	ON AspNetUsers.DefaultLanguageId = DbContentTypeGroupLanguage.LanguageId
WHERE DbContentTypeGroupLanguage.ContentTypeGroupId IN ( 
		SELECT dbContentType.ContentTypeGroupId 
		FROM dbContentType 
		JOIN AspNetUsers 
			ON AspNetUsers.SecurityLevel >= dbContentType.SecurityLevel
		WHERE AspNetUsers.Id = @CurrentUser )
	AND AspNetUsers.Id = @CurrentUser
ORDER BY Name