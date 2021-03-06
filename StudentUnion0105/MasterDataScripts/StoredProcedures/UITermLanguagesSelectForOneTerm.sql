CREATE PROCEDURE [dbo].[UITermLanguagesSelectForOneTerm] (@TermId int)
AS
SELECT dbUITermLanguage.Id
	, dbUITermLanguage.Customization Name
	, dbLanguage.LanguageName Description
FROM dbUITermLanguage
JOIN dbLanguage
	ON dbUITermLanguage.LanguageId = dbLanguage.Id
WHERE dbUITermLanguage.TermId = @TermId
ORDER BY dbLanguage.LanguageName