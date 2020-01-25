CREATE PROCEDURE IndexAdminGetNoOfRecordsAndPerLanguage (@TableName varchar(30))
AS
IF @TableName = 'Classifications'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbClassificationLanguage.LanguageId) NoOfRecords
	FROM DbClassification 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbClassificationLanguage 
		ON DbClassification.Id = DbClassificationLanguage.ClassificationId 
		AND DbLanguage.Id = DbClassificationLanguage.LanguageId
	WHERE ClassificationStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbClassification 
	WHERE ClassificationStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Classification levels'
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbClassificationLevelLanguage.LanguageId) NoOfRecords
	FROM DbClassification
	JOIN DbClassificationLevel
		ON DbClassification.Id = DbClassificationLevel.ClassificationId
	CROSS JOIN DbLanguage 
	LEFT JOIN DbClassificationLevelLanguage
		ON DbClassificationLevel.Id = DbClassificationLevelLanguage.ClassificationLevelId 
		AND DbLanguage.Id = DbClassificationLevelLanguage.LanguageId
	WHERE ClassificationStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbClassification 
	JOIN DbClassificationLevel
		ON DbClassification.Id = DbClassificationLevel.ClassificationId
	WHERE ClassificationStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Classification values'
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbClassificationValueLanguage.LanguageId) NoOfRecords
	FROM DbClassification
	JOIN DbClassificationValue
		ON DbClassification.Id = DbClassificationValue.ClassificationId
	CROSS JOIN DbLanguage 
	LEFT JOIN DbClassificationValueLanguage
		ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId 
		AND DbLanguage.Id = DbClassificationValueLanguage.LanguageId
	WHERE ClassificationStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbClassification 
	JOIN DbClassificationValue
		ON DbClassification.Id = DbClassificationValue.ClassificationId
	WHERE ClassificationStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Classification pages'
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbClassificationPageLanguage.LanguageId) NoOfRecords
	FROM DbClassification
	JOIN DbClassificationPage
		ON DbClassification.Id = DbClassificationPage.ClassificationId
	CROSS JOIN DbLanguage 
	LEFT JOIN DbClassificationPageLanguage
		ON DbClassificationPage.Id = DbClassificationPageLanguage.ClassificationPageId 
		AND DbLanguage.Id = DbClassificationPageLanguage.LanguageId
	WHERE ClassificationStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbClassification 
	JOIN DbClassificationPage
		ON DbClassification.Id = DbClassificationPage.ClassificationId
	WHERE ClassificationStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Classification page sections'
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbClassificationPageSectionLanguage.LanguageId) NoOfRecords
	FROM DbClassification
	JOIN DbClassificationPage
		ON DbClassification.Id = DbClassificationPage.ClassificationId
	JOIN DbClassificationPageSection 
		ON DbClassificationPage.Id = DbClassificationPageSection.ClassificationPageId 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbClassificationPageSectionLanguage
		ON DbClassificationPageSection.Id = DbClassificationPageSectionLanguage.PageSectionId 
		AND DbLanguage.Id = DbClassificationPageSectionLanguage.LanguageId
	WHERE ClassificationStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbClassification 
	JOIN DbClassificationPage
		ON DbClassification.Id = DbClassificationPage.ClassificationId
	JOIN DbClassificationPageSection 
		ON DbClassificationPage.Id = DbClassificationPageSection.ClassificationPageId 
	WHERE ClassificationStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Content types'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbContentTypeLanguage.LanguageId) NoOfRecords
	FROM DbContentType
	CROSS JOIN DbLanguage 
	LEFT JOIN DbContentTypeLanguage 
		ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId 
		AND DbLanguage.Id = DbContentTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbContentType 
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Left menus'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(dbLeftMenuLanguage.LanguageId) NoOfRecords
	FROM DbLeftMenu
	CROSS JOIN DbLanguage 
	LEFT JOIN dbLeftMenuLanguage 
		ON dbLeftMenu.Id = dbLeftMenuLanguage.LeftMenuId 
		AND DbLanguage.Id = dbLeftMenuLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM dbLeftMenu
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Menu level 1'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(dbMenu1Language.LanguageId) NoOfRecords
	FROM dbMenu1
	CROSS JOIN DbLanguage 
	LEFT JOIN dbMenu1Language 
		ON dbMenu1.Id = dbMenu1Language.Menu1Id
		AND DbLanguage.Id = dbMenu1Language.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM dbMenu1
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Menu level 2'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(dbMenu2Language.LanguageId) NoOfRecords
	FROM dbMenu2
	CROSS JOIN DbLanguage 
	LEFT JOIN dbMenu2Language 
		ON dbMenu2.Id = dbMenu2Language.Menu2Id
		AND DbLanguage.Id = dbMenu2Language.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM dbMenu2
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Menu level 3'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(dbMenu3Language.LanguageId) NoOfRecords
	FROM dbMenu3
	CROSS JOIN DbLanguage 
	LEFT JOIN dbMenu3Language 
		ON dbMenu3.Id = dbMenu3Language.Menu3Id
		AND DbLanguage.Id = dbMenu3Language.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM dbMenu3
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Organizations'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbOrganizationLanguage.LanguageId) NoOfRecords
	FROM DbOrganization 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbOrganizationLanguage 
		ON DbOrganization.Id = DbOrganizationLanguage.OrganizationId 
		AND DbLanguage.Id = DbOrganizationLanguage.LanguageId
	WHERE OrganizationStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbOrganization
	WHERE OrganizationStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Organization type'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbOrganizationTypeLanguage.LanguageId) NoOfRecords
	FROM DbOrganizationType
	CROSS JOIN DbLanguage 
	LEFT JOIN DbOrganizationTypeLanguage 
		ON DbOrganizationType.Id = DbOrganizationTypeLanguage.OrganizationTypeId
		AND DbLanguage.Id = DbOrganizationTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbOrganizationType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Pages'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbPageLanguage.LanguageId) NoOfRecords
	FROM DbPage 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbPageLanguage 
		ON DbPage.Id = DbPageLanguage.PageId 
		AND DbLanguage.Id = DbPageLanguage.LanguageId
	WHERE PageStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbPage
	WHERE PageStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Page sections'
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbPageSectionLanguage.LanguageId) NoOfRecords
	FROM DbPage
	JOIN DbPageSection
		ON DbPage.Id = DbPageSection.PageId
	CROSS JOIN DbLanguage 
	LEFT JOIN DbPageSectionLanguage
		ON DbPageSection.Id = DbPageSectionLanguage.PageSectionId 
		AND DbLanguage.Id = DbPageSectionLanguage.LanguageId
	WHERE PageStatusId = 1 
		AND DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbPage 
	JOIN DbPageSection
		ON DbPage.Id = DbPageSection.PageId
	WHERE PageStatusId = 1) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Page section types'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbPageSectionTypeLanguage.LanguageId) NoOfRecords
	FROM DbPageSectionType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbPageSectionTypeLanguage 
		ON DbPageSectionType.Id = DbPageSectionTypeLanguage.PageSectionTypeId 
		AND DbLanguage.Id = DbPageSectionTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbPageSectionType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Page types'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbPageTypeLanguage.LanguageId) NoOfRecords
	FROM DbPageType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbPageTypeLanguage 
		ON DbPageType.Id = DbPageTypeLanguage.PageTypeId 
		AND DbLanguage.Id = DbPageTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbPageType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

