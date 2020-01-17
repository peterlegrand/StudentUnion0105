CREATE PROCEDURE PartialTopMenu1 (@LanguageId int) AS
SELECT 
	dbMenu1.Id
	, CASE WHEN dbMenu1.MenuTypeId = 1  THEN dbMenu1Language.MenuName -- No action
	WHEN dbMenu1.MenuTypeId = 2 THEN DbClassificationLanguage.MenuName -- Classification
	WHEN dbMenu1.MenuTypeId = 3 THEN dbMenu1Language.MenuName -- Controller action id
	WHEN dbMenu1.MenuTypeId = 4 THEN dbMenu1Language.MenuName -- Feature
	END AS MenuName
	, CASE WHEN dbMenu1.MenuTypeId = 1  THEN '' -- No action
	WHEN dbMenu1.MenuTypeId = 2 THEN 'FrontClassificationPage' -- Classification
	WHEN dbMenu1.MenuTypeId = 3 THEN dbMenu1.Controller -- Controller action id
	WHEN dbMenu1.MenuTypeId = 4 THEN dbMenu1.Controller -- Feature
	END AS MenuController
	, CASE WHEN dbMenu1.MenuTypeId = 1  THEN '' -- No action
	WHEN dbMenu1.MenuTypeId = 2 THEN 'Index' -- Classification
	WHEN dbMenu1.MenuTypeId = 3 THEN dbMenu1.Action-- Controller action id
	WHEN dbMenu1.MenuTypeId = 4 THEN dbMenu1.Action -- Feature
	END AS MenuAction
	, CASE WHEN dbMenu1.MenuTypeId = 1  THEN 0 -- No action
	WHEN dbMenu1.MenuTypeId = 2 THEN DbClassification.DefaultClassificationPageId -- Classification
	WHEN dbMenu1.MenuTypeId = 3 THEN dbMenu1.DestinationId-- Controller action id
	WHEN dbMenu1.MenuTypeId = 4 THEN dbMenu1.DestinationId -- Feature
	END AS MenuDestinationId
	, '' IconCss
	
FROM dbMenu1
JOIN dbMenu1Language
	ON dbMenu1.Id = dbMenu1Language.Menu1Id
LEFT JOIN DbClassificationLanguage
	ON DbClassificationLanguage.ClassificationId = dbMenu1.ClassificationId
LEFT JOIN DbClassification
	ON DbClassification.Id = dbMenu1.ClassificationId
WHERE dbMenu1Language.LanguageId = @LanguageId
	AND DbClassificationLanguage.LanguageId = @LanguageId
ORDER BY dbMenu1.Sequence
