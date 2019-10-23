CREATE PROCEDURE ClassificationValueDeletePost (@Id int)
AS
BEGIN TRANSACTION
DELETE FROM dbClassificationValueLanguage
WHERE dbClassificationValueLanguage.ClassificationValueId = @Id 
AND dbClassificationValueLanguage.ClassificationValueId 
	NOT IN (SELECT dbClassificationValue.ParentValueId FROM  dbClassificationValue)

DELETE FROM dbClassificationValue
WHERE Id = @Id
COMMIT TRANSACTION