ELSE IF @TableName = 'Process templates'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplate 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateLanguage 
		ON DbProcessTemplate.Id = DbProcessTemplateLanguage.ProcessTemplateId 
		AND DbLanguage.Id = DbProcessTemplateLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplate
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Process template fields'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateFieldLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateField 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateFieldLanguage 
		ON DbProcessTemplateField.Id = DbProcessTemplateFieldLanguage.ProcessTemplateFieldId 
		AND DbLanguage.Id = DbProcessTemplateFieldLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateField
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END



ELSE IF @TableName = 'Process template field types'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateFieldTypeLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateFieldType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateFieldTypeLanguage 
		ON DbProcessTemplateFieldType.Id = DbProcessTemplateFieldTypeLanguage.FieldTypeId 
		AND DbLanguage.Id = DbProcessTemplateFieldTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateFieldType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Process template flows'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateFlowLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateFlow 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateFlowLanguage 
		ON DbProcessTemplateFlow.Id = DbProcessTemplateFlowLanguage.FlowId 
		AND DbLanguage.Id = DbProcessTemplateFlowLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateFlow
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Process template flow conditions'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateFlowConditionLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateFlowCondition 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateFlowConditionLanguage 
		ON DbProcessTemplateFlowCondition.Id = DbProcessTemplateFlowConditionLanguage.FlowConditionId 
		AND DbLanguage.Id = DbProcessTemplateFlowConditionLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateFlowCondition
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Process template flow conditions'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateGroupLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateGroup 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateGroupLanguage 
		ON DbProcessTemplateGroup.Id = DbProcessTemplateGroupLanguage.ProcessTemplateGroupId 
		AND DbLanguage.Id = DbProcessTemplateGroupLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateGroup
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END



