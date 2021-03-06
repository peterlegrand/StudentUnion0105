CREATE PROCEDURE PageSectionLanguageEditPost (
@LId int
, @Name nvarchar(50)
, @Description nvarchar(max)
, @MenuName nvarchar(50)
, @MouseOver nvarchar(50)
, @DropDownName nvarchar(50)
, @PageName nvarchar(50)
, @PageDescription nvarchar(max)
, @HeaderName nvarchar(50)
, @HeaderDescription nvarchar(max)
, @TopicName nvarchar(50)
, @Modifier varchar(450))
AS
UPDATE dbPageSectionLanguage 
SET Name = @name
, Description = @Description
, MenuName = @MenuName
, MouseOver = @MouseOver
, TitleName = @HeaderName
, TitleDescription = @HeaderDescription
, ModifierId = @Modifier
, ModifiedDate = getdate()
WHERE Id = @LId
