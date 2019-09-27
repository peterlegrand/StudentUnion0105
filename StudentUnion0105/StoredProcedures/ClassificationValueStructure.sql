

CREATE PROCEDURE [dbo].[ClassificationValueStructure] (@Language Int, @ClassificationId Int )
                                        AS 
                                        WITH StructureClassValue (ClassificationId
												, ParentId, Id, ClassificationValueName, Level, Path)
                                        AS
                                        (
                                    	    SELECT 
												v.ClassificationId
												, v.ParentValueId
                                        		, v.Id
                                        		, l.ClassificationValueName
                                        		, 0 AS level
                                        		, CAST(v.Id AS VARCHAR(255)) AS Path
                                        	FROM dbClassificationValue AS v
                                        	JOIN dbClassificationValueLanguage AS l
                                        		ON v.Id = l.ClassificationValueId
                                        	WHERE v.ParentValueId IS NULL
                                        		AND l.LanguageId = @Language
                                        		AND v.ClassificationId = @ClassificationId
                                        	UNION ALL
                                        	SELECT v.ClassificationId
												, v.ParentValueId
                                        		, v.Id
                                        		, l.ClassificationValueName
                                        		, level + 1
                                        		, CAST(s.Path + '.' + CAST(v.Id AS VARCHAR(255)) AS VARCHAR(255))
                                        	FROM dbClassificationValue AS v
                                        	JOIN dbClassificationValueLanguage AS l
                                        		ON v.Id = l.ClassificationValueId
                                        	JOIN StructureClassValue s
                                        		ON s.Id = v.ParentValueId
                                        	WHERE l.LanguageId = @Language
                                        	AND v.ClassificationId = @ClassificationId
                                        	)

                                        	SELECT ClassificationId
												, ISNULL(ParentId,0) ParentId
                                        	, Id, ClassificationValueName, Level, Path
                                        	FROM StructureClassValue 
											ORDER BY Path