CREATE PROCEDURE PartialTopMenu2 (@LanguageId int, @Id int) AS
SELECT
	Id
	, Menu1MenuTypeId
	, Menu2MenuTypeId
	, MenuName
	, MenuController
	, MenuAction
	, MenuDestinationId
	, IconCss
FROM (SELECT 
	 dbMenu2.Id 
	, dbmenu1.MenuTypeId Menu1MenuTypeId
	, dbmenu2.MenuTypeId Menu2MenuTypeId
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
	, cast(dbMenu2.Sequence as varchar(max)) Sequence
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
	AND dbMenu1.MenuTypeId IN (1,3,4)

UNION ALL

SELECT 
	DbClassificationValue.Id
	, 2
	,0
	, DbClassificationValueLanguage.MenuName
	, 'FrontClassificationValuePage'
	, 'Index'
	, DbClassificationValue.Id
	, '' IconCss
	, DbClassificationValueLanguage.MenuName
FROM dbMenu1
JOIN DbClassificationLevel
	ON dbMenu1.ClassificationId = DbClassificationLevel.ClassificationId
JOIN DbClassificationValue
	ON dbMenu1.ClassificationId = DbClassificationValue.ClassificationId
JOIN DbClassificationValueLanguage
	ON DbClassificationValueLanguage.ClassificationValueId = DbClassificationValue.Id
WHERE DbClassificationLevel.Sequence = 1
	AND DbClassificationLevel.InMenu = 1
	AND DbClassificationValue.ParentValueId IS NULL
	AND DbClassificationValueLanguage.LanguageId = @LanguageId
	AND dbMenu1.Id = @Id
) AllData ORDER BY Sequence