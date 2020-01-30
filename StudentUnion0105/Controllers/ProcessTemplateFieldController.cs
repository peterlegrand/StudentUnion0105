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
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateFieldController : PortalController
    {
        private readonly IProcessTemplateRepository _processTemplate;
        private readonly IProcessTemplateLanguageRepository _processTemplateLanguage;
        private readonly IProcessTemplateFieldRepository _processTemplateField;
        private readonly IProcessTemplateFieldLanguageRepository _processTemplateFieldLanguage;
        private readonly IProcessTemplateFieldTypeRepository _processTemplateFieldType;
        private readonly IProcessTemplateFieldTypeLanguageRepository _processTemplateFieldTypeLanguage;
        private readonly IMasterListRepository _masterList;
        private readonly IDataTypeRepository _dataType;
        private readonly SuDbContext _context;

        public ProcessTemplateFieldController(UserManager<SuUserModel> userManager
            , IProcessTemplateRepository processTemplate
            , IProcessTemplateLanguageRepository processTemplateLanguage
            , ILanguageRepository language
            , IProcessTemplateFieldRepository processTemplateField
            , IProcessTemplateFieldLanguageRepository processTemplateFieldLanguage
            , IProcessTemplateFieldTypeRepository processTemplateFieldType
            , IProcessTemplateFieldTypeLanguageRepository processTemplateFieldTypeLanguage
            , SuDbContext context
            , IMasterListRepository masterList
            , IDataTypeRepository dataType) : base(userManager, language)
        {
            _processTemplate = processTemplate;
            _processTemplateLanguage = processTemplateLanguage;
            _processTemplateField = processTemplateField;
            _processTemplateFieldLanguage = processTemplateFieldLanguage;
            _processTemplateFieldType = processTemplateFieldType;
            _processTemplateFieldTypeLanguage = processTemplateFieldTypeLanguage;
            _masterList = masterList;
            _dataType = dataType;
            _context = context;
        }

        public SuDbContext Context { get; }

        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            SqlParameter[] parameters =
    {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@PId", Id)
                };
            var ProcessTemplateField = _context.ZdbObjectIndexGet.FromSql("ProcessTemplateFieldIndexGet @Id, @LanguageId", parameters).ToList();
            //PETER Why do I need this viewbag
            ViewBag.PId = Id;
            return View(ProcessTemplateField);


            //var ProcessTemplateField = (from c in  _processTemplateField.GetAllProcessTemplateFields()
            //                   join l in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
            //          on c.Id equals l.ProcessTemplateFieldId
            //                   where c.ProcessTemplateId== Id
            //                   && l.LanguageId == DefaultLanguageID
            //                   orderby l.Name
            //                   select new SuObjectVM
            //                   {
            //                       Id = c.Id
            //                   ,
            //                       Name = l.Name
            //                   ,
            //                       ObjectId = c.ProcessTemplateId
            //                   }).ToList();
            //ViewBag.ObjectId = Id.ToString();


            //return View(ProcessTemplateField);
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


            SqlParameter[] parameters =
            {
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId)
                    , new SqlParameter("@OId", Id)
                };

            SuProcessTemplateFieldEditGetModel ProcessTemplateFieldEditGet = _context.ZdbSuProcessTemplateFieldEditGet.FromSql("ProcessTemplateFieldEditGet @LanguageId, @OId", parameters).First();

            var FieldTypeList = new List<SelectListItem>();
            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);
            var FieldTypesFromDb = _context.ZDbTypeList.FromSql("ContentTypeSelectAllForLanguage @LanguageId", parameter).ToList();
            foreach (var FieldTypeFromDb in FieldTypesFromDb)
            {
                FieldTypeList.Add(new SelectListItem
                {
                    Text = FieldTypeFromDb.Name,
                    Value = FieldTypeFromDb.Id.ToString()
                });
            }

            SuProcessTemplateFieldEditGetWithListModel ProcessTemplateFieldWithList = new SuProcessTemplateFieldEditGetWithListModel
            {
                ProcessTemplateField = ProcessTemplateFieldEditGet,
                FieldTypeList = FieldTypeList
            };

            return View(ProcessTemplateFieldWithList);

            //var ProcessTemplateField = (from c in _processTemplateField.GetAllProcessTemplateFields()
            //                            join l in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
            //                            on c.Id equals l.ProcessTemplateFieldId
            //                            where c.Id == Id && l.LanguageId == DefaultLanguageID
            //                            orderby l.Name
            //                            select new SuObjectVM
            //                            {
            //                                Id = c.ProcessTemplateId
            //                                ,
            //                                ObjectId = c.Id
            //                                ,
            //                                LanguageId = l.LanguageId
            //                                ,
            //                                ObjectLanguageId = l.Id
            //                                ,
            //                                Name = l.Name
            //                                ,
            //                                Description = l.Description
            //                                ,
            //                                MouseOver = l.MouseOver
            //                                , NotNullId = c.FieldDataTypeId
            //                                , NotNullId2 = c.FieldMasterListId
            //                            }).First();

            ////DataTypes
            //var DataTypeList = new List<SelectListItem>();

            //var DataTypesFromDb = _context.ZDbStatusList.FromSql("DataTypeSelectAll").ToList();


            //foreach (var DataTypeFromDb in DataTypesFromDb)
            //{
            //    DataTypeList.Add(new SelectListItem
            //    {
            //        Text = DataTypeFromDb.Name,
            //        Value = DataTypeFromDb.Id.ToString()
            //    });
            //}

            ////ContentType


            ////MasterList
            //var MasterListList = new List<SelectListItem>();

            //var MasterListsFromDb = _context.ZDbTypeList.FromSql("GetMasterList").ToList();


            //foreach (var MasterListFromDb in MasterListsFromDb)
            //{
            //    MasterListList.Add(new SelectListItem
            //    {
            //        Text = MasterListFromDb.Name,
            //        Value = MasterListFromDb.Id.ToString()
            //    });
            //}

            ////MasterList

            //var FieldsAndDropDowns = new SuProcessTemplateFieldWith2DropDown { Field = ProcessTemplateField, DataTypes = DataTypeList, MasterList = MasterListList } ;


            //return View(FieldsAndDropDowns);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuProcessTemplateFieldEditGetWithListModel FromForm)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
    
                SqlParameter[] parameters =
                    {
                    new SqlParameter("@Id", FromForm.ProcessTemplateField.OId),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
                    new SqlParameter("@ProcessTemplateFieldTypeId", FromForm.ProcessTemplateField.ProcessTemplateFieldTypeId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.ProcessTemplateField.Name),
                    new SqlParameter("@Description", FromForm.ProcessTemplateField.Description),
                    new SqlParameter("@MouseOver", FromForm.ProcessTemplateField.MouseOver),
                    new SqlParameter("@MenuName", FromForm.ProcessTemplateField.MenuName)
                    };
                _context.Database.ExecuteSqlCommand("ProcessTemplateFieldEditPost " +
                            "@Id" +
                            ", @LanguageId" +
                            ", @ProcessTemplateFieldTypeId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
            }
            return RedirectToAction("Index", new { Id = FromForm.ProcessTemplateField.PId.ToString() });

        }
        //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );




        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var FieldTypeList = new List<SelectListItem>();
            var parameter = new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId);
            var FieldTypesFromDb = _context.ZDbTypeList.FromSql("ContentTypeSelectAllForLanguage @LanguageId", parameter).ToList();
            foreach (var FieldTypeFromDb in FieldTypesFromDb)
            {
                FieldTypeList.Add(new SelectListItem
                {
                    Text = FieldTypeFromDb.Name,
                    Value = FieldTypeFromDb.Id.ToString()
                });
            }

            SuProcessTemplateFieldEditGetModel ProcessTemplateFieldEditGet = new SuProcessTemplateFieldEditGetModel
            {
                PId = Id
            };
            SuProcessTemplateFieldEditGetWithListModel ProcessTemplateFieldWithList = new SuProcessTemplateFieldEditGetWithListModel
            {
                ProcessTemplateField = ProcessTemplateFieldEditGet,
                FieldTypeList = FieldTypeList
            };

            return View(ProcessTemplateFieldWithList);

            //var ProcessTemplateField = new SuObjectVM
            //{
            //    Id = Id
            //                                ,
            //    LanguageId = DefaultLanguageID
            //};

            ////DataTypes
            //var DataTypeList = new List<SelectListItem>();

            //var DataTypesFromDb = _context.ZDbStatusList.FromSql("DataTypeSelectAll").ToList();


            //foreach (var DataTypeFromDb in DataTypesFromDb)
            //{
            //    DataTypeList.Add(new SelectListItem
            //    {
            //        Text = DataTypeFromDb.Name,
            //        Value = DataTypeFromDb.Id.ToString()
            //    });
            //}

            ////ContentType


            ////MasterList
            //var MasterListList = new List<SelectListItem>();

            //var MasterListsFromDb = _context.ZDbTypeList.FromSql("GetMasterList").ToList();


            //foreach (var MasterListFromDb in MasterListsFromDb)
            //{
            //    MasterListList.Add(new SelectListItem
            //    {
            //        Text = MasterListFromDb.Name,
            //        Value = MasterListFromDb.Id.ToString()
            //    });
            //}

            ////MasterList

            //var FieldsAndDropDowns = new SuProcessTemplateFieldWith2DropDown { Field = ProcessTemplateField, DataTypes = DataTypeList, MasterList = MasterListList };


            //return View(FieldsAndDropDowns);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuProcessTemplateFieldEditGetWithListModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
    

                SqlParameter[] parameters =
                    {
                    new SqlParameter("@PId", FromForm.ProcessTemplateField.PId),
                    new SqlParameter("@LanguageId", CurrentUser.DefaultLanguageId),
                    new SqlParameter("@ProcessTemplateFieldTypeId", FromForm.ProcessTemplateField.ProcessTemplateFieldTypeId),
                    new SqlParameter("@ModifierId", CurrentUser.Id),
                    new SqlParameter("@Name", FromForm.ProcessTemplateField.Name),
                    new SqlParameter("@Description", FromForm.ProcessTemplateField.Description),
                    new SqlParameter("@MouseOver", FromForm.ProcessTemplateField.MouseOver),
                    new SqlParameter("@MenuName", FromForm.ProcessTemplateField.MenuName)
                    };

                _context.Database.ExecuteSqlCommand("ProcessTemplateFieldCreatePost " +
                            "@PId" +
                            ", @LanguageId" +
                            ", @ProcessTemplateFieldTypeId" +
                            ", @ModifierId" +
                            ", @Name" +
                            ", @Description" +
                            ", @MouseOver" +
                            ", @MenuName", parameters);
            }
            return RedirectToAction("Index", new { Id = FromForm.ProcessTemplateField.PId.ToString() });

