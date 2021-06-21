using Collei.Lavi.Morph.Core;
using Collei.Lavi.Morph.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Inflect
{
    internal class ConjugatorHelper
    {
        public static string MakeDesiderative(Verb verb, EnumVerbPersons person, EnumVerbTenses tense, EnumVerbVoices voice, EnumVerbDefinitenesses definiteness)
        {
            return "na " + MakeFactual(verb, person, tense, voice, definiteness);
        }

        public static string MakeImperative(Verb verb, EnumVerbPersons person, EnumVerbDefinitenesses definiteness)
        {
            String suffix;
            Term conjugated = new Term(verb.Stem);
            EnumHarmony harmony = verb.Harmony;
            bool vocalic = verb.Vocalic;
            //
            if (definiteness == EnumVerbDefinitenesses.Definite)
            {
                if (harmony == EnumHarmony.Back)
                {
                    if (vocalic)
                    {
                        suffix = WhichPerson(person, "chod", "chonu", "chtok");
                    }
                    else
                    {
                        suffix = WhichPerson(person, "chod", "ichonu", "ichtok");
                    }
                }
                else
                {
                    if (vocalic)
                    {
                        suffix = WhichPerson(person, "ched", "chenu", "chtek");
                    }
                    else
                    {
                        suffix = WhichPerson(person, "ched", "ichenu", "ichtek");
                    }
                }
            }
            else
            {
                if (vocalic)
                {
                    suffix = WhichPerson(person, "ch", "moch", "toch");
                }
                else
                {
                    suffix = WhichPerson(person, "och", "omoch", "otoch");
                }
            }
            //
            if (String.IsNullOrEmpty(suffix))
            {
                return " ";
            }
            conjugated.AppendSuffix(suffix);
            return conjugated.Word;
        }

        public static string MakeFactual(Verb verb, EnumVerbPersons person, EnumVerbTenses tense, EnumVerbVoices voice, EnumVerbDefinitenesses definiteness)
        {
            string suffix;
            Term conjugated = new Term(verb.Stem);
            EnumHarmony harmony = verb.Harmony;
            bool vocalic = verb.Vocalic;
            //
            if (tense == EnumVerbTenses.Perfect)
            {
                if (definiteness == EnumVerbDefinitenesses.Definite)
                {
                    if (harmony == EnumHarmony.Back)
                    {
                        suffix = WhichPerson(person, "tom", "tod", "tja", "tonu", "totok", "tjuk");
                    }
                    else
                    {
                        suffix = WhichPerson(person, "tem", "ted", "tje", "tenu", "titek", "tjuk");
                    }
                }
                else
                {
                    suffix = WhichPerson(person, "tu", "tiš", "te", "time", "tite", "tech");
                }
            }
            else
            {
                if (definiteness == EnumVerbDefinitenesses.Definite)
                {
                    if (harmony == EnumHarmony.Back)
                    {
                        suffix = WhichPerson(person, "jom", "jod", "ja", "jonu", "jotok", "juk");
                    }
                    else
                    {
                        suffix = WhichPerson(person, "jem", "jed", "je", "jenu", "jitek", "juk");
                    }
                }
                else
                {
                    if (vocalic)
                    {
                        suffix = WhichPerson(person, "ju", "jš", "j", "jme", "jte", "jech");
                    }
                    else
                    {
                        suffix = WhichPerson(person, "u", "iš", "e", "ime", "ite", "ech");
                    }
                }
            }
            //
            conjugated.AppendSuffix(suffix);
            conjugated.AppendSuffix(GenerateVoiceAffix(conjugated, voice));
            //
            return conjugated.Word;
        }

        private static string WhichPerson(EnumVerbPersons person, string you, string we, string youPlural)
        {
            switch (person)
            {
                case EnumVerbPersons.You:
                    return you;
                case EnumVerbPersons.We:
                    return we;
                case EnumVerbPersons.YouPlural:
                    return youPlural;
                default:
                    return "";
            }
        }

        private static string WhichPerson(EnumVerbPersons person, string i, string you, string heSheIt, string we, string youPlural, string they)
        {
            switch (person)
            {
                case EnumVerbPersons.I:
                    return i;
                case EnumVerbPersons.HeSheIt:
                    return heSheIt;
                case EnumVerbPersons.They:
                    return they;
                default:
                    return WhichPerson(person, you, we, youPlural);
            }
        }

        private static string GenerateVoiceAffix(Term conjugatedVerb, EnumVerbVoices voice)
        {
            bool vocalic = conjugatedVerb.Vocalic;
            EnumHarmony harmony = conjugatedVerb.Harmony;
            //
            if (voice == EnumVerbVoices.Passive)
            {
                if (vocalic)
                {
                    return "ri";
                }
                return "i";
            }
            else if (voice == EnumVerbVoices.Medial)
            {
                if (harmony == EnumHarmony.Back)
                {
                    if (vocalic)
                    {
                        return "ror";
                    }
                    return "or";
                }
                else
                {
                    if (vocalic)
                    {
                        return "rer";
                    }
                    return "er";
                }
            }
            //
            return "";
        }



    }
}
