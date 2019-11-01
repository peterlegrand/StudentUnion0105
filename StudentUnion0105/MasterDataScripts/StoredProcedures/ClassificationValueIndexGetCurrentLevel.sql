CREATE PROCEDURE ClassificationValueIndexGetCurrentLevel (@ClassificationId Int )
                                        AS 
                                        WITH StructureClassValue (ParentValuId, Id, Level)
                                        AS
                                        (
                                    	    SELECT 
											    v.ParentValueId
												, v.Id
                                        		, 0 AS level
                                        	FROM dbClassificationValue AS v
                                        	WHERE v.ParentValueId IS NULL
                                        		AND v.ClassificationId = @ClassificationId
                                        	UNION ALL
                                        	SELECT 
												v.ParentValueId
												, v.Id
												, level + 1
                                        	FROM dbClassificationValue AS v
                                        	JOIN StructureClassValue s
                                        		ON s.Id = v.ParentValueId
                                        	AND v.ClassificationId = @ClassificationId
                                        	)

                                        	SELECT MAX(Level) IntValue
                                        	FROM StructureClassValue 
											