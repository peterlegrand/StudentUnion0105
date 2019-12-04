CREATE PROCEDURE UITermLanguageEditGet (@LId int)
AS
SELECT dbUITermLanguage.Id OId
	, dbUITermLanguage.Customization
	, dbUITermLanguage.TermId
	, dbUITermLanguage.LanguageId
	, dbLanguage.LanguageName
	, dbUITerm.Name
FROM dbUITermLanguage
JOIN dbUITerm 
	ON dbUITermLanguage.TermId = dbUITerm.Id 
JOIN dbLanguage
	ON dbLanguage.Id = dbUITermLanguage.LanguageId
WHERE dbUITermLanguage.Id = @Id
