CREATE PROCEDURE IndexAdminGetNoOfRecords 
AS SELECT * FROM (
SELECT COUNT(*) NoOfRecords, 1 TableNumber, 'Classifications' AS Topic FROM DbClassification WHERE ClassificationStatusId = 1
UNION ALL
SELECT COUNT(*) , 2, 'Classification levels'  FROM DbClassificationLevel JOIN DbClassification ON DbClassification.Id = DbClassificationLevel.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1
UNION ALL
SELECT COUNT(*) , 3, 'Classification values' FROM DbClassificationValue  JOIN DbClassification ON DbClassification.Id = DbClassificationValue.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1
UNION ALL
SELECT COUNT(*) , 4, 'Classification pages' FROM DbClassificationPage JOIN DbClassification ON DbClassification.Id = DbClassificationPage.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1
UNION ALL
SELECT COUNT(*) , 5, 'Classification page sections' FROM DbClassificationPageSection JOIN DbClassificationPage ON DbClassificationPage.Id = DbClassificationPageSection.ClassificationPageId JOIN  DbClassification ON DbClassification.Id = DbClassificationPage.ClassificationId WHERE  DbClassification.ClassificationStatusId = 1
UNION ALL 
SELECT COUNT(*) , 6, 'Content types' FROM DbContentType 
UNION ALL 
SELECT COUNT(*) , 7, 'Left menus' FROM dbLeftMenu 
UNION ALL 
SELECT COUNT(*) , 8, 'Menu level 1' FROM dbMenu1
UNION ALL 
SELECT COUNT(*) , 9, 'Menu level 2' FROM dbMenu2
UNION ALL 
SELECT COUNT(*) , 10, 'Menu level 3' FROM dbMenu3
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
) RecordsPerTable ORDER BY Topic
