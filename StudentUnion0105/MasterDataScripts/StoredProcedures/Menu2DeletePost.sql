CREATE PROCEDURE Menu2DeletePost (@OId int)
AS
BEGIN TRANSACTION
DELETE FROM dbMenu2Language 
WHERE dbMenu2Language.Menu2Id = @OId;

DELETE FROM dbMenu2
WHERE dbMenu2.Id = @OId
COMMIT TRANSACTION