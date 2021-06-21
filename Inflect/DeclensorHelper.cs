using Collei.Lavi.Morph.Core;
using Collei.Lavi.Morph.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Inflect
{
    internal class DeclensorHelper
    {
        public static string MakeDeclension(Term noun, EnumNounPersons person, EnumNounCases nounCase, EnumNounPluralities plurality)
        {
            return MakeDeclension(new Term(MakePossessive(noun, person, plurality)), nounCase, EnumNounPluralities.Singular);
        }

        public static string MakeDeclension(Term noun, EnumNounCases nounCase, EnumNounPluralities plurality)
        {
            String affix = "";
            //
            if (plurality == EnumNounPluralities.Singular)
            {
                if (noun.Harmony == EnumHarmony.Back)
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichCase(nounCase, "", "t", "n", "nak", "kar", "ni", "ve", "no", "le", "to");
                    }
                    else if (noun.EndsWith("r", "s", "š", "n", "t"))
                    {
                        affix = WhichCase(nounCase, "", "t", "en", "nak", "kar", "ni", "ve", "no", "le", "to");
                    }
                    else
                    {
                        affix = WhichCase(nounCase, "", "ot", "en", "nak", "kar", "ni", "ve", "no", "le", "to");
                    }
                }
                else
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichCase(nounCase, "", "t", "n", "nek", "ker", "ni", "ve", "no", "le", "to");
                    }
                    else if (noun.EndsWith("r", "s", "š", "n", "t"))
                    {
                        affix = WhichCase(nounCase, "", "t", "en", "nek", "ker", "ni", "ve", "no", "le", "to");
                    }
                    else
                    {
                        affix = WhichCase(nounCase, "", "et", "en", "nek", "ker", "ni", "ve", "no", "le", "to");
                    }
                }
            }
            else if (plurality == EnumNounPluralities.Dual)
            {
                if (noun.Harmony == EnumHarmony.Back)
                {
                    affix = WhichCase(nounCase, "lar", "lart", "laren", "larnak", "larkar", "larni", "larve", "larno", "larle", "larto");
                }
                else
                {
                    affix = WhichCase(nounCase, "ler", "lert", "leren", "lernek", "lerker", "lerni", "lerve", "lerno", "lerle", "lerto");
                }
            }
            else if (plurality == EnumNounPluralities.Plural)
            {
                if (noun.Harmony == EnumHarmony.Back)
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichCase(nounCase, "k", "tok", "nim", "nakim", "karim", "kni", "kve", "kno", "kle", "kto");
                    }
                    else
                    {
                        affix = WhichCase(nounCase, "ok", "otok", "enim", "nakim", "karim", "okni", "okve", "okno", "okle", "okto");
                    }
                }
                else
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichCase(nounCase, "k", "tek", "nim", "nekim", "kerim", "kni", "kve", "kno", "kle", "kto");
                    }
                    else
                    {
                        affix = WhichCase(nounCase, "ek", "etek", "enim", "nekim", "kerim", "ekni", "ekve", "ekno", "ekle", "ekto");
                    }
                }
            }
            //
            return noun.Word + affix;
        }

        public static string MakePossessive(Term noun, EnumNounPersons person, EnumNounPluralities plurality)
        {
            String affix = "";
            //
            if (plurality == EnumNounPluralities.Singular)
            {
                if (noun.Harmony == EnumHarmony.Back)
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichPerson(person, "m", "d", "j", "nu", "tok", "juk");
                    }
                    else
                    {
                        affix = WhichPerson(person, "om", "od", "ja", "onu", "otok", "juk");
                    }
                }
                else
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichPerson(person, "m", "d", "j", "nu", "tek", "juk");
                    }
                    else
                    {
                        affix = WhichPerson(person, "em", "ed", "je", "enu", "itek", "juk");
                    }
                }
            }
            else if (plurality == EnumNounPluralities.Dual)
            {
                if (noun.Harmony == EnumHarmony.Back)
                {
                    affix = WhichPerson(person, "laram", "larad", "larja", "laranu", "lartok", "larjuk");
                }
                else
                {
                    affix = WhichPerson(person, "lerem", "lered", "lerje", "lerenu", "lertek", "lerjuk");
                }
            }
            else if (plurality == EnumNounPluralities.Plural)
            {
                if (noun.Harmony == EnumHarmony.Back)
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichPerson(person, "im", "id", "ij", "inu", "itok", "ijuk");
                    }
                    else
                    {
                        affix = WhichPerson(person, "oim", "oid", "oija", "oinu", "oitok", "oijuk");
                    }
                }
                else
                {
                    if (noun.Vocalic)
                    {
                        affix = WhichPerson(person, "im", "id", "ij", "inu", "itek", "ijuk");
                    }
                    else
                    {
                        affix = WhichPerson(person, "eim", "eid", "eije", "einu", "eitek", "eijuk");
                    }
                }
            }
            //
            return noun.Word + affix;
        }

        public static string WhichPerson(EnumNounPersons person, string i, string you, string heSheIt, string we, string youPlural, string they)
        {
            switch (person)
            {
                case EnumNounPersons.I:
                    return i;
                case EnumNounPersons.You:
                    return you;
                case EnumNounPersons.HeSheIt:
                    return heSheIt;
                case EnumNounPersons.We:
                    return we;
                case EnumNounPersons.YouPlural:
                    return youPlural;
                case EnumNounPersons.They:
                    return they;
                case EnumNounPersons.Neutral:
                    break;
            }
            //
            return "";
        }

        public static string WhichCase(EnumNounCases nounCase, string nominative, string accusative, string genitive, string dative, string ablative, string locative, string instrumental, string partitive, string abessive, string comitative)
        {
            switch (nounCase)
            {
                case EnumNounCases.Accusative:
                    return accusative;
                case EnumNounCases.Genitive:
                    return genitive;
                case EnumNounCases.dative:
                    return dative;
                case EnumNounCases.Ablative:
                    return ablative;
                case EnumNounCases.Locative:
                    return locative;
                case EnumNounCases.Instrumental:
                    return instrumental;
                case EnumNounCases.Partitive:
                    return partitive;
                case EnumNounCases.Abessive:
                    return abessive;
                case EnumNounCases.Comitative:
                    return comitative;
                case EnumNounCases.Nominative:
                    return nominative;
                default:
                    break;
            }
            //
            return nominative;
        }

    }
}
