DECLARE @CurrentUser uniqueidentifier; 
 
SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com'; 

INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 39, 'Kennis','Kennis','Kennis', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 39, 'Ervaring','Ervaring','Ervaring', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  3, 39, 'Opdracht','Opdracht','Opdracht', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 39, 'Organizatie','Organizatie','Organizatie', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 39, 'Afdeling','Afdeling','Afdeling', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 39, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 39, 'Inhoudsopgave','Inhoudsopgave','Inhoudsopgave', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageTypeLanguage ( PageTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 39, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId, Name, Description, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1,39, N'Köppen klimaat',N'Köppen klimaat',N'Köppen klimaat',N'Köppen klimaat', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,Name, Description, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2,39, 'Grond soort','Grond soort','Grond soort','Grond soort', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,Name, Description, MenuName, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3,39, 'Gewas','Gewas','Gewas','Gewas', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(1, 39, 'Hoofd klimaat groep','Hoofd klimaat groep','Hoofd klimaat groep','Hoofd klimaat groep', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(2, 39, 'Sub klimaat groep','Sub klimaat groep','Sub klimaat groep','Sub klimaat groep', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(3, 39, '2de sub klimaat groep','2de sub klimaat groep','2de sub klimaat groep','2de sub klimaat groep', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(4, 39, 'Grond soort groep','Grond soort groep','Grond soort groep','Grond soort groep', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(5, 39, 'Gewas groep','Gewas groep','Gewas groep','Gewas groep', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(6, 39, 'Gewas klasse','Gewas klasse','Gewas klasse','Gewas klasse', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(7, 39, 'Gewas sub klasse','Gewas sub klasse','Gewas sub klasse','Gewas sub klasse', @CurrentUser, @CurrentUser, getdate(), getdate()); 
INSERT INTO dbClassificationLevelLanguage ( 
ClassificationLevelId 
, LanguageId 
, Name 
, MenuName 
, Description 
, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(8, 39, 'Gewas rang','Gewas rang','Gewas rang','Gewas rang', @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(1, 39, 'A','A: Tropish klimaat','A','A','A' 
, 'A','A: Tropish klimaat','A','A: Tropish klimaat','A' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(2, 39, 'B','B: Droog (woestijn) klimaat','B','B','B' 
, 'B','B: Droog (woestijn) klimaat','B','B: Droog (woestijn) klimaat','B' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(3, 39, 'C','C: Gematigd klimaat','C','C','C: Gematigd klimaat' 
, 'C','C: Gematigd klimaat','C','C: Gematigd klimaat','C' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(4, 39, 'D','D: Continentaal klimaat','D','D','D: Continentaal klimaat' 
, 'D','D: Continentaal klimaat','D','D: Continentaal klimaat','D' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(5, 39, 'E','E: Pool klimaat','E','E','E: Pool klimaat' 
, 'E','E: Pool klimaat','E','E: Pool klimaat','E' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(6, 39, 'Af','Af: Tropisch regenwoud klimaat','Af','Af','Af' 
, 'Af','Af: Tropisch regenwoud klimaat','Af','Af: Tropisch regenwoud klimaat','Af' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(7, 39, 'Am','Am: Tropisch moesson klimaat','Am','Am','Am' 
, 'Am','Am: Tropisch moesson klimaat','Am','Am: Tropisch moesson klimaat','Am' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(8, 39, 'Aw/As','Aw/As: Tropisch savanne klimaat','Aw/As','Aw/As','Aw/As' 
, 'Aw/As','Aw/As: Tropisch savanne klimaat','Aw/As','Aw/As: Tropisch savanne klimaat','Aw/As' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(9, 39, 'Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken','Aw','Aw','Aw' 
, 'Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken','Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken','Aw' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(10, 39, 'As','As: Tropisch savanne klimaat met droge zomer kenmerk','As','As','As' 
, 'As','As: Tropisch savanne klimaat met droge zomer kenmerk','As','As: Tropisch savanne klimaat met droge zomer kenmerk','As' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(11, 39, 'BW','BW: Droog klimaat','BW','BW','BW: Droog klimaat' 
, 'BW','BW: Droog klimaat','BW','BW: Droog klimaat','BW' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(12, 39, 'BS','BS: Semi droog klimaat','BS','BS','BS: Semi droog klimaat' 
, 'BS','BS: Semi droog klimaat','BS','BS: Semi droog klimaat','BS' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(13, 39, 'Csa','Csa: Mediterrane hete zomerklimaat','Csa','Csa','Csa' 
, 'Csa','Csa: Mediterrane hete zomerklimaat','Csa','Csa: Mediterrane hete zomerklimaat','Csa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(14, 39, 'Csb','Csb: Mediterraan warm / koel zomerklimaat','Csb','Csb','Csb' 
, 'Csb','Csb: Mediterraan warm / koel zomerklimaat','Csb','Csb: Mediterraan warm / koel zomerklimaat','Csb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(15, 39, 'Csc','Csc: Mediterraan koud zomerklimaat','Csc','Csc','Csc' 
, 'Csc','Csc: Mediterraan koud zomerklimaat','Csc','Csc: Mediterraan koud zomerklimaat','Csc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(16, 39, 'Cfa','Cfa: Vochtige subtropische klimaat','Cfa','Cfa','Cfa' 
, 'Cfa','Cfa: Vochtige subtropische klimaat','Cfa','Cfa: Vochtige subtropische klimaat','Cfa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(17, 39, 'Cfb','Cfb: Oceanisch klimaat','Cfb','Cfb','Cfb: Oceanisch klimaat' 
, 'Cfb','Cfb: Oceanisch klimaat','Cfb','Cfb: Oceanisch klimaat','Cfb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(18, 39, 'Cfc','Cfc: Subpolair oceaanklimaat','Cfc','Cfc','Cfc' 
, 'Cfc','Cfc: Subpolair oceaanklimaat','Cfc','Cfc: Subpolair oceaanklimaat','Cfc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(19, 39, 'Cwa','Cwa: Droge winter vochtig subtropisch klimaat','Cwa','Cwa','Cwa' 
, 'Cwa','Cwa: Droge winter vochtig subtropisch klimaat','Cwa','Cwa: Droge winter vochtig subtropisch klimaat','Cwa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(20, 39, 'Cwb','Cwb: Droog-winter subtropisch hooglandklimaat','Cwb','Cwb','Cwb' 
, 'Cwb','Cwb: Droog-winter subtropisch hooglandklimaat','Cwb','Cwb: Droog-winter subtropisch hooglandklimaat','Cwb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(21, 39, 'Cwc','Cwc: Droog-winter subpolair oceaanklimaat','Cwc','Cwc','Cwc' 
, 'Cwc','Cwc: Droog-winter subpolair oceaanklimaat','Cwc','Cwc: Droog-winter subpolair oceaanklimaat','Cwc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(22, 39, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa' 
, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten','Dfa/Dwa/Dsa' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(23, 39, 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb' 
, 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat','Dfb/Dwb/Dsb' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(24, 39, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc' 
, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat','Dfc/Dwc/Dsc' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(25, 39, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd' 
, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters','Dfd/Dwd/Dsd' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(26, 39, 'ET','ET: Toendra klimaat','ET','ET','ET: Toendra klimaat' 
, 'ET','ET: Toendra klimaat','ET','ET: Toendra klimaat','ET' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(27, 39, 'EF','EF: Ijskap klimaat','EF','EF','EF: Ijskap klimaat' 
, 'EF','EF: Ijskap klimaat','EF','EF: Ijskap klimaat','EF' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(28, 39, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol','Alfisol' 
, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(29, 39, 'Andisol','Andisol – volcanic','Andisol','Andisol','Andisol – volcanic ' 
, 'Andisol','Andisol – volcanic ','Andisol','Andisol – volcanic ','Andisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(30, 39, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol','Aridisol' 
, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(31, 39, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol','Entisol' 
, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(32, 39, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol','Gelisol' 
, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(33, 39, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol','Histosol ' 
, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol – organic soils, formerly called bog soils.','Histosol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(34, 39, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol','Inceptisol' 
, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(35, 39, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol','Mollisol' 
, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(36, 39, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol','Oxisol' 
, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(37, 39, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol','Spodosol' 
, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(38, 39, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol','Ultisol' 
, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate()); 
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
VALUES(39, 39, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol','Vertisol ' 
, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol' 
, @CurrentUser, @CurrentUser, getdate(), getdate());

INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1, 39, 'Goedkeuring', 'Inhoud goedkeuring', 'Goedkeuring',getdate(), getdate(), @CurrentUser, @CurrentUser);
INSERT INTO dbProcessTemplateGroupLanguage (ProcessTemplateGroupId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(2, 39, 'Opdracht', 'Opdracht', 'Opdracht',getdate(), getdate(), @CurrentUser, @CurrentUser);

INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 39, 'Kennis goedkeuring', 'Kennis goedkeuring' , 'Kennis goedkeuring' , getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 39, 'Ervaring goedkeuring', 'Ervaring goedkeuring' , 'Ervaring goedkeuring' , getdate(), getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateLanguage (ProcessTemplateId, LanguageId, Name, Description, MouseOver,  ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 39, 'Onderzoek opdracht', 'Onderzoek opdracht' , 'Onderzoek opdracht' , getdate(), getdate(), @CurrentUser, @CurrentUser)


INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 39, 'Kennis onderwerp','Kennis onderwerp','Kennis onderwerp',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 39, 'Interessegebied','Interessegebied','Interessegebied',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 39, 'Land','Land','Land',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (4, 39, 'Invoeren','Invoeren','Invoeren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (5, 39, 'Annuleren','Annuleren','Annuleren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (6, 39, 'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (7, 39, 'Afkeuren','Afkeuren','Afkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (8, 39, 'Ervarings onderwerp','Ervarings onderwerp','Ervarings onderwerp',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (9, 39, 'Aantal dagen','Aantal dagen','Aantal dagen',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (10, 39, 'Invoeren','Invoeren','Invoeren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (11, 39, 'Annuleren','Annuleren','Annuleren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (12, 39, 'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (13, 39, 'Afkeuren','Afkeuren','Afkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (14, 39, 'Onderzoek onderwerp','Onderzoek onderwerp','Onderzoek onderwerp',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (15, 39, 'Steekproefgrootte','Steekproefgrootte','Steekproefgrootte',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (16, 39, 'Invoeren','Invoeren','Invoeren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (17, 39, 'Annuleren','Annuleren','Annuleren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (18, 39, 'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFieldLanguage (ProcessTemplateFieldId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (19, 39, 'Afkeuren','Afkeuren','Afkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)


	
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (1, 39, 'Maak nieuw','Maak nieuw','Maak nieuw',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (2, 39, 'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (3, 39, 'Informeren','Informeren','Informeren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 

VALUES (4, 39, 'Maak nieuw','Maak nieuw','Maak nieuw',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (5, 39, 'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)

INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (6, 39, 'Maak nieuw','Maak nieuw','Maak nieuw',getdate(),getdate(), @CurrentUser, @CurrentUser )
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (7, 39, 'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate() , @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateStepLanguage (StepId
	, LanguageId
	, Name
	, Description
	, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId) 
VALUES (8, 39, 'Informeren','Informeren','Informeren',getdate(),getdate() , @CurrentUser, @CurrentUser)



INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(1,39,'Aanmaken','Aanmaken','Aanmaken',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(2,39,'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(3,39,'Informeren','Informeren','Informeren',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(4,39,'Voltooid','Voltooid','Voltooid',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(5,39,'Aanmaken','Aanmaken','Aanmaken',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(6,39,'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(7,39,'Voltooid','Voltooid','Voltooid',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(8,39,'Aanmaken','Aanmaken','AanmakenInformeren',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(9,39,'Goedkeuren','Goedkeuren','Goedkeuren',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(10,39,'Informeren','Informeren','Informeren',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT INTO dbProcessTemplateFlowLanguage (FlowId, LanguageId, Name, Description, MouseOver, ModifiedDate, CreatedDate, CreatorId, ModifierId)
VALUES(11,39,'Voltooid','Voltooid','Voltooid',getdate(),getdate(), @CurrentUser, @CurrentUser)


INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (1,39,'Open haakje','Open haakje','Open haakje',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (2,39,'Admin','Admin','Admin',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (3,39,'En','En','En',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (4,39,'5 of hoger','5 of hoger','5 of hoger',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (5,39,'Sluit haakje','Sluit haakje','Sluit haakje',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (6,39,'Of','Of','Of',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (7,39,'10 of hoger','10 of hoger','10 of hoger',getdate(),getdate(), @CurrentUser, @CurrentUser)
INSERT dbProcessTemplateFlowConditionLanguage (FlowConditionId, LanguageId, Name, Description, MouseOver, CreatedDate,ModifiedDate, CreatorId, ModifierId)
VALUES (8,39,'goedkeuring leraar','goedkeuring leraar','goedkeuring leraar',getdate(),getdate(), @CurrentUser, @CurrentUser)

SET IDENTITY_INSERT dbUITermLanguage ON;
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(5, 1, 39, 'Eigenschappen');
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(6, 2, 39, 'Identiteit');
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(7, 3, 39, 'Naam');
INSERT INTO dbUITermLanguage (Id, TermId, LanguageId, Customization) VALUES(8, 4, 39, 'Eigenschap toevoegen');

SET IDENTITY_INSERT dbUITermLanguage OFF;

INSERT INTO dbPageLanguage ( PageId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 39, 'Nieuws pagina', 'Nieuws pagina', 'Nieuws pagina', 'Nieuws pagina', 'Nieuws pagina', 'Nieuws pagina', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageLanguage ( PageId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 39, 'Algemeen', 'Algemeen', 'Algemeen', 'Algemeen', 'Algemeen', 'Algemeen', @CurrentUser, @CurrentUser, getdate(),getdate())  


INSERT INTO dbPageSectionLanguage ( PageSectionId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  1, 39, 'New knowledge','New knowledge','New knowledge','New knowledge','New knowledge','New knowledge', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSectionLanguage ( PageSectionId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  2, 39, 'New knowledge','New knowledge','New knowledge','New knowledge','New knowledge','New knowledge', @CurrentUser, @CurrentUser, getdate(),getdate())  
INSERT INTO dbPageSectionLanguage ( PageSectionId, LanguageId, Name, Description, MouseOver, MenuName, TitleName, TitleDescription, CreatorId, ModifierId, CreatedDate, ModifiedDate)  
VALUES(  3, 39, 'Assignments','Assignments','Assignments','Assignments','Assignments','Assignments', @CurrentUser, @CurrentUser, getdate(),getdate())  


