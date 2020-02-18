using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Classes;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    //PETER CHeck what the base class should be
    public class ContentController : PortalController
    {
        private readonly IClassificationRepository _classification;
                private readonly SuDbContext _context;


        public ContentController(
            UserManager<SuUserModel> userManager
           , SuDbContext context
            , IClassificationRepository classification
            , ILanguageRepository language
            ) : base(userManager, language)
        {
            _classification = classification;
                    _context = context;
}
        public async Task<IActionResult> Index()
        {
            //PETER no terms go to the content yet?
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create1()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@CurrentUser", CurrentUser.Id);

            var ContentTypeGroupsFromDb = _context.ZDbTypeList.FromSql("ContentCreate1GetContentTypeGroup @CurrentUser", parameter).ToList();


            var GroupList = new List<ContentCreate1GetContentTypeGroup>();
            foreach (var GroupFromDb in ContentTypeGroupsFromDb)
            {
                var TypeList = new List<ContentCreate1GetContentType>();

                SqlParameter[] parameters =
                {
                    new SqlParameter("@CurrentUser", CurrentUser.Id)
                    , new SqlParameter("@Id", GroupFromDb.Id)
                };

                var ContentTypesFromDb = _context.ZDbTypeList.FromSql("ContentCreate1GetContentType @CurrentUser, @Id", parameters).ToList();

                foreach (var TypeFromDb in ContentTypesFromDb)
                {
                    TypeList.Add(new ContentCreate1GetContentType
                    {
                        name = TypeFromDb.Name,
                        Id = TypeFromDb.Id
                    });
                }

                GroupList.Add(new ContentCreate1GetContentTypeGroup
                {

                    Name = GroupFromDb.Name,
                    Id = GroupFromDb.Id,
                    Types = TypeList

                });
            }
            return View(GroupList);
        }

    //    [HttpGet]
    //    public async Task<IActionResult> Create()
    //    {
    //        var CurrentUser = await _userManager.GetUserAsync(User);
    //        var DefaultLanguageID = CurrentUser.DefaultLanguageId;

    //        var UICustomizationArray = new UICustomization(_context);
    //        ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
    //        Menus a = new Menus(_context);
    //        ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);




    //        var StatusList = new List<SelectListItem>();
    //        var TypeList = new List<SelectListItem>();
    //        var OrganizationList = new List<SelectListItem>();
    //        var ProjectList = new List<SelectListItem>();
    //        var SecurityLevelList = new List<SelectListItem>();
    //        var LanguageList = new List<SelectListItem>();
    //        int NoOfClassifications = _classification.GetAllClassifcations().Count();

    //        List<SelectListItem>[] ClassificationValueSets = new List<SelectListItem>[NoOfClassifications];
    //      //  DbSet<SuValueList>[] dbValueList = new DbSet<SuValueList>[NoOfClassifications];
    //        int y = 0;

    //        foreach (var ClassificationfromDb in _classification.GetAllClassifcations())
    //        {
    //            List<SuValueList> ValuesFromDb = new List<SuValueList>();

    //            SqlParameter[] parameters =
    //{
    //                new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
    //                , new SqlParameter("@Id",ClassificationfromDb.Id)
    //            };

    //            ValuesFromDb = _context.DbValueList.FromSql("ClassificationValueStructureValues  @LanguageId, @Id", parameters).ToList();
    //            ClassificationValueSets[y] = new List<SelectListItem>
    //            {
    //                new SelectListItem

    //                {
    //                    Text = "-- no selection --",
    //                    Value = "0"
    //                }
    //            };
    //            foreach (var ValueFromDb in ValuesFromDb)
    //            {

    //                ClassificationValueSets[y].Add(new SelectListItem

    //                {
    //                    Text = ValueFromDb.Name,
    //                    Value = ValueFromDb.ClassificationValueId.ToString()
    //                });
    //            }
    //            y++;
    //        }

    //        var ContentStatusFromDb = _context.ZDbStatusList.FromSql("ContentStatusSelectAll").ToList();


    //        foreach (var StatusFromDb in ContentStatusFromDb)
    //        {
    //            StatusList.Add(new SelectListItem
    //            {
    //                Text = StatusFromDb.Name,
    //                Value = StatusFromDb.Id.ToString()
    //            });
    //        }

    //        var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

    //        var ContentTypesFromDb = _context.ZDbTypeList.FromSql("ContentTypeSelectAllForLanguage @LanguageId", parameter).ToList();

    //        foreach (var TypeFromDb in ContentTypesFromDb)
    //        {
    //            TypeList.Add(new SelectListItem
    //            {
    //                Text = TypeFromDb.Name,
    //                Value = TypeFromDb.Id.ToString()
    //            });
    //        }

    //        var OrganizationsFromDb = _context.ZdbOrganizationIndexGet.FromSql("OrgStructure @LanguageId", parameter).ToList();

    //        foreach (var OrganizationFromDb in OrganizationsFromDb)
    //        {
    //            OrganizationList.Add(new SelectListItem
    //            {
    //                Text = OrganizationFromDb.Name,
    //                Value = OrganizationFromDb.Id.ToString()
    //            });
    //        }

    //        var ProjectsFromDb = _context.DbGetProjectStructure.FromSql("ProjStructure @LanguageId", parameter).ToList();

    //        ProjectList.Add(new SelectListItem { Value = "0", Text = "No project" });
    //        foreach (var ProjectFromDb in ProjectsFromDb)
    //        {
    //            ProjectList.Add(new SelectListItem
    //            {
    //                Text = ProjectFromDb.Name,
    //                Value = ProjectFromDb.Id.ToString()
    //            });
    //        }


    //        var SecurityLevelsFromDb = _context.DbSecurityLevelList.FromSql("SecurityLevelSelectAll").ToList();

    //        foreach (var SecurityLevelFromDb in SecurityLevelsFromDb)
    //        {
    //            SecurityLevelList.Add(new SelectListItem
    //            {
    //                Text = SecurityLevelFromDb.Name,
    //                Value = SecurityLevelFromDb.Id.ToString()
    //            });
    //        }

    //        var LanguagesFromDb = _context.ZDbLanguageList.FromSql("LanguageSelectAll").ToList();

    //        foreach (var LanguageFromDb in LanguagesFromDb)
    //        {
    //            LanguageList.Add(new SelectListItem
    //            {
    //                Text = LanguageFromDb.Name,
    //                Value = LanguageFromDb.Id.ToString()
    //            });
    //        }


    //        SuContentModel content = new SuContentModel
    //        {
    //            LanguageId = CurrentUser.DefaultLanguageId
    //        };
    //        int?[] SelectedValues = new int?[NoOfClassifications];
    //        SuCreateContentModel ContentWithDropDowns = new SuCreateContentModel
    //        {
    //            Content = content
    //            ,
    //            ContentType = TypeList
    //            ,
    //            ContentStatus = StatusList
    //            ,
    //            SecurityLevel = SecurityLevelList
    //            ,
    //            Langauge = LanguageList
    //            ,
    //            Organization = OrganizationList
    //            ,
    //            Project = ProjectList
    //            ,
    //            Values = ClassificationValueSets
    //            ,
    //            NoOfClassifications = NoOfClassifications
    //            ,
    //            SelectedValues = SelectedValues
    //        };
    //        ViewBag.tools = new[] {
    //    "Bold", "Italic", "Underline", "StrikeThrough",
    //    "FontName", "FontSize", "FontColor", "BackgroundColor",
    //    "LowerCase", "UpperCase", "|",
    //    "Formats", "Alignments", "OrderedList", "UnorderedList",
    //    "Outdent", "Indent", "|",
    //    "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
    //    "SourceCode", "FullScreen", "|", "Undo", "Redo"
    //        };

    //        return View(ContentWithDropDowns);
    //    }

        [HttpGet]
        public async Task<IActionResult> Create2(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            SqlParameter[] parametersForAllowed =
   {
                    new SqlParameter("@CurrentUser", CurrentUser.Id)
                    , new SqlParameter("@Id",Id)
                };
            var CheckIfAllowed = _context.ZdbInt.FromSql("ContentCreate2GetAllowed @CurrentUser, @Id", parametersForAllowed).First();
            if (CheckIfAllowed.intValue == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index2"
                });
            }

            var StatusList = new List<SelectListItem>();
            var OrganizationList = new List<SelectListItem>();
            var ProjectList = new List<SelectListItem>();
            var SecurityLevelList = new List<SelectListItem>();
            var LanguageList = new List<SelectListItem>();
            int NoOfClassifications = _classification.GetAllClassifcations().Count();

            var parameterForProcess = new SqlParameter("@Id", Id);
            var ProcessTemplateId = _context.ZdbInt2.FromSql("ContentCreate2ProcessTemplateIdGet  @Id", parameterForProcess).First();


            List<SelectListItem>[] ClassificationValueSets = new List<SelectListItem>[NoOfClassifications];

                            SqlParameter[] parametersForClassifications =
    {
                    new SqlParameter("@Id", Id)
                    , new SqlParameter("@CurrentUser",CurrentUser.Id)
                };
                           var ClassificationIdsFromDb = _context.ZdbInt.FromSql("ContentCreate2GetClassifications  @Id, @CurrentUser", parametersForClassifications).ToList();


          //  DbSet<SuValueList>[] dbValueList = new DbSet<SuValueList>[NoOfClassifications];
            int y = 0;

            foreach (var ClassificationfromDb in ClassificationIdsFromDb)
            {
                List<SuValueList> ValuesFromDb = new List<SuValueList>();

                SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id",ClassificationfromDb.intValue)
                };

                ValuesFromDb = _context.DbValueList.FromSql("ClassificationValueStructureValues  @LanguageId, @Id", parameters).ToList();
                ClassificationValueSets[y] = new List<SelectListItem>
                {
                    new SelectListItem

                    {
                        Text = "-- no selection --",
                        Value = "0"
                    }
                };
                foreach (var ValueFromDb in ValuesFromDb)
                {

                    ClassificationValueSets[y].Add(new SelectListItem

                    {
                        Text = ValueFromDb.Name,
                        Value = ValueFromDb.ClassificationValueId.ToString()
                    });
                }
                y++;
            }

            var ContentStatusFromDb = _context.ZDbStatusList.FromSql("ContentStatusList").ToList();


            foreach (var StatusFromDb in ContentStatusFromDb)
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);

            

            var OrganizationsFromDb = _context.ZdbOrganizationIndexGet.FromSql("OrgStructure @LanguageId", parameter).ToList();

            foreach (var OrganizationFromDb in OrganizationsFromDb)
            {
                OrganizationList.Add(new SelectListItem
                {
                    Text = OrganizationFromDb.Name,
                    Value = OrganizationFromDb.Id.ToString()
                });
            }

            var ProjectsFromDb = _context.DbGetProjectStructure.FromSql("ProjStructure @LanguageId", parameter).ToList();

            ProjectList.Add(new SelectListItem { Value = "0", Text = "No project" });
            foreach (var ProjectFromDb in ProjectsFromDb)
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.Name,
                    Value = ProjectFromDb.Id.ToString()
                });
            }


            var SecurityLevelsFromDb = _context.ZDbSecurityLevelList.FromSql("SecurityLevelSelectAll").ToList();

            foreach (var SecurityLevelFromDb in SecurityLevelsFromDb)
            {
                SecurityLevelList.Add(new SelectListItem
                {
                    Text = SecurityLevelFromDb.Name,
                    Value = SecurityLevelFromDb.Id.ToString()
                });
            }

            var LanguagesFromDb = _context.ZDbLanguageList.FromSql("LanguageSelectAll").ToList();

            foreach (var LanguageFromDb in LanguagesFromDb)
            {
                LanguageList.Add(new SelectListItem
                {
                    Text = LanguageFromDb.Name,
                    Value = LanguageFromDb.Id.ToString()
                });
            }


            SuContentModel content = new SuContentModel
            {
                LanguageId = CurrentUser.DefaultLanguageId
                ,
                ContentTypeId = Id
            };
            int?[] SelectedValues = new int?[NoOfClassifications];
            SuContentCreate2GetModel ContentWithDropDowns = new SuContentCreate2GetModel
            {
                Content = content
            ,
                ProcessTemplateId = ProcessTemplateId.intValue 
                ,
                ContentStatus = StatusList
                ,
                SecurityLevel = SecurityLevelList
                ,
                Langauge = LanguageList
                ,
                Organization = OrganizationList
                ,
                Project = ProjectList
                ,
                Values = ClassificationValueSets
                ,
                NoOfClassifications = NoOfClassifications
                ,
                SelectedValues = SelectedValues
            };
            ViewBag.tools = new[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|",
        "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };

            return View(ContentWithDropDowns);
        }


        [HttpPost]
        public async Task<IActionResult> Create2(SuContentCreate2GetModel FromForm)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var ProjectId = FromForm.Content.ProjectId == null ? 0 : FromForm.Content.ProjectId;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ContentTypeId", FromForm.Content.ContentTypeId),
                new SqlParameter("@ContentStatusId", FromForm.Content.ContentStatusId),
                new SqlParameter("@LangaugeId", FromForm.Content.LanguageId),
                new SqlParameter("@Title", FromForm.Content.Title),
                new SqlParameter("@Description", FromForm.Content.Description),
                new SqlParameter("@SecurityLevel", FromForm.Content.SecurityLevel),
                new SqlParameter("@OrganizationId", FromForm.Content.OrganizationId),
                new SqlParameter("@ProjectId", ProjectId ?? 0 ),
                new SqlParameter("@CreatorId", CurrentUser.Id),
        
                new SqlParameter
                {
                    ParameterName = "@new_identity",
                    SqlDbType = SqlDbType.Int
                    , Direction = ParameterDirection.Output
                }
            };

            _context.Database.ExecuteSqlCommand("ContentCreate2Post @ContentTypeId" +
                ", @ContentStatusId" +
                ", @LangaugeId" +
                ", @Title" +
                ", @Description" +
                ", @SecurityLevel" +
                ", @OrganizationId" +
                ", @ProjectId" +
                ", @CreatorId, @new_identity OUTPUT", parameters);

            if (FromForm.NoOfClassifications != null)
            {

                //    
                foreach (var x in FromForm.SelectedValues)
                {
                    //                    SqlParameter[] parameters2 = new SqlParameter[2];
                    if (x.Value != 0)
                    {
                        SqlParameter[] parameters2 =
                    {
                new SqlParameter("@ContentId", parameters[9].Value),
                new SqlParameter("@ClassificationValueId", x.Value)
                        };
                        _context.Database.ExecuteSqlCommand("ContentValueCreate @ContentId, @ClassificationValueId", parameters2);

                    }
                }
            }



            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index2"
            });

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);
            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            SqlParameter[] parametersForAllowed =
   {
                    new SqlParameter("@Id", Id)
                    , new SqlParameter("@CurrentUser",CurrentUser.Id)
                };
            var CheckIfAllowed = _context.ZdbInt.FromSql("ContentEditGetAllowed @Id, @CurrentUser", parametersForAllowed).First();
            if (CheckIfAllowed.intValue == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index2"
                });
            }


            var parameterContent = new SqlParameter("@Id", Id);

            var ContentFromDb = _context.ZdbContentEditGetContent.FromSql("ContentEditGetContent @Id", parameterContent).First();
            var ContentClassificationValuesFromDb = _context.ZdbContentEditGetClassificationValues.FromSql("ContentEditGetClassificationValues @Id", parameterContent).ToList();


            var StatusList = new List<SelectListItem>();
            var OrganizationList = new List<SelectListItem>();
            var ProjectList = new List<SelectListItem>();
            var SecurityLevelList = new List<SelectListItem>();
            var LanguageList = new List<SelectListItem>();
            int NoOfClassifications = _classification.GetAllClassifcations().Count();

            List<SelectListItem>[] ClassificationValueSets = new List<SelectListItem>[NoOfClassifications];

            var parametersForClassifications = new SqlParameter("@Id", Id);

            var ClassificationIdsFromDb = _context.ZdbInt.FromSql("ContentEditGetClassifications @Id", parametersForClassifications).ToList();


            //  DbSet<SuValueList>[] dbValueList = new DbSet<SuValueList>[NoOfClassifications];
            int y = 0;

            foreach (var ClassificationfromDb in ClassificationIdsFromDb)
            {
                List<SuValueList> ValuesFromDb = new List<SuValueList>();

                SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@Id",ClassificationfromDb.intValue)
                };

                ValuesFromDb = _context.DbValueList.FromSql("ClassificationValueStructureValues  @LanguageId, @Id", parameters).ToList();
                ClassificationValueSets[y] = new List<SelectListItem>
                {
                    new SelectListItem

                    {
                        Text = "-- no selection --",
                        Value = "0"
                    }
                };
                foreach (var ValueFromDb in ValuesFromDb)
                {

                    ClassificationValueSets[y].Add(new SelectListItem

                    {
                        Text = ValueFromDb.Name,
                        Value = ValueFromDb.ClassificationValueId.ToString()
                    });
                }
                y++;
            }

            var ContentStatusFromDb = _context.ZDbStatusList.FromSql("ContentEditGetStatusList").ToList();


            foreach (var StatusFromDb in ContentStatusFromDb)
            {
                StatusList.Add(new SelectListItem
                {
                    Text = StatusFromDb.Name,
                    Value = StatusFromDb.Id.ToString()
                });
            }

            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);



            var OrganizationsFromDb = _context.ZdbOrganizationIndexGet.FromSql("OrgStructure @LanguageId", parameter).ToList();

            foreach (var OrganizationFromDb in OrganizationsFromDb)
            {
                OrganizationList.Add(new SelectListItem
                {
                    Text = OrganizationFromDb.Name,
                    Value = OrganizationFromDb.Id.ToString()
                });
            }

            var ProjectsFromDb = _context.DbGetProjectStructure.FromSql("ProjStructure @LanguageId", parameter).ToList();

            ProjectList.Add(new SelectListItem { Value = "0", Text = "No project" });
            foreach (var ProjectFromDb in ProjectsFromDb)
            {
                ProjectList.Add(new SelectListItem
                {
                    Text = ProjectFromDb.Name,
                    Value = ProjectFromDb.Id.ToString()
                });
            }


            var SecurityLevelsFromDb = _context.ZDbSecurityLevelList.FromSql("SecurityLevelSelectAll").ToList();

            foreach (var SecurityLevelFromDb in SecurityLevelsFromDb)
            {
                SecurityLevelList.Add(new SelectListItem
                {
                    Text = SecurityLevelFromDb.Name,
                    Value = SecurityLevelFromDb.Id.ToString()
                });
            }

            var LanguagesFromDb = _context.ZDbLanguageList.FromSql("LanguageSelectAll").ToList();

            foreach (var LanguageFromDb in LanguagesFromDb)
            {
                LanguageList.Add(new SelectListItem
                {
                    Text = LanguageFromDb.Name,
                    Value = LanguageFromDb.Id.ToString()
                });
            }


            SuContentModel content = new SuContentModel
            {
                LanguageId = CurrentUser.DefaultLanguageId
            };
            int?[] SelectedValues = new int?[NoOfClassifications];
            SuContentEditGetAllLists ContentWithDropDowns = new SuContentEditGetAllLists
            {
                Content = ContentFromDb

                ,
                ContentStatus = StatusList
                ,
                SecurityLevel = SecurityLevelList
                ,
                Langauge = LanguageList
                ,
                Organization = OrganizationList
                ,
                Project = ProjectList
                ,
                Values = ClassificationValueSets
                ,
                NoOfClassifications = NoOfClassifications
                ,
                SelectedValues = ContentClassificationValuesFromDb
            };
            ViewBag.tools = new[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|",
        "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };

            return View(ContentWithDropDowns);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SuContentEditGetAllLists FromForm)
        {

            var CurrentUser = await _userManager.GetUserAsync(User);
            var ProjectId = FromForm.Content.ProjectId == null ? 0 : FromForm.Content.ProjectId;
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", FromForm.Content.Id),
                new SqlParameter("@ContentStatusId", FromForm.Content.ContentStatusId),
                new SqlParameter("@LangaugeId", FromForm.Content.LanguageId),
                new SqlParameter("@Title", FromForm.Content.Title),
                new SqlParameter("@Description", FromForm.Content.Description),
                new SqlParameter("@SecurityLevel", FromForm.Content.SecurityLevel),
                new SqlParameter("@OrganizationId", FromForm.Content.OrganizationId),
                new SqlParameter("@ProjectId", ProjectId  ),
                new SqlParameter("@CreatorId", CurrentUser.Id),

                
            };

            _context.Database.ExecuteSqlCommand("ContentEditPost " +
                "@Id" +
                ", @ContentStatusId" +
                ", @LangaugeId" +
                ", @Title" +
                ", @Description" +
                ", @SecurityLevel" +
                ", @OrganizationId" +
                ", @ProjectId" +
                ", @CreatorId" +
                " ", parameters);

            if (FromForm.NoOfClassifications != null)
            {

                //    
                foreach (var x in FromForm.SelectedValues)
                {
                    //                    SqlParameter[] parameters2 = new SqlParameter[2];
                    if (x.Id != 0 && x.ValueId !=0)
                    {
                        SqlParameter[] parameters2 =
                    {
                new SqlParameter("@Id",x.Id ),
                new SqlParameter("@ValueId", x.ValueId)
                        };
                        _context.Database.ExecuteSqlCommand("ContentEditPostUpdateValue @Id, @ValueId", parameters2);

                 }
                    else if (x.Id != 0 && x.ValueId == 0)
                    {
                        var parameter2 = new SqlParameter("@Id", x.Id);
                        _context.Database.ExecuteSqlCommand("ContentEditPostDeleteValue @Id", parameter2);
                    }
                    else if (x.Id == 0 && x.ValueId != 0)
                    {
                        SqlParameter[] parameters2 =
                    {
                new SqlParameter("@Id", FromForm.Content.Id ),
                new SqlParameter("@ValueId", x.ValueId)
                        };
                        _context.Database.ExecuteSqlCommand("ContentEditPostInsertValue @Id, @ValueId", parameters2);
                    }

                }
            }



            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Index2"
            });

        }

    }
}