CREATE PROCEDURE [dbo].[ContentCreate]  
 @ContentTypeId int 
, @ContentStatusId int 
, @LangaugeId int 
, @Title nvarchar(max) 
, @Description nvarchar(max) 
, @SecurityLevel int 
, @OrganizationId int 
, @ProjectId int 
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
, CreatedDate 
, ModifiedDate) 
VALUES ( 
@ContentTypeId 
, @ContentStatusId 
, @LangaugeId 
, @Title 
, @Description 
, @SecurityLevel 
, @OrganizationId 
, iif(@ProjectId=0,null,@ProjectId) 
, GETDATE() 
, getdate() 
) 
SET @new_identity = SCOPE_IDENTITY()