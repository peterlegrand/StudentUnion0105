CREATE PROCEDURE 
	[dbo].[PageSectionUpdate] 
	 @Id int											--0
	, @NewSequence int									--1
	, @ContentTypeId int								--2
	, @HasPaging bit									--3
	, @MaxContent  int									--4
	, @OneTwoColumns  int								--5
	, @PageSectionTypeId  int							--6
	, @ShowContentTypeTitle bit							--7
	, @ShowContentTypeDescription bit					--8
	, @ShowSectionTitle bit								--9
	, @ShowSectionTitleDescription bit					--10
	, @SortById bit										--11
	, @LanguageId int									--12
	, @PageSectionName nvarchar(max)					--13
	, @PageSectionDescription nvarchar(max)				--14
	, @PageSectionTitleName nvarchar(max)				--15
	, @PageSectionTitleDescription nvarchar(max)		--16
	, @PageSectionMouseOver nvarchar(max)				--17
	, @ModifiedDate datetime2(7)						--18
	, @PageSectionLanguageId int						--19
	, @PageId int										--20
	

AS
DECLARE @OldSequence int; 
SELECT @OldSequence = Sequence FROM dbPageSection WHERE Id = @Id;
BEGIN TRANSACTION
IF @OldSequence < @NewSequence
UPDATE 
	s 
SET Sequence = Sequence - 1
FROM dbPageSection s 
WHERE Sequence <= @NewSequence
	AND Sequence > @OldSequence
	AND PageId = @PageId;
ELSE
UPDATE s
	
SET Sequence= Sequence + 1
FROM dbPageSection  s WHERE Sequence >= @NewSequence
	AND Sequence < @OldSequence
	AND PageId = @PageId;


UPDATE 
	dbPageSection
SET 
	dbPageSection.ContentTypeId = iif(@ContentTypeId=0,null,@ContentTypeId)
	, dbPageSection.HasPaging = @HasPaging
	, dbPageSection.MaxContent = @MaxContent
	, dbPageSection.OneTwoColumns = @OneTwoColumns
	, dbPageSection.PageSectionTypeId =@PageSectionTypeId
	, dbPageSection.Sequence =@NewSequence
	, dbPageSection.ShowContentTypeDescription = @ShowContentTypeDescription
	, dbPageSection.ShowContentTypeTitle = @ShowContentTypeTitle
	, dbPageSection.ShowSectionTitle = @ShowSectionTitle
	, dbPageSection.ShowSectionTitleDescription = @ShowSectionTitleDescription
	, dbPageSection.SortById = @SortById
WHERE 
	dbPageSection.Id = @Id

UPDATE 
	dbPageSectionLanguage
SET
	 PageSectionName  = @PageSectionName 
	, PageSectionDescription = @PageSectionDescription 
	, PageSectionTitle = @PageSectionTitleName 
	, PageSectionTitleDescription = @PageSectionTitleDescription 
	, PageSectionMouseOver = @PageSectionMouseOver 
	, ModifiedDate = @ModifiedDate
WHERE 
 Id = @PageSectionLanguageId 

COMMIT TRANSACTION
