CREATE PROCEDURE PreferenceLeftMenuEditPost (
@Id int
, @MenuShow bit
, @MenuAddShow bit
, @SearchShow bit
, @AdvancedSearchShow bit
, @MenuName nvarchar(max)
, @MenuURL nvarchar(max)
, @Sequence int
, @UserId nvarchar(50))
AS 

BEGIN TRANSACTION
DECLARE @OldSequence int
SELECT @OldSequence = Sequence FROM dbLeftMenuUser WHERE Id = @Id
IF @OldSequence > @Sequence
BEGIN
UPDATE s
	
SET Sequence= Sequence + 1
FROM dbLeftMenuUser s WHERE Sequence >= @Sequence
	AND Sequence < @OldSequence
	AND UserId = @UserId;

--UPDATE dbLeftMenuUser SET Sequence = Sequence + 1 WHERE Sequence < @Sequence AND Sequence >= @OldSequence AND UserId = @UserId
END
ELSE
BEGIN
UPDATE 
	s 
SET Sequence = Sequence - 1
FROM dbLeftMenuUser s 
WHERE Sequence <= @Sequence
	AND Sequence > @OldSequence
	AND UserId = @UserId;

--UPDATE dbLeftMenuUser SET Sequence = Sequence - 1 WHERE Sequence <= @Sequence AND Sequence > @OldSequence AND  UserId = @UserId
END

UPDATE dbLeftMenuUser 
SET MenuShow = @MenuShow
, MenuAddShow = @MenuAddShow
, SearchShow = @SearchShow
, AdvancedSearchShow = @AdvancedSearchShow
, MenuName = @MenuName
, MenuURL = @MenuURL
, Sequence = @Sequence
WHERE Id = @Id
COMMIT TRANSACTION