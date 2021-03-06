CREATE PROCEDURE PageLanguageEditPost (
@LId int
, @Name nvarchar(50)
, @Description nvarchar(max)
, @MenuName nvarchar(50)
, @MouseOver nvarchar(50)
, @Modifier varchar(450)
, @TitleName nvarchar(50)
, @TitleDescription nvarchar(max))
AS
UPDATE dbPageLanguage 
SET Name = @name
, Description = @Description
, MenuName = @MenuName
, MouseOver = @MouseOver
, TitleName = @TitleName
, TitleDescription = @TitleDescription
, ModifierId = @Modifier
, ModifiedDate = getdate()
WHERE Id = @LId
