CREATE PROCEDURE [dbo].[OrgStructure] (@LanguageId Int )
                                    AS 
                                    WITH StructureOrg (ParentId, Id, Name, Level, Path)
                                    AS
                                    (
                                    	SELECT o.ParentOrganizationId
                                    		, o.Id
                                    		, l.Name
                                    		, 0 AS level
                                    		, CAST(o.Id AS VARCHAR(255)) AS Path
                                    	FROM dbOrganization AS o
                                    	JOIN dbOrganizationLanguage AS l
                                    		ON o.Id = l.OrganizationId
                                    	WHERE o.ParentOrganizationId IS NULL
                                    		AND l.LanguageId = @LanguageId
                                    	UNION ALL
                                    	SELECT o.ParentOrganizationId
                                    		, o.Id
                                    		, l.Name
                                    		, level + 1
                                    		, CAST(s.Path + '.' + CAST(o.Id AS VARCHAR(255)) AS VARCHAR(255))
                                    	FROM dbOrganization AS o
                                    	JOIN dbOrganizationLanguage AS l
                                    		ON o.Id = l.OrganizationId
                                    	JOIN StructureOrg s
                                    		ON s.Id = o.ParentOrganizationId
                                    	WHERE l.LanguageId = @LanguageId
                                    	)

                                    	SELECT ISNULL(ParentId,0) ParentId
                                    	, Id, Name, Level, Path
                                    	FROM StructureOrg ORDER BY Path
