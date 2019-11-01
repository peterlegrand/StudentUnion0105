CREATE PROCEDURE ClassificationValueIndexGetMaxLevel (@Id int)
AS
SELECT COUNT(*) IntValue FROM dbClassificationLevel WHERE ClassificationId = @Id