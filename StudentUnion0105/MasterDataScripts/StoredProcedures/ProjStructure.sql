CREATE PROCEDURE [dbo].[ProjStructure] (@LanguageId Int )
                                    AS 
                                    WITH StructureProj (ParentId, Id, Name, Level, Path)
                                    AS
                                    (
                                    	SELECT p.ParentProjectId
                                    		, p.Id
                                    		, l.Name
                                    		, 0 AS level
                                    		, CAST(p.Id AS VARCHAR(255)) AS Path
                                    	FROM dbProject AS p
                                    	JOIN dbProjectLanguage AS l
                                    		ON p.Id = l.ProjectId
                                    	WHERE (p.ParentProjectId IS NULL 
                                            OR p.ParentProjectId = 0) 
                                    		AND l.LanguageId = @LanguageId
                                    	UNION ALL
                                    	SELECT p.ParentProjectId
                                    		, p.Id
                                    		, l.Name
                                    		, level + 1
                                    		, CAST(s.Path + '.' + CAST(p.Id AS VARCHAR(255)) AS VARCHAR(255))
                                    	FROM dbProject AS p
                                    	JOIN dbProjectLanguage AS l
                                    		ON p.Id = l.ProjectId
                                    	JOIN StructureProj s
                                    		ON s.Id = p.ParentProjectId
                                    	WHERE l.LanguageId = @LanguageId
                                    	)

                                    	SELECT ISNULL(ParentId,0) ParentId
                                    	, Id, Name, Level, Path
                                    	FROM StructureProj ORDER BY Path
