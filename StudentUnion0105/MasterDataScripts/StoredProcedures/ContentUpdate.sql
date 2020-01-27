CREATE PROCEDURE [dbo].[ContentUpdate]  
@Id int 
, @ContentTypeId int 
, @ContentStatusId int 
, @LanguageId int 
, @Title nvarchar(max) 
, @Description nvarchar(max) 
, @SecurityLevel int 
, @OrganizationId int 
, @ProjectId int 
 
AS 
UPDATE dbContent  
SET  
ContentTypeId = @ContentTypeId 
, ContentStatusId = @ContentStatusId 
, LanguageId = @LanguageId 
, Title = @Title 
, Description = @Description 
, SecurityLevel = @SecurityLevel 
, OrganizationId = @OrganizationId 
, ProjectId = iif(@ProjectId=0,null,@ProjectId) 
WHERE Id = @Id 