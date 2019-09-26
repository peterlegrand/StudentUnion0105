using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentUnion0105.Data;
using StudentUnion0105.Models;


namespace StudentUnion0105.Controllers
{
    [AllowAnonymous]
    public class SetupWizardController : Controller
    {
        private readonly UserManager<SuUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment env;
        private readonly SuDbContext _context;

        public SetupWizardController(UserManager<SuUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IHostingEnvironment env
            , SuDbContext context
            )
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var x = await userManager.FindByEmailAsync("eplegrand@gmail.com");
            if ( x == null)
            {
                SuUser user1 = new SuUser()
                {
                    UserName = "eplegrand@gmail.com",
                    Email = "eplegrand@gmail.com",
                    DefaultLangauge = 41
                };

                IdentityResult result = userManager.CreateAsync(user1, "Pipo!9165").Result;

            }

            if (env.IsDevelopment())
                
            { 
            if (userManager.FindByEmailAsync("pipo@gmail.com").Result == null)
            {
                SuUser user1 = new SuUser()
                {
                    UserName = "pipo@gmail.com",
                    Email = "pipo@gmail.com",
                    DefaultLangauge = 41
                };
                
                IdentityResult result = userManager.CreateAsync(user1, "Xipo!9165").Result;
                }
            }

            var user = await userManager.FindByEmailAsync("eplegrand@gmail.com");

            foreach (var a in await userManager.GetRolesAsync(user))
            { await userManager.RemoveFromRoleAsync(user, a); }
            userManager.AddToRoleAsync(user, "Admin").Wait();
            userManager.AddToRoleAsync(user, "Super admin").Wait();