//            return RedirectToAction("Index");

            //            var CurrentUser = await _userManager.GetUserAsync(User);
            //

            //            SqlParameter[] parameters =
            //{
            //                new SqlParameter("@ProcessTemplateId", FromForm.Field.Id)
            //                , new SqlParameter("@FieldDataTypeId", FromForm.Field.NotNullId)
            //                , new SqlParameter("@FieldMasterListId", FromForm.Field.NotNullId2)
            //                , new SqlParameter("@LanguageId", FromForm.Field.LanguageId)
            //                , new SqlParameter("@Name", FromForm.Field.Name)
            //                , new SqlParameter("@Description", FromForm.Field.Description)
            //                , new SqlParameter("@MouseOver", FromForm.Field.MouseOver)
            //            };

            //            _context.Database.ExecuteSqlCommand("ProcessTemplateFieldCreate @ProcessTemplateId, @FieldDataTypeId, @FieldMasterListId, @LanguageId, @Name, @Description, @MouseOver", parameters);

        }


        public async Task<IActionResult> LanguageIndex(int Id)
        {


            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);


            var parameter = new SqlParameter("@OId", Id);

            var LanguageIndex = _context.ZdbObjectLanguageIndexGet.FromSql("ProcessTemplateFieldLanguageIndexGet @OId", parameter).ToList();
            ViewBag.Id = Id;

            return View(LanguageIndex);

        }

        [HttpGet]
        public async Task<IActionResult> LanguageEdit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);


            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var ObjectLanguage = _context.ZdbObjectLanguageEditGet.FromSql("ProcessTemplateFieldLanguageEditGet @Id", parameter).First();
            return View(ObjectLanguage);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldLanguage = _processTemplateFieldLanguage.GetProcessTemplateFieldLanguage(FromForm.SuObject.Id);
                ProcessTemplateFieldLanguage.Name = FromForm.SuObject.Name;
                ProcessTemplateFieldLanguage.Description = FromForm.SuObject.Description;

                ProcessTemplateFieldLanguage.MouseOver = FromForm.SuObject.MouseOver;
                _processTemplateFieldLanguage.UpdateProcessTemplateFieldLanguage(ProcessTemplateFieldLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> LanguageCreate(int Id)
        {


            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLanguageId;

            var UICustomizationArray = new UICustomization(_context);
            ViewBag.Terms = await UICustomizationArray.UIArray(this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), DefaultLanguageID);
            Menus a = new Menus(_context);

            ViewBag.menuItems = await a.TopMenu(DefaultLanguageID);

            var parameter = new SqlParameter("@Id", Id);

            var LanguageList = _context.ZdbLanguageCreateGetLanguageList.FromSql("ProcessTemplateFieldLanguageCreateGetLanguageList @Id", parameter).ToList();

            List<SelectListItem> LList = new List<SelectListItem>();
            foreach (var Language in LanguageList)
            {
                LList.Add(new SelectListItem { Value = Language.Value, Text = Language.Text });
            }

            if (LList.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id });
            }
            SuObjectLanguageEditGetModel ProcessTemplateField = new SuObjectLanguageEditGetModel
            {
                OId = Id
            };
            ViewBag.Id = Id.ToString();
            var ProcessTemplateFieldAndStatus = new SuObjectLanguageEditGetWitLanguageListModel
            {
                SuObject = ProcessTemplateField
                ,
                LanguageList = LList
            };
            return View(ProcessTemplateFieldAndStatus);


            //List<int> LanguagesAlready = new List<int>();
            //LanguagesAlready = (from c in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
            //                    where c.ProcessTemplateFieldId == Id
            //                    select c.LanguageId).ToList();


            //var SuLanguage = (from l in _language.GetAllLanguages()
            //                  where !LanguagesAlready.Contains(l.Id)
            //                  && l.Active == true
            //                  select new SelectListItem
            //                  {
            //                      Value = l.Id.ToString()
            //                  ,
            //                      Text = l.LanguageName
            //                  }).ToList();

            //if (SuLanguage.Count() == 0)
            //{
            //    return RedirectToAction("LanguageIndex", new { Id });
            //}
            //SuObjectVM SuObject = new SuObjectVM
            //{
            //    ObjectId = Id
            //};
            //ViewBag.Id = Id.ToString();
            //var ClassificationAndStatus = new SuObjectAndStatusViewModel
            //{
            //    SuObject = SuObject
            //    ,
            //    SomeKindINumSelectListItem = SuLanguage
            //};
            //return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                SuProcessTemplateFieldLanguageModel ProcessTemplateFieldLanguage = new SuProcessTemplateFieldLanguageModel
                {
                    Name = FromForm.SuObject.Name,
                    Description = FromForm.SuObject.Description,
                    MouseOver = FromForm.SuObject.MouseOver,
                    ProcessTemplateFieldId = FromForm.SuObject.ObjectId,
                    LanguageId = FromForm.SuObject.LanguageId
                };

                _processTemplateFieldLanguage.AddProcessTemplateFieldLanguage(ProcessTemplateFieldLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        public ActionResult GetMasterList()
        {
            var DataTypeList = new List<SelectListItem>();


            var MasterListsFromDb = _context.ZDbStatusList.FromSql("GetMasterList").ToList();

            foreach (var DataTypeFromDb in MasterListsFromDb)
            {
                DataTypeList.Add(new SelectListItem
                {
                    Text = DataTypeFromDb.Name,
                    Value = DataTypeFromDb.Id.ToString()
                });
            }

            JsonResult x = Json(DataTypeList);
            return x;
        }

    }
}