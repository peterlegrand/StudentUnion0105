CREATE PROCEDURE ClassificationValueDeleteGet (@Id int, @LanguageId int)
AS
SELECT dbClassificationValueLanguage.ClassificationValueId
	, dbClassificationValueLanguage.Name
	, dbClassificationValueLanguage.MouseOver
	, dbClassificationValueLanguage.MenuName
	, dbClassificationValueLanguage.Description
	, dbClassificationValueLanguage.DropDownName
	, dbClassificationValueLanguage.PageName
	, dbClassificationValueLanguage.PageDescription
	, dbClassificationValueLanguage.HeaderName
	, dbClassificationValueLanguage.HeaderDescription
	, dbClassificationValueLanguage.TopicName
FROM dbClassificationValue
JOIN dbClassificationValueLanguage
	ON dbClassificationValue.Id = dbClassificationValueLanguage.ClassificationValueId
WHERE LanguageId = @LanguageId 
	AND dbClassificationValue.Id = @Id
