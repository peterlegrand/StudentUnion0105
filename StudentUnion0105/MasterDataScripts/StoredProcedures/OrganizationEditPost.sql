CREATE PROCEDURE OrganizationEditPost (
	@OId int
	, @StatusId int
	, @TypeId int
	, @LId int
	, @LanguageId int
	, @Name nvarchar(50)
	, @Description nvarchar(max)
	, @MouseOver nvarchar(50)
	, @MenuName nvarchar(50)
	, @ModifierId nvarchar(450)
	)
AS
BEGIN TRANSACTION
UPDATE dbOrganization 
SET
	OrganizationStatusId = @StatusId
	, OrganizationTypeId = @TypeId
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE Id = @OId;
UPDATE dbOrganizationLanguage
SET
	 Name = @Name
	, Description = @Description
	, MouseOver = @MouseOver
	, MenuName = @MenuName
	, ModifierId = @ModifierId
	, ModifiedDate = getdate()
WHERE OrganizationId = @OId
	AND LanguageId = @LanguageId
COMMIT TRANSACTION


