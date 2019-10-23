CREATE PROCEDURE UITermLanguageSelectForUpdate (@Id int)
AS
SELECT dbUITermLanguage.Id
	, dbUITermLanguage.Customization
	, dbUITermLanguage.TermId
	, dbUITermLanguage.LanguageId
FROM dbUITermLanguage
WHERE dbUITermLanguage.Id = @Id
