CREATE PROCEDURE PartialTopMenu2 (@LanguageId int, @Id int) AS
SELECT 
	 dbMenu2.Id 
	, CASE WHEN dbMenu2.MenuTypeId = 1  THEN dbMenu2Language.MenuName -- No action
	WHEN dbMenu2.MenuTypeId = 2 THEN ClassificationLanguage.MenuName -- Classification
	WHEN dbMenu2.MenuTypeId = 3 THEN dbMenu2Language.MenuName -- Controller action id
	WHEN dbMenu2.MenuTypeId = 4 THEN dbMenu2Language.MenuName -- Feature
	END AS MenuName
	, CASE WHEN dbMenu2.MenuTypeId = 1  THEN '' -- No action
	WHEN dbMenu2.MenuTypeId = 2 THEN 'FrontClassificationPage' -- Classification
	WHEN dbMenu2.MenuTypeId = 3 THEN dbMenu2.Controller -- Controller action id
	WHEN dbMenu2.MenuTypeId = 4 THEN dbMenu2.Controller -- Feature
	END AS MenuController
	, CASE WHEN dbMenu2.MenuTypeId = 1  THEN '' -- No action
	WHEN dbMenu2.MenuTypeId = 2 THEN 'Index' -- Classification
	WHEN dbMenu2.MenuTypeId = 3 THEN dbMenu2.Action-- Controller action id
	WHEN dbMenu2.MenuTypeId = 4 THEN dbMenu2.Action -- Feature
	END AS MenuAction
	, CASE WHEN dbMenu2.MenuTypeId = 1  THEN 0 -- No action
	WHEN dbMenu2.MenuTypeId = 2 THEN DbClassification.DefaultClassificationPageId -- Classification
	WHEN dbMenu2.MenuTypeId = 3 THEN dbMenu2.DestinationId-- Controller action id
	WHEN dbMenu2.MenuTypeId = 4 THEN dbMenu2.DestinationId -- Feature
	END AS MenuDestinationId
	, '' IconCss
FROM dbMenu1
JOIN dbMenu2
	ON dbMenu1.Id = dbmenu2.Menu1Id
JOIN dbMenu2Language
	ON dbMenu2.Id = dbMenu2Language.Menu2Id
LEFT JOIN (SELECT ClassificationId, MenuName FROM DbClassificationLanguage WHERE LanguageId = @LanguageId) ClassificationLanguage
	ON ClassificationLanguage.ClassificationId = dbMenu2.ClassificationId
LEFT JOIN DbClassification
	ON DbClassification.Id = dbMenu2.ClassificationId
WHERE dbMenu2Language.LanguageId = @LanguageId
	AND dbMenu1.Id = @Id
ORDER BY dbMenu2.Sequence

