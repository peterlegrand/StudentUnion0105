CREATE PROCEDURE UITermLanguageUpdate (@Id int, @Customization nvarchar(max))
AS
UPDATE dbUITermLanguage SET Customization = @Customization
WHERE Id = @Id



