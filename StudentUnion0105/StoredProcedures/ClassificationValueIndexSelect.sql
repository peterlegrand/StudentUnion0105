CREATE PROCEDURE ClassificationValueIndexSelect (@LanguageId int)
AS 
SELECT dbClassificationValue.Id
	, dbClassificationValueLanguage.LanguageId
	, dbClassificationValue.ClassificationId
	, dbClassificationValue.ParentValueId
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
	, Creator.UserName Creator
	, Modifier.UserName Modifier
	, dbClassificationValue.CreatedDate
	, dbClassificationValue.ModifiedDate
FROM dbClassificationValue
JOIN dbClassificationValueLanguage
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
JOIN AspNetUsers Creator
	ON CAST( dbClassificationValue.CreatorId as nvarchar(450))= Creator.Id
JOIN AspNetUsers Modifier
	ON CAST( dbClassificationValue.CreatorId as nvarchar(450))= Modifier.Id
WHERE dbClassificationValueLanguage.LanguageId = @LanguageId
ORDER BY 
dbClassificationValueLanguage.Name