ELSE IF @TableName = 'Process template steps'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateStepLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateStep 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateStepLanguage 
		ON DbProcessTemplateStep.Id = DbProcessTemplateStepLanguage.StepId 
		AND DbLanguage.Id = DbProcessTemplateStepLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateStep
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Process template step types'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProcessTemplateStepTypeLanguage.LanguageId) NoOfRecords
	FROM DbProcessTemplateStepType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProcessTemplateStepTypeLanguage 
		ON DbProcessTemplateStepType.Id = DbProcessTemplateStepTypeLanguage.StepTypeId 
		AND DbLanguage.Id = DbProcessTemplateStepTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProcessTemplateStepType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'Projects'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbProjectLanguage.LanguageId) NoOfRecords
	FROM DbProject 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbProjectLanguage 
		ON DbProject.Id = DbProjectLanguage.ProjectId 
		AND DbLanguage.Id = DbProjectLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbProject
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'User interface terms'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbUITermLanguage.LanguageId) NoOfRecords
	FROM DbUITerm 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbUITermLanguage 
		ON DbUITerm.Id = DbUITermLanguage.TermId
		AND DbLanguage.Id = DbUITermLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbUITerm
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'User role types in organizations'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbUserOrganizationTypeLanguage.LanguageId) NoOfRecords
	FROM DbUserOrganizationType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbUserOrganizationTypeLanguage 
		ON DbUserOrganizationType.Id = DbUserOrganizationTypeLanguage.TypeId 
		AND DbLanguage.Id = DbUserOrganizationTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbUserOrganizationType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'User role types in projects'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbUserProjectTypeLanguage.LanguageId) NoOfRecords
	FROM DbUserProjectType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbUserProjectTypeLanguage 
		ON DbUserProjectType.Id = DbUserProjectTypeLanguage.TypeId 
		AND DbLanguage.Id = DbUserProjectTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbUserProjectType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END


ELSE IF @TableName = 'User relation types with other users'  
BEGIN
	SELECT LanguageName, NoOfRecords FROM (
	SELECT 
		LanguageName
		, COUNT(DbUserRelationTypeLanguage.LanguageId) NoOfRecords
	FROM DbUserRelationType 
	CROSS JOIN DbLanguage 
	LEFT JOIN DbUserRelationTypeLanguage 
		ON DbUserRelationType.Id = DbUserRelationTypeLanguage.TypeId 
		AND DbLanguage.Id = DbUserRelationTypeLanguage.LanguageId
	WHERE DbLanguage.Active =1 
	GROUP BY dbLanguage.LanguageName 
	UNION ALL
	SELECT 
		'0'
		, COUNT(*) NoOfRecords
	FROM DbUserRelationType
	) AllRecords LEFT JOIN (SELECT LanguageName LanguageName1, IntValue FROM DbLanguage LEFT JOIN (SELECT intvalue FROM  DbSetting where DbSetting.Id=1) setting ON Setting.IntValue = DbLanguage.Id) ListOfLanguages  ON AllRecords.LanguageName = ListOfLanguages.LanguageName1 ORDER BY IIF(IntValue IS NULL,AllREcords.languagename, '1')
END

