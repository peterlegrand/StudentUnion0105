DECLARE @CurrentUser uniqueidentifier; 
 
SELECT @CurrentUser = Id from AspNetUSers Where email = 'eplegrand@gmail.com'; 
 
UPDATE AspNetUsers SET DefaultLangauge = 41; 
 

SET IDENTITY_INSERT dbLanguage ON;
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(1, 'Abkhazian', N'аҧсуа бызшәа, аҧсшәа', 'ab', 'abk', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(2, 'Afar', N'Afaraf', 'aa', 'aar', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(3, 'Afrikaans', N'Afrikaans', 'af', 'afr', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(4, 'Akan', N'Akan', 'ak', 'aka', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(5, 'Albanian', N'Shqip', 'sq', 'sqi', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(6, 'Amharic', N'አማርኛ', 'am', 'amh', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(7, 'Arabic', N'العربية', 'ar', 'ara', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(8, 'Aragonese', N'aragonés', 'an', 'arg', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(9, 'Armenian', N'Հայերեն', 'hy', 'hye', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(10, 'Assamese', N'অসমীয়া', 'as', 'asm', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(11, 'Avaric', N'авар мацӀ, магӀарул мацӀ', 'av', 'ava', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(12, 'Avestan', N'avesta', 'ae', 'ave', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(13, 'Aymara', N'aymar aru', 'ay', 'aym', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(14, 'Azerbaijani', N'azərbaycan dili', 'az', 'aze', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(15, 'Bambara', N'bamanankan', 'bm', 'bam', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(16, 'Bashkir', N'башҡорт теле', 'ba', 'bak', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(17, 'Basque', N'euskara, euskera', 'eu', 'eus', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(18, 'Belarusian', N'беларуская мова', 'be', 'bel', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(19, 'Bengali', N'বাংলা', 'bn', 'ben', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(20, 'Bihari languages', N'भोजपुरी', 'bh', 'bih', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(21, 'Bislama', N'Bislama', 'bi', 'bis', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(22, 'Bosnian', N'bosanski jezik', 'bs', 'bos', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(23, 'Breton', N'brezhoneg', 'br', 'bre', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(24, 'Bulgarian', N'български език', 'bg', 'bul', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(25, 'Burmese', N'ဗမာစာ', 'my', 'mya', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(26, 'Catalan, Valencian', N'català, valencià', 'ca', 'cat', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(27, 'Chamorro', N'Chamoru', 'ch', 'cha', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(28, 'Chechen', N'нохчийн мотт', 'ce', 'che', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(29, 'Chichewa, Chewa, Nyanja', N'chiCheŵa, chinyanja', 'ny', 'nya', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(30, 'Chinese', N'中文 (Zhōngwén), 汉语, 漢語', 'zh', 'zho', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(31, 'Chuvash', N'чӑваш чӗлхи', 'cv', 'chv', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(32, 'Cornish', N'Kernewek', 'kw', 'cor', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(33, 'Corsican', N'corsu, lingua corsa', 'co', 'cos', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(34, 'Cree', N'ᓀᐦᐃᔭᐍᐏᐣ', 'cr', 'cre', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(35, 'Croatian', N'hrvatski jezik', 'hr', 'hrv', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(36, 'Czech', N'čeština, český jazyk', 'cs', 'ces', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(37, 'Danish', N'dansk', 'da', 'dan', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(38, 'Divehi, Dhivehi, Maldivian', N'ދިވެހި', 'dv', 'div', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(39, 'Dutch, Flemish', N'Nederlands, Vlaams', 'nl', 'nld', 1); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(40, 'Dzongkha', N'རྫོང་ཁ', 'dz', 'dzo', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(41, 'English', N'English', 'en', 'eng', 1); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(42, 'Esperanto', N'Esperanto', 'eo', 'epo', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(43, 'Estonian', N'eesti, eesti keel', 'et', 'est', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(44, 'Ewe', N'Eʋegbe', 'ee', 'ewe', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(45, 'Faroese', N'føroyskt', 'fo', 'fao', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(46, 'Fijian', N'vosa Vakaviti', 'fj', 'fij', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(47, 'Finnish', N'suomi, suomen kieli', 'fi', 'fin', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(48, 'French', N'français, langue française', 'fr', 'fra', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(49, 'Fulah', N'Fulfulde, Pulaar, Pular', 'ff', 'ful', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(50, 'Galician', N'Galego', 'gl', 'glg', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(51, 'Georgian', N'ქართული', 'ka', 'kat', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(52, 'German', N'Deutsch', 'de', 'deu', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(53, 'Greek, Modern (1453-)', N'ελληνικά', 'el', 'ell', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(54, 'Guarani', N'Avañe''ẽ', 'gn', 'grn', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(55, 'Gujarati', N'ગુજરાતી', 'gu', 'guj', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(56, 'Haitian, Haitian Creole', N'Kreyòl ayisyen', 'ht', 'hat', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(57, 'Hausa', N'(Hausa) هَوُسَ', 'ha', 'hau', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(58, 'Hebrew', N'עברית', 'he', 'heb', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(59, 'Herero', N'Otjiherero', 'hz', 'her', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(60, 'Hindi', N'हिन्दी, हिंदी', 'hi', 'hin', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(61, 'Hiri Motu', N'Hiri Motu', 'ho', 'hmo', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(62, 'Hungarian', N'magyar', 'hu', 'hun', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(63, 'Interlingua', N'Interlingua', 'ia', 'ina', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(64, 'Indonesian', N'Bahasa Indonesia', 'id', 'ind', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(65, 'Interlingue, Occidental', N'(originally:) Occidental, (after WWII:) Interlingue', 'ie', 'ile', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(66, 'Irish', N'Gaeilge', 'ga', 'gle', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(67, 'Igbo', N'Asụsụ Igbo', 'ig', 'ibo', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(68, 'Inupiaq', N'Iñupiaq, Iñupiatun', 'ik', 'ipk', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(69, 'Ido', N'Ido', 'io', 'ido', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(70, 'Icelandic', N'Íslenska', 'is', 'isl', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(71, 'Italian', N'Italiano', 'it', 'ita', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(72, 'Inuktitut', N'ᐃᓄᒃᑎᑐᑦ', 'iu', 'iku', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(73, 'Japanese', N'日本語 (にほんご)', 'ja', 'jpn', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(74, 'Javanese', N'ꦧꦱꦗꦮ, Basa Jawa', 'jv', 'jav', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(75, 'Kalaallisut, Greenlandic', N'kalaallisut, kalaallit oqaasii', 'kl', 'kal', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(76, 'Kannada', N'ಕನ್ನಡ', 'kn', 'kan', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(77, 'Kanuri', N'Kanuri', 'kr', 'kau', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(78, 'Kashmiri', N'कश्मीरी, كشميري‎', 'ks', 'kas', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(79, 'Kazakh', N'қазақ тілі', 'kk', 'kaz', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(80, 'Central Khmer', N'ខ្មែរ, ខេមរភាសា, ភាសាខ្មែរ', 'km', 'khm', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(81, 'Kikuyu, Gikuyu', N'Gĩkũyũ', 'ki', 'kik', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(82, 'Kinyarwanda', N'Ikinyarwanda', 'rw', 'kin', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(83, 'Kirghiz, Kyrgyz', N'Кыргызча, Кыргыз тили', 'ky', 'kir', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(84, 'Komi', N'коми кыв', 'kv', 'kom', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(85, 'Kongo', N'Kikongo', 'kg', 'kon', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(86, 'Korean', N'한국어', 'ko', 'kor', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(87, 'Kurdish', N'Kurdî, کوردی‎', 'ku', 'kur', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(88, 'Kuanyama, Kwanyama', N'Kuanyama', 'kj', 'kua', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(89, 'Latin', N'latine, lingua latina', 'la', 'lat', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(90, 'Luxembourgish, Letzeburgesch', N'Lëtzebuergesch', 'lb', 'ltz', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(91, 'Ganda', N'Luganda', 'lg', 'lug', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(92, 'Limburgan, Limburger, Limburgish', N'Limburgs', 'li', 'lim', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(93, 'Lingala', N'Lingála', 'ln', 'lin', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(94, 'Lao', N'ພາສາລາວ', 'lo', 'lao', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(95, 'Lithuanian', N'lietuvių kalba', 'lt', 'lit', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(96, 'Luba-Katanga', N'Kiluba', 'lu', 'lub', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(97, 'Latvian', N'latviešu valoda', 'lv', 'lav', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(98, 'Manx', N'Gaelg, Gailck', 'gv', 'glv', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(99, 'Macedonian', N'македонски јазик', 'mk', 'mkd', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(100, 'Malagasy', N'fiteny malagasy', 'mg', 'mlg', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(101, 'Malay', N'Bahasa Melayu, بهاس ملايو‎', 'ms', 'msa', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(102, 'Malayalam', N'മലയാളം', 'ml', 'mal', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(103, 'Maltese', N'Malti', 'mt', 'mlt', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(104, 'Maori', N'te reo Māori', 'mi', 'mri', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(105, 'Marathi', N'मराठी', 'mr', 'mar', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(106, 'Marshallese', N'Kajin M̧ajeļ', 'mh', 'mah', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(107, 'Mongolian', N'Монгол хэл', 'mn', 'mon', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(108, 'Nauru', N'Dorerin Naoero', 'na', 'nau', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(109, 'Navajo, Navaho', N'Diné bizaad', 'nv', 'nav', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(110, 'North Ndebele', N'isiNdebele', 'nd', 'nde', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(111, 'Nepali', N'नेपाली', 'ne', 'nep', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(112, 'Ndonga', N'Owambo', 'ng', 'ndo', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(113, 'Norwegian Bokmål', N'Norsk Bokmål', 'nb', 'nob', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(114, 'Norwegian Nynorsk', N'Norsk Nynorsk', 'nn', 'nno', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(115, 'Norwegian', N'Norsk', 'no', 'nor', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(116, 'Sichuan Yi, Nuosu', N'ꆈꌠ꒿ Nuosuhxop', 'ii', 'iii', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(117, 'South Ndebele', N'isiNdebele', 'nr', 'nbl', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(118, 'Occitan', N'occitan, lenga d''òc', 'oc', 'oci', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(119, 'Ojibwa', N'ᐊᓂᔑᓈᐯᒧᐎᓐ', 'oj', 'oji', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(120, 'Church Slavic, Old Slavonic, Church Slavonic', N'ѩзыкъ словѣньскъ', 'cu', 'chu', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(121, 'Oromo', N'Afaan Oromoo', 'om', 'orm', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(122, 'Oriya', N'ଓଡ଼ିଆ', 'or', 'ori', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(123, 'Ossetian, Ossetic', N'ирон æвзаг', 'os', 'oss', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(124, 'Punjabi, Panjabi', N'ਪੰਜਾਬੀ, پنجابی‎', 'pa', 'pan', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(125, 'Pali', N'पालि, पाळि', 'pi', 'pli', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(126, 'Persian', N'فارسی', 'fa', 'fas', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(127, 'Polish', N'język polski, polszczyzna', 'pl', 'pol', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(128, 'Pashto, Pushto', N'پښتو', 'ps', 'pus', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(129, 'Portuguese', N'Português', 'pt', 'por', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(130, 'Quechua', N'Runa Simi, Kichwa', 'qu', 'que', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(131, 'Romansh', N'Rumantsch Grischun', 'rm', 'roh', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(132, 'Rundi', N'Ikirundi', 'rn', 'run', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(133, 'Romanian, Moldavian, Moldovan', N'Română', 'ro', 'ron', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(134, 'Russian', N'русский', 'ru', 'rus', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(135, 'Sanskrit', N'संस्कृतम्', 'sa', 'san', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(136, 'Sardinian', N'sardu', 'sc', 'srd', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(137, 'Sindhi', N'सिन्धी, سنڌي، سندھی‎', 'sd', 'snd', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(138, 'Northern Sami', N'Davvisámegiella', 'se', 'sme', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(139, 'Samoan', N'gagana fa''a Samoa', 'sm', 'smo', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(140, 'Sango', N'yângâ tî sängö', 'sg', 'sag', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(141, 'Serbian', N'српски језик', 'sr', 'srp', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(142, 'Gaelic, Scottish Gaelic', N'Gàidhlig', 'gd', 'gla', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(143, 'Shona', N'chiShona', 'sn', 'sna', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(144, 'Sinhala, Sinhalese', N'සිංහල', 'si', 'sin', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(145, 'Slovak', N'Slovenčina, Slovenský Jazyk', 'sk', 'slk', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(146, 'Slovenian', N'Slovenski Jezik, Slovenščina', 'sl', 'slv', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(147, 'Somali', N'Soomaaliga, af Soomaali', 'so', 'som', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(148, 'Southern Sotho', N'Sesotho', 'st', 'sot', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(149, 'Spanish, Castilian', N'Español', 'es', 'spa', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(150, 'Sundanese', N'Basa Sunda', 'su', 'sun', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(151, 'Swahili', N'Kiswahili', 'sw', 'swa', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(152, 'Swati', N'SiSwati', 'ss', 'ssw', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(153, 'Swedish', N'Svenska', 'sv', 'swe', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(154, 'Tamil', N'தமிழ்', 'ta', 'tam', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(155, 'Telugu', N'తెలుగు', 'te', 'tel', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(156, 'Tajik', N'тоҷикӣ, toçikī, تاجیکی‎', 'tg', 'tgk', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(157, 'Thai', N'ไทย', 'th', 'tha', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(158, 'Tigrinya', N'ትግርኛ', 'ti', 'tir', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(159, 'Tibetan', N'བོད་ཡིག', 'bo', 'bod', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(160, 'Turkmen', N'Türkmen, Түркмен', 'tk', 'tuk', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(161, 'Tagalog', N'Wikang Tagalog', 'tl', 'tgl', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(162, 'Tswana', N'Setswana', 'tn', 'tsn', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(163, 'Tonga (Tonga Islands)', N'Faka Tonga', 'to', 'ton', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(164, 'Turkish', N'Türkçe', 'tr', 'tur', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(165, 'Tsonga', N'Xitsonga', 'ts', 'tso', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(166, 'Tatar', N'татар теле, tatar tele', 'tt', 'tat', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(167, 'Twi', N'Twi', 'tw', 'twi', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(168, 'Tahitian', N'Reo Tahiti', 'ty', 'tah', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(169, 'Uighur, Uyghur', N'ئۇيغۇرچە‎, Uyghurche', 'ug', 'uig', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(170, 'Ukrainian', N'Українська', 'uk', 'ukr', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(171, 'Urdu', N'اردو', 'ur', 'urd', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(172, 'Uzbek', N'Oʻzbek, Ўзбек, أۇزبېك‎', 'uz', 'uzb', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(173, 'Venda', N'Tshivenḓa', 've', 'ven', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(174, 'Vietnamese', N'Tiếng Việt', 'vi', 'vie', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(175, 'Volapük', N'Volapük', 'vo', 'vol', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(176, 'Walloon', N'Walon', 'wa', 'wln', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(177, 'Welsh', N'Cymraeg', 'cy', 'cym', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(178, 'Wolof', N'Wollof', 'wo', 'wol', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(179, 'Western Frisian', N'Frysk', 'fy', 'fry', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(180, 'Xhosa', N'isiXhosa', 'xh', 'xho', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(181, 'Yiddish', N'ייִדיש', 'yi', 'yid', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(182, 'Yoruba', N'Yorùbá', 'yo', 'yor', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(183, 'Zhuang, Chuang', N'Saɯ cueŋƅ, Saw cuengh', 'za', 'zha', 0); 
INSERT INTO dbLanguage (Id, LanguageName, ForeignName, ISO6391, ISO6392, Active) VALUES(184, 'Zulu', N'isiZulu', 'zu', 'zul', 0); 
 
SET IDENTITY_INSERT dbLanguage OFF
  
SET IDENTITY_INSERT dbClaim ON
 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (1, 'Classification', 'Classification', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (2, 'Classification', 'ClassificationPage', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (3, 'Administration', 'Role', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (4, 'Classification', 'ClassificationLevel', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (5, 'Type', 'ContentType', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (6, 'Type', 'OrganizationType', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (7, 'Type', 'PageType', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (8, 'Page', 'Page', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (9, 'Project', 'Project', 'Menu'); 
INSERT INTO dbClaim (Id, ClaimGroup, Claim, ClaimType) VALUES (10, 'Type', 'Type', 'Menu'); 

SET IDENTITY_INSERT dbClaim OFF

SET IDENTITY_INSERT dbSecurityLevel ON
 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (1, '1'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (2, '2'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (3, '3'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (4, '4'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (5, '5'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (6, '6'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (7, '7'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (8, '8'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (9, '9'); 
INSERT INTO dbSecurityLevel (Id, Name) VALUES (10, '10'); 

SET IDENTITY_INSERT dbSecurityLevel OFF
 
SET IDENTITY_INSERT dbSetting ON

INSERT INTO dbSetting  (Id, IntValue, SettingName) VALUES (1, 41, 'Default language'); 
INSERT INTO dbSetting  (Id, IntValue, SettingName) VALUES (2, 2, 'Home page'); 
 
SET IDENTITY_INSERT dbSetting OFF

SET IDENTITY_INSERT dbClassificationStatus ON

INSERT INTO dbClassificationStatus (Id, ClassificationStatusName) VALUES (1, 'Active'); 
INSERT INTO dbClassificationStatus (Id, ClassificationStatusName) VALUES (2, 'Inactive'); 

SET IDENTITY_INSERT dbClassificationStatus OFF

SET IDENTITY_INSERT dbOrganizationStatus ON
 
INSERT INTO dbOrganizationStatus (Id, OrganizationStatusName) VALUES (1, 'Active'); 
INSERT INTO dbOrganizationStatus (Id, OrganizationStatusName) VALUES (2, 'Inactive'); 

SET IDENTITY_INSERT dbOrganizationStatus OFF

SET IDENTITY_INSERT dbProjectStatus ON
 
INSERT INTO dbProjectStatus (Id, ProjectStatusName) VALUES (1, 'Active'); 
INSERT INTO dbProjectStatus (Id, ProjectStatusName) VALUES (2, 'Inactive'); 

SET IDENTITY_INSERT dbProjectStatus OFF

SET IDENTITY_INSERT dbPageStatus ON

INSERT INTO dbPageStatus (Id, PageStatusName) VALUES (1, 'Active'); 
INSERT INTO dbPageStatus (Id, PageStatusName) VALUES (2, 'Inactive'); 

SET IDENTITY_INSERT dbPageStatus OFF

SET IDENTITY_INSERT dbMasterList ON

INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (0, '-- Not linked --', '-- Not linked --',1); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (1, 'Users', 'Users',5); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (2, 'Organizations', 'Organizations',3); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (3, 'Projects', 'Projects',4); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (4, 'Classifications', 'Classifications',2); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (5, 'Content', 'Content',2); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (6, 'Language', 'Language',2); 
INSERT dbMasterList (Id, MasterListName, MasterListDescription, Sequence) VALUES (7, 'Country', 'Country',2); 

SET IDENTITY_INSERT dbMasterList OFF

SET IDENTITY_INSERT dbDataType ON


INSERT dbDataType (Id, DataTypeName, DataTypeDescription) VALUES (1, 'Text', 'Text'); 
INSERT dbDataType (Id, DataTypeName, DataTypeDescription) VALUES (2, 'Number', 'Number'); 
INSERT dbDataType (Id, DataTypeName, DataTypeDescription) VALUES (3, 'Date', 'Date'); 
INSERT dbDataType (Id, DataTypeName, DataTypeDescription) VALUES (4, 'Date time', 'Date time'); 
SET IDENTITY_INSERT dbDataType OFF

SET IDENTITY_INSERT dbCountry ON

INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (1, 'Afghanistan', 'AF', 'AFG', 4, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (2, 'Åland Islands', 'AX', 'ALA', 248, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (3, 'Albania', 'AL', 'ALB', 8, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (4, 'Algeria', 'DZ', 'DZA', 12, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (5, 'American Samoa', 'AS', 'ASM', 16, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (6, 'Andorra', 'AD', 'AND', 20, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (7, 'Angola', 'AO', 'AGO', 24, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (8, 'Anguilla', 'AI', 'AIA', 660, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (9, 'Antarctica', 'AQ', 'ATA', 10, ''); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (10, 'Antigua and Barbuda', 'AG', 'ATG', 28, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (11, 'Argentina', 'AR', 'ARG', 32, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (12, 'Armenia', 'AM', 'ARM', 51, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (13, 'Aruba', 'AW', 'ABW', 533, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (14, 'Australia', 'AU', 'AUS', 36, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (15, 'Austria', 'AT', 'AUT', 40, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (16, 'Azerbaijan', 'AZ', 'AZE', 31, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (17, 'Bahamas', 'BS', 'BHS', 44, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (18, 'Bahrain', 'BH', 'BHR', 48, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (19, 'Bangladesh', 'BD', 'BGD', 50, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (20, 'Barbados', 'BB', 'BRB', 52, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (21, 'Belarus', 'BY', 'BLR', 112, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (22, 'Belgium', 'BE', 'BEL', 56, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (23, 'Belize', 'BZ', 'BLZ', 84, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (24, 'Benin', 'BJ', 'BEN', 204, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (25, 'Bermuda', 'BM', 'BMU', 60, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (26, 'Bhutan', 'BT', 'BTN', 64, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (27, 'Bolivia (Plurinational State of)', 'BO', 'BOL', 68, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (28, 'Bonaire, Sint Eustatius and Saba', 'BQ', 'BES', 535, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (29, 'Bosnia and Herzegovina', 'BA', 'BIH', 70, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (30, 'Botswana', 'BW', 'BWA', 72, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (31, 'Bouvet Island', 'BV', 'BVT', 74, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (32, 'Brazil', 'BR', 'BRA', 76, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (33, 'British Indian Ocean Territory', 'IO', 'IOT', 86, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (34, 'Brunei Darussalam', 'BN', 'BRN', 96, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (35, 'Bulgaria', 'BG', 'BGR', 100, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (36, 'Burkina Faso', 'BF', 'BFA', 854, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (37, 'Burundi', 'BI', 'BDI', 108, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (38, 'Cabo Verde', 'CV', 'CPV', 132, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (39, 'Cambodia', 'KH', 'KHM', 116, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (40, 'Cameroon', 'CM', 'CMR', 120, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (41, 'Canada', 'CA', 'CAN', 124, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (42, 'Cayman Islands', 'KY', 'CYM', 136, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (43, 'Central African Republic', 'CF', 'CAF', 140, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (44, 'Chad', 'TD', 'TCD', 148, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (45, 'Chile', 'CL', 'CHL', 152, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (46, 'China', 'CN', 'CHN', 156, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (47, 'Christmas Island', 'CX', 'CXR', 162, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (48, 'Cocos (Keeling) Islands', 'CC', 'CCK', 166, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (49, 'Colombia', 'CO', 'COL', 170, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (50, 'Comoros', 'KM', 'COM', 174, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (51, 'Congo', 'CG', 'COG', 178, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (52, 'Congo, Democratic Republic of the', 'CD', 'COD', 180, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (53, 'Cook Islands', 'CK', 'COK', 184, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (54, 'Costa Rica', 'CR', 'CRI', 188, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (55, 'Côte d''Ivoire', 'CI', 'CIV', 384, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (56, 'Croatia', 'HR', 'HRV', 191, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (57, 'Cuba', 'CU', 'CUB', 192, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (58, 'Curaçao', 'CW', 'CUW', 531, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (59, 'Cyprus', 'CY', 'CYP', 196, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (60, 'Czechia', 'CZ', 'CZE', 203, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (61, 'Denmark', 'DK', 'DNK', 208, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (62, 'Djibouti', 'DJ', 'DJI', 262, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (63, 'Dominica', 'DM', 'DMA', 212, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (64, 'Dominican Republic', 'DO', 'DOM', 214, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (65, 'Ecuador', 'EC', 'ECU', 218, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (66, 'Egypt', 'EG', 'EGY', 818, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (67, 'El Salvador', 'SV', 'SLV', 222, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (68, 'Equatorial Guinea', 'GQ', 'GNQ', 226, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (69, 'Eritrea', 'ER', 'ERI', 232, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (70, 'Estonia', 'EE', 'EST', 233, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (71, 'Eswatini', 'SZ', 'SWZ', 748, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (72, 'Ethiopia', 'ET', 'ETH', 231, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (73, 'Falkland Islands (Malvinas)', 'FK', 'FLK', 238, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (74, 'Faroe Islands', 'FO', 'FRO', 234, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (75, 'Fiji', 'FJ', 'FJI', 242, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (76, 'Finland', 'FI', 'FIN', 246, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (77, 'France', 'FR', 'FRA', 250, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (78, 'French Guiana', 'GF', 'GUF', 254, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (79, 'French Polynesia', 'PF', 'PYF', 258, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (80, 'French Southern Territories', 'TF', 'ATF', 260, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (81, 'Gabon', 'GA', 'GAB', 266, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (82, 'Gambia', 'GM', 'GMB', 270, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (83, 'Georgia', 'GE', 'GEO', 268, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (84, 'Germany', 'DE', 'DEU', 276, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (85, 'Ghana', 'GH', 'GHA', 288, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (86, 'Gibraltar', 'GI', 'GIB', 292, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (87, 'Greece', 'GR', 'GRC', 300, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (88, 'Greenland', 'GL', 'GRL', 304, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (89, 'Grenada', 'GD', 'GRD', 308, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (90, 'Guadeloupe', 'GP', 'GLP', 312, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (91, 'Guam', 'GU', 'GUM', 316, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (92, 'Guatemala', 'GT', 'GTM', 320, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (93, 'Guernsey', 'GG', 'GGY', 831, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (94, 'Guinea', 'GN', 'GIN', 324, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (95, 'Guinea-Bissau', 'GW', 'GNB', 624, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (96, 'Guyana', 'GY', 'GUY', 328, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (97, 'Haiti', 'HT', 'HTI', 332, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (98, 'Heard Island and McDonald Islands', 'HM', 'HMD', 334, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (99, 'Holy See', 'VA', 'VAT', 336, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (100, 'Honduras', 'HN', 'HND', 340, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (101, 'Hong Kong', 'HK', 'HKG', 344, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (102, 'Hungary', 'HU', 'HUN', 348, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (103, 'Iceland', 'IS', 'ISL', 352, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (104, 'India', 'IN', 'IND', 356, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (105, 'Indonesia', 'ID', 'IDN', 360, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (106, 'Iran (Islamic Republic of)', 'IR', 'IRN', 364, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (107, 'Iraq', 'IQ', 'IRQ', 368, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (108, 'Ireland', 'IE', 'IRL', 372, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (109, 'Isle of Man', 'IM', 'IMN', 833, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (110, 'Israel', 'IL', 'ISR', 376, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (111, 'Italy', 'IT', 'ITA', 380, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (112, 'Jamaica', 'JM', 'JAM', 388, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (113, 'Japan', 'JP', 'JPN', 392, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (114, 'Jersey', 'JE', 'JEY', 832, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (115, 'Jordan', 'JO', 'JOR', 400, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (116, 'Kazakhstan', 'KZ', 'KAZ', 398, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (117, 'Kenya', 'KE', 'KEN', 404, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (118, 'Kiribati', 'KI', 'KIR', 296, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (119, 'Korea (Democratic People''s Republic of)', 'KP', 'PRK', 408, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (120, 'Korea, Republic of', 'KR', 'KOR', 410, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (121, 'Kuwait', 'KW', 'KWT', 414, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (122, 'Kyrgyzstan', 'KG', 'KGZ', 417, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (123, 'Lao People''s Democratic Republic', 'LA', 'LAO', 418, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (124, 'Latvia', 'LV', 'LVA', 428, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (125, 'Lebanon', 'LB', 'LBN', 422, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (126, 'Lesotho', 'LS', 'LSO', 426, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (127, 'Liberia', 'LR', 'LBR', 430, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (128, 'Libya', 'LY', 'LBY', 434, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (129, 'Liechtenstein', 'LI', 'LIE', 438, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (130, 'Lithuania', 'LT', 'LTU', 440, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (131, 'Luxembourg', 'LU', 'LUX', 442, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (132, 'Macao', 'MO', 'MAC', 446, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (133, 'Madagascar', 'MG', 'MDG', 450, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (134, 'Malawi', 'MW', 'MWI', 454, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (135, 'Malaysia', 'MY', 'MYS', 458, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (136, 'Maldives', 'MV', 'MDV', 462, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (137, 'Mali', 'ML', 'MLI', 466, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (138, 'Malta', 'MT', 'MLT', 470, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (139, 'Marshall Islands', 'MH', 'MHL', 584, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (140, 'Martinique', 'MQ', 'MTQ', 474, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (141, 'Mauritania', 'MR', 'MRT', 478, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (142, 'Mauritius', 'MU', 'MUS', 480, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (143, 'Mayotte', 'YT', 'MYT', 175, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (144, 'Mexico', 'MX', 'MEX', 484, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (145, 'Micronesia (Federated States of)', 'FM', 'FSM', 583, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (146, 'Moldova, Republic of', 'MD', 'MDA', 498, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (147, 'Monaco', 'MC', 'MCO', 492, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (148, 'Mongolia', 'MN', 'MNG', 496, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (149, 'Montenegro', 'ME', 'MNE', 499, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (150, 'Montserrat', 'MS', 'MSR', 500, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (151, 'Morocco', 'MA', 'MAR', 504, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (152, 'Mozambique', 'MZ', 'MOZ', 508, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (153, 'Myanmar', 'MM', 'MMR', 104, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (154, 'Namibia', 'NA', 'NAM', 516, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (155, 'Nauru', 'NR', 'NRU', 520, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (156, 'Nepal', 'NP', 'NPL', 524, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (157, 'Netherlands', 'NL', 'NLD', 528, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (158, 'New Caledonia', 'NC', 'NCL', 540, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (159, 'New Zealand', 'NZ', 'NZL', 554, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (160, 'Nicaragua', 'NI', 'NIC', 558, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (161, 'Niger', 'NE', 'NER', 562, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (162, 'Nigeria', 'NG', 'NGA', 566, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (163, 'Niue', 'NU', 'NIU', 570, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (164, 'Norfolk Island', 'NF', 'NFK', 574, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (165, 'North Macedonia', 'MK', 'MKD', 807, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (166, 'Northern Mariana Islands', 'MP', 'MNP', 580, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (167, 'Norway', 'NO', 'NOR', 578, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (168, 'Oman', 'OM', 'OMN', 512, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (169, 'Pakistan', 'PK', 'PAK', 586, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (170, 'Palau', 'PW', 'PLW', 585, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (171, 'Palestine, State of', 'PS', 'PSE', 275, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (172, 'Panama', 'PA', 'PAN', 591, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (173, 'Papua New Guinea', 'PG', 'PNG', 598, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (174, 'Paraguay', 'PY', 'PRY', 600, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (175, 'Peru', 'PE', 'PER', 604, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (176, 'Philippines', 'PH', 'PHL', 608, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (177, 'Pitcairn', 'PN', 'PCN', 612, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (178, 'Poland', 'PL', 'POL', 616, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (179, 'Portugal', 'PT', 'PRT', 620, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (180, 'Puerto Rico', 'PR', 'PRI', 630, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (181, 'Qatar', 'QA', 'QAT', 634, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (182, 'Réunion', 'RE', 'REU', 638, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (183, 'Romania', 'RO', 'ROU', 642, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (184, 'Russian Federation', 'RU', 'RUS', 643, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (185, 'Rwanda', 'RW', 'RWA', 646, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (186, 'Saint Barthélemy', 'BL', 'BLM', 652, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (187, 'Saint Helena, Ascension and Tristan da Cunha', 'SH', 'SHN', 654, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (188, 'Saint Kitts and Nevis', 'KN', 'KNA', 659, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (189, 'Saint Lucia', 'LC', 'LCA', 662, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (190, 'Saint Martin (French part)', 'MF', 'MAF', 663, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (191, 'Saint Pierre and Miquelon', 'PM', 'SPM', 666, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (192, 'Saint Vincent and the Grenadines', 'VC', 'VCT', 670, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (193, 'Samoa', 'WS', 'WSM', 882, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (194, 'San Marino', 'SM', 'SMR', 674, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (195, 'Sao Tome and Principe', 'ST', 'STP', 678, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (196, 'Saudi Arabia', 'SA', 'SAU', 682, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (197, 'Senegal', 'SN', 'SEN', 686, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (198, 'Serbia', 'RS', 'SRB', 688, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (199, 'Seychelles', 'SC', 'SYC', 690, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (200, 'Sierra Leone', 'SL', 'SLE', 694, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (201, 'Singapore', 'SG', 'SGP', 702, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (202, 'Sint Maarten (Dutch part)', 'SX', 'SXM', 534, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (203, 'Slovakia', 'SK', 'SVK', 703, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (204, 'Slovenia', 'SI', 'SVN', 705, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (205, 'Solomon Islands', 'SB', 'SLB', 90, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (206, 'Somalia', 'SO', 'SOM', 706, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (207, 'South Africa', 'ZA', 'ZAF', 710, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (208, 'South Georgia and the South Sandwich Islands', 'GS', 'SGS', 239, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (209, 'South Sudan', 'SS', 'SSD', 728, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (210, 'Spain', 'ES', 'ESP', 724, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (211, 'Sri Lanka', 'LK', 'LKA', 144, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (212, 'Sudan', 'SD', 'SDN', 729, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (213, 'Suriname', 'SR', 'SUR', 740, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (214, 'Svalbard and Jan Mayen', 'SJ', 'SJM', 744, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (215, 'Sweden', 'SE', 'SWE', 752, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (216, 'Switzerland', 'CH', 'CHE', 756, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (217, 'Syrian Arab Republic', 'SY', 'SYR', 760, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (218, 'Taiwan, Province of China', 'TW', 'TWN', 158, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (219, 'Tajikistan', 'TJ', 'TJK', 762, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (220, 'Tanzania, United Republic of', 'TZ', 'TZA', 834, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (221, 'Thailand', 'TH', 'THA', 764, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (222, 'Timor-Leste', 'TL', 'TLS', 626, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (223, 'Togo', 'TG', 'TGO', 768, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (224, 'Tokelau', 'TK', 'TKL', 772, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (225, 'Tonga', 'TO', 'TON', 776, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (226, 'Trinidad and Tobago', 'TT', 'TTO', 780, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (227, 'Tunisia', 'TN', 'TUN', 788, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (228, 'Turkey', 'TR', 'TUR', 792, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (229, 'Turkmenistan', 'TM', 'TKM', 795, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (230, 'Turks and Caicos Islands', 'TC', 'TCA', 796, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (231, 'Tuvalu', 'TV', 'TUV', 798, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (232, 'Uganda', 'UG', 'UGA', 800, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (233, 'Ukraine', 'UA', 'UKR', 804, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (234, 'United Arab Emirates', 'AE', 'ARE', 784, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (235, 'United Kingdom of Great Britain and Northern Ireland', 'GB', 'GBR', 826, 'Europe'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (236, 'United States of America', 'US', 'USA', 840, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (237, 'United States Minor Outlying Islands', 'UM', 'UMI', 581, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (238, 'Uruguay', 'UY', 'URY', 858, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (239, 'Uzbekistan', 'UZ', 'UZB', 860, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (240, 'Vanuatu', 'VU', 'VUT', 548, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (241, 'Venezuela (Bolivarian Republic of)', 'VE', 'VEN', 862, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (242, 'Viet Nam', 'VN', 'VNM', 704, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (243, 'Virgin Islands (British)', 'VG', 'VGB', 92, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (244, 'Virgin Islands (U.S.)', 'VI', 'VIR', 850, 'Americas'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (245, 'Wallis and Futuna', 'WF', 'WLF', 876, 'Oceania'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (246, 'Western Sahara', 'EH', 'ESH', 732, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (247, 'Yemen', 'YE', 'YEM', 887, 'Asia'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (248, 'Zambia', 'ZM', 'ZMB', 894, 'Africa'); 
INSERT dbCountry (Id, CountryName, ISO31662, ISO31663, ISO3166Num, Region) VALUES (249, 'Zimbabwe', 'ZW', 'ZWE', 716, 'Africa'); 

SET IDENTITY_INSERT dbCountry OFF

SET IDENTITY_INSERT dbProcessTemplateStepFieldStatus ON

INSERT dbProcessTemplateStepFieldStatus (Id, StatusName) VALUES (1, 'Hide'); 
INSERT dbProcessTemplateStepFieldStatus (Id, StatusName) VALUES (2, 'Disabled'); 
INSERT dbProcessTemplateStepFieldStatus (Id, StatusName) VALUES (3, 'Editable'); 
INSERT dbProcessTemplateStepFieldStatus (Id, StatusName) VALUES (4, 'Mandatory'); 

SET IDENTITY_INSERT dbProcessTemplateStepFieldStatus OFF
SET IDENTITY_INSERT dbProcessTemplateFlowConditionType ON

INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (1, 'Field', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (2, 'Creator', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (3, 'Security level creator', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (4, 'Role creator', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (5, 'Manager creator', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (6, 'Organization creator', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (7, 'Field - Project parent', getdate(), getdate()); 
INSERT dbProcessTemplateFlowConditionType (Id, ConditionTypeName, CreatedDate, ModifiedDate) VALUES (8, 'Field - Organization parent', getdate(), getdate()); 

SET IDENTITY_INSERT dbProcessTemplateFlowConditionType OFF
