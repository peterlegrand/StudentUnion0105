DECLARE @CurrentUser uniqueidentifier; 
 
SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com'; 
--DEMO 
 
INSERT INTO dbContentType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 41, 'Knowledge','Knowledge','Knowledge', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbContentType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'Experience','Experience','Experience', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbContentType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  3, 41, 'Assignments','Assignments','Assignments', @CurrentUser, @CurrentUser, getdate(),getdate())  
 
INSERT INTO dbOrganizationType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 41, 'Organization','Organization','Organization', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbOrganizationType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'Department','Department','Department', @CurrentUser, @CurrentUser, getdate(),getdate())  
 
INSERT INTO dbPageSectionType (CreatorId , ModifierId, ModifiedDate, CreatedDate, IndexSection) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate(), 0); 
INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSectionType (CreatorId , ModifierId, ModifiedDate, CreatedDate, IndexSection) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate(), 1); 
INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'Index','Index','Index', @CurrentUser, @CurrentUser, getdate(),getdate())  
 
INSERT INTO dbPageType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbPageTypeLanguage ( PageTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 41, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate())  
 


INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId, ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,41, N'Köppen climate',N'Köppen climate',N'Köppen climate',N'Köppen climate', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2,41, 'Soil','Soil','Soil','Soil', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3,41, 'Crop','Crop','Crop','Crop', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 1, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 41, 'Main climate group','Main climate group','Main climate group','Main climate group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 2, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 41, 'Sub climate group','Sub climate group','Sub climate group','Sub climate group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 3, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 41, '2nd sub climate group','2nd sub climate group','2nd sub climate group','2nd sub climate group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 1, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(4, 41, 'Soil group','Soil group','Soil group','Soil group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 1, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(5, 41, 'Crop group','Crop group','Crop group','Crop group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 2, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(6, 41, 'Crop class','Crop class','Crop class','Crop class', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 3, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(7, 41, 'Crop sub-class','Crop sub-class','Crop sub-class','Crop sub-class', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 4, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, ClassificationLevelName 
, ClassificationLevelMenuName 
, ClassificationLevelDescription 
, ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(8, 41, 'Crop order','Crop order','Crop order','Crop order', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 41, 'A','A: Tropical/megathermal climates','A','A','A: Tropical/megathermal climates' 
, 'A','A: Tropical/megathermal climates','A','A: Tropical/megathermal climates','A' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 41, 'B','B: Dry (desert and semi-arid) climates','B','B','B: Dry (desert and semi-arid) climates' 
, 'B','B: Dry (desert and semi-arid) climates','B','B: Dry (desert and semi-arid) climates','B' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 41, 'C','C: Temperate/mesothermal climates','C','C','C: Temperate/mesothermal climates' 
, 'C','C: Temperate/mesothermal climates','C','C: Temperate/mesothermal climates','C' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(4, 41, 'D','D: Continental/microthermal climates','D','D','D: Continental/microthermal climates' 
, 'D','D: Continental/microthermal climates','D','D: Continental/microthermal climates','D' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(5, 41, 'E','E: Polar climates','E','E','E: Polar climates' 
, 'E','E: Polar climates','E','E: Polar climates','E' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(6, 41, 'Af','Af: Tropical rainforest climate','Af','Af','Af: Tropical rainforest climate' 
, 'Af','Af: Tropical rainforest climate','Af','Af: Tropical rainforest climate','Af' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(7, 41, 'Am','Am: Tropical monsoon climate','Am','Am','Am: Tropical monsoon climate' 
, 'Am','Am: Tropical monsoon climate','Am','Am: Tropical monsoon climate','Am' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(8, 41, 'Aw/As','Aw/As: Tropical savanna climate','Aw/As','Aw/As','Aw/As: Tropical savanna climate' 
, 'Aw/As','Aw/As: Tropical savanna climate','Aw/As','Aw/As: Tropical savanna climate','Aw/As' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,8, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(9, 41, 'Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw','Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics' 
, 'Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,8, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(10, 41, 'As','As: Tropical savanna climate with dry-summer characteristics','As','As','As: Tropical savanna climate with dry-summer characteristics' 
, 'As','As: Tropical savanna climate with dry-summer characteristics','As','As: Tropical savanna climate with dry-summer characteristics','As' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(11, 41, 'BW','BW: Arid Climate','BW','BW','BW: Arid Climate' 
, 'BW','BW: Arid Climate','BW','BW: Arid Climate','BW' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(12, 41, 'BS','BS: Semi-arid (Steppe) Climate','BS','BS','BS: Semi-arid (Steppe) Climate' 
, 'BS','BS: Semi-arid (Steppe) Climate','BS','BS: Semi-arid (Steppe) Climate','BS' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(13, 41, 'Csa','Csa: Mediterranean hot summer climates','Csa','Csa','Csa: Mediterranean hot summer climates' 
, 'Csa','Csa: Mediterranean hot summer climates','Csa','Csa: Mediterranean hot summer climates','Csa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(14, 41, 'Csb','Csb: Mediterranean warm/cool summer climates','Csb','Csb','Csb: Mediterranean warm/cool summer climates' 
, 'Csb','Csb: Mediterranean warm/cool summer climates','Csb','Csb: Mediterranean warm/cool summer climates','Csb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(15, 41, 'Csc','Csc: Mediterranean cold summer climates','Csc','Csc','Csc: Mediterranean cold summer climates' 
, 'Csc','Csc: Mediterranean cold summer climates','Csc','Csc: Mediterranean cold summer climates','Csc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(16, 41, 'Cfa','Cfa: Humid subtropical climates','Cfa','Cfa','Cfa: Humid subtropical climates' 
, 'Cfa','Cfa: Humid subtropical climates','Cfa','Cfa: Humid subtropical climates','Cfa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(17, 41, 'Cfb','Cfb: Oceanic climate','Cfb','Cfb','Cfb: Oceanic climate' 
, 'Cfb','Cfb: Oceanic climate','Cfb','Cfb: Oceanic climate','Cfb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(18, 41, 'Cfc','Cfc: Subpolar oceanic climate','Cfc','Cfc','Cfc: Subpolar oceanic climate' 
, 'Cfc','Cfc: Subpolar oceanic climate','Cfc','Cfc: Subpolar oceanic climate','Cfc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(19, 41, 'Cwa','Cwa: Dry-winter humid subtropical climate','Cwa','Cwa','Cwa: Dry-winter humid subtropical climate' 
, 'Cwa','Cwa: Dry-winter humid subtropical climate','Cwa','Cwa: Dry-winter humid subtropical climate','Cwa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(20, 41, 'Cwb','Cwb: Dry-winter subtropical highland climate','Cwb','Cwb','Cwb: Dry-winter subtropical highland climate' 
, 'Cwb','Cwb: Dry-winter subtropical highland climate','Cwb','Cwb: Dry-winter subtropical highland climate','Cwb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(21, 41, 'Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc','Cwc','Cwc: Dry-winter subpolar oceanic climate' 
, 'Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(22, 41, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates' 
, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(23, 41, 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates' 
, 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates','Dfb/Dwb/Dsb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(24, 41, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates' 
, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(25, 41, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters' 
, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,5, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(26, 41, 'ET','ET: Tundra climate','ET','ET','ET: Tundra climate' 
, 'ET','ET: Tundra climate','ET','ET: Tundra climate','ET' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,5, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(27, 41, 'EF','EF: Ice cap climate','EF','EF','EF: Ice cap climate' 
, 'EF','EF: Ice cap climate','EF','EF: Ice cap climate','EF' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(28, 41, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.' 
, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(29, 41, 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol','Andisol – volcanic ash soils. They are young and very fertile. ' 
, 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(30, 41, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.' 
, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(31, 41, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.' 
, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(32, 41, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.' 
, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(33, 41, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol','Histosol – organic soils, formerly called bog soils.' 
, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol – organic soils, formerly called bog soils.','Histosol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(34, 41, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.' 
, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(35, 41, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.' 
, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(36, 41, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.' 
, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(37, 41, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.' 
, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(38, 41, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.' 
, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, ClassificationValueName 
, ClassificationValueDescription 
, ClassificationValueDropDownName 
, ClassificationValueMenuName 
, ClassificationValueMouseOver 
, ClassificationValuePageName 
, ClassificationValuePageDescription 
, ClassificationValueHeaderName 
, ClassificationValueHeaderDescription 
, ClassificationValueTopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(39, 41, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.' 
, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbProcessTemplateGroup (Sequence, ModifiedDate, CreatedDate)
VALUES(1, getdate(), getdate());
INSERT INTO dbProcessTemplateGroup (Sequence, ModifiedDate, CreatedDate)
VALUES(1, getdate(), getdate());
INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, ProcessTemplateGroupName, ProcessTemplateGroupDescription, ProcessTemplateGroupMouseOver, ModifiedDate, CreatedDate)
VALUES(1, 41, 'Approval', 'Content approval', 'Approval',getdate(), getdate());
INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, ProcessTemplateGroupName, ProcessTemplateGroupDescription, ProcessTemplateGroupMouseOver, ModifiedDate, CreatedDate)
VALUES(2, 41, 'Assignment', 'Assignment', 'Assignment',getdate(), getdate());

INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ModifiedDate, CreatedDate) 
VALUES (1, getdate(), getdate())
INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ModifiedDate, CreatedDate) 
VALUES (1, getdate(), getdate())
INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ModifiedDate, CreatedDate) 
VALUES (2, getdate(), getdate())

INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, ProcessTemplateName, ProcessTemplateDescription, ProcessTemplateMouseOver,  ModifiedDate, CreatedDate) 
VALUES (1, 41, 'Knowledge approval', 'Knowledge approval' , 'Knowledge approval' , getdate(), getdate())
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, ProcessTemplateName, ProcessTemplateDescription, ProcessTemplateMouseOver,  ModifiedDate, CreatedDate) 
VALUES (2, 41, 'Experience approval', 'Experience approval' , 'Experience approval' , getdate(), getdate())
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, ProcessTemplateName, ProcessTemplateDescription, ProcessTemplateMouseOver,  ModifiedDate, CreatedDate) 
VALUES (3, 41, 'Research assignment', 'Research assignment' , 'Research assignment' , getdate(), getdate())

INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (1, 1, 0 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (1, 1, 0 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (1, 1, 0 )

INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (2, 1, 0 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (2, 2, 0 )

INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (3, 1, 0 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, FieldDataTypeId, FieldMasterListId) 
VALUES (3, 2, 0 )

INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (1, 41, 'Knowledge topic','Knowledge topic','Knowledge topic',getdate(),getdate() )
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (2, 41, 'Area of interest','Area of interest','Area of interest',getdate(),getdate() )
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (3, 41, 'Country','Country','Country',getdate(),getdate() )
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (4, 41, 'Experience topic','Experience topic','Experience topic',getdate(),getdate() )
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (5, 41, 'No of days','No of days','No of days',getdate(),getdate() )
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (6, 41, 'Research topic','Research topic','Research topic',getdate(),getdate() )
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, ProcessTemplateFieldName
	, ProcessTemplateFieldDescription
	, ProcessTemplateFieldMouseOver, ModifiedDate, CreatedDate) 
VALUES (7, 41, 'Sample size','Sample size','Sample size',getdate(),getdate() )


 
INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (1)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (1)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (1)

INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (2)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (2)

INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (3)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (3)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId)
VALUES (3)


INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (1, 41, 'Create','Create','Create',getdate(),getdate() )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (2, 41, 'Approve','Approve','Approve',getdate(),getdate() )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (3, 41, 'Inform','Inform','Inform',getdate(),getdate() )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 

VALUES (4, 41, 'Create','Create','Create',getdate(),getdate() )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (5, 41, 'Approve','Approve','Approve',getdate(),getdate() )

INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (6, 41, 'Create','Create','Create',getdate(),getdate() )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (7, 41, 'Approve','Approve','Approve',getdate(),getdate() )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, ProcessTemplateStepName
	, ProcessTemplateStepDescription
	, ProcessTemplateStepMouseOver, ModifiedDate, CreatedDate) 
VALUES (8, 41, 'Inform','Inform','Inform',getdate(),getdate() )

INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,1,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,1,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,1,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,2,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,2,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,2,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,3,1,3);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,3,1,3);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,3,1,3);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,4,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,4,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,5,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,5,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,6,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,6,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,6,1,1);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,7,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,7,1,2);
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,7,1,2);



INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (1,0,1);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (1,1,2);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (1,2,3);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (1,3,0);

INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (2,0,4);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (2,4,5);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (2,5,0);

INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (3,0,6);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (3,6,7);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (3,7,8);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (3,8,0);

INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(1,41,'Creating','Creating','Creating',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(2,41,'Approving','Approving','Approving',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(3,41,'Informing','Informing','Informing',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(4,41,'Completed','Completed','Completed',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(5,41,'Creating','Creating','Creating',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(6,41,'Approving','Approving','Approving',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(7,41,'Completed','Completed','Completed',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(8,41,'Creating','Creating','CreatingInforming',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(9,41,'Approving','Approving','Approving',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(10,41,'Informing','Informing','Informing',getdate(),getdate())
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate)
VALUES(11,41,'Completed','Completed','Completed',getdate(),getdate())
