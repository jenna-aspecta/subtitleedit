﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Nikse.SubtitleEdit.Core.Common
{
    public class DvdSubtitleLanguage
    {
        public static class Language
        {
            public static Dictionary<string, string> LanguageNames { get; set; } = new Dictionary<string, string>
            {
               {"aa", "Afar"               },
               {"ab", "Abkhazian"          },
               {"af", "Afrikaans"          },
               {"am", "Amharic"            },
               {"ar", "Arabic"             },
               {"as", "Assamese"           },
               {"ay", "Aymara"             },
               {"az", "Azerbaijani"        },
               {"ba", "Bashkir"            },
               {"be", "Belarusian"         },
               {"bg", "Bulgarian"          },
               {"bh", "Bihari"             },
               {"bi", "Bislama"            },
               {"bn", "Bengali"            },
               {"bo", "Tibetan"            },
               {"br", "Breton"             },
               {"ca", "Catalan"            },
               {"co", "Corsican"           },
               {"cs", "Czech"              },
               {"cy", "Welsh"              },
               {"da", "Danish"             },
               {"de", "German"             },
               {"dz", "Dzongkha"           },
               {"el", "Greek"              },
               {"en", "English"            },
               {"eo", "Esperanto"          },
               {"es", "Spanish"            },
               {"et", "Estonian"           },
               {"eu", "Basque"             },
               {"fa", "Persian"            },
               {"fi", "Finnish"            },
               {"fj", "Fijian"             },
               {"fo", "Faroese"            },
               {"fr", "French"             },
               {"fy", "Western Frisian"    },
               {"ga", "Irish"              },
               {"gd", "Scottish Gaelic"    },
               {"gl", "Galician"           },
               {"gn", "Guarani"            },
               {"gu", "Gujarati"           },
               {"ha", "Hausa"              },
               {"he", "Hebrew"             },
               {"hi", "Hindi"              },
               {"hr", "Croatian"           },
               {"hu", "Hungarian"          },
               {"hy", "Armenian"           },
               {"ia", "Interlingua"        },
               {"id", "Indonesian"         },
               {"ie", "Interlingue"        },
               {"ik", "Inupiaq"            },
               {"is", "Icelandic"          },
               {"it", "Italian"            },
               {"iu", "Inuktitut"          },
               {"ja", "Japanese"           },
               {"jv", "Javanese"           },
               {"ka", "Georgian"           },
               {"kk", "Kazakh"             },
               {"kl", "Kalaallisut"        },
               {"km", "Khmer"              },
               {"kn", "Kannada"            },
               {"ko", "Korean"             },
               {"ks", "Kashmiri"           },
               {"ku", "Kurdish"            },
               {"ky", "Kyrgyz"             },
               {"la", "Latin"              },
               {"lb", "Luxembourgish"      },
               {"ln", "Lingala"            },
               {"lo", "Lao"                },
               {"lt", "Lithuanian"         },
               {"lv", "Latvian"            },
               {"mg", "Malagasy"           },
               {"mi", "Maori"              },
               {"mk", "Macedonian"         },
               {"ml", "Malayalam"          },
               {"mn", "Mongolian"          },
               {"mo", "Moldavian"          },
               {"mr", "Marathi"            },
               {"ms", "Malay"              },
               {"mt", "Maltese"            },
               {"my", "Burmese"            },
               {"na", "Nauru"              },
               {"ne", "Nepali"             },
               {"nl", "Dutch"              },
               {"no", "Norwegian"          },
               {"oc", "Occitan"            },
               {"om", "Oromo"              },
               {"or", "Oriya"              },
               {"pa", "Punjabi"            },
               {"pl", "Polish"             },
               {"ps", "Pashto"             },
               {"pt", "Portuguese"         },
               {"qu", "Quechua"            },
               {"rm", "Romansh"            },
               {"rn", "Rundi"              },
               {"ro", "Romanian"           },
               {"ru", "Russian"            },
               {"rw", "Kinyarwanda"        },
               {"sa", "Sanskrit"           },
               {"sd", "Sindhi"             },
               {"sg", "Sango"              },
               {"sh", "Serbo-Croatian"     },
               {"si", "Sinhala"            },
               {"sk", "Slovak"             },
               {"sl", "Slovenian"          },
               {"sm", "Samoan"             },
               {"sn", "Shona"              },
               {"so", "Somali"             },
               {"sq", "Albanian"           },
               {"sr", "Serbian"            },
               {"ss", "Swati"              },
               {"st", "Southern Sotho"     },
               {"su", "Sundanese"          },
               {"sv", "Swedish"            },
               {"sw", "Swahili"            },
               {"ta", "Tamil"              },
               {"te", "Telugu"             },
               {"tg", "Tajik"              },
               {"th", "Thai"               },
               {"ti", "Tigrinya"           },
               {"tk", "Turkmen"            },
               {"tl", "Tagalog"            },
               {"tn", "Tswana"             },
               {"to", "Tongan"             },
               {"tr", "Turkish"            },
               {"ts", "Tsonga"             },
               {"tt", "Tatar"              },
               {"tw", "Twi"                },
               {"ug", "Uyghur"             },
               {"uk", "Ukrainian"          },
               {"ur", "Urdu"               },
               {"uz", "Uzbek"              },
               {"vi", "Vietnamese"         },
               {"vo", "Volapük"            },
               {"wo", "Wolof"              },
               {"xh", "Xhosa"              },
               {"yi", "Yiddish"            },
               {"yo", "Yoruba"             },
               {"za", "Zhuang"             },
               {"zh", "Chinese"            },
               {"zu", "Zulu"               },
            };
            public static string NotSpecified { get; set; } = "Not Specified";
            public static string UnknownCodeX { get; set; } = "Unknown ({0})";
            public static string CultureName { get; set; } = "en-US";
        }

        private class LanguagesByCode : KeyedCollection<string, DvdSubtitleLanguage>
        {
            public LanguagesByCode(IEnumerable<DvdSubtitleLanguage> languages)
            {
                foreach (var language in languages)
                {
                    Add(language);
                }
            }

            public DvdSubtitleLanguage GetValueOrNull(string code)
            {
                Dictionary.TryGetValue(code, out var language);
                return language;
            }

            protected override string GetKeyForItem(DvdSubtitleLanguage dsl)
            {
                return dsl.Code;
            }
        }

        private static readonly Dictionary<string, string> IsoToDvd = new Dictionary<string, string>
        {
            { "yi", "ji" }, { "jv", "jw" }, { "id", "in" }, { "he", "iw" } // { "bs", "sh" }, { "nb", "no" }, { "nn", "no" } ???
        };

        private static readonly Dictionary<string, string> DvdToIso = new Dictionary<string, string>
        {
            { "ji", "yi" }, { "jw", "jv" }, { "in", "id" }, { "iw", "he" }
        };

        private static readonly string[] CompliantDescriptions = {   // DVD code + native name
            "aa:Qafár af", "ab:аҧсуа бызшәа", "af:Afrikaans", "am:አማርኛ", "ar:العربية", "as:অসমীয়া", "ay:Aymar aru", "az:azərbaycan dili", "ba:башҡорт теле", "be:беларуская",
            "bg:български", "bh:भोजपुरी", "bi:Bislama", "bn:বাংলা", "bo:བོད་སྐད་", "br:brezhoneg", "ca:català", "co:corsu", "cs:čeština", "cy:Cymraeg", "da:dansk", "de:Deutsch", "dz:རྫོང་ཁ",
            "el:Ελληνικά", "en:English", "eo:esperanto", "es:español", "et:eesti", "eu:euskara", "fa:فارسی", "fi:suomi", "fj:Vosa Vakaviti", "fo:føroyskt", "fr:français",
            "fy:West-Frysk", "ga:Gaeilge", "gd:Gàidhlig", "gl:galego", "gn:Avañe'ẽ", "gu:ગુજરાતી", "ha:Hausa", "hi:हिन्दी", "hr:hrvatski", "hu:magyar", "hy:հայերեն", "ia:Interlingua",
            "ie:Interlingue", "ik:iñupiaq", "in:Indonesia", "is:íslenska", "it:italiano", "iu:ᐃᓄᒃᑎᑐᑦ", "iw:עברית", "ja:日本語", "ji:ייִדיש", "jw:Basa Jawa", "ka:ქართული", "kk:қазақ тілі",
            "kl:kalaallisut", "km:ខ្មែរ", "kn:ಕನ್ನಡ", "ko:한국어", "ks:کٲشُر", "ku:Kurdî", "ky:кыргызча", "la:lingua latina", "lb:Lëtzebuergesch", "ln:lingála", "lo:ລາວ", "lt:lietuvių",
            "lv:latviešu", "mg:Malagasy", "mi:Te reo Māori", "mk:македонски", "ml:മലയാളം", "mn:монгол", "mo:moldovenească", "mr:मराठी", "ms:Bahasa Melayu", "mt:Malti", "my:ဗမာ (myanma)",
            "na:Dorerin Naoero", "ne:नेपाली", "nl:Nederlands", "no:norsk", "oc:occitan", "om:Oromoo", "or:ଓଡ଼ିଆ", "pa:ਪੰਜਾਬੀ", "pl:polski", "ps:پښتو", "pt:português", "qu:Runasimi", "rm:rumantsch",
            "rn:Ikirundi", "ro:română", "ru:русский", "rw:Kinyarwanda", "sa:ंस्कृतम्", "sd:सिन्धी‎", "sg:Sängö", "sh:Srpskohrvatski", "si:සිංහල", "sk:slovenčina", "sl:slovenščina", "sm:Gagana fa'a Samoa",
            "sn:chiShona", "so:Soomaali", "sq:shqip", "sr:српски", "ss:SiSwati", "st:Sesotho", "su:Basa Sunda", "sv:svenska", "sw:Kiswahili", "ta:தமிழ்", "te:తెలుగు", "tg:тоҷикӣ", "th:ไทย", "ti:ትግርኛ",
            "tk:türkmençe", "tl:Wikang Tagalog", "tn:Setswana", "to:lea fakatonga", "tr:Türkçe", "ts:Xitsonga", "tt:татар теле", "tw:Twi", "ug:ئۇيغۇرچە", "uk:українська", "ur:اردو", "uz:o‘zbek",
            "vi:Tiếng Việt", "vo:Volapük", "wo:Wollof", "xh:IsiXhosa", "yo:Èdè Yorùbá", "za:Vahcuengh (話僮)", "zh:中文", "zu:isiZulu"
        };

        private static LanguagesByCode _compliantLanguagesByCode;

        public string Code { get; }
        public string LocalName { get; }
        public string NativeName { get; }

        public DvdSubtitleLanguage(string code, string localName, string nativeName)
        {
            Code = code;
            LocalName = localName;
            NativeName = nativeName;
        }

        private DvdSubtitleLanguage(string description)
        {
            NativeName = description.Substring(3);
            var code = description.Remove(2);
            Code = code;
            if (Language.LanguageNames.TryGetValue(ConvertDvdToIso(code), out var localName))
            {
                LocalName = localName;
            }
            else
            {
                throw new Exception($"Dvd language {code} not found!");
            }
        }

        public override string ToString()
        {
            return LocalName;
        }

        public static DvdSubtitleLanguage English => CompliantLanguagesByCode["en"];

        public static IEnumerable<DvdSubtitleLanguage> CompliantLanguages => CompliantLanguagesByCode;

        private static LanguagesByCode CompliantLanguagesByCode
        {
            get
            {
                if (_compliantLanguagesByCode == null)
                {
                    var cl = CompliantDescriptions.Select(s => new DvdSubtitleLanguage(s)).OrderBy(dsl => dsl.LocalName, StringComparer.CurrentCultureIgnoreCase).ThenBy(dsl => dsl.LocalName, StringComparer.Ordinal);
                    var ns = new[] { new DvdSubtitleLanguage("  ", Language.NotSpecified, "Not Specified") };
                    _compliantLanguagesByCode = new LanguagesByCode(ns.Concat(cl));
                }
                return _compliantLanguagesByCode;
            }
        }

        public static void Initialize()
        {
            _compliantLanguagesByCode = null;
        }

        public static string GetLocalLanguageName(string code)
        {
            var language = GetLanguageOrNull(code);
            return language == null ? GetNonCompliantLocalLanguageName(code) : language.LocalName;
        }

        public static string GetNativeLanguageName(string code)
        {
            var language = GetLanguageOrNull(code);
            return language == null ? GetNonCompliantNativeLanguageName(code) : language.NativeName;
        }

        public static DvdSubtitleLanguage GetLanguageOrNull(string code)
        {
            var dvdCode = ConvertIsoToDvd(code.ToLowerInvariant());
            return CompliantLanguagesByCode.GetValueOrNull(dvdCode);
        }

        private static string GetNonCompliantLocalLanguageName(string code)
        {
            try
            {
                var codeCulture = CultureInfo.GetCultureInfo(code);
                try
                {
                    var seCulture = CultureInfo.GetCultureInfo(Language.CultureName);
                    if (seCulture.Name == CultureInfo.CurrentUICulture.Name)
                    {
                        return codeCulture.DisplayName; // SE culture == UI culture
                    }
                }
                catch
                {
                    // ignored
                }

                return codeCulture.EnglishName; // SE culture != UI culture
            }
            catch
            {
                return string.Format(Language.UnknownCodeX, code);
            }
        }

        private static string GetNonCompliantNativeLanguageName(string code)
        {
            try
            {
                return CultureInfo.GetCultureInfo(code).NativeName;
            }
            catch
            {
                return $"Unknown ({code})";
            }
        }

        private static string ConvertDvdToIso(string dvdCode)
        {
            if (!DvdToIso.TryGetValue(dvdCode, out var isoCode))
            {
                isoCode = dvdCode;
            }

            return isoCode;
        }

        private static string ConvertIsoToDvd(string isoCode)
        {
            if (!IsoToDvd.TryGetValue(isoCode, out var dvdCode))
            {
                dvdCode = isoCode;
            }

            return dvdCode;
        }

    }
}
