CREATE PROCEDURE ContentTypeLanguageEditPost (
@LId int
, @Name nvarchar(50)
, @Description nvarchar(max)
, @MenuName nvarchar(50)
, @MouseOver nvarchar(50)
, @TitleName nvarchar(50)
, @TitleDescription nvarchar(max)
, @Modifier varchar(450))
AS
UPDATE dbContentTypeLanguage 
SET Name = @name
, Description = @Description
, MenuName = @MenuName
, MouseOver = @MouseOver
, TitleName = @TitleName
, TitleDescription = @TitleDescription
, ModifierId = @Modifier
, ModifiedDate = getdate()
WHERE Id = @LId