            var SuperAdmin = await roleManager.FindByNameAsync("Super admin");
            var checkroles = await roleManager.GetClaimsAsync(SuperAdmin);
            foreach (var claim in await roleManager.GetClaimsAsync(SuperAdmin))
            {
                await roleManager.RemoveClaimAsync(SuperAdmin, claim);
            }
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Role"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Classification"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Page"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Project"));
            await roleManager.AddClaimAsync(SuperAdmin, new System.Security.Claims.Claim("Menu", "Type"));

            _context.Database.ExecuteSqlCommand(
                "create PROCEDURE InitializeDB AS" +
"DECLARE @CurrentUser uniqueidentifier;" +
"--DECLARE @Id int;" +
"--DECLARE @OutputTbl TABLE (ID INT);" +
"" +
"SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com';" +
"" +
"UPDATE AspNetUsers SET DefaultLangauge = 41;" +
"" +
"" +
"INSERT INTO dbLanguage VALUES(1, 'Abkhazian', N'аҧсуа бызшәа, аҧсшәа', 'ab', 'abk', 0);" +
"INSERT INTO dbLanguage VALUES(2, 'Afar', N'Afaraf', 'aa', 'aar', 0);" +
"INSERT INTO dbLanguage VALUES(3, 'Afrikaans', N'Afrikaans', 'af', 'afr', 0);" +
"INSERT INTO dbLanguage VALUES(4, 'Akan', N'Akan', 'ak', 'aka', 0);" +
"INSERT INTO dbLanguage VALUES(5, 'Albanian', N'Shqip', 'sq', 'sqi', 0);" +
"INSERT INTO dbLanguage VALUES(6, 'Amharic', N'አማርኛ', 'am', 'amh', 0);" +
"INSERT INTO dbLanguage VALUES(7, 'Arabic', N'العربية', 'ar', 'ara', 0);" +
"INSERT INTO dbLanguage VALUES(8, 'Aragonese', N'aragonés', 'an', 'arg', 0);" +
"INSERT INTO dbLanguage VALUES(9, 'Armenian', N'Հայերեն', 'hy', 'hye', 0);" +
"INSERT INTO dbLanguage VALUES(10, 'Assamese', N'অসমীয়া', 'as', 'asm', 0);" +
"INSERT INTO dbLanguage VALUES(11, 'Avaric', N'авар мацӀ, магӀарул мацӀ', 'av', 'ava', 0);" +
"INSERT INTO dbLanguage VALUES(12, 'Avestan', N'avesta', 'ae', 'ave', 0);" +
"INSERT INTO dbLanguage VALUES(13, 'Aymara', N'aymar aru', 'ay', 'aym', 0);" +
"INSERT INTO dbLanguage VALUES(14, 'Azerbaijani', N'azərbaycan dili', 'az', 'aze', 0);" +
"INSERT INTO dbLanguage VALUES(15, 'Bambara', N'bamanankan', 'bm', 'bam', 0);" +
"INSERT INTO dbLanguage VALUES(16, 'Bashkir', N'башҡорт теле', 'ba', 'bak', 0);" +
"INSERT INTO dbLanguage VALUES(17, 'Basque', N'euskara, euskera', 'eu', 'eus', 0);" +
"INSERT INTO dbLanguage VALUES(18, 'Belarusian', N'беларуская мова', 'be', 'bel', 0);" +
"INSERT INTO dbLanguage VALUES(19, 'Bengali', N'বাংলা', 'bn', 'ben', 0);" +
"INSERT INTO dbLanguage VALUES(20, 'Bihari languages', N'भोजपुरी', 'bh', 'bih', 0);" +
"INSERT INTO dbLanguage VALUES(21, 'Bislama', N'Bislama', 'bi', 'bis', 0);" +
"INSERT INTO dbLanguage VALUES(22, 'Bosnian', N'bosanski jezik', 'bs', 'bos', 0);" +
"INSERT INTO dbLanguage VALUES(23, 'Breton', N'brezhoneg', 'br', 'bre', 0);" +
"INSERT INTO dbLanguage VALUES(24, 'Bulgarian', N'български език', 'bg', 'bul', 0);" +
"INSERT INTO dbLanguage VALUES(25, 'Burmese', N'ဗမာစာ', 'my', 'mya', 0);" +
"INSERT INTO dbLanguage VALUES(26, 'Catalan, Valencian', N'català, valencià', 'ca', 'cat', 0);" +
"INSERT INTO dbLanguage VALUES(27, 'Chamorro', N'Chamoru', 'ch', 'cha', 0);" +
"INSERT INTO dbLanguage VALUES(28, 'Chechen', N'нохчийн мотт', 'ce', 'che', 0);" +
"INSERT INTO dbLanguage VALUES(29, 'Chichewa, Chewa, Nyanja', N'chiCheŵa, chinyanja', 'ny', 'nya', 0);" +
"INSERT INTO dbLanguage VALUES(30, 'Chinese', N'中文 (Zhōngwén), 汉语, 漢語', 'zh', 'zho', 0);" +
"INSERT INTO dbLanguage VALUES(31, 'Chuvash', N'чӑваш чӗлхи', 'cv', 'chv', 0);" +
"INSERT INTO dbLanguage VALUES(32, 'Cornish', N'Kernewek', 'kw', 'cor', 0);" +
"INSERT INTO dbLanguage VALUES(33, 'Corsican', N'corsu, lingua corsa', 'co', 'cos', 0);" +
"INSERT INTO dbLanguage VALUES(34, 'Cree', N'ᓀᐦᐃᔭᐍᐏᐣ', 'cr', 'cre', 0);" +
"INSERT INTO dbLanguage VALUES(35, 'Croatian', N'hrvatski jezik', 'hr', 'hrv', 0);" +
"INSERT INTO dbLanguage VALUES(36, 'Czech', N'čeština, český jazyk', 'cs', 'ces', 0);" +
"INSERT INTO dbLanguage VALUES(37, 'Danish', N'dansk', 'da', 'dan', 0);" +
"INSERT INTO dbLanguage VALUES(38, 'Divehi, Dhivehi, Maldivian', N'ދިވެހި', 'dv', 'div', 0);" +
"INSERT INTO dbLanguage VALUES(39, 'Dutch, Flemish', N'Nederlands, Vlaams', 'nl', 'nld', 1);" +
"INSERT INTO dbLanguage VALUES(40, 'Dzongkha', N'རྫོང་ཁ', 'dz', 'dzo', 0);" +
"INSERT INTO dbLanguage VALUES(41, 'English', N'English', 'en', 'eng', 1);" +
"INSERT INTO dbLanguage VALUES(42, 'Esperanto', N'Esperanto', 'eo', 'epo', 0);" +
"INSERT INTO dbLanguage VALUES(43, 'Estonian', N'eesti, eesti keel', 'et', 'est', 0);" +
"INSERT INTO dbLanguage VALUES(44, 'Ewe', N'Eʋegbe', 'ee', 'ewe', 0);" +
"INSERT INTO dbLanguage VALUES(45, 'Faroese', N'føroyskt', 'fo', 'fao', 0);" +
"INSERT INTO dbLanguage VALUES(46, 'Fijian', N'vosa Vakaviti', 'fj', 'fij', 0);" +
"INSERT INTO dbLanguage VALUES(47, 'Finnish', N'suomi, suomen kieli', 'fi', 'fin', 0);" +
"INSERT INTO dbLanguage VALUES(48, 'French', N'français, langue française', 'fr', 'fra', 0);" +
"INSERT INTO dbLanguage VALUES(49, 'Fulah', N'Fulfulde, Pulaar, Pular', 'ff', 'ful', 0);" +
"INSERT INTO dbLanguage VALUES(50, 'Galician', N'Galego', 'gl', 'glg', 0);" +
"INSERT INTO dbLanguage VALUES(51, 'Georgian', N'ქართული', 'ka', 'kat', 0);" +
"INSERT INTO dbLanguage VALUES(52, 'German', N'Deutsch', 'de', 'deu', 0);" +
"INSERT INTO dbLanguage VALUES(53, 'Greek, Modern (1453-)', N'ελληνικά', 'el', 'ell', 0);" +
"INSERT INTO dbLanguage VALUES(54, 'Guarani', N'Avañe''ẽ', 'gn', 'grn', 0);" +
"INSERT INTO dbLanguage VALUES(55, 'Gujarati', N'ગુજરાતી', 'gu', 'guj', 0);" +
"INSERT INTO dbLanguage VALUES(56, 'Haitian, Haitian Creole', N'Kreyòl ayisyen', 'ht', 'hat', 0);" +
"INSERT INTO dbLanguage VALUES(57, 'Hausa', N'(Hausa) هَوُسَ', 'ha', 'hau', 0);" +
"INSERT INTO dbLanguage VALUES(58, 'Hebrew', N'עברית', 'he', 'heb', 0);" +
"INSERT INTO dbLanguage VALUES(59, 'Herero', N'Otjiherero', 'hz', 'her', 0);" +
"INSERT INTO dbLanguage VALUES(60, 'Hindi', N'हिन्दी, हिंदी', 'hi', 'hin', 0);" +
"INSERT INTO dbLanguage VALUES(61, 'Hiri Motu', N'Hiri Motu', 'ho', 'hmo', 0);" +
"INSERT INTO dbLanguage VALUES(62, 'Hungarian', N'magyar', 'hu', 'hun', 0);" +
"INSERT INTO dbLanguage VALUES(63, 'Interlingua', N'Interlingua', 'ia', 'ina', 0);" +
"INSERT INTO dbLanguage VALUES(64, 'Indonesian', N'Bahasa Indonesia', 'id', 'ind', 0);" +
"INSERT INTO dbLanguage VALUES(65, 'Interlingue, Occidental', N'(originally:) Occidental, (after WWII:) Interlingue', 'ie', 'ile', 0);" +
"INSERT INTO dbLanguage VALUES(66, 'Irish', N'Gaeilge', 'ga', 'gle', 0);" +
"INSERT INTO dbLanguage VALUES(67, 'Igbo', N'Asụsụ Igbo', 'ig', 'ibo', 0);" +
"INSERT INTO dbLanguage VALUES(68, 'Inupiaq', N'Iñupiaq, Iñupiatun', 'ik', 'ipk', 0);" +
"INSERT INTO dbLanguage VALUES(69, 'Ido', N'Ido', 'io', 'ido', 0);" +
"INSERT INTO dbLanguage VALUES(70, 'Icelandic', N'Íslenska', 'is', 'isl', 0);" +
"INSERT INTO dbLanguage VALUES(71, 'Italian', N'Italiano', 'it', 'ita', 0);" +
"INSERT INTO dbLanguage VALUES(72, 'Inuktitut', N'ᐃᓄᒃᑎᑐᑦ', 'iu', 'iku', 0);" +
"INSERT INTO dbLanguage VALUES(73, 'Japanese', N'日本語 (にほんご)', 'ja', 'jpn', 0);" +
"INSERT INTO dbLanguage VALUES(74, 'Javanese', N'ꦧꦱꦗꦮ, Basa Jawa', 'jv', 'jav', 0);" +
"INSERT INTO dbLanguage VALUES(75, 'Kalaallisut, Greenlandic', N'kalaallisut, kalaallit oqaasii', 'kl', 'kal', 0);" +
"INSERT INTO dbLanguage VALUES(76, 'Kannada', N'ಕನ್ನಡ', 'kn', 'kan', 0);" +
"INSERT INTO dbLanguage VALUES(77, 'Kanuri', N'Kanuri', 'kr', 'kau', 0);" +
"INSERT INTO dbLanguage VALUES(78, 'Kashmiri', N'कश्मीरी, كشميري‎', 'ks', 'kas', 0);" +
"INSERT INTO dbLanguage VALUES(79, 'Kazakh', N'қазақ тілі', 'kk', 'kaz', 0);" +
"INSERT INTO dbLanguage VALUES(80, 'Central Khmer', N'ខ្មែរ, ខេមរភាសា, ភាសាខ្មែរ', 'km', 'khm', 0);" +
"INSERT INTO dbLanguage VALUES(81, 'Kikuyu, Gikuyu', N'Gĩkũyũ', 'ki', 'kik', 0);" +
"INSERT INTO dbLanguage VALUES(82, 'Kinyarwanda', N'Ikinyarwanda', 'rw', 'kin', 0);" +
"INSERT INTO dbLanguage VALUES(83, 'Kirghiz, Kyrgyz', N'Кыргызча, Кыргыз тили', 'ky', 'kir', 0);" +
"INSERT INTO dbLanguage VALUES(84, 'Komi', N'коми кыв', 'kv', 'kom', 0);" +
"INSERT INTO dbLanguage VALUES(85, 'Kongo', N'Kikongo', 'kg', 'kon', 0);" +
"INSERT INTO dbLanguage VALUES(86, 'Korean', N'한국어', 'ko', 'kor', 0);" +
"INSERT INTO dbLanguage VALUES(87, 'Kurdish', N'Kurdî, کوردی‎', 'ku', 'kur', 0);" +
"INSERT INTO dbLanguage VALUES(88, 'Kuanyama, Kwanyama', N'Kuanyama', 'kj', 'kua', 0);" +
"INSERT INTO dbLanguage VALUES(89, 'Latin', N'latine, lingua latina', 'la', 'lat', 0);" +
"INSERT INTO dbLanguage VALUES(90, 'Luxembourgish, Letzeburgesch', N'Lëtzebuergesch', 'lb', 'ltz', 0);" +
"INSERT INTO dbLanguage VALUES(91, 'Ganda', N'Luganda', 'lg', 'lug', 0);" +
"INSERT INTO dbLanguage VALUES(92, 'Limburgan, Limburger, Limburgish', N'Limburgs', 'li', 'lim', 0);" +
"INSERT INTO dbLanguage VALUES(93, 'Lingala', N'Lingála', 'ln', 'lin', 0);" +
"INSERT INTO dbLanguage VALUES(94, 'Lao', N'ພາສາລາວ', 'lo', 'lao', 0);" +
"INSERT INTO dbLanguage VALUES(95, 'Lithuanian', N'lietuvių kalba', 'lt', 'lit', 0);" +
"INSERT INTO dbLanguage VALUES(96, 'Luba-Katanga', N'Kiluba', 'lu', 'lub', 0);" +
"INSERT INTO dbLanguage VALUES(97, 'Latvian', N'latviešu valoda', 'lv', 'lav', 0);" +
"INSERT INTO dbLanguage VALUES(98, 'Manx', N'Gaelg, Gailck', 'gv', 'glv', 0);" +
"INSERT INTO dbLanguage VALUES(99, 'Macedonian', N'македонски јазик', 'mk', 'mkd', 0);" +
"INSERT INTO dbLanguage VALUES(100, 'Malagasy', N'fiteny malagasy', 'mg', 'mlg', 0);" +
"INSERT INTO dbLanguage VALUES(101, 'Malay', N'Bahasa Melayu, بهاس ملايو‎', 'ms', 'msa', 0);" +
"INSERT INTO dbLanguage VALUES(102, 'Malayalam', N'മലയാളം', 'ml', 'mal', 0);" +
"INSERT INTO dbLanguage VALUES(103, 'Maltese', N'Malti', 'mt', 'mlt', 0);" +
"INSERT INTO dbLanguage VALUES(104, 'Maori', N'te reo Māori', 'mi', 'mri', 0);" +
"INSERT INTO dbLanguage VALUES(105, 'Marathi', N'मराठी', 'mr', 'mar', 0);" +
"INSERT INTO dbLanguage VALUES(106, 'Marshallese', N'Kajin M̧ajeļ', 'mh', 'mah', 0);" +
"INSERT INTO dbLanguage VALUES(107, 'Mongolian', N'Монгол хэл', 'mn', 'mon', 0);" +
"INSERT INTO dbLanguage VALUES(108, 'Nauru', N'Dorerin Naoero', 'na', 'nau', 0);" +
"INSERT INTO dbLanguage VALUES(109, 'Navajo, Navaho', N'Diné bizaad', 'nv', 'nav', 0);" +
"INSERT INTO dbLanguage VALUES(110, 'North Ndebele', N'isiNdebele', 'nd', 'nde', 0);" +
"INSERT INTO dbLanguage VALUES(111, 'Nepali', N'नेपाली', 'ne', 'nep', 0);" +
"INSERT INTO dbLanguage VALUES(112, 'Ndonga', N'Owambo', 'ng', 'ndo', 0);" +
"INSERT INTO dbLanguage VALUES(113, 'Norwegian Bokmål', N'Norsk Bokmål', 'nb', 'nob', 0);" +
"INSERT INTO dbLanguage VALUES(114, 'Norwegian Nynorsk', N'Norsk Nynorsk', 'nn', 'nno', 0);" +
"INSERT INTO dbLanguage VALUES(115, 'Norwegian', N'Norsk', 'no', 'nor', 0);" +
"INSERT INTO dbLanguage VALUES(116, 'Sichuan Yi, Nuosu', N'ꆈꌠ꒿ Nuosuhxop', 'ii', 'iii', 0);" +
"INSERT INTO dbLanguage VALUES(117, 'South Ndebele', N'isiNdebele', 'nr', 'nbl', 0);" +
"INSERT INTO dbLanguage VALUES(118, 'Occitan', N'occitan, lenga d''òc', 'oc', 'oci', 0);" +
"INSERT INTO dbLanguage VALUES(119, 'Ojibwa', N'ᐊᓂᔑᓈᐯᒧᐎᓐ', 'oj', 'oji', 0);" +
"INSERT INTO dbLanguage VALUES(120, 'Church Slavic, Old Slavonic, Church Slavonic', N'ѩзыкъ словѣньскъ', 'cu', 'chu', 0);" +
"INSERT INTO dbLanguage VALUES(121, 'Oromo', N'Afaan Oromoo', 'om', 'orm', 0);" +
"INSERT INTO dbLanguage VALUES(122, 'Oriya', N'ଓଡ଼ିଆ', 'or', 'ori', 0);" +
"INSERT INTO dbLanguage VALUES(123, 'Ossetian, Ossetic', N'ирон æвзаг', 'os', 'oss', 0);" +
"INSERT INTO dbLanguage VALUES(124, 'Punjabi, Panjabi', N'ਪੰਜਾਬੀ, پنجابی‎', 'pa', 'pan', 0);" +
"INSERT INTO dbLanguage VALUES(125, 'Pali', N'पालि, पाळि', 'pi', 'pli', 0);" +
"INSERT INTO dbLanguage VALUES(126, 'Persian', N'فارسی', 'fa', 'fas', 0);" +
"INSERT INTO dbLanguage VALUES(127, 'Polish', N'język polski, polszczyzna', 'pl', 'pol', 0);" +
"INSERT INTO dbLanguage VALUES(128, 'Pashto, Pushto', N'پښتو', 'ps', 'pus', 0);" +
"INSERT INTO dbLanguage VALUES(129, 'Portuguese', N'Português', 'pt', 'por', 0);" +
"INSERT INTO dbLanguage VALUES(130, 'Quechua', N'Runa Simi, Kichwa', 'qu', 'que', 0);" +
"INSERT INTO dbLanguage VALUES(131, 'Romansh', N'Rumantsch Grischun', 'rm', 'roh', 0);" +
"INSERT INTO dbLanguage VALUES(132, 'Rundi', N'Ikirundi', 'rn', 'run', 0);" +
"INSERT INTO dbLanguage VALUES(133, 'Romanian, Moldavian, Moldovan', N'Română', 'ro', 'ron', 0);" +
"INSERT INTO dbLanguage VALUES(134, 'Russian', N'русский', 'ru', 'rus', 0);" +
"INSERT INTO dbLanguage VALUES(135, 'Sanskrit', N'संस्कृतम्', 'sa', 'san', 0);" +
"INSERT INTO dbLanguage VALUES(136, 'Sardinian', N'sardu', 'sc', 'srd', 0);" +
"INSERT INTO dbLanguage VALUES(137, 'Sindhi', N'सिन्धी, سنڌي، سندھی‎', 'sd', 'snd', 0);" +
"INSERT INTO dbLanguage VALUES(138, 'Northern Sami', N'Davvisámegiella', 'se', 'sme', 0);" +
"INSERT INTO dbLanguage VALUES(139, 'Samoan', N'gagana fa''a Samoa', 'sm', 'smo', 0);" +
"INSERT INTO dbLanguage VALUES(140, 'Sango', N'yângâ tî sängö', 'sg', 'sag', 0);" +
"INSERT INTO dbLanguage VALUES(141, 'Serbian', N'српски језик', 'sr', 'srp', 0);" +
"INSERT INTO dbLanguage VALUES(142, 'Gaelic, Scottish Gaelic', N'Gàidhlig', 'gd', 'gla', 0);" +
"INSERT INTO dbLanguage VALUES(143, 'Shona', N'chiShona', 'sn', 'sna', 0);" +
"INSERT INTO dbLanguage VALUES(144, 'Sinhala, Sinhalese', N'සිංහල', 'si', 'sin', 0);" +
"INSERT INTO dbLanguage VALUES(145, 'Slovak', N'Slovenčina, Slovenský Jazyk', 'sk', 'slk', 0);" +
"INSERT INTO dbLanguage VALUES(146, 'Slovenian', N'Slovenski Jezik, Slovenščina', 'sl', 'slv', 0);" +
"INSERT INTO dbLanguage VALUES(147, 'Somali', N'Soomaaliga, af Soomaali', 'so', 'som', 0);" +
"INSERT INTO dbLanguage VALUES(148, 'Southern Sotho', N'Sesotho', 'st', 'sot', 0);" +
"INSERT INTO dbLanguage VALUES(149, 'Spanish, Castilian', N'Español', 'es', 'spa', 0);" +
"INSERT INTO dbLanguage VALUES(150, 'Sundanese', N'Basa Sunda', 'su', 'sun', 0);" +
"INSERT INTO dbLanguage VALUES(151, 'Swahili', N'Kiswahili', 'sw', 'swa', 0);" +
"INSERT INTO dbLanguage VALUES(152, 'Swati', N'SiSwati', 'ss', 'ssw', 0);" +
"INSERT INTO dbLanguage VALUES(153, 'Swedish', N'Svenska', 'sv', 'swe', 0);" +
"INSERT INTO dbLanguage VALUES(154, 'Tamil', N'தமிழ்', 'ta', 'tam', 0);" +
"INSERT INTO dbLanguage VALUES(155, 'Telugu', N'తెలుగు', 'te', 'tel', 0);" +
"INSERT INTO dbLanguage VALUES(156, 'Tajik', N'тоҷикӣ, toçikī, تاجیکی‎', 'tg', 'tgk', 0);" +
"INSERT INTO dbLanguage VALUES(157, 'Thai', N'ไทย', 'th', 'tha', 0);" +
"INSERT INTO dbLanguage VALUES(158, 'Tigrinya', N'ትግርኛ', 'ti', 'tir', 0);" +
"INSERT INTO dbLanguage VALUES(159, 'Tibetan', N'བོད་ཡིག', 'bo', 'bod', 0);" +
"INSERT INTO dbLanguage VALUES(160, 'Turkmen', N'Türkmen, Түркмен', 'tk', 'tuk', 0);" +
"INSERT INTO dbLanguage VALUES(161, 'Tagalog', N'Wikang Tagalog', 'tl', 'tgl', 0);" +
"INSERT INTO dbLanguage VALUES(162, 'Tswana', N'Setswana', 'tn', 'tsn', 0);" +
"INSERT INTO dbLanguage VALUES(163, 'Tonga (Tonga Islands)', N'Faka Tonga', 'to', 'ton', 0);" +
"INSERT INTO dbLanguage VALUES(164, 'Turkish', N'Türkçe', 'tr', 'tur', 0);" +
"INSERT INTO dbLanguage VALUES(165, 'Tsonga', N'Xitsonga', 'ts', 'tso', 0);" +
"INSERT INTO dbLanguage VALUES(166, 'Tatar', N'татар теле, tatar tele', 'tt', 'tat', 0);" +
"INSERT INTO dbLanguage VALUES(167, 'Twi', N'Twi', 'tw', 'twi', 0);" +
"INSERT INTO dbLanguage VALUES(168, 'Tahitian', N'Reo Tahiti', 'ty', 'tah', 0);" +
"INSERT INTO dbLanguage VALUES(169, 'Uighur, Uyghur', N'ئۇيغۇرچە‎, Uyghurche', 'ug', 'uig', 0);" +
"INSERT INTO dbLanguage VALUES(170, 'Ukrainian', N'Українська', 'uk', 'ukr', 0);" +
"INSERT INTO dbLanguage VALUES(171, 'Urdu', N'اردو', 'ur', 'urd', 0);" +
"INSERT INTO dbLanguage VALUES(172, 'Uzbek', N'Oʻzbek, Ўзбек, أۇزبېك‎', 'uz', 'uzb', 0);" +
"INSERT INTO dbLanguage VALUES(173, 'Venda', N'Tshivenḓa', 've', 'ven', 0);" +
"INSERT INTO dbLanguage VALUES(174, 'Vietnamese', N'Tiếng Việt', 'vi', 'vie', 0);" +
"INSERT INTO dbLanguage VALUES(175, 'Volapük', N'Volapük', 'vo', 'vol', 0);" +
"INSERT INTO dbLanguage VALUES(176, 'Walloon', N'Walon', 'wa', 'wln', 0);" +
"INSERT INTO dbLanguage VALUES(177, 'Welsh', N'Cymraeg', 'cy', 'cym', 0);" +
"INSERT INTO dbLanguage VALUES(178, 'Wolof', N'Wollof', 'wo', 'wol', 0);" +
"INSERT INTO dbLanguage VALUES(179, 'Western Frisian', N'Frysk', 'fy', 'fry', 0);" +
"INSERT INTO dbLanguage VALUES(180, 'Xhosa', N'isiXhosa', 'xh', 'xho', 0);" +
"INSERT INTO dbLanguage VALUES(181, 'Yiddish', N'ייִדיש', 'yi', 'yid', 0);" +
"INSERT INTO dbLanguage VALUES(182, 'Yoruba', N'Yorùbá', 'yo', 'yor', 0);" +
"INSERT INTO dbLanguage VALUES(183, 'Zhuang, Chuang', N'Saɯ cueŋƅ, Saw cuengh', 'za', 'zha', 0);" +
"INSERT INTO dbLanguage VALUES(184, 'Zulu', N'isiZulu', 'zu', 'zul', 0);" +
"" +
"" +
"INSERT INTO dbContentType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  1, 41, 'Knowledge','Knowledge','Knowledge', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbContentType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 41, 'Experience','Experience','Experience', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbContentType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  3, 41, 'Assignments','Assignments','Assignments', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"" +
"INSERT INTO dbOrganizationType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  1, 41, 'Organization','Organization','Organization', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbOrganizationType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 41, 'Department','Department','Department', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"" +
"INSERT INTO dbPageSectionType (CreatorId , ModifierId, ModifiedDate, CreatedDate, IndexSection) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate(), 0);" +
"INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 41, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbPageSectionType (CreatorId , ModifierId, ModifiedDate, CreatedDate, IndexSection) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate(), 1);" +
"INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 41, 'Index','Index','Index', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"" +
"INSERT INTO dbPageType (CreatorId , ModifierId, ModifiedDate, CreatedDate) VALUES(@CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbPageTypeLanguage ( PageTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  1, 41, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"" +
"" +
"SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com';" +
"" +
"" +
"INSERT INTO dbClaim VALUES (1, 'Classification', 'Classification', 'Menu');" +
"INSERT INTO dbClaim VALUES (2, 'Classification', 'ClassificationPage', 'Menu');" +
"INSERT INTO dbClaim VALUES (3, 'Administration', 'Role', 'Menu');" +
"INSERT INTO dbClaim VALUES (4, 'Classification', 'ClassificationLevel', 'Menu');" +
"INSERT INTO dbClaim VALUES (5, 'Type', 'ContentType', 'Menu');" +
"INSERT INTO dbClaim VALUES (6, 'Type', 'OrganizationType', 'Menu');" +
"INSERT INTO dbClaim VALUES (7, 'Type', 'PageType', 'Menu');" +
"INSERT INTO dbClaim VALUES (8, 'Page', 'Page', 'Menu');" +
"INSERT INTO dbClaim VALUES (9, 'Project', 'Project', 'Menu');" +
"INSERT INTO dbClaim VALUES (10, 'Type', 'Type', 'Menu');" +
"" +
"INSERT INTO dbSecurityLevel VALUES (1, '1');" +
"INSERT INTO dbSecurityLevel VALUES (2, '2');" +
"INSERT INTO dbSecurityLevel VALUES (3, '3');" +
"INSERT INTO dbSecurityLevel VALUES (4, '4');" +
"INSERT INTO dbSecurityLevel VALUES (5, '5');" +
"INSERT INTO dbSecurityLevel VALUES (6, '6');" +
"INSERT INTO dbSecurityLevel VALUES (7, '7');" +
"INSERT INTO dbSecurityLevel VALUES (8, '8');" +
"INSERT INTO dbSecurityLevel VALUES (9, '9');" +
"INSERT INTO dbSecurityLevel VALUES (10, '10');" +
"" +
"INSERT INTO dbSetting  (Id, IntValue, SettingName) VALUES (1, 41, 'Default language');" +
"INSERT INTO dbSetting  (Id, IntValue, SettingName) VALUES (2, 2, 'Home page');" +
"" +
"INSERT INTO dbClassificationStatus VALUES (1, 'Active');" +
"INSERT INTO dbClassificationStatus VALUES (2, 'Inactive');" +
"" +
"INSERT INTO dbOrganizationStatus VALUES (1, 'Active');" +
"INSERT INTO dbOrganizationStatus VALUES (2, 'Inactive');" +
"" +
"INSERT INTO dbProjectStatus VALUES (1, 'Active');" +
"INSERT INTO dbProjectStatus VALUES (2, 'Inactive');" +
"" +
"INSERT INTO dbPageStatus VALUES (1, 'Active');" +
"INSERT INTO dbPageStatus VALUES (2, 'Inactive');" +
"" +
"INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId, ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,41, N'Köppen climate',N'Köppen climate',N'Köppen climate',N'Köppen climate', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2,41, 'Soil','Soil','Soil','Soil', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassification (ClassificationStatusId, DefaultClassificationPageId, DropDownSequence, HasDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) VALUES(1,0,0, 1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3,41, 'Crop','Crop','Crop','Crop', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 1, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 41, 'Main climate group','Main climate group','Main climate group','Main climate group', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 2, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, 41, 'Sub climate group','Sub climate group','Sub climate group','Sub climate group', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 3, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 41, '2nd sub climate group','2nd sub climate group','2nd sub climate group','2nd sub climate group', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, 1, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(4, 41, 'Soil group','Soil group','Soil group','Soil group', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 1, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(6, 41, 'Crop group','Crop group','Crop group','Crop group', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 2, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(7, 41, 'Crop class','Crop class','Crop class','Crop class', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 3, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(8, 41, 'Crop sub-class','Crop sub-class','Crop sub-class','Crop sub-class', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationLevel (ClassificationId, Sequence, DateLevel, OnTheFly, Alphabetically, CanLink, InDropDown, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 4, 0,0,1,0,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(9, 41, 'Crop order','Crop order','Crop order','Crop order', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 41, 'A','A: Tropical/megathermal climates','A','A','A: Tropical/megathermal climates'" +
", 'A','A: Tropical/megathermal climates','A','A: Tropical/megathermal climates','A'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, 41, 'B','B: Dry (desert and semi-arid) climates','B','B','B: Dry (desert and semi-arid) climates'" +
", 'B','B: Dry (desert and semi-arid) climates','B','B: Dry (desert and semi-arid) climates','B'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 41, 'C','C: Temperate/mesothermal climates','C','C','C: Temperate/mesothermal climates'" +
", 'C','C: Temperate/mesothermal climates','C','C: Temperate/mesothermal climates','C'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(4, 41, 'D','D: Continental/microthermal climates','D','D','D: Continental/microthermal climates'" +
", 'D','D: Continental/microthermal climates','D','D: Continental/microthermal climates','D'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(5, 41, 'E','E: Polar climates','E','E','E: Polar climates'" +
", 'E','E: Polar climates','E','E: Polar climates','E'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(6, 41, 'Af','Af: Tropical rainforest climate','Af','Af','Af: Tropical rainforest climate'" +
", 'Af','Af: Tropical rainforest climate','Af','Af: Tropical rainforest climate','Af'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(7, 41, 'Am','Am: Tropical monsoon climate','Am','Am','Am: Tropical monsoon climate'" +
", 'Am','Am: Tropical monsoon climate','Am','Am: Tropical monsoon climate','Am'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,1, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(8, 41, 'Aw/As','Aw/As: Tropical savanna climate','Aw/As','Aw/As','Aw/As: Tropical savanna climate'" +
", 'Aw/As','Aw/As: Tropical savanna climate','Aw/As','Aw/As: Tropical savanna climate','Aw/As'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,8, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(9, 41, 'Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw','Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics'" +
", 'Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw','Aw: Tropical savanna climate with non-seasonal or dry-winter characteristics','Aw'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,8, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(10, 41, 'As','As: Tropical savanna climate with dry-summer characteristics','As','As','As: Tropical savanna climate with dry-summer characteristics'" +
", 'As','As: Tropical savanna climate with dry-summer characteristics','As','As: Tropical savanna climate with dry-summer characteristics','As'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(11, 41, 'BW','BW: Arid Climate','BW','BW','BW: Arid Climate'" +
", 'BW','BW: Arid Climate','BW','BW: Arid Climate','BW'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(12, 41, 'BS','BS: Semi-arid (Steppe) Climate','BS','BS','BS: Semi-arid (Steppe) Climate'" +
", 'BS','BS: Semi-arid (Steppe) Climate','BS','BS: Semi-arid (Steppe) Climate','BS'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(13, 41, 'Csa','Csa: Mediterranean hot summer climates','Csa','Csa','Csa: Mediterranean hot summer climates'" +
", 'Csa','Csa: Mediterranean hot summer climates','Csa','Csa: Mediterranean hot summer climates','Csa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(14, 41, 'Csb','Csb: Mediterranean warm/cool summer climates','Csb','Csb','Csb: Mediterranean warm/cool summer climates'" +
", 'Csb','Csb: Mediterranean warm/cool summer climates','Csb','Csb: Mediterranean warm/cool summer climates','Csb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(15, 41, 'Csc','Csc: Mediterranean cold summer climates','Csc','Csc','Csc: Mediterranean cold summer climates'" +
", 'Csc','Csc: Mediterranean cold summer climates','Csc','Csc: Mediterranean cold summer climates','Csc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(16, 41, 'Cfa','Cfa: Humid subtropical climates','Cfa','Cfa','Cfa: Humid subtropical climates'" +
", 'Cfa','Cfa: Humid subtropical climates','Cfa','Cfa: Humid subtropical climates','Cfa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(17, 41, 'Cfb','Cfb: Oceanic climate','Cfb','Cfb','Cfb: Oceanic climate'" +
", 'Cfb','Cfb: Oceanic climate','Cfb','Cfb: Oceanic climate','Cfb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(18, 41, 'Cfc','Cfc: Subpolar oceanic climate','Cfc','Cfc','Cfc: Subpolar oceanic climate'" +
", 'Cfc','Cfc: Subpolar oceanic climate','Cfc','Cfc: Subpolar oceanic climate','Cfc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(19, 41, 'Cwa','Cwa: Dry-winter humid subtropical climate','Cwa','Cwa','Cwa: Dry-winter humid subtropical climate'" +
", 'Cwa','Cwa: Dry-winter humid subtropical climate','Cwa','Cwa: Dry-winter humid subtropical climate','Cwa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(20, 41, 'Cwb','Cwb: Dry-winter subtropical highland climate','Cwb','Cwb','Cwb: Dry-winter subtropical highland climate'" +
", 'Cwb','Cwb: Dry-winter subtropical highland climate','Cwb','Cwb: Dry-winter subtropical highland climate','Cwb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,3, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(21, 41, 'Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc','Cwc','Cwc: Dry-winter subpolar oceanic climate'" +
", 'Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc','Cwc: Dry-winter subpolar oceanic climate','Cwc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(22, 41, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates'" +
", 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hot summer continental climates','Dfa/Dwa/Dsa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(23, 41, 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates'" +
", 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warm summer continental or hemiboreal climates','Dfb/Dwb/Dsb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(24, 41, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates'" +
", 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctic or boreal climates','Dfc/Dwc/Dsc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,4, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(25, 41, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters'" +
", 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctic or boreal climates with severe winters','Dfd/Dwd/Dsd'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,5, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(26, 41, 'ET','ET: Tundra climate','ET','ET','ET: Tundra climate'" +
", 'ET','ET: Tundra climate','ET','ET: Tundra climate','ET'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, ParentValueId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,5, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(27, 41, 'EF','EF: Ice cap climate','EF','EF','EF: Ice cap climate'" +
", 'EF','EF: Ice cap climate','EF','EF: Ice cap climate','EF'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(28, 41, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.'" +
", 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(29, 41, 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol','Andisol – volcanic ash soils. They are young and very fertile. '" +
", 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(30, 41, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.'" +
", 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(31, 41, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.'" +
", 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(32, 41, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.'" +
", 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(33, 41, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol','Histosol – organic soils, formerly called bog soils.'" +
", 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol – organic soils, formerly called bog soils.','Histosol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(34, 41, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.'" +
", 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(35, 41, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.'" +
", 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(36, 41, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.'" +
", 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(37, 41, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.'" +
", 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(38, 41, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.'" +
", 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"INSERT INTO dbClassificationValue (ClassificationId, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(39, 41, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.'" +
", 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"" +
"" +
"GO" +
"" +
"" +
"" +
"/****** Object:  StoredProcedure [dbo].[ClassificationAndLanguageUpdate]    Script Date: 9/20/2019 3:12:15 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"CREATE PROCEDURE " +
"[dbo].[ClassificationAndLanguageUpdate] " +
" @Id int" +
", @ClassificationStatusId int" +
", @DefaultClassificationPageId int" +
", @HasDropDown bit" +
", @DropDownSequence  int" +
", @ClassificationLanguageId  int" +
", @LanguageId  int" +
", @ClassificationName nvarchar(max)" +
", @ClassificationDescription nvarchar(max)" +
", @ClassificationMenuName nvarchar(max)" +
", @ClassificationMouseOver nvarchar(max)" +
", @ModifiedDate datetime2(7)" +
"AS" +
"BEGIN TRANSACTION" +
"UPDATE " +
"dbClassification" +
"SET " +
"dbClassification.ClassificationStatusId = @ClassificationStatusId" +
", dbClassification.DefaultClassificationPageId = iif(@DefaultClassificationPageId=0,null,@DefaultClassificationPageId)" +
", dbClassification.HasDropDown = @HasDropDown" +
", dbClassification.DropDownSequence = @DropDownSequence" +
", dbClassification.ModifiedDate = @ModifiedDate" +
"WHERE " +
"dbClassification.Id = @Id" +
"" +
"UPDATE " +
"dbClassificationLanguage" +
"SET" +
" dbClassificationLanguage.ClassificationName  = @ClassificationName" +
", dbClassificationLanguage.ClassificationDescription = @ClassificationDescription" +
", dbClassificationLanguage.ClassificationMenuName = @ClassificationMenuName " +
", dbClassificationLanguage.ClassificationMouseOver = @ClassificationMouseOver" +
", dbClassificationLanguage.ModifiedDate = @ModifiedDate" +
"WHERE " +
" Id = @ClassificationLanguageId" +
"" +
"COMMIT TRANSACTION" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ClassificationValueStructure]    Script Date: 9/20/2019 3:12:27 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ClassificationValueStructure] (@Language Int, @ClassificationId Int )" +
"                                        AS " +
"                                        WITH StructureClassValue (ClassificationId" +
", ParentId, Id, ClassificationValueName, Level, Path)" +
"                                        AS" +
"                                        (" +
"                                        SELECT " +
"v.ClassificationId" +
", v.ParentValueId" +
"                                        , v.Id" +
"                                        , l.ClassificationValueName" +
"                                        , 0 AS level" +
"                                        , CAST(v.Id AS VARCHAR(255)) AS Path" +
"                                        FROM dbClassificationValue AS v" +
"                                        JOIN dbClassificationValueLanguage AS l" +
"                                        ON v.Id = l.ClassificationValueId" +
"                                        WHERE v.ParentValueId IS NULL" +
"                                        AND l.LanguageId = @Language" +
"                                        AND v.ClassificationId = @ClassificationId" +
"                                        UNION ALL" +
"                                        SELECT v.ClassificationId" +
", v.ParentValueId" +
"                                        , v.Id" +
"                                        , l.ClassificationValueName" +
"                                        , level + 1" +
"                                        , CAST(s.Path + '.' + CAST(v.Id AS VARCHAR(255)) AS VARCHAR(255))" +
"                                        FROM dbClassificationValue AS v" +
"                                        JOIN dbClassificationValueLanguage AS l" +
"                                        ON v.Id = l.ClassificationValueId" +
"                                        JOIN StructureClassValue s" +
"                                        ON s.Id = v.ParentValueId" +
"                                        WHERE l.LanguageId = @Language" +
"                                        AND v.ClassificationId = @ClassificationId" +
"                                        )" +
"" +
"                                        SELECT ClassificationId" +
", ISNULL(ParentId,0) ParentId" +
"                                        , Id, ClassificationValueName, Level, Path" +
"                                        FROM StructureClassValue " +
"ORDER BY Path" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ClassificationValueStructureValues]    Script Date: 9/20/2019 3:12:37 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ClassificationValueStructureValues] (@Language Int, @ClassificationId Int )" +
"                                        AS " +
"                                        WITH StructureClassValue (ClassificationId" +
", ParentId, Id, ClassificationValueName, Level, Path)" +
"                                        AS" +
"                                        (" +
"                                        SELECT " +
"v.ClassificationId" +
", v.ParentValueId" +
"                                        , v.Id" +
"                                        , l.ClassificationValueName" +
"                                        , 0 AS level" +
"                                        , CAST(v.Id AS VARCHAR(255)) AS Path" +
"                                        FROM dbClassificationValue AS v" +
"                                        JOIN dbClassificationValueLanguage AS l" +
"                                        ON v.Id = l.ClassificationValueId" +
"                                        WHERE v.ParentValueId IS NULL" +
"                                        AND l.LanguageId = @Language" +
"                                        AND v.ClassificationId = @ClassificationId" +
"                                        UNION ALL" +
"                                        SELECT v.ClassificationId" +
", v.ParentValueId" +
"                                        , v.Id" +
"                                        , l.ClassificationValueName" +
"                                        , level + 1" +
"                                        , CAST(s.Path + '.' + CAST(v.Id AS VARCHAR(255)) AS VARCHAR(255))" +
"                                        FROM dbClassificationValue AS v" +
"                                        JOIN dbClassificationValueLanguage AS l" +
"                                        ON v.Id = l.ClassificationValueId" +
"                                        JOIN StructureClassValue s" +
"                                        ON s.Id = v.ParentValueId" +
"                                        WHERE l.LanguageId = @Language" +
"                                        AND v.ClassificationId = @ClassificationId" +
"                                        )" +
"" +
"                                        SELECT Id ClassificationValueId" +
"                                        , ClassificationValueName" +
"                                        FROM StructureClassValue " +
"ORDER BY Path" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ContentCreate]    Script Date: 9/20/2019 3:12:45 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ContentCreate] " +
" @ContentTypeId int" +
", @ContentStatusId int" +
", @LangaugeId int" +
", @Title nvarchar(max)" +
", @Description nvarchar(max)" +
", @SecurityLevel int" +
", @OrganizationId int" +
", @ProjectId int" +
", @new_identity INT = NULL OUTPUT" +
"AS" +
"INSERT dbContent" +
"(ContentTypeId" +
", ContentStatusId" +
", LanguageId" +
", Title" +
", Description" +
", SecurityLevel" +
", OrganizationId" +
", ProjectId" +
", CreatedDate" +
", ModifiedDate)" +
"VALUES (" +
"@ContentTypeId" +
", @ContentStatusId" +
", @LangaugeId" +
", @Title" +
", @Description" +
", @SecurityLevel" +
", @OrganizationId" +
", iif(@ProjectId=0,null,@ProjectId)" +
", GETDATE()" +
", getdate()" +
")" +
"SET @new_identity = SCOPE_IDENTITY();" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ContentCreate]    Script Date: 9/20/2019 3:12:45 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ContentCreate] " +
" @ContentTypeId int" +
", @ContentStatusId int" +
", @LangaugeId int" +
", @Title nvarchar(max)" +
", @Description nvarchar(max)" +
", @SecurityLevel int" +
", @OrganizationId int" +
", @ProjectId int" +
", @new_identity INT = NULL OUTPUT" +
"AS" +
"INSERT dbContent" +
"(ContentTypeId" +
", ContentStatusId" +
", LanguageId" +
", Title" +
", Description" +
", SecurityLevel" +
", OrganizationId" +
", ProjectId" +
", CreatedDate" +
", ModifiedDate)" +
"VALUES (" +
"@ContentTypeId" +
", @ContentStatusId" +
", @LangaugeId" +
", @Title" +
", @Description" +
", @SecurityLevel" +
", @OrganizationId" +
", iif(@ProjectId=0,null,@ProjectId)" +
", GETDATE()" +
", getdate()" +
")" +
"SET @new_identity = SCOPE_IDENTITY();" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ContentInsert]    Script Date: 9/20/2019 3:13:07 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"CREATE PROCEDURE " +
"[dbo].[ContentInsert] " +
"  @ContentTypeId int" +
", @ContentStatusId int" +
", @LanguageId int" +
", @Title nvarchar(max)" +
", @Description nvarchar(max)" +
", @SecurityLevel int" +
", @OrganizationId int" +
", @ProjectId int--3" +
"AS" +
"BEGIN TRANSACTION" +
"INSERT" +
"dbContent " +
"(" +
"ContentTypeId" +
", ContentStatusId" +
", LanguageId" +
", Title" +
", Description" +
", SecurityLevel" +
", OrganizationId" +
", ProjectId" +
", ModifiedDate" +
", CreatedDate" +
")" +
"OUTPUT Inserted.Id" +
"VALUES" +
"(" +
"  @ContentTypeId " +
", @ContentStatusId " +
", @LanguageId " +
", @Title " +
", @Description " +
", @SecurityLevel " +
", @OrganizationId" +
", @ProjectId " +
", Getdate()" +
", Getdate())" +
"COMMIT TRANSACTION" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ContentUpdate]    Script Date: 9/20/2019 3:13:25 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ContentUpdate] " +
"@Id int" +
", @ContentTypeId int" +
", @ContentStatusId int" +
", @LangaugeId int" +
", @Title nvarchar(max)" +
", @Description nvarchar(max)" +
", @SecurityLevel int" +
", @OrganizationId int" +
", @ProjectId int" +
"" +
"AS" +
"UPDATE dbContent " +
"SET " +
"ContentTypeId = @ContentTypeId" +
", ContentStatusId = @ContentStatusId" +
", LanguageId = @LangaugeId" +
", Title = @Title" +
", Description = @Description" +
", SecurityLevel = @SecurityLevel" +
", OrganizationId = @OrganizationId" +
", ProjectId = iif(@ProjectId=0,null,@ProjectId)" +
"WHERE Id = @Id" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ContentValueCreate]    Script Date: 9/20/2019 3:13:32 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ContentValueCreate] " +
" @ContentId int" +
", @ClassificationValueId int" +
"AS" +
"INSERT dbContentClassificationValue" +
"(ContentId" +
", ClassificationValueId" +
")" +
"VALUES (" +
"@ContentId" +
", @ClassificationValueId" +
")" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[GetContentStatus]    Script Date: 9/20/2019 3:13:40 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"" +
"CREATE PROCEDURE [dbo].[GetContentStatus]" +
"AS " +
"SELECT " +
"dbContentStatus.Id" +
", ISNULL(dbContentStatus.ContentStatusName,'') Name" +
"FROM dbContentStatus" +
"ORDER BY dbContentStatus.ContentStatusName" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[GetContentType]    Script Date: 9/20/2019 3:13:47 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"" +
"CREATE PROCEDURE [dbo].[GetContentType] (@Language Int)" +
"AS " +
"SELECT " +
"dbContentTypeLanguage.ContentTypeId Id" +
", ISNULL(dbContentTypeLanguage.Name,'') Name" +
"FROM dbContentType" +
"JOIN dbContentTypeLanguage" +
"ON dbContentType.Id = dbContentTypeLanguage.ContentTypeId" +
"WHERE dbContentTypeLanguage.LanguageId = @Language" +
"ORDER BY dbContentTypeLanguage.Name" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[GetLanguage]    Script Date: 9/20/2019 3:13:54 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"" +
"CREATE PROCEDURE [dbo].[GetLanguage]" +
"AS " +
"SELECT " +
"dbLanguage.Id" +
", ISNULL(dbLanguage.LanguageName,'') Name" +
"FROM dbLanguage" +
"ORDER BY dbLanguage.LanguageName" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[GetLanguage]    Script Date: 9/20/2019 3:13:54 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"" +
"CREATE PROCEDURE [dbo].[GetLanguage]" +
"AS " +
"SELECT " +
"dbLanguage.Id" +
", ISNULL(dbLanguage.LanguageName,'') Name" +
"FROM dbLanguage" +
"ORDER BY dbLanguage.LanguageName" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[GetSecurityLevel]    Script Date: 9/20/2019 3:14:07 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"" +
"CREATE PROCEDURE [dbo].[GetSecurityLevel] " +
"AS " +
"SELECT " +
"dbSecurityLevel.Id Id" +
", ISNULL(dbsecuritylevel.Name,'') Name" +
"FROM dbSecurityLevel" +
"ORDER BY dbSecurityLevel.Id" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[OrgStructure]    Script Date: 9/20/2019 3:14:22 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[OrgStructure] (@Language Int )" +
"                                    AS " +
"                                    WITH StructureOrg (ParentId, Id, Name, Level, Path)" +
"                                    AS" +
"                                    (" +
"                                    SELECT o.ParentOrganizationId" +
"                                    , o.Id" +
"                                    , l.Name" +
"                                    , 0 AS level" +
"                                    , CAST(o.Id AS VARCHAR(255)) AS Path" +
"                                    FROM dbOrganization AS o" +
"                                    JOIN dbOrganizationLanguage AS l" +
"                                    ON o.Id = l.OrganizationId" +
"                                    WHERE o.ParentOrganizationId IS NULL" +
"                                    AND l.LanguageId = @Language" +
"                                    UNION ALL" +
"                                    SELECT o.ParentOrganizationId" +
"                                    , o.Id" +
"                                    , l.Name" +
"                                    , level + 1" +
"                                    , CAST(s.Path + '.' + CAST(o.Id AS VARCHAR(255)) AS VARCHAR(255))" +
"                                    FROM dbOrganization AS o" +
"                                    JOIN dbOrganizationLanguage AS l" +
"                                    ON o.Id = l.OrganizationId" +
"                                    JOIN StructureOrg s" +
"                                    ON s.Id = o.ParentOrganizationId" +
"                                    WHERE l.LanguageId = @Language" +
"                                    )" +
"" +
"                                    SELECT ISNULL(ParentId,0) ParentId" +
"                                    , Id, Name, Level, Path" +
"                                    FROM StructureOrg ORDER BY Path" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[PageSectionUpdate]    Script Date: 9/20/2019 3:14:30 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"" +
"" +
"CREATE PROCEDURE " +
"[dbo].[PageSectionUpdate] " +
" @Id int" +
", @NewSequence int" +
", @ContentTypeId int" +
", @HasPaging bit" +
", @MaxContent  int" +
", @OneTwoColumns  int" +
", @PageSectionTypeId  int" +
", @ShowContentTypeTitle bit" +
", @ShowContentTypeDescription bit" +
", @ShowSectionTitle bit" +
", @ShowSectionTitleDescription bit" +
", @SortById bit" +
", @LanguageId int" +
", @PageSectionName nvarchar(max)" +
", @PageSectionDescription nvarchar(max)" +
", @PageSectionTitleName nvarchar(max)" +
", @PageSectionTitleDescription nvarchar(max)" +
", @PageSectionMouseOver nvarchar(max)" +
", @ModifiedDate datetime2(7)" +
", @PageSectionLanguageId int" +
", @PageId int" +
"" +
"" +
"AS" +
"DECLARE @OldSequence int; " +
"SELECT @OldSequence = Sequence FROM dbPageSection WHERE Id = @Id;" +
"BEGIN TRANSACTION" +
"IF @OldSequence < @NewSequence" +
"UPDATE " +
"s " +
"SET Sequence = Sequence - 1" +
"FROM dbPageSection s " +
"WHERE Sequence <= @NewSequence" +
"AND Sequence > @OldSequence" +
"AND PageId = @PageId;" +
"ELSE" +
"UPDATE s" +
"" +
"SET Sequence= Sequence + 1" +
"FROM dbPageSection  s WHERE Sequence >= @NewSequence" +
"AND Sequence < @OldSequence" +
"AND PageId = @PageId;" +
"" +
"" +
"UPDATE " +
"dbPageSection" +
"SET " +
"dbPageSection.ContentTypeId = iif(@ContentTypeId=0,null,@ContentTypeId)" +
", dbPageSection.HasPaging = @HasPaging" +
", dbPageSection.MaxContent = @MaxContent" +
", dbPageSection.OneTwoColumns = @OneTwoColumns" +
", dbPageSection.PageSectionTypeId =@PageSectionTypeId" +
", dbPageSection.Sequence =@NewSequence" +
", dbPageSection.ShowContentTypeDescription = @ShowContentTypeDescription" +
", dbPageSection.ShowContentTypeTitle = @ShowContentTypeTitle" +
", dbPageSection.ShowSectionTitle = @ShowSectionTitle" +
", dbPageSection.ShowSectionTitleDescription = @ShowSectionTitleDescription" +
", dbPageSection.SortById = @SortById" +
"WHERE " +
"dbPageSection.Id = @Id" +
"" +
"UPDATE " +
"dbPageSectionLanguage" +
"SET" +
" PageSectionName  = @PageSectionName " +
", PageSectionDescription = @PageSectionDescription " +
", PageSectionTitle = @PageSectionTitleName " +
", PageSectionTitleDescription = @PageSectionTitleDescription " +
", PageSectionMouseOver = @PageSectionMouseOver " +
", ModifiedDate = @ModifiedDate" +
"WHERE " +
" Id = @PageSectionLanguageId " +
"" +
"COMMIT TRANSACTION" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ProjStructure]    Script Date: 9/20/2019 3:14:37 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE [dbo].[ProjStructure] (@Language Int )" +
"                                    AS " +
"                                    WITH StructureProj (ParentId, Id, Name, Level, Path)" +
"                                    AS" +
"                                    (" +
"                                    SELECT p.ParentProjectId" +
"                                    , p.Id" +
"                                    , l.Name" +
"                                    , 0 AS level" +
"                                    , CAST(p.Id AS VARCHAR(255)) AS Path" +
"                                    FROM dbProject AS p" +
"                                    JOIN dbProjectLanguage AS l" +
"                                    ON p.Id = l.ProjectId" +
"                                    WHERE (p.ParentProjectId IS NULL " +
"                                            OR p.ParentProjectId = 0) " +
"                                    AND l.LanguageId = @Language" +
"                                    UNION ALL" +
"                                    SELECT p.ParentProjectId" +
"                                    , p.Id" +
"                                    , l.Name" +
"                                    , level + 1" +
"                                    , CAST(s.Path + '.' + CAST(p.Id AS VARCHAR(255)) AS VARCHAR(255))" +
"                                    FROM dbProject AS p" +
"                                    JOIN dbProjectLanguage AS l" +
"                                    ON p.Id = l.ProjectId" +
"                                    JOIN StructureProj s" +
"                                    ON s.Id = p.ParentProjectId" +
"                                    WHERE l.LanguageId = @Language" +
"                                    )" +
"" +
"                                    SELECT ISNULL(ParentId,0) ParentId" +
"                                    , Id, Name, Level, Path" +
"                                    FROM StructureProj ORDER BY Path" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ShowContent]    Script Date: 9/20/2019 3:14:46 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE " +
"[dbo].[ShowContent] " +
"  @ContentTypeId int" +
"AS" +
"IF @ContentTypeId IS NULL " +
"BEGIN" +
"SELECT dbContent.Id" +
", dbContent.Title" +
", dbContent.Description" +
", dbContent.ContentStatusId" +
", dbContent.ContentTypeId" +
", dbContent.CreatedDate" +
", dbContent.CreatorId" +
", dbContent.LanguageId" +
", dbContent.ModifiedDate" +
", dbContent.ModifierId" +
", dbContent.OrganizationId" +
", dbContent.ProjectId" +
", dbContent.SecurityLevel" +
"FROM dbContent" +
"END" +
"ELSE" +
"BEGIN" +
"SELECT dbContent.Id" +
", dbContent.Title" +
", dbContent.Description" +
", dbContent.ContentStatusId" +
", dbContent.ContentTypeId" +
", dbContent.CreatedDate" +
", dbContent.CreatorId" +
", dbContent.LanguageId" +
", dbContent.ModifiedDate" +
", dbContent.ModifierId" +
", dbContent.OrganizationId" +
", dbContent.ProjectId" +
", dbContent.SecurityLevel" +
"FROM dbContent" +
"WHERE dbContent.ContentTypeId = @ContentTypeId" +
"END" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ShowPage]    Script Date: 9/20/2019 3:15:00 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE " +
"[dbo].[ShowPage] " +
"@Id int" +
", @LanguageId int" +
"AS" +
"SELECT dbPage.Id" +
", dbPageLanguage.PageTitle" +
", dbPageLanguage.PageDescription" +
"FROM dbpage " +
"JOIN dbPageLanguage" +
"ON dbPage.Id = dbPageLanguage.PageId" +
"" +
"WHERE dbPage.Id = @Id" +
"AND dbPageLanguage.LanguageId = @LanguageId" +
"GO" +
"" +
"" +
"GO" +
"" +
"/****** Object:  StoredProcedure [dbo].[ShowPageSection]    Script Date: 9/20/2019 3:15:17 PM ******/" +
"SET ANSI_NULLS ON" +
"GO" +
"" +
"SET QUOTED_IDENTIFIER ON" +
"GO" +
"" +
"CREATE PROCEDURE " +
"[dbo].[ShowPageSection] " +
"@Id int" +
", @LanguageId int" +
"AS" +
"SELECT " +
"dbPageSection.Id" +
", dbPageSection.PageId" +
", dbPageSection.ShowSectionTitle" +
", dbPageSection.ShowSectionTitleDescription" +
", dbPageSection.ShowContentTypeTitle" +
", dbPageSection.ShowContentTypeDescription" +
", dbPageSection.OneTwoColumns" +
", dbPageSection.ContentTypeId" +
", dbPageSection.SortById" +
", dbPageSection.MaxContent" +
", dbPageSection.HasPaging" +
", dbPageSectionLanguage.PageSectionTitle" +
", dbPageSectionLanguage.PageSectionDescription" +
", dbPageSectionType.IndexSection" +
"FROM dbPageSection " +
"JOIN dbPageSectionLanguage" +
"ON dbPageSection.Id = dbPageSectionLanguage.PageSectionId" +
"JOIN dbPageSectionType" +
"ON dbPageSection.PageSectionTypeId = dbPageSectionType.Id" +
"WHERE dbPageSection.PageId = @Id" +
"AND dbPageSectionLanguage.LanguageId = @LanguageId" +
"ORDER BY dbPageSection.Sequence" +
"GO" +
"CREATE PROCEDURE [dbo].[GetProcessTemplateGroup] (@Language Int)" +
"AS " +
"SELECT " +
"    dbProcessTemplateGroupLanguage.ProcessTemplateGroupId Id" +
"    , ISNULL(dbProcessTemplateGroupLanguage.ProcessTemplateGroupName,'') Name" +
"FROM dbProcessTemplateGroup" +
"JOIN dbProcessTemplateGroupLanguage" +
"    ON dbProcessTemplateGroup.Id = dbProcessTemplateGroupLanguage.ProcessTemplateGroupId" +
"WHERE dbProcessTemplateGroupLanguage.LanguageId = @Language" +
"ORDER BY dbProcessTemplateGroupLanguage.ProcessTemplateGroupName GO" +

