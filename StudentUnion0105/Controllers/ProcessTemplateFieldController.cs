using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;
using StudentUnion0105.Repositories;
using StudentUnion0105.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentUnion0105.Controllers
{
    public class ProcessTemplateFieldController : Controller
    {
        private readonly UserManager<SuUser> _userManager;
        private readonly IProcessTemplateRepository _processTemplate;
        private readonly IProcessTemplateLanguageRepository _processTemplateLanguage;
        private readonly ILanguageRepository _language;
        private readonly IProcessTemplateFieldRepository _processTemplateField;
        private readonly IProcessTemplateFieldLanguageRepository _processTemplateFieldLanguage;
        private readonly IProcessTemplateFieldTypeRepository _processTemplateFieldType;
        private readonly IProcessTemplateFieldTypeLanguageRepository _processTemplateFieldTypeLanguage;
        private readonly SuDbContext _context;
        private readonly IMasterListRepository _masterList;
        private readonly IDataTypeRepository _dataType;

        public ProcessTemplateFieldController(UserManager<SuUser> userManager
            , IProcessTemplateRepository processTemplate
            , IProcessTemplateLanguageRepository processTemplateLanguage
            , ILanguageRepository language
            , IProcessTemplateFieldRepository processTemplateField
            , IProcessTemplateFieldLanguageRepository processTemplateFieldLanguage
            , IProcessTemplateFieldTypeRepository processTemplateFieldType
            , IProcessTemplateFieldTypeLanguageRepository processTemplateFieldTypeLanguage
            , SuDbContext context
            , IMasterListRepository masterList
            , IDataTypeRepository dataType)
        {
            _userManager = userManager;
            _processTemplate = processTemplate;
            _processTemplateLanguage = processTemplateLanguage;
            _language = language;
            _processTemplateField = processTemplateField;
            _processTemplateFieldLanguage = processTemplateFieldLanguage;
            _processTemplateFieldType = processTemplateFieldType;
            _processTemplateFieldTypeLanguage = processTemplateFieldTypeLanguage;
            _context = context;
            _masterList = masterList;
            _dataType = dataType;
        }

        public SuDbContext Context { get; }

        public async Task<IActionResult> Index(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;

            var ProcessTemplateField = (from c in  _processTemplateField.GetAllProcessTemplateFields()
                               join l in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                      on c.Id equals l.ProcessTemplateFieldId
                               where c.ProcessTemplateId== Id
                               && l.LanguageId == DefaultLanguageID
                               orderby l.ProcessTemplateFieldName
                               select new SuObjectVM
                               {
                                   Id = c.Id
                               ,
                                   Name = l.ProcessTemplateFieldName
                               ,
                                   ObjectId = c.ProcessTemplateId
                               }).ToList();
            ViewBag.ObjectId = Id.ToString();


            return View(ProcessTemplateField);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateField = (from c in _processTemplateField.GetAllProcessTemplateFields()
                                        join l in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                        on c.Id equals l.ProcessTemplateFieldId
                                        where c.Id == Id && l.LanguageId == DefaultLanguageID
                                        orderby l.ProcessTemplateFieldName
                                        select new SuObjectVM
                                        {
                                            Id = c.ProcessTemplateId
                                            ,
                                            ObjectId = c.Id
                                            ,
                                            LanguageId = l.LanguageId
                                            ,
                                            ObjectLanguageId = l.Id
                                            ,
                                            Name = l.ProcessTemplateFieldName
                                            ,
                                            Description = l.ProcessTemplateFieldDescription
                                            ,
                                            MouseOver = l.ProcessTemplateFieldMouseOver
                                            , NotNullId = c.FieldDataTypeId
                                            , NotNullId2 = c.FieldMasterListId
                                        }).First();

            //DataTypes
            var DataTypeList = new List<SelectListItem>();

            var DataTypesFromDb = _context.dbStatusList.FromSql($"GetDataTypes").ToList();


            foreach (var DataTypeFromDb in DataTypesFromDb)
            {
                DataTypeList.Add(new SelectListItem
                {
                    Text = DataTypeFromDb.Name,
                    Value = DataTypeFromDb.Id.ToString()
                });
            }

            //ContentType


            //MasterList
            var MasterListList = new List<SelectListItem>();

            var MasterListsFromDb = _context.dbStatusList.FromSql($"GetMasterList").ToList();


            foreach (var MasterListFromDb in MasterListsFromDb)
            {
                MasterListList.Add(new SelectListItem
                {
                    Text = MasterListFromDb.Name,
                    Value = MasterListFromDb.Id.ToString()
                });
            }

            //MasterList

            var FieldsAndDropDowns = new SuProcessTemplateFieldWith2DropDown { Field = ProcessTemplateField, DataTypes = DataTypeList, MasterList = MasterListList } ;


            return View(FieldsAndDropDowns);
           

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuProcessTemplateFieldWith2DropDown FromForm)
        {

            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;
                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFieldUpdate @p0, @p1, @p2, @p3, @p4, @p5, @p6 " 
                    ,
                    parameters: new[] { FromForm.Field.ObjectId.ToString()           //0
                                        ,FromForm.Field.NotNullId.ToString()
                                        ,FromForm.Field.NotNullId2.ToString()
                                        , FromForm.Field.ObjectLanguageId.ToString()
                                        , FromForm.Field.Name
                                        , FromForm.Field.Description
                                        , FromForm.Field.MouseOver
                                        , CurrentUser.Id

                    });
            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );

            return RedirectToAction("Index", new { Id = FromForm.Field.Id.ToString() });



        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            var DefaultLanguageID = CurrentUser.DefaultLangauge;
            var ProcessTemplateField = new SuObjectVM
            {
                Id = Id
                                            ,
                LanguageId = DefaultLanguageID
            };

            //DataTypes
            var DataTypeList = new List<SelectListItem>();

            var DataTypesFromDb = _context.dbStatusList.FromSql($"GetDataTypes").ToList();


            foreach (var DataTypeFromDb in DataTypesFromDb)
            {
                DataTypeList.Add(new SelectListItem
                {
                    Text = DataTypeFromDb.Name,
                    Value = DataTypeFromDb.Id.ToString()
                });
            }

            //ContentType


            //MasterList
            var MasterListList = new List<SelectListItem>();

            var MasterListsFromDb = _context.dbTypeList.FromSql($"GetMasterList").ToList();


            foreach (var MasterListFromDb in MasterListsFromDb)
            {
                MasterListList.Add(new SelectListItem
                {
                    Text = MasterListFromDb.Name,
                    Value = MasterListFromDb.Id.ToString()
                });
            }

            //MasterList

            var FieldsAndDropDowns = new SuProcessTemplateFieldWith2DropDown { Field = ProcessTemplateField, DataTypes = DataTypeList, MasterList = MasterListList };


            return View(FieldsAndDropDowns);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuProcessTemplateFieldWith2DropDown FromForm)
        {
            if (ModelState.IsValid)
            {
                var CurrentUser = await _userManager.GetUserAsync(User);
                var DefaultLanguageID = CurrentUser.DefaultLangauge;

                var a = _context.Database.ExecuteSqlCommand("ProcessTemplateFieldCreate @p0, @p1, @p2, @p3, @p4, @p5, @p6  ",
                    parameters: new[] { FromForm.Field.Id.ToString()           //0
                                           , FromForm.Field.NotNullId.ToString()
                                           , FromForm.Field.NotNullId2.ToString()
                                           , FromForm.Field.LanguageId.ToString()
                                           , FromForm.Field.Name
                                           , FromForm.Field.Description
                                           , FromForm.Field.MouseOver
                                           , CurrentUser.Id


                    });

            }
            return RedirectToAction("Index", new { Id = FromForm.Field.Id.ToString() });

        }


        public IActionResult LanguageIndex(int Id)
        {

            var 
                ProcessTemplateFieldLanguage = (from c in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                          join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                                          where c.ProcessTemplateFieldId == Id
                                          select new SuObjectVM
                                          {
                                              Id = c.Id
                                          ,
                                              Name = c.ProcessTemplateFieldName
                                          ,
                                              Language = l.LanguageName
                                          ,
                                              MouseOver = c.ProcessTemplateFieldMouseOver
                                          ,
                                              ObjectId = c.ProcessTemplateFieldId
                                          }).ToList();
            ViewBag.Id = Id;

            return View(ProcessTemplateFieldLanguage);
        }

        [HttpGet]
        public IActionResult LanguageEdit(int Id)
        {
            var FieldLanguage = (from c in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                         join l in _language.GetAllLanguages()
                         on c.LanguageId equals l.Id
                         where c.Id == Id
                         select new SuObjectVM
                         {
                             Id = c.Id
                            ,
                             Name = c.ProcessTemplateFieldName
                            ,
                             Description = c.ProcessTemplateFieldDescription
                            ,
                             MouseOver = c.ProcessTemplateFieldMouseOver
                            ,
                             Language = l.LanguageName
                            ,
                             ObjectId = c.ProcessTemplateFieldId

                         }).First();

            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = FieldLanguage //, a = ClassificationList
            };
            return View(ClassificationAndStatus);
            //return View(FieldLanguage);


        }

        [HttpPost]
        public IActionResult LanguageEdit(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldLanguage = _processTemplateFieldLanguage.GetProcessTemplateFieldLanguage(FromForm.SuObject.Id);
                ProcessTemplateFieldLanguage.ProcessTemplateFieldName = FromForm.SuObject.Name;
                ProcessTemplateFieldLanguage.ProcessTemplateFieldDescription = FromForm.SuObject.Description;

                ProcessTemplateFieldLanguage.ProcessTemplateFieldMouseOver = FromForm.SuObject.MouseOver;
                _processTemplateFieldLanguage.UpdateProcessTemplateFieldLanguage(ProcessTemplateFieldLanguage);


            }
            //            return  RedirectToRoute("EditRole" + "/"+FromForm.Classification.ClassificationId.ToString() );

            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }

        [HttpGet]
        public IActionResult LanguageCreate(int Id)
        {
            List<int> LanguagesAlready = new List<int>();
            LanguagesAlready = (from c in _processTemplateFieldLanguage.GetAllProcessTemplateFieldLanguages()
                                where c.ProcessTemplateFieldId == Id
                                select c.LanguageId).ToList();


            var SuLanguage = (from l in _language.GetAllLanguages()
                              where !LanguagesAlready.Contains(l.Id)
                              && l.Active == true
                              select new SelectListItem
                              {
                                  Value = l.Id.ToString()
                              ,
                                  Text = l.LanguageName
                              }).ToList();

            if (SuLanguage.Count() == 0)
            {
                return RedirectToAction("LanguageIndex", new { Id = Id });
            }
            SuObjectVM SuObject = new SuObjectVM();
            SuObject.ObjectId = Id;
            ViewBag.Id = Id.ToString();
            var ClassificationAndStatus = new SuObjectAndStatusViewModel
            {
                SuObject = SuObject
                ,
                SomeKindINumSelectListItem = SuLanguage
            };
            return View(ClassificationAndStatus);
        }

        [HttpPost]
        public IActionResult LanguageCreate(SuObjectAndStatusViewModel FromForm)
        {
            if (ModelState.IsValid)
            {
                var ProcessTemplateFieldLanguage = new SuProcessTemplateFieldLanguageModel();
                ProcessTemplateFieldLanguage.ProcessTemplateFieldName = FromForm.SuObject.Name;
                ProcessTemplateFieldLanguage.ProcessTemplateFieldDescription = FromForm.SuObject.Description;
                ProcessTemplateFieldLanguage.ProcessTemplateFieldMouseOver = FromForm.SuObject.MouseOver;
                ProcessTemplateFieldLanguage.ProcessTemplateFieldId = FromForm.SuObject.ObjectId;
                ProcessTemplateFieldLanguage.LanguageId = FromForm.SuObject.LanguageId;

                var NewProcessTemplateField = _processTemplateFieldLanguage.AddProcessTemplateFieldLanguage(ProcessTemplateFieldLanguage);


            }
            return RedirectToAction("LanguageIndex", new { Id = FromForm.SuObject.ObjectId.ToString() });



        }


    }
}