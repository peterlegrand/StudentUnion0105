CREATE PROCEDURE  
[dbo].[ContentInsert]  
  @ContentTypeId int 
, @ContentStatusId int 
, @LanguageId int 
, @Title nvarchar(max) 
, @Description nvarchar(max) 
, @SecurityLevel int 
, @OrganizationId int 
, @ProjectId int--3 
AS 
BEGIN TRANSACTION 
INSERT 
dbContent  
( 
ContentTypeId 
, ContentStatusId 
, LanguageId 
, Title 
, Description 
, SecurityLevel 
, OrganizationId 
, ProjectId 
, ModifiedDate 
, CreatedDate 
) 
OUTPUT Inserted.Id 
VALUES 
( 
  @ContentTypeId  
, @ContentStatusId  
, @LanguageId  
, @Title  
, @Description  
, @SecurityLevel  
, @OrganizationId 
, @ProjectId  
, Getdate() 
, Getdate()) 
COMMIT TRANSACTION 