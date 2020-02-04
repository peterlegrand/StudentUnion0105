CREATE PROCEDURE ContentEditGetAllowed (@Id int, @CurrentUSer nvarchar(50))
AS
SELECT CASE WHEN COUNT(1) > 0 THEN 1 ELSE 0 END AS [intValue]
 FROM dbContent
WHERE DbContent.CreatorId = @CurrentUSer
	AND DbContent.Id = @Id

