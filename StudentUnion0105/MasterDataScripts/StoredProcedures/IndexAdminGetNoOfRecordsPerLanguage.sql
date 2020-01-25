CREATE PROCEDURE IndexAdminGetNoOfRecordsPerLanguage 
AS 
SELECT 1 TableNumber, DbClassificationLanguage.LanguageId,  COUNT(*) FROM DbClassification JOIN DbClassificationLanguage ON DbClassification.Id = DbClassificationLanguage.ClassificationId WHERE ClassificationStatusId = 1 GROUP BY DbClassificationLanguage.LanguageId
UNION ALL
SELECT 2, DbClassificationLevelLanguage.LanguageId, COUNT(*) FROM DbClassificationLevel JOIN DbClassificationLevelLanguage ON DbClassificationLevel.Id = DbClassificationLevelLanguage.ClassificationLevelId JOIN DbClassification ON DbClassification.Id = DbClassificationLevel.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1 GROUP BY DbClassificationLevelLanguage.LanguageId
UNION ALL
SELECT 3, DbClassificationValueLanguage.LanguageId, COUNT(*) FROM DbClassificationValue JOIN DbClassificationValueLanguage ON DbClassificationValue.Id = DbClassificationValueLanguage.ClassificationValueId JOIN DbClassification ON DbClassification.Id = DbClassificationValue.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1 GROUP BY DbClassificationValueLanguage.LanguageId
UNION ALL
SELECT 4, DbClassificationPageLanguage.LanguageId, COUNT(*) FROM DbClassificationPage JOIN DbClassificationPageLanguage ON DbClassificationPage.Id = DbClassificationPageLanguage.ClassificationPageId JOIN DbClassification ON DbClassification.Id = DbClassificationPage.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1 GROUP BY DbClassificationPageLanguage.LanguageId
UNION ALL
SELECT 5, DbClassificationPageSectionlanguage.LanguageId, COUNT(*)  FROM DbClassificationPageSection JOIN DbClassificationPageSectionLanguage ON DbClassificationPageSection.Id = DbClassificationPageSection.ClassificationPageId JOIN DbClassificationPage ON DbClassificationPage.Id = DbClassificationPageSection.ClassificationPageId JOIN  DbClassification ON DbClassification.Id = DbClassificationPage.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1 GROUP BY DbClassificationPageSectionLanguage.LanguageId
UNION ALL 
SELECT 6, DbContentTypeLanguage.LanguageId, COUNT(*) FROM DbContentType JOIN DbContentTypeLanguage ON DbContentType.Id = DbContentTypeLanguage.ContentTypeId GROUP BY DbContentTypeLanguage.LanguageId 
UNION ALL 
SELECT 7, dbLeftMenuLanguage.LanguageId, COUNT(*) FROM dbLeftMenu JOIN dbLeftMenuLanguage ON dbLeftMenu.Id = dbLeftMenuLanguage.LeftMenuId GROUP BY dbLeftMenuLanguage.LanguageId
UNION ALL 
SELECT 8, dbMenu1Language.LanguageId,  COUNT(*) FROM dbMenu1 JOIN dbMenu1Language ON dbMenu1.Id = dbMenu1Language.Menu1Id GROUP BY dbMenu1Language.LanguageId
UNION ALL 
SELECT 9, dbMenu2Language.LanguageId,  COUNT(*) FROM dbMenu2 JOIN dbMenu2Language ON dbMenu2.Id = dbMenu2Language.Menu2Id GROUP BY dbMenu2Language.LanguageId
UNION ALL 
SELECT 10, dbMenu3Language.LanguageId,  COUNT(*) FROM dbMenu3 JOIN dbMenu3Language ON dbMenu3.Id = dbMenu3Language.Menu3Id GROUP BY dbMenu3Language.LanguageId
UNION ALL 
SELECT COUNT(*) , 11, 'Organizations' FROM DbOrganization WHERE DbOrganization.OrganizationStatusId = 1
UNION ALL 
SELECT COUNT(*) , 12, 'Organization types' FROM DbOrganizationType
UNION ALL 
SELECT COUNT(*) , 13, 'Pages' FROM DbPage WHERE DbPage.PageStatusId = 1
UNION ALL 
SELECT COUNT(*) , 14, 'Page sections' FROM DbPage JOIN DbPageSection ON DbPage.Id = DbPageSection.PageId  WHERE DbPage.PageStatusId = 1 
UNION ALL 
SELECT COUNT(*) , 15, 'Page section types' FROM DbPageSectionType
UNION ALL 
SELECT COUNT(*) , 16, 'Page types' FROM DbPageType
UNION ALL 
SELECT COUNT(*) , 17, 'Process templates' FROM DbProcessTemplate 
UNION ALL 
SELECT COUNT(*) , 18, 'Process template fields' FROM DbProcessTemplateField   
UNION ALL 
SELECT COUNT(*) , 19, 'Process template field types' FROM DbProcessTemplateFieldType   
UNION ALL 
SELECT COUNT(*) , 20, 'Process template flows' FROM DbProcessTemplateFlow
UNION ALL 
SELECT COUNT(*) , 21, 'Process template flow conditions' FROM DbProcessTemplateFlowCondition
UNION ALL 
SELECT COUNT(*) , 22, 'Process template groups' FROM DbProcessTemplateGroup
UNION ALL 
SELECT COUNT(*) , 23, 'Process template steps' FROM DbProcessTemplateStep
UNION ALL 
SELECT COUNT(*) , 24, 'Process template step types' FROM dbProcessTemplateStepType
UNION ALL 
SELECT COUNT(*) , 25, 'Projects' FROM DbProject
UNION ALL 
SELECT COUNT(*) , 26, 'User interface terms' FROM DbUITerm
UNION ALL 
SELECT COUNT(*) , 27, 'User role types in organizations' FROM DbUserOrganizationType
UNION ALL 
SELECT COUNT(*) , 28, 'User role types in projects' FROM DbUserProjectType
UNION ALL 
SELECT COUNT(*) , 29, 'User relation types with other users' FROM DbUserRelationType
