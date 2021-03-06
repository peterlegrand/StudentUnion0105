CREATE PROCEDURE [dbo].[UITermLanguageSelect] (@Controller varchar(30),@Action varchar(20), @LanguageId int)
AS
SELECT dbUITerm.Id
, ISNULL(dbUITermLanguage.Customization, dbUIterm.Name) Name 
FROM (SELECT * FROM dbUITermLanguage WHERE LanguageId = @LanguageId) dbUITermLanguage
RIGHT JOIN dbUITerm
	ON dbUITermLanguage.TermId = dbUITerm.Id
JOIN dbUITermScreen
	ON dbUITerm.Id = dbUITermScreen.TermId
JOIN dbUIScreen
	ON dbUIScreen.Id = dbUITermScreen.ScreenId
WHERE dbUIScreen.Controller = @Controller
	AND dbUIScreen.Action = @Action
ORDER BY dbUITermScreen.Sequence