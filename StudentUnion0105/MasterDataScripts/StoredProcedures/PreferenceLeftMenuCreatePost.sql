CREATE PROCEDURE PreferenceLeftMenuCreatePost (
	@LeftMenuId int
	, @MenuShow bit
	, @MenuAddShow bit
	, @SearchShow bit
	, @AdvancedSearchShow bit
	, @MenuName nvarchar(max)
	, @MenuURL nvarchar(max)
	, @Sequence int
	, @UserId nvarchar(50)
	)
AS
BEGIN TRANSACTION

UPDATE dbLeftMenuUser SET Sequence = Sequence + 1 WHERE Sequence >= @Sequence and UserId = @UserId

INSERT INTO dbLeftMenuUser (
	LeftMenuId 
	, MenuShow
	, MenuAddShow
	, SearchShow
	, AdvancedSearchShow
	, MenuName
	, MenuURL
	, Sequence
	, UserId
	)
VALUES (
	@LeftMenuId
	, @MenuShow
	, @MenuAddShow
	, @SearchShow
	, @AdvancedSearchShow
	, @MenuName
	, @MenuURL
	, @Sequence
	, @USerId
	);

COMMIT TRANSACTION


