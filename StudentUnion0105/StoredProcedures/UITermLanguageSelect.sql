CREATE PROCEDURE UITermLanguageSelect (@Controller varchar(20),@Action varchar(20), @LanguageId int)
AS
SELECT dbTerm.Id
, ISNULL(dbTermLanguage.Customization, dbterm.Name) Customization 
FROM dbTermLanguage
JOIN dbTerm
	ON dbTermLanguage.TermId = dbTerm.Id
JOIN dbTermScreen
	ON dbTerm.Id = dbTermScreen.TermId
JOIN dbScreen
	ON dbScreen.Id = dbTermScreen.ScreenId
WHERE dbTermLanguage.LanguageId = @LanguageId
	AND dbScreen.Controller = @Controller
	AND dbScreen.Action = @Action