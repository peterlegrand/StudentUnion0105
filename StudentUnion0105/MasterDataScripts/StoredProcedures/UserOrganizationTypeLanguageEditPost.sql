CREATE PROCEDURE UserOrganizationTypeLanguageEditPost (
@LId int
, @Name nvarchar(50)
, @Description nvarchar(max)
, @MenuName nvarchar(50)
, @MouseOver nvarchar(50)
, @Modifier varchar(450))
AS
UPDATE dbUserOrganizationTypeLanguage 
SET Name = @name
, Description = @Description
, MenuName = @MenuName
, MouseOver = @MouseOver
, ModifierId = @Modifier
, ModifiedDate = getdate()
WHERE Id = @LId
