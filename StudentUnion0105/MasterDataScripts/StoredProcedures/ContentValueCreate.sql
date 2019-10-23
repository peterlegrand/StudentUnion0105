CREATE PROCEDURE [dbo].[ContentValueCreate]  
 @ContentId int 
, @ClassificationValueId int 
AS 
INSERT dbContentClassificationValue 
(ContentId 
, ClassificationValueId 
) 
VALUES ( 
@ContentId 
, @ClassificationValueId 
) 