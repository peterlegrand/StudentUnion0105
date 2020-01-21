DECLARE @CurrentUser uniqueidentifier; 
DECLARE @SecondUser uniqueidentifier; 
 
SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com'; 
SELECT @SecondUser = Id from AspNetUSers Where email = 'pipo@gmail.com'; 
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
VALUES(  1, 41, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSectionType (CreatorId , ModifierId, ModifiedDate, CreatedDate, IndexSection) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate(), 1); 
INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'Index','Index','Index', @CurrentUser, @CurrentUser, getdate(),getdate())  
 
INSERT INTO dbPageType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbPageTypeLanguage ( PageTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 41, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate())  
 


INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId, Name, Description, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,41, N'Köppen climate',N'Köppen climate',N'Köppen climate',N'Köppen climate', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,Name, Description, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2,41, 'Soil','Soil','Soil','Soil', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,Name, Description, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3,41, 'Crop','Crop','Crop','Crop', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 1, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 41, 'Main climate group','Main climate group','Main climate group','Main climate group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 2, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 41, 'Sub climate group','Sub climate group','Sub climate group','Sub climate group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 3, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 41, '2nd sub climate group','2nd sub climate group','2nd sub climate group','2nd sub climate group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 1, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(4, 41, 'Soil group','Soil group','Soil group','Soil group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 1, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(5, 41, 'Crop group','Crop group','Crop group','Crop group', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown,InMenu,  CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 2, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(6, 41, 'Crop class','Crop class','Crop class','Crop class', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 3, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(7, 41, 'Crop sub-class','Crop sub-class','Crop sub-class','Crop sub-class', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, InMenu, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 4, 0,0,1,0,1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(8, 41, 'Crop order','Crop order','Crop order','Crop order', @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
  INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 41, 'A','A: Tropical/megathermal climates','A','A','A: Tropical/megathermal climates' 
, 'A','A: Tropical/megathermal climates','A','A: Tropical/megathermal climates','A' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 41, 'B','B: Dry (desert and semi-arid) climates','B','B','B: Dry (desert and semi-arid) climates' 
, 'B','B: Dry (desert and semi-arid) climates','B','B: Dry (desert and semi-arid) climates','B' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 41, 'C','C: Temperate/mesothermal climates','C','C','C: Temperate/mesothermal climates' 
, 'C','C: Temperate/mesothermal climates','C','C: Temperate/mesothermal climates','C' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(4, 41, 'D','D: Continental/microthermal climates','D','D','D: Continental/microthermal climates' 
, 'D','D: Continental/microthermal climates','D','D: Continental/microthermal climates','D' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(5, 41, 'E','E: Polar climates','E','E','E: Polar climates' 
, 'E','E: Polar climates','E','E: Polar climates','E' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(6, 41, 'Af','Af: Tropical rainforest climate','Af','Af','Af: Tropical rainforest climate' 
, 'Af','Af: Tropical rainforest climate','Af','Af: Tropical rainforest climate','Af' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(7, 41, 'Am','Am: Tropical monsoon climate','Am','Am','Am: Tropical monsoon climate' 
, 'Am','Am: Tropical monsoon climate','Am','Am: Tropical monsoon climate','Am' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(8, 41, 'Aw/As','Aw/As: Tropical savanna climate','Aw/As','Aw/As','Aw/As: Tropical savanna climate' 
, 'Aw/As','Aw/As: Tropical savanna climate','Aw/As','Aw/As: Tropical savanna climate','Aw/As' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,8, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(9
, 41
, 'Aw'
,'Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics'
,'Aw'
,'Aw'
,'Aw' 
, 'Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,8, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(10, 41, 'As','As: Tropical savanna climate with dry-summer characteristics','As','As'
,'As' 
, 'As','As: Tropical savanna climate with dry-summer characteristics','As','As: Tropical savanna climate with dry-summer characteristics','As' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(11, 41, 'BW','BW: Arid Climate','BW','BW','BW: Arid Climate' 
, 'BW','BW: Arid Climate','BW','BW: Arid Climate','BW' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(12, 41, 'BS','BS: Semi-arid (Steppe) Climate','BS','BS','BS: Semi-arid (Steppe) Climate' 
, 'BS','BS: Semi-arid (Steppe) Climate','BS','BS: Semi-arid (Steppe) Climate','BS' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(13, 41, 'Csa','Csa: Mediterranean hot summer climates','Csa','Csa','Csa: Mediterranean hot summer climates' 
, 'Csa','Csa: Mediterranean hot summer climates','Csa','Csa: Mediterranean hot summer climates','Csa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(14, 41, 'Csb','Csb: Mediterranean warm/cool summer climates','Csb','Csb','Csb: Mediterranean warm/cool summer climates' 
, 'Csb','Csb: Mediterranean warm/cool summer climates','Csb','Csb: Mediterranean warm/cool summer climates','Csb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(15, 41, 'Csc','Csc: Mediterranean cold summer climates','Csc','Csc','Csc: Mediterranean cold summer climates' 
, 'Csc','Csc: Mediterranean cold summer climates','Csc','Csc: Mediterranean cold summer climates','Csc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(16, 41, 'Cfa','Cfa: Humid subtropical climates','Cfa','Cfa','Cfa: Humid subtropical climates' 
, 'Cfa','Cfa: Humid subtropical climates','Cfa','Cfa: Humid subtropical climates','Cfa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(17, 41, 'Cfb','Cfb: Oceanic climate','Cfb','Cfb','Cfb: Oceanic climate' 
, 'Cfb','Cfb: Oceanic climate','Cfb','Cfb: Oceanic climate','Cfb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(18, 41, 'Cfc','Cfc: Subpolar oceanic climate','Cfc','Cfc','Cfc: Subpolar oceanic climate' 
, 'Cfc','Cfc: Subpolar oceanic climate','Cfc','Cfc: Subpolar oceanic climate','Cfc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(19, 41, 'Cwa','Cwa: Dry-winter humid subtropical climate','Cwa','Cwa','Cwa: Dry-winter humid subtropical climate' 
, 'Cwa','Cwa: Dry-winter humid subtropical climate','Cwa','Cwa: Dry-winter humid subtropical climate','Cwa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(20, 41, 'Cwb','Cwb: Dry-winter subtropical highland climate','Cwb','Cwb','Cwb: Dry-winter subtropical highland climate' 
, 'Cwb','Cwb: Dry-winter subtropical highland climate','Cwb','Cwb: Dry-winter subtropical highland climate','Cwb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(21, 41, 'Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc','Cwc','Cwc: Dry-winter subpolar oceanic climate' 
, 'Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(22, 41, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates' 
, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId --1
, LanguageId --2
, Name --3
, Description  --4 
, DropDownName --5
, MenuName --6
, MouseOver --7
, PageName --8
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(23--1
, 41
, 'Dfb/Dwb/Dsb'
,'Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates'
,'Dfb/Dwb/Dsb'
,'Dfb/Dwb/Dsb'
,'Dfb/Dwb/Dsb' 
, 'Dfb/Dwb/Dsb'
,'Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates'
,'Dfb/Dwb/Dsb'
,'Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates'
,'Dfb/Dwb/Dsb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(24, 41, 'Dfc/Dwc/Dsc'
,'Dfc/Dwc/Dsc: Subarctic or boreal climates'
,'Dfc/Dwc/Dsc'
,'Dfc/Dwc/Dsc'
,'Dfc/Dwc/Dsc' 
, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(25, 41
, 'Dfd/Dwd/Dsd'
,'Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters'
,'Dfd/Dwd/Dsd'
,'Dfd/Dwd/Dsd'
,'Dfd/Dwd/Dsd' 
, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,5, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(26, 41, 'ET','ET: Tundra climate','ET','ET','ET' 
, 'ET','ET: Tundra climate','ET','ET: Tundra climate','ET' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,5, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(27, 41, 'EF','EF: Ice cap climate','EF','EF','EF' 
, 'EF','EF: Ice cap climate','EF','EF: Ice cap climate','EF' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(28, 41, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol','Alfisol' 
, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(29, 41, 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol','Andisol ' 
, 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(30, 41, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol','Aridisol' 
, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(31, 41, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol','Entisol' 
, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(32, 41, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol','Gelisol' 
, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(33, 41, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol','Histosol' 
, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol – organic soils, formerly called bog soils.','Histosol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(34, 41, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol','Inceptisol' 
, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(35, 41, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol','Mollisol' 
, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(36, 41, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol','Oxisol' 
, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(37, 41, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol','Spodosol' 
, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(38, 41, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol','Ultisol' 
, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationValueLanguage ( 
ClassificationValueId 
, LanguageId 
, Name 
, Description 
, DropDownName 
, MenuName 
, MouseOver 
, PageName 
, PageDescription 
, HeaderName 
, HeaderDescription 
, TopicName 
, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(39, 41, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol','Vertisol' 
, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
 
 
INSERT INTO dbProcessTemplateGroup (Sequence, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1, getdate(), getdate(), @CurrentUser, @CurrentUser);
INSERT INTO dbProcessTemplateGroup (Sequence, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1, getdate(), getdate(), @CurrentUser, @CurrentUser);
INSERT INTO dbProcessTemplateGroup (Sequence, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1, getdate(), getdate(), @CurrentUser, @CurrentUser);
INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1, 41, 'Approval', 'Content approval', 'Approval',getdate(), getdate(), @CurrentUser, @CurrentUser);
INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(2, 41, 'Assignment', 'Assignment', 'Assignment',getdate(), getdate(), @CurrentUser, @CurrentUser);
INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(3, 41, 'Calendar', 'Calendar', 'Calendar',getdate(), getdate(), @CurrentUser, @CurrentUser);

INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ShowInPersonalCalendar, ShowInEventCalendar, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 0, 0, getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ShowInPersonalCalendar, ShowInEventCalendar, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 0, 0, getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ShowInPersonalCalendar, ShowInEventCalendar, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 0, 0, getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ShowInPersonalCalendar, ShowInEventCalendar, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 1, 0, getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplate (ProcessTemplateGroupId, ShowInPersonalCalendar, ShowInEventCalendar, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 0, 1, getdate(), getdate(), @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 41, 'Knowledge approval', 'Knowledge approval' , 'Knowledge approval' , getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 41, 'Experience approval', 'Experience approval' , 'Experience approval' , getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 41, 'Research assignment', 'Research assignment' , 'Research assignment' , getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (4, 41, 'Appointment', 'Appointment' , 'Appointment' , getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (5, 41, 'Event', 'Event' , 'Event' , getdate(), getdate(), @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 1)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 1)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 1)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 10 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (1, 9 )

INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (2, 1 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (2, 2)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (2, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (2, 10 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (2, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (2, 9 )

INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (3, 1)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (3, 2)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (3, 9)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (3, 10 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (3, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (3, 9)

INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 1)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 11)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 3)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 9)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 10 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (4, 9)

INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (5, 1)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (5, 3)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (5, 9)
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (5, 10 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (5, 9 )
INSERT INTO dbProcessTemplateField (ProcessTemplateId, ProcessTemplateFieldTypeId) 
VALUES (5, 9)


INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 41, 'Knowledge topic','Knowledge topic','Knowledge topic',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 41, 'Area of interest','Area of interest','Area of interest',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 41, 'Country','Country','Country',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (4, 41, 'Submit','Submit','Submit',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (5, 41, 'Cancel','Cancel','Cancel',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (6, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (7, 41, 'Reject','Reject','Reject',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (8, 41, 'Experience topic','Experience topic','Experience topic',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (9, 41, 'No of days','No of days','No of days',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (10, 41, 'Submit','Submit','Submit',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (11, 41, 'Cancel','Cancel','Cancel',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (12, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (13, 41, 'Reject','Reject','Reject',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (14, 41, 'Research topic','Research topic','Research topic',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (15, 41, 'Sample size','Sample size','Sample size',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (16, 41, 'Submit','Submit','Submit',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (17, 41, 'Cancel','Cancel','Cancel',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (18, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (19, 41, 'Reject','Reject','Reject',getdate(),getdate() , @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (20, 41, 'Appointment topic','Appointment topic','Appointment topic',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (20, 41, 'User','User','User',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (21, 41, 'Appointment date','Appointment date','Appointment date',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (22, 41, 'Submit','Submit','Submit',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (23, 41, 'Cancel','Cancel','Cancel',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (24, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (25, 41, 'Reject','Reject','Reject',getdate(),getdate() , @CurrentUser, @CurrentUser)


INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (26, 41, 'Event topic','Event topic','Event topic',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (27, 41, 'Event date','Event date','Event date',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (28, 41, 'Submit','Submit','Submit',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (29, 41, 'Cancel','Cancel','Cancel',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (30, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (31, 41, 'Reject','Reject','Reject',getdate(),getdate() , @CurrentUser, @CurrentUser)



 
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (1,2)  
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (1,3)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (1,4)

INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (2,2)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (2,4)

INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (3,2)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (3,3)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (3,4)


INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (4,2)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (4,3)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (4,4)


INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (5,2)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (5,3)
INSERT INTO dbProcessTemplateStep (ProcessTemplateId, ProcessTemplateStepTypeId)
VALUES (5,4)


INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 41, 'Create','Create','Create',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 41, 'Inform','Inform','Inform',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 

VALUES (4, 41, 'Create','Create','Create',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (5, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (6, 41, 'Create','Create','Create',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (7, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (8, 41, 'Inform','Inform','Inform',getdate(),getdate() , @CurrentUser, @CurrentUser)


INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (9, 41, 'Create','Create','Create',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (10, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (11, 41, 'Inform','Inform','Inform',getdate(),getdate() , @CurrentUser, @CurrentUser)


INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (12, 41, 'Create','Create','Create',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (13, 41, 'Approve','Approve','Approve',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (14, 41, 'Inform','Inform','Inform',getdate(),getdate() , @CurrentUser, @CurrentUser)


-- Flow 1
-- Step: Create  
-- Field: Knowledge topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,1,2,1);
-- Step: Create  
-- Field: Area of interest
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,2,3,2);
-- Step: Create  
-- Field: Country
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,3,4,3);
-- Step: Create  
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,4,3,4);
-- Step: Create  
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,5,3,5);
-- Step: Create  
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,6,1,6);
-- Step: Create  
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (1,7,1,7);
-- Step: Approval 
-- Field: Knowledge topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,1,2,1);
-- Step: Approval
-- Field: Area of interest
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,2,2,2);
-- Step: Approval
-- Field: Country
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,3,2,3);
-- Step: Approval
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,4,1,4);
-- Step: Approval
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,5,3,7);
-- Step: Approval
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,6,3,5);
-- Step: Approval
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (2,7,3,6);
-- Step: Inform 
-- Field: Knowledge topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,1,2,1);
-- Step: Inform
-- Field: Area of interest
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,2,2,2);
-- Step: Inform  
-- Field: Country
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,3,2,3);
-- Step: Inform  
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,4,3,4);
-- Step: Inform  
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,5,3,5);
-- Step: Inform  
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,6,1,6);
-- Step: Inform  
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (3,7,1,7);

-- Flow 2
-- Step: Create  
-- Field: Experience topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,8,3,1);
-- Step: Create  
-- Field: No of days
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,9,3,2);
-- Step: Create  
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,10,3,3);
-- Step: Create  
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,11,3,4);
-- Step: Create  
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,12,1,5);
-- Step: Create  
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (4,13,1,6);
-- Step: Approval  
-- Field: Experience topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,8,2,1);
-- Step: Approval
-- Field: No of days
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,9,2,2);
-- Step: Approval
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,10,1,3);
-- Step: Approval
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,11,1,4);
-- Step: Approval
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,12,3,5);
-- Step: Approval
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (5,13,3,5);


-- Flow 3
-- Step: Create  
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,14,3,1);
-- Step: Create  
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,15,3,2);
-- Step: Create  
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,16,3,3);
-- Step: Create  
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,17,3,4);
-- Step: Create  
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,18,1,5);
-- Step: Create  
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (6,19,1,6);
-- Step: Approval  
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,14,2,1);
-- Step: Approval
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,15,2,2);
-- Step: Approval
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,16,1,3);
-- Step: Approval
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,17,1,4);
-- Step: Approval
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,18,3,5);
-- Step: Approval
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (7,19,3,6);
-- Step: Inform 
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,14,2,1);
-- Step: Inform
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,15,2,2);
-- Step: Inform
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,16,3,3);
-- Step: Inform
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,17,3,4);
-- Step: Inform
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,18,1,5);
-- Step: Inform
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (8,19,1,6);



-- Flow 4
-- Step: Create  
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,20,3,1);
-- Step: Create  
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,21,3,1);
-- Step: Create  
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,22,3,2);
-- Step: Create  
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,23,3,3);
-- Step: Create  
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,24,3,4);
-- Step: Create  
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,25,1,5);
-- Step: Create  
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,26,1,6);
-- Step: Approval  
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,20,2,1);
-- Step: Approval
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,21,2,1);
-- Step: Approval
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,22,2,2);
-- Step: Approval
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,23,1,3);
-- Step: Approval
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,24,1,4);
-- Step: Approval
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,25,3,5);
-- Step: Approval
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,26,3,6);
-- Step: Inform 
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,20,2,1);
-- Step: Inform
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,21,2,1);
-- Step: Inform
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,22,2,2);
-- Step: Inform
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,23,3,3);
-- Step: Inform
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,24,3,4);
-- Step: Inform
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,25,1,5);
-- Step: Inform
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,26,1,6);




-- Flow 4
-- Step: Create  
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,27,3,1);
-- Step: Create  
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,28,3,2);
-- Step: Create  
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,29,3,3);
-- Step: Create  
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,30,3,4);
-- Step: Create  
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,31,1,5);
-- Step: Create  
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (9,32,1,6);
-- Step: Approval  
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,27,2,1);
-- Step: Approval
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,28,2,2);
-- Step: Approval
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,29,1,3);
-- Step: Approval
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,30,1,4);
-- Step: Approval
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,31,3,5);
-- Step: Approval
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (10,32,3,6);
-- Step: Inform 
-- Field: Research topic
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,27,2,1);
-- Step: Inform
-- Field: Sample size
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,28,2,2);
-- Step: Inform
-- Field: Submit
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,29,3,3);
-- Step: Inform
-- Field: Cancel
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,30,3,4);
-- Step: Inform
-- Field: Approve
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,31,1,5);
-- Step: Inform
-- Field: Reject
INSERT INTO dbProcessTemplateStepField (StepId, FieldId, StatusId, Sequence)
VALUES (11,32,1,6);


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

INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (4,0,9);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (4,9,10);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (4,10,11);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (4,11,0);

INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (5,0,12);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (5,12,13);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (5,13,14);
INSERT INTO dbProcessTemplateFlow (ProcessTemplateId, ProcessTemplateFromStepId, ProcessTemplateToStepId)
VALUES (5,14,0);

INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1,41,'Creating','Creating','Creating',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(2,41,'Approving','Approving','Approving',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(3,41,'Informing','Informing','Informing',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(4,41,'Completed','Completed','Completed',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(5,41,'Creating','Creating','Creating',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(6,41,'Approving','Approving','Approving',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(7,41,'Completed','Completed','Completed',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(8,41,'Creating','Creating','CreatingInforming',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(9,41,'Approving','Approving','Approving',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(10,41,'Informing','Informing','Informing',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(11,41,'Completed','Completed','Completed',getdate(),getdate(), @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(12,41,'Creating','Creating','CreatingInforming',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(13,41,'Approving','Approving','Approving',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(14,41,'Informing','Informing','Informing',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(15,41,'Completed','Completed','Completed',getdate(),getdate(), @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(16,41,'Creating','Creating','CreatingInforming',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(17,41,'Approving','Approving','Approving',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(18,41,'Informing','Informing','Informing',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(19,41,'Completed','Completed','Completed',getdate(),getdate(), @CurrentUser, @CurrentUser)


INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId)
VALUES (1, 9); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionString)
VALUES (1, 4, 1, 1, 'Admin'); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId)
VALUES (1, 10); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionInt)
VALUES (1, 3, 4, 2, 5); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId)
VALUES (1, 12); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId)
VALUES (1, 11); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionInt)
VALUES (1, 3, 4, 2, 10); 

INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionInt)
VALUES (5, 3, 4, 2, 10); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionInt)
VALUES (8, 3, 4, 2, 10); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionInt)
VALUES (12, 3, 4, 2, 10); 
INSERT dbProcessTemplateFlowCondition (
	ProcessTemplateFlowId
	, ProcessTemplateConditionTypeId
	, ComparisonOperatorId
	, DataTypeId
	, ProcessTemplateFlowConditionInt)
VALUES (16, 3, 4, 2, 10); 


INSERT dbProcessTemplateFlowCondition (ProcessTemplateFlowId, ProcessTemplateConditionTypeId)
VALUES (2, 14); 


INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (1,41,'Open bracket','Open bracket','Open bracket',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (2,41,'Admin','Admin','Admin',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (3,41,'And','And','And',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (4,41,'5 or higher','5 or higher','5 or higher',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (5,41,'Closing bracket','Closing bracket','Closing bracket',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (6,41,'Or','Or','Or',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (7,41,'10 or higher','10 or higher','10 or higher',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (8,41,'Teacher approver','Teacher approver','Teacher approver',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (9,41,'10 or higher','10 or higher','10 or higher',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (10,41,'10 or higher','10 or higher','10 or higher',getdate(),getdate(), @CurrentUser, @CurrentUser)

SET IDENTITY_INSERT dbUITermLanguage ON;
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(1, 1, 41, 'Properties');
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(2, 2, 41, 'Id #');
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(3, 3, 41, 'Unique name');
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(4, 4, 41, 'Add new property');

SET IDENTITY_INSERT dbUITermLanguage OFF;



SET IDENTITY_INSERT dbUserRelationType ON;
INSERT INTO dbUserRelationType (Id, Name, Description) VALUES(1, 'Teacher/Student', 'Teacher/Student');
INSERT INTO dbUserRelationType (Id, Name, Description) VALUES(2, 'Principal/Teacher', 'Principal/Teacher');

SET IDENTITY_INSERT dbUserRelationType OFF;


SET IDENTITY_INSERT dbUserRelationTypeLanguage ON;
INSERT INTO dbUserRelationTypeLanguage (Id, TypeId, LanguageId, FromIsOfToName, ToIsOfFromName, FromIsOfToDescription, ToIsOfFromDescription, FromIsOfToMenuName, ToIsOfFromMenuName, FromIsOfToMouseOver, ToIsOfFromMouseOver, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, 1, 41, 'Student', 'Teacher', 'Student', 'Teacher','Student', 'Teacher', 'Student', 'Teacher', @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbUserRelationTypeLanguage (Id, TypeId, LanguageId, FromIsOfToName, ToIsOfFromName, FromIsOfToDescription, ToIsOfFromDescription, FromIsOfToMenuName, ToIsOfFromMenuName, FromIsOfToMouseOver, ToIsOfFromMouseOver, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, 2, 41, 'Teacher', 'Principle', 'Teacher', 'Principle','Teacher', 'Principle','Teacher', 'Principle',@CurrentUser, @CurrentUser, getdate(), getdate());

SET IDENTITY_INSERT dbUserRelationTypeLanguage OFF;

SET IDENTITY_INSERT dbOrganization ON;
INSERT INTO dbOrganization (Id, OrganizationStatusId, OrganizationTypeId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, 1, 1 , @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbOrganization (Id, ParentOrganizationId,OrganizationStatusId, OrganizationTypeId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, 1, 1, 2 , @CurrentUser, @CurrentUser, getdate(), getdate());

SET IDENTITY_INSERT dbOrganization OFF;

SET IDENTITY_INSERT dbOrganizationLanguage ON;
INSERT INTO dbOrganizationLanguage (Id, OrganizationId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, 1, 41, 'Chulalongkorn University','Chulalongkorn University','Chulalongkorn University',  @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbOrganizationLanguage (Id, OrganizationId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, 2, 41, 'Faculty of medicine','Faculty of medicine','Faculty of medicine',  @CurrentUser, @CurrentUser, getdate(), getdate());

SET IDENTITY_INSERT dbOrganizationLanguage OFF;

SET IDENTITY_INSERT dbProject ON;
INSERT INTO dbProject (Id, ProjectStatusId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, 1, @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbProject (Id, ParentProjectId,ProjectStatusId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, 1, 1 , @CurrentUser, @CurrentUser, getdate(), getdate());
SET IDENTITY_INSERT dbProject OFF;

SET IDENTITY_INSERT dbProjectLanguage ON;
INSERT INTO dbProjectLanguage (Id, ProjectId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, 1, 41, 'Zero Waste','Zero Waste','Zero Waste',  @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbProjectLanguage (Id, ProjectId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, 2, 41, 'Clean up beach 2019','Clean up beach 2019','Clean up beach 2019',  @CurrentUser, @CurrentUser, getdate(), getdate());

SET IDENTITY_INSERT dbProjectLanguage OFF;

SET IDENTITY_INSERT dbUserOrganization ON;
INSERT INTO dbUserOrganization (Id, UserId, OrganizationId, TypeId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, @CurrentUser, 1, 1,  @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbUserOrganization (Id, UserId, OrganizationId, TypeId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, @CurrentUser, 2, 2,  @CurrentUser, @CurrentUser, getdate(), getdate());
SET IDENTITY_INSERT dbUserOrganization OFF;


SET IDENTITY_INSERT dbUserProject ON;
INSERT INTO dbUserProject (Id, UserId, ProjectId, TypeId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(1, @CurrentUser, 1, 1,  @CurrentUser, @CurrentUser, getdate(), getdate());
INSERT INTO dbUserProject (Id, UserId, ProjectId, TypeId, CreatorId, ModifierId, ModifiedDate, CreatedDate) 
VALUES(2, @CurrentUser, 2, 2,  @CurrentUser, @CurrentUser, getdate(), getdate());
SET IDENTITY_INSERT dbUserProject OFF;

INSERT INTO dbPage (PageStatusId, PageTypeId, ShowTitleName, ShowTitleDescription, CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(1, 1, 1, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbPageLanguage ( PageId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 41, 'News page','New page','New page','New page','New page','New page', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPage (PageStatusId, PageTypeId, ShowTitleName, ShowTitleDescription,CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(1, 1, 1, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbPageLanguage ( PageId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'General','General','General','General','General','General', @CurrentUser, @CurrentUser, getdate(),getdate())  

INSERT INTO dbPageSection (PageId, Sequence, PageSectionTypeId, ShowSectionTitleName, ShowSectionTitleDescription, ShowContentTypeTitle, ShowContentTypeDescription, OneTwoColumns, ContentTypeId, SortById, MaxContent, HasPaging) 
VALUES(1, 1, 1, 1, 1, 0, 0, 2, 1, 1, 5, 1); 
INSERT INTO dbPageSectionLanguage ( PageSectionId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 41, 'New knowledge','New knowledge','New knowledge','New knowledge','New knowledge','New knowledge', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSection (PageId, Sequence, PageSectionTypeId, ShowSectionTitleName, ShowSectionTitleDescription, ShowContentTypeTitle, ShowContentTypeDescription, OneTwoColumns, ContentTypeId, SortById, MaxContent, HasPaging) 
VALUES(1, 1, 1, 1, 1, 0, 0, 2, 2, 1, 5, 1); 
INSERT INTO dbPageSectionLanguage ( PageSectionId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 41, 'New knowledge','New knowledge','New knowledge','New knowledge','New knowledge','New knowledge', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSection (PageId, Sequence, PageSectionTypeId, ShowSectionTitleName, ShowSectionTitleDescription, ShowContentTypeTitle, ShowContentTypeDescription, OneTwoColumns, ContentTypeId, SortById, MaxContent, HasPaging) 
VALUES(2, 1, 1, 1, 1, 0, 0, 2, 3, 1, 5, 1); 
INSERT INTO dbPageSectionLanguage ( PageSectionId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  3, 41, 'Assignments','Assignments','Assignments','Assignments','Assignments','Assignments', @CurrentUser, @CurrentUser, getdate(),getdate())  


INSERT INTO dbContent (ContentTypeId, ContentStatusId, LanguageId, Title, Description, SecurityLevel, OrganizationId, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (3,4,41,'Solar installation site assignment', 'This is the assignment for site survey for an installation of a solar array',1,1, @CurrentUser, @CurrentUser, getdate(), getdate())
INSERT INTO dbContent (ContentTypeId, ContentStatusId, LanguageId, Title, Description, SecurityLevel, OrganizationId, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (3,4,41,'Agriculture in a circular model', 'Assignment on how to make use of the circular concept in agriculture',1,1, @CurrentUser, @CurrentUser, getdate(), getdate())
INSERT INTO dbContent (ContentTypeId, ContentStatusId, LanguageId, Title, Description, SecurityLevel, OrganizationId, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (3,4,41,'Tropical climate', '<p></p><div class="pasteContent" style="display:inline;">    <!--StartFragment--><p style="margin: 0.5em 0px; color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">A<span>&nbsp;</span><b>tropical climate</b><span>&nbsp;</span>in the<span>&nbsp;</span><a href="https://en.wikipedia.org/wiki/K%C3%B6ppen_climate_classification" title="Köppen climate classification" style="text-decoration: none; color: rgb(11, 0, 128); background: none;">Köppen climate classification</a><span>&nbsp;</span>is a non-<a href="https://en.wikipedia.org/wiki/Arid" title="Arid" style="text-decoration: none; color: rgb(11, 0, 128); background: none;">arid</a><span>&nbsp;</span>climate in which all twelve months have mean temperatures warmer than 18&nbsp;°C (64&nbsp;°F). Tropical climates are normally found from the equator to 25 north and south latitude. Tropical climates are typically frost-free, and changes in the solar angle are small since they occupy low latitudes. In tropical climates, the temperature remains relatively constant (hot) throughout the year. Sunlight is intense.<img class="e-rte-image e-imginline" width="auto" height="auto" alt="TropicalClimate.png" src="/Images/Content/TropicalClimate.png" style="min-width: 0px; min-height: 0px;"></p><p style="margin: 0.5em 0px; color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">In<span>&nbsp;</span><a href="https://en.wikipedia.org/wiki/Tropical" class="mw-redirect" title="Tropical" style="text-decoration: none; color: rgb(11, 0, 128); background: none;">tropical</a><span>&nbsp;</span>climates there are often only two seasons: a wet season and a dry season. The wet season normally occurs at the time of high-sun (which is from May through September in the Northern Hemisphere, and from November to March in the Southern Hemisphere). The dry season often occurs at the time of low sun (November to March in the Northern Hemisphere, and from May to September in the Southern Hemisphere).</p><!--EndFragment-->    </div><br><p></p>',1,1, @CurrentUser, @CurrentUser, getdate(), getdate())
INSERT INTO dbContent (ContentTypeId, ContentStatusId, LanguageId, Title, Description, SecurityLevel, OrganizationId, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (3,4,41,'Tropical rainforest climate', '<p></p><div class="pasteContent" style="display:inline;">    <!--StartFragment--><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">A<span>&nbsp;</span></span><b style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">tropical rainforest climate</b><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>is a<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/Tropical_climate" title="Tropical climate" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">tropical climate</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>usually found within 10 to 15 degrees latitude of the<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/Equator" title="Equator" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">equator</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">, and has at least 50 mm (2 inches) of rainfall every month of the year. Regions with this climate are typically designated<span>&nbsp;</span></span><i style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">Af</i><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>by the<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/K%C3%B6ppen_climate_classification" title="Köppen climate classification" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">Köppen climate classification</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">. A tropical rainforest climate is typically hot, very humid and wet.</span><!--EndFragment-->    </div><br><p></p><p></p><div class="pasteContent" style="display:inline;"><img class="e-rte-image e-imginline" width="auto" height="auto" alt="tropicalrainforestclimate.png" src="/Images/Content/tropicalrainforestclimate.png" style="min-width: 0px; min-height: 0px;"><br></div><p></p>',1,1, @CurrentUser, @CurrentUser, getdate(), getdate())
INSERT INTO dbContent (ContentTypeId, ContentStatusId, LanguageId, Title, Description, SecurityLevel, OrganizationId, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (3,4,41,'Tropical monsoon climate', '<p></p><div class="pasteContent" style="display:inline;">    <!--StartFragment--><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">An<span>&nbsp;</span></span><b style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">area of tropical monsoon climate</b><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>(occasionally known as a<span>&nbsp;</span></span><b style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">tropical wet climate</b><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>or a<span>&nbsp;</span></span><b style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">tropical monsoon and trade-wind littoral climate</b><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">) is a type of<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/Climate" title="Climate" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">climate</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>that corresponds to the<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/K%C3%B6ppen_climate_classification" title="Köppen climate classification" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">Köppen climate classification</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>category "Am". Tropical monsoon climates have monthly mean temperatures above 18&nbsp;°C (64&nbsp;°F) in every month of the year and a dry season.<span>&nbsp;</span></span><sup id="cite_ref-McKnight_1-0" class="reference" style="line-height: 1; white-space: nowrap; font-weight: 400; font-style: normal; font-size: 11.2px; color: rgb(34, 34, 34); font-family: sans-serif; text-align: start; text-indent: 0px; background-color: rgb(255, 255, 255);"><a href="https://en.wikipedia.org/wiki/Tropical_monsoon_climate#cite_note-McKnight-1" style="text-decoration: none; color: rgb(11, 0, 128); background: none;">[1]</a></sup><sup class="reference" style="line-height: 1; white-space: nowrap; font-weight: 400; font-style: normal; font-size: 11.2px; color: rgb(34, 34, 34); font-family: sans-serif; text-align: start; text-indent: 0px; background-color: rgb(255, 255, 255);">:<span>200–1</span></sup><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>Tropical monsoon climates is the intermediate climate between the wet Af (or<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/Tropical_rainforest_climate" title="Tropical rainforest climate" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">tropical rainforest climate</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">) and the drier Aw (or<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/Tropical_savanna_climate" title="Tropical savanna climate" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">tropical savanna climate</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;">).</span><!--EndFragment-->    </div><br><p></p><div><div class="pasteContent" style="display:inline;"><img class="e-rte-image e-imginline" width="auto" height="auto" alt="Tropicalmonsoonclimate.png" src="/Images/Content/Tropicalmonsoonclimate.png" style="min-width: 0px; min-height: 0px;"><br></div></div>',1,1, @CurrentUser, @CurrentUser, getdate(), getdate())
INSERT INTO dbContent (ContentTypeId, ContentStatusId, LanguageId, Title, Description, SecurityLevel, OrganizationId, CreatorId, ModifierId, ModifiedDate, CreatedDate)
VALUES (3,4,41,'Tropical savanna climate', '<p></p><div class="pasteContent" style="display:inline;">    <!--StartFragment--><b style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">Tropical savanna climate</b><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>or<span>&nbsp;</span></span><b style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255);">tropical wet and dry climate</b><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>is a type of<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/Climate" title="Climate" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">climate</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>that corresponds to the<span>&nbsp;</span></span><a href="https://en.wikipedia.org/wiki/K%C3%B6ppen_climate_classification" title="Köppen climate classification" style="text-decoration: none; color: rgb(11, 0, 128); background: none rgb(255, 255, 255); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal;">Köppen climate classification</a><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><span>&nbsp;</span>categories "Aw" and "As". Tropical savanna climates have monthly mean temperatures above 18 °C (64 °F) in every month of the year and typically a pronounced dry season, with the driest month having less than 60 mm (2.36 inches) of precipitation.</span></div><br><p></p><div><div class="pasteContent" style="display:inline;"><span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-weight: 400; text-align: start; text-indent: 0px; white-space: normal; background-color: rgb(255, 255, 255); display: inline !important; float: none;"><img class="e-rte-image e-imginline" width="auto" height="auto" alt="Tropicalsavannaclimate.png" src="/Images/Content/Tropicalsavannaclimate.png" style="min-width: 0px; min-height: 0px;"><br></span></div></div>',1,1, @CurrentUser, @CurrentUser, getdate(), getdate())

INSERT INTO DbContentClassificationValue (ContentId, ClassificationValueId) VALUES (3,1)
INSERT INTO DbContentClassificationValue (ContentId, ClassificationValueId) VALUES (4,6)
INSERT INTO DbContentClassificationValue (ContentId, ClassificationValueId) VALUES (5,7)
INSERT INTO DbContentClassificationValue (ContentId, ClassificationValueId) VALUES (6,8)

INSERT INTO dbClassificationPage (ClassificationId, StatusId, ShowTitleName, ShowTitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 1, 1, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationPageLanguage ( 
ClassificationPageId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver
, TitleName
, TitleDescription, 
CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 41, 'Climate page','Climate page','Climate page','Climate page','Page about different climates','This page shows general information on climate', @CurrentUser, @CurrentUser, getdate(), getdate()); 

INSERT INTO dbClassificationPage (ClassificationId, StatusId, ShowTitleName, ShowTitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 1, 1, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationPageLanguage ( 
ClassificationPageId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver
, TitleName
, TitleDescription, 
CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 41, 'Soil page','Soil page','Soil page','Soil page','Page about different soils','This page shows general information on soils', @CurrentUser, @CurrentUser, getdate(), getdate()); 

INSERT INTO dbClassificationPage (ClassificationId, StatusId, ShowTitleName, ShowTitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 1, 1, 1, @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationPageLanguage ( 
ClassificationPageId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver
, TitleName
, TitleDescription, 
CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 41, 'Crop page','Crop page','Crop page','Crop page','Page about different crops','This page shows general information on crops', @CurrentUser, @CurrentUser, getdate(), getdate()); 

SELECT * FROM dbClassificationPageSection
INSERT INTO dbClassificationPageSection (
ClassificationPageId
, Sequence
, SectionTypeId
, ShowSectionTitleName
, ShowSectionTitleDescription
, ShowContentTypeTitleName
, ShowContentTypeTitleDescription
, OneTwoColumns
, SortById
, MaxContent
, HasPaging)  
VALUES(1, 1, 1, 1, 1, 0, 0, 1, 1, 5, 1); 

INSERT INTO dbClassificationPageSection (
ClassificationPageId
, Sequence
, SectionTypeId
, ShowSectionTitleName
, ShowSectionTitleDescription
, ShowContentTypeTitleName
, ShowContentTypeTitleDescription
, OneTwoColumns
, SortById
, MaxContent
, HasPaging)  
VALUES(1, 2, 1, 1, 1, 0, 0, 1, 1, 5, 1); 


INSERT INTO dbClassificationPageSection (
ClassificationPageId
, Sequence
, SectionTypeId
, ShowSectionTitleName
, ShowSectionTitleDescription
, ShowContentTypeTitleName
, ShowContentTypeTitleDescription
, OneTwoColumns
, SortById
, MaxContent
, HasPaging)  
VALUES(2, 1, 1, 1, 1, 0, 0, 1, 1, 5, 1); 

INSERT INTO dbClassificationPageSection (
ClassificationPageId
, Sequence
, SectionTypeId
, ShowSectionTitleName
, ShowSectionTitleDescription
, ShowContentTypeTitleName
, ShowContentTypeTitleDescription
, OneTwoColumns
, SortById
, MaxContent
, HasPaging)  
VALUES(2, 2, 1, 1, 1, 0, 0, 1, 1, 5, 1); 


INSERT INTO dbClassificationPageSection (
ClassificationPageId
, Sequence
, SectionTypeId
, ShowSectionTitleName
, ShowSectionTitleDescription
, ShowContentTypeTitleName
, ShowContentTypeTitleDescription
, OneTwoColumns
, SortById
, MaxContent
, HasPaging)  
VALUES(3, 1, 1, 1, 1, 0, 0, 1, 1, 5, 1); 

INSERT INTO dbClassificationPageSection (
ClassificationPageId
, Sequence
, SectionTypeId
, ShowSectionTitleName
, ShowSectionTitleDescription
, ShowContentTypeTitleName
, ShowContentTypeTitleDescription
, OneTwoColumns
, SortById
, MaxContent
, HasPaging)  
VALUES(3, 2, 1, 1, 1, 0, 0, 1, 1, 5, 1); 

INSERT INTO DbClassificationPageSectionLanguage (
PageSectionId, LanguageId, Name, Description, MenuName, MouseOver, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (1, 41, 'Main section 1', 'Main section', 'Main section', 'Main section', 'Main section', 'Main section',@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO DbClassificationPageSectionLanguage (
PageSectionId, LanguageId, Name, Description, MenuName, MouseOver, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (2, 41, 'Second section 1', 'Main section', 'Main section', 'Main section', 'Main section', 'Main section',@CurrentUser, @CurrentUser, getdate(), getdate()); 

INSERT INTO DbClassificationPageSectionLanguage (
PageSectionId, LanguageId, Name, Description, MenuName, MouseOver, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (3, 41, 'Main section 2', 'Main section', 'Main section', 'Main section', 'Main section', 'Main section',@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO DbClassificationPageSectionLanguage (
PageSectionId, LanguageId, Name, Description, MenuName, MouseOver, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (4, 41, 'Second section 2', 'Main section', 'Main section', 'Main section', 'Main section', 'Main section',@CurrentUser, @CurrentUser, getdate(), getdate()); 

INSERT INTO DbClassificationPageSectionLanguage (
PageSectionId, LanguageId, Name, Description, MenuName, MouseOver, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (5, 41, 'Main section 3', 'Main section', 'Main section', 'Main section', 'Main section', 'Main section',@CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO DbClassificationPageSectionLanguage (
PageSectionId, LanguageId, Name, Description, MenuName, MouseOver, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (6, 41, 'Second section 3', 'Main section', 'Main section', 'Main section', 'Main section', 'Main section',@CurrentUser, @CurrentUser, getdate(), getdate()); 


INSERT INTO dbMenu1 (
	MenuTypeId
, Sequence
, ClassificationId
, FeatureId
, Controller
, Action
, DestinationId
 , CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 1, 0, 0, 'FrontPage', 'Index', 0, @CurrentUser, @CurrentUser, getdate(), getdate()) 

INSERT INTO dbMenu1 (
	MenuTypeId
, Sequence
, ClassificationId
, FeatureId
, Controller
, Action
, DestinationId
 , CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 2, 1, 0, '', '', 0, @CurrentUser, @CurrentUser, getdate(), getdate()) 

INSERT INTO dbMenu1 (
	MenuTypeId
, Sequence
, ClassificationId
, FeatureId
, Controller
, Action
, DestinationId
 , CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 3, 2, 0, '', '', 0, @CurrentUser, @CurrentUser, getdate(), getdate()) 

SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com'; 
INSERT INTO DbMenu1Language (
Menu1Id, LanguageId, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (1, 41, 'Home', 'Home', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO DbMenu1Language (
Menu1Id, LanguageId, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (2, 41, 'First class', 'First', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO DbMenu1Language (
Menu1Id, LanguageId, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES (3, 41, 'Second class', 'Second', @CurrentUser, @CurrentUser, getdate(), getdate()); 


INSERT INTO DbUserRelation (FromUserId, ToUserId, TypeId, CreatorId, ModifierId, CreatedDate, ModifiedDate)
VALUES(@SecondUser, @CurrentUser, 1, @CurrentUser, @CurrentUser, getdate(), getdate())

INSERT INTO DbProcess (ProcessTemplateId, StepId, CreatorId, ModifierId, CreatedDate, ModifiedDate)
VALUES(1, 1, @SecondUser, @SecondUser, getdate(), getdate())

INSERT INTO DbProcess (ProcessTemplateId, StepId, CreatorId, ModifierId, CreatedDate, ModifiedDate)
VALUES(1, 1, @SecondUser, @SecondUser, getdate(), getdate())

INSERT INTO DbProcess (ProcessTemplateId, StepId, CreatorId, ModifierId, CreatedDate, ModifiedDate)
VALUES(4, 1, @SecondUser, @SecondUser, getdate(), getdate())
INSERT INTO DbProcess (ProcessTemplateId, StepId, CreatorId, ModifierId, CreatedDate, ModifiedDate)
VALUES(4, 1, @SecondUser, @SecondUser, getdate(), getdate())
INSERT INTO DbProcess (ProcessTemplateId, StepId, CreatorId, ModifierId, CreatedDate, ModifiedDate)
VALUES(5, 1, @SecondUser, @SecondUser, getdate(), getdate())

INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) VALUES (1, 1, 'Airpolution', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) VALUES (1, 2, 'Urban air polution', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) VALUES (1, 3, 'Netherlands', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) VALUES (2, 1, 'Plastics', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) VALUES (2, 2, 'Plastics in the ocean', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) VALUES (2, 3, 'Micronesia', getdate(), 0)

INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (3, 20, 'Demo SU', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (3, 21, @CurrentUser, getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (3, 22, '', getdate(), 0)

INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (4, 20, 'Advanced demo SU', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (4, 21, @CurrentUser, getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (4, 22, '',DateAdd(day, 10, getdate()), 0)

INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (5, 27, 'SU Launch', getdate(), 0)
INSERT INTO DbProcessField (ProcessId, ProcessTemplateFieldId, StringValue, DateTimeValue, IntValue) 
VALUES (5, 28,'', DateAdd(day, 5, getdate()), 0)


INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(1, 1, 1,'','',1, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(2, 1, 1,'','',2, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(3, 1, 1,'','',3, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(4, 1, 1,'','',4, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(7, 1, 1,'','',7, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(8, 1, 1,'','',8, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(10, 1, 1,'','',9, @CurrentUser, 1,1)
INSERT INTO dbo.dbLeftMenuUser (LeftMenuId , MenuShow, MenuAddShow, MenuName, MenuURL, Sequence, UserId, AdvancedSearchShow, SearchShow)
VALUES(16, 1, 1,'','',10, @CurrentUser, 1,1)