//"DUTCH"
"INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  1, 39, 'Kennis','Kennis','Kennis', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 39, 'Ervaring','Ervaring','Ervaring', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbContentTypeLanguage ( ContentTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  3, 39, 'Opdracht','Opdracht','Opdracht', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  1, 39, 'Organizatie','Organizatie','Organizatie', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbOrganizationTypeLanguage ( OrganizationTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 39, 'Afdeling','Afdeling','Afdeling', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 39, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbPageSectionTypeLanguage ( PageSectionTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  2, 39, 'Inhoudsopgave','Inhoudsopgave','Inhoudsopgave', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbPageTypeLanguage ( PageTypeId, LanguageId, Name, Description, MouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(  1, 39, 'Default','Default','Default', @CurrentUser, @CurrentUser, getdate(),getdate()) " +
"INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId, ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1,41, N'Köppen klimaat',N'Köppen klimaat',N'Köppen klimaat',N'Köppen klimaat', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2,41, 'Grond soort','Grond soort','Grond soort','Grond soort', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLanguage (ClassificationId, LanguageId,ClassificationName, ClassificationDescription, ClassificationMenuName, ClassificationMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3,41, 'Gewas','Gewas','Gewas','Gewas', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 41, 'Hoofd klimaat groep','Hoofd klimaat groep','Hoofd klimaat groep','Hoofd klimaat groep', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, 41, 'Sub klimaat groep','Sub klimaat groep','Sub klimaat groep','Sub klimaat groep', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 41, '2de sub klimaat groep','2de sub klimaat groep','2de sub klimaat groep','2de sub klimaat groep', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(4, 41, 'Grond soort groep','Grond soort groep','Grond soort groep','Grond soort groep', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(6, 41, 'Gewas groep','Gewas groep','Gewas groep','Gewas groep', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(7, 41, 'Gewas klasse','Gewas klasse','Gewas klasse','Gewas klasse', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(8, 41, 'Gewas sub klasse','Gewas sub klasse','Gewas sub klasse','Gewas sub klasse', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationLevelLanguage (" +
"ClassificationLevelId" +
", LanguageId" +
", ClassificationLevelName" +
", ClassificationLevelMenuName" +
", ClassificationLevelDescription" +
", ClassificationLevelMouseOver, CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(9, 41, 'Gewas rang','Gewas rang','Gewas rang','Gewas rang', @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(1, 41, 'A','A: Tropish klimaat','A','A','A: Tropish klimaat'" +
", 'A','A: Tropish klimaat','A','A: Tropish klimaat','A'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(2, 41, 'B','B: Droog (woestijn) klimaat','B','B','B: Droog (woestijn) klimaat'" +
", 'B','B: Droog (woestijn) klimaat','B','B: Droog (woestijn) klimaat','B'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(3, 41, 'C','C: Gematigd klimaat','C','C','C: Gematigd klimaat'" +
", 'C','C: Gematigd klimaat','C','C: Gematigd klimaat','C'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(4, 41, 'D','D: Continentaal klimaat','D','D','D: Continentaal klimaat'" +
", 'D','D: Continentaal klimaat','D','D: Continentaal klimaat','D'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(5, 41, 'E','E: Pool klimaat','E','E','E: Pool klimaat'" +
", 'E','E: Pool klimaat','E','E: Pool klimaat','E'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(6, 41, 'Af','Af: Tropisch regenwoud klimaat','Af','Af','Af: Tropisch regenwoud klimaat'" +
", 'Af','Af: Tropisch regenwoud klimaat','Af','Af: Tropisch regenwoud klimaat','Af'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(7, 41, 'Am','Am: Tropisch moesson klimaat','Am','Am','Am: Tropisch moesson klimaat'" +
", 'Am','Am: Tropisch moesson klimaat','Am','Am: Tropisch moesson klimaat','Am'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(8, 41, 'Aw/As','Aw/As: Tropisch savanne klimaat','Aw/As','Aw/As','Aw/As: Tropisch savanne klimaat'" +
", 'Aw/As','Aw/As: Tropisch savanne klimaat','Aw/As','Aw/As: Tropisch savanne klimaat','Aw/As'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(9, 41, 'Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken','Aw','Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken'" +
", 'Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken','Aw','Aw: Tropisch savanne klimaat met geen seizoen of droge winter kenmerken','Aw'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(10, 41, 'As','As: Tropisch savanne klimaat met droge zomer kenmerk','As','As','As: Tropisch savanne klimaat met droge zomer kenmerk'" +
", 'As','As: Tropisch savanne klimaat met droge zomer kenmerk','As','As: Tropisch savanne klimaat met droge zomer kenmerk','As'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(11, 41, 'BW','BW: Droog klimaat','BW','BW','BW: Droog klimaat'" +
", 'BW','BW: Droog klimaat','BW','BW: Droog klimaat','BW'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(12, 41, 'BS','BS: Semi droog klimaat','BS','BS','BS: Semi droog klimaat'" +
", 'BS','BS: Semi droog klimaat','BS','BS: Semi droog klimaat','BS'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(13, 41, 'Csa','Csa: Mediterrane hete zomerklimaat','Csa','Csa','Csa: Mediterrane hete zomerklimaat'" +
", 'Csa','Csa: Mediterrane hete zomerklimaat','Csa','Csa: Mediterrane hete zomerklimaat','Csa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(14, 41, 'Csb','Csb: Mediterraan warm / koel zomerklimaat','Csb','Csb','Csb: Mediterraan warm / koel zomerklimaat'" +
", 'Csb','Csb: Mediterraan warm / koel zomerklimaat','Csb','Csb: Mediterraan warm / koel zomerklimaat','Csb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(15, 41, 'Csc','Csc: Mediterraan koud zomerklimaat','Csc','Csc','Csc: Mediterraan koud zomerklimaat'" +
", 'Csc','Csc: Mediterraan koud zomerklimaat','Csc','Csc: Mediterraan koud zomerklimaat','Csc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(16, 41, 'Cfa','Cfa: Vochtige subtropische klimaat','Cfa','Cfa','Cfa: Vochtige subtropische klimaat'" +
", 'Cfa','Cfa: Vochtige subtropische klimaat','Cfa','Cfa: Vochtige subtropische klimaat','Cfa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(17, 41, 'Cfb','Cfb: Oceanisch klimaat','Cfb','Cfb','Cfb: Oceanisch klimaat'" +
", 'Cfb','Cfb: Oceanisch klimaat','Cfb','Cfb: Oceanisch klimaat','Cfb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(18, 41, 'Cfc','Cfc: Subpolair oceaanklimaat','Cfc','Cfc','Cfc: Subpolair oceaanklimaat'" +
", 'Cfc','Cfc: Subpolair oceaanklimaat','Cfc','Cfc: Subpolair oceaanklimaat','Cfc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(19, 41, 'Cwa','Cwa: Droge winter vochtig subtropisch klimaat','Cwa','Cwa','Cwa: Droge winter vochtig subtropisch klimaat'" +
", 'Cwa','Cwa: Droge winter vochtig subtropisch klimaat','Cwa','Cwa: Droge winter vochtig subtropisch klimaat','Cwa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(20, 41, 'Cwb','Cwb: Droog-winter subtropisch hooglandklimaat','Cwb','Cwb','Cwb: Droog-winter subtropisch hooglandklimaat'" +
", 'Cwb','Cwb: Droog-winter subtropisch hooglandklimaat','Cwb','Cwb: Droog-winter subtropisch hooglandklimaat','Cwb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(21, 41, 'Cwc','Cwc: Droog-winter subpolair oceaanklimaat','Cwc','Cwc','Cwc: Droog-winter subpolair oceaanklimaat'" +
", 'Cwc','Cwc: Droog-winter subpolair oceaanklimaat','Cwc','Cwc: Droog-winter subpolair oceaanklimaat','Cwc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(22, 41, 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten'" +
", 'Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten','Dfa/Dwa/Dsa','Dfa/Dwa/Dsa: Hete zomer continentale klimaten','Dfa/Dwa/Dsa'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(23, 41, 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat'" +
", 'Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat','Dfb/Dwb/Dsb','Dfb/Dwb/Dsb: Warme zomer continentale of hemiboreale klimaat','Dfb/Dwb/Dsb'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(24, 41, 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat'" +
", 'Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat','Dfc/Dwc/Dsc','Dfc/Dwc/Dsc: Subarctische of boreale klimaat','Dfc/Dwc/Dsc'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(25, 41, 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters'" +
", 'Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters','Dfd/Dwd/Dsd','Dfd/Dwd/Dsd: Subarctische of boreale klimaat met strenge winters','Dfd/Dwd/Dsd'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(26, 41, 'ET','ET: Toendra klimaat','ET','ET','ET: Toendra klimaat'" +
", 'ET','ET: Toendra klimaat','ET','ET: Toendra klimaat','ET'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(27, 41, 'EF','EF: Ijskap klimaat','EF','EF','EF: Ijskap klimaat'" +
", 'EF','EF: Ijskap klimaat','EF','EF: Ijskap klimaat','EF'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(28, 41, 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.'" +
", 'Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol','Alfisol – soils with aluminium and iron. They have horizons of clay accumulation, and form where there is enough moisture and warmth for at least three months of plant growth.','Alfisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(29, 41, 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol','Andisol – volcanic ash soils. They are young and very fertile. '" +
", 'Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol','Andisol – volcanic ash soils. They are young and very fertile. ','Andisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(30, 41, 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.'" +
", 'Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol','Aridisol – dry soils forming under desert conditions which have fewer than 90 consecutive days of moisture during the growing season and are nonleached.','Aridisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(31, 41, 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.'" +
", 'Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol','Entisol – recently formed soils that lack well-developed horizons. Commonly found on unconsolidated river and beach sediments of sand and clay or volcanic ash, some have an A horizon on top of bedrock.','Entisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(32, 41, 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.'" +
", 'Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol','Gelisol – permafrost soils with permafrost within two metres of the surface or gelic materials and permafrost within one metre.','Gelisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(33, 41, 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol','Histosol – organic soils, formerly called bog soils.'" +
", 'Histosol','Histosol – organic soils, formerly called bog soils.','Histosol','Histosol – organic soils, formerly called bog soils.','Histosol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(34, 41, 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.'" +
", 'Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol','Inceptisol – young soils. They have subsurface horizon formation but show little eluviation and illuviation.','Inceptisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(35, 41, 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.'" +
", 'Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol','Mollisol – soft, deep, dark fertile soil formed in grasslands and some hardwood forests with very thick A horizons.','Mollisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(36, 41, 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.'" +
", 'Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol','Oxisol – are heavily weathered, are rich in iron and aluminum oxides (sesquioxides) or kaolin but low in silica. They have only trace nutrients due to heavy tropical rainfall and high temperatures and low CEC of the remaining clays.','Oxisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(37, 41, 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.'" +
", 'Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol','Spodosol – acid soils with organic colloid layer complexed with iron and aluminium leached from a layer above. They are typical soils of coniferous and deciduous forests in cooler climates.','Spodosol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(38, 41, 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.'" +
", 'Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol','Ultisol – acid soils in the humid tropics and subtropics, which are depleted in calcium, magnesium and potassium (important plant nutrients). They are highly weathered, but not as weathered as Oxisols.','Ultisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" +
"INSERT INTO dbClassificationValueLanguage (" +
"ClassificationValueId" +
", LanguageId" +
", ClassificationValueName" +
", ClassificationValueDescription" +
", ClassificationValueDropDownName" +
", ClassificationValueMenuName" +
", ClassificationValueMouseOver" +
", ClassificationValuePageName" +
", ClassificationValuePageDescription" +
", ClassificationValueHeaderName" +
", ClassificationValueHeaderDescription" +
", ClassificationValueTopicName" +
", CreatorId, ModifierId, CreatedDate, ModifiedDate) " +
"VALUES(39, 41, 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.'" +
", 'Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol','Vertisol – inverted soils. They are clay-rich and tend to swell when wet and shrink upon drying, often forming deep cracks into which surface layers can fall. They are difficult to farm or to construct roads and buildings due to their high expansion rate.','Vertisol'" +
", @CurrentUser, @CurrentUser, getdate(), getdate());" 




);

            return View();
        }
    }
}