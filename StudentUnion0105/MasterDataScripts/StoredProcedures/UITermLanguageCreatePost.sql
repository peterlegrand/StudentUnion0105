CREATE PROCEDURE UITermLanguageCreatePost (@Id int, @LanguageId int, @Customization nvarchar(255))
AS
INSERT INTO dbUITermLanguage (TermId, LanguageId, Customization)
VALUES (@Id, @LanguageId, @Customization)
