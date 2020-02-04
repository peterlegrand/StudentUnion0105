CREATE PROCEDURE ContentCreate2GetAllowed (@Id int, @SecurityLevel int)
AS
SELECT CASE WHEN COUNT(1) > 0 THEN 1 ELSE 0 END AS [intValue]
 FROM dbContentType
WHERE DbContentType.SecurityLevel <= @SecurityLevel
	AND DbContentType.Id = @Id

