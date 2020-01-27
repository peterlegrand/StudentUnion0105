CREATE PROCEDURE [dbo].[ContentCreate]  
 @ContentTypeId int 
, @ContentStatusId int 
, @LanguageId int 
, @Title nvarchar(max) 
, @Description nvarchar(max) 
, @SecurityLevel int 
, @OrganizationId int 
, @ProjectId int 
, @CreatorId nvarchar(255)
, @new_identity INT = NULL OUTPUT 
AS 
INSERT dbContent 
(ContentTypeId 
, ContentStatusId 
, LanguageId 
, Title 
, Description 
, SecurityLevel 
, OrganizationId 
, ProjectId 
, CreatorId
, ModifierId
, CreatedDate 
, ModifiedDate) 
VALUES ( 
@ContentTypeId 
, @ContentStatusId 
, @LanguageId 
, @Title 
, @Description 
, @SecurityLevel 
, @OrganizationId 
, iif(@ProjectId=0,null,@ProjectId) 
, @CreatorId
, @CreatorId
, GETDATE() 
, getdate() 
) 
SET @new_identity = SCOPE_IDENTITY()