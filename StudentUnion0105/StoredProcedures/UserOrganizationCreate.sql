CREATE PROCEDURE [dbo].[UserOrganizationCreate] (@UserId varchar(450), @OrganizationId int, @TypeId int, @CurrentUser varchar(450)) 
AS  
INSERT INTO dbUserOrganization (UserId, OrganizationId, TypeId, ModifiedDate, CreatedDate, ModifierId, CreatorId)
VALUES (@UserId, @OrganizationId, @TypeId, getdate(), getdate(), @CurrentUser, @CurrentUser)