CREATE PROCEDURE UITermLanguageEditPost (@Id int, @Customization nvarchar(255))
AS
UPDATE dbUITermLanguage SET Customization = @Customization WHERE Id = @Id