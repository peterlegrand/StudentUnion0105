CREATE PROCEDURE PreferenceLeftMenuEditPost (
@Id int
, @MenuShow bit
, @MenuAddShow bit
, @SearchShow bit
, @AdvancedSearchShow bit
, @MenuName nvarchar(max)
, @MenuURL nvarchar(max)
, @Sequence int)
AS 

UPDATE dbLeftMenuUser 
SET MenuShow = @MenuShow
, MenuAddShow = @MenuAddShow
, SearchShow = @SearchShow
, AdvancedSearchShow = @AdvancedSearchShow
, MenuName = @MenuName
, MenuURL = @MenuURL
, Sequence = @Sequence
WHERE Id = @Id
