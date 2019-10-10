CREATE PROCEDURE [dbo].[UserProjectCreate] (@UserId varchar(450), @ProjectId int, @TypeId int, @CurrentUser varchar(450)) 
AS  
INSERT INTO dbUserProject (UserId, ProjectId, TypeId, ModifiedDate, CreatedDate, ModifierId, CreatorId)
VALUES (@UserId, @ProjectId, @TypeId, getdate(), getdate(), @CurrentUser, @CurrentUser)