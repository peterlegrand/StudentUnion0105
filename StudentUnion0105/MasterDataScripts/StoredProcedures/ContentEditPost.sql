CREATE PROCEDURE ContentEditPost
	@Id int
, @ContentStatusId int 
, @LanguageId int 
, @Title nvarchar(max) 
, @Description nvarchar(max) 
, @SecurityLevel int 
, @OrganizationId int 
, @ProjectId int 
, @ModifierId nvarchar(255)
AS 
IF @ProjectId =0
BEGIN
UPDATE dbContent SET 
 ContentStatusId = @ContentStatusId 
, LanguageId = @LanguageId 
, Title = @Title 
, Description = @Description 
, SecurityLevel = @SecurityLevel 
, OrganizationId = @OrganizationId 
, ModifierId = @ModifierId
, ModifiedDate =GETDATE()
END
ELSE
BEGIN
UPDATE dbContent SET 
 ContentStatusId = @ContentStatusId 
, LanguageId = @LanguageId 
, Title = @Title 
, Description = @Description 
, SecurityLevel = @SecurityLevel 
, OrganizationId = @OrganizationId 
, ProjectId = @ProjectId 
, ModifierId = @ModifierId
, ModifiedDate =GETDATE()
END