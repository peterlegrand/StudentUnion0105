CREATE PROCEDURE UITermLanguageEditPost (@LId int, @Customization nvarchar(255))
AS
UPDATE dbUITermLanguage SET Customization = @Customization WHERE Id = @LId