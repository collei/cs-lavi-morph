using Collei.Lavi.Morph.Core;
using Collei.Lavi.Morph.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Inflect
{
    public class ConjugationTable
    {
        public EnumVerbTenses Tense { get; set; }
        public EnumVerbVoices Voice { get; set; }
        public EnumVerbModes Mode { get; set; }
        public EnumVerbDefinitenesses Definiteness { get; set; }
        public Verb Original { get; }

        private List<ConjugatedItem> Items { get; }

        public ConjugationTable(Verb verb)
        {
            if (verb == null)
            {
                throw new ArgumentNullException("O verbo fornecido não pode ser nulo.", nameof(verb));
            }
            if (verb.Word == "")
            {
                throw new ArgumentException("O verbo fornecido não pode ser uma string vazia.", nameof(verb));
            }

            Original = verb;
            Items = new List<ConjugatedItem>();
            Tense = EnumVerbTenses.Imperfect;
            Voice = EnumVerbVoices.Active;
            Mode = EnumVerbModes.Factual;
            Definiteness = EnumVerbDefinitenesses.Indefinite;
        }

        public ConjugationTable Add(EnumVerbPersons person)
        {
            Items.Add(new ConjugatedItem(Original, person, Tense, Voice, Mode, Definiteness));
            return this;
        }

        public List<Term> AsList()
        {
            List<Term> list = new List<Term>();
            //
            foreach (ConjugatedItem item in Items)
            {
                list.Add(item.Conjugated.Clone());
            }
            //
            return list;
        }

        public List<Term> AsList(params Enum[] filters)
        {
            List<Term> list = new List<Term>();
            //
            foreach (ConjugatedItem item in Items)
            {
                if (item.Matches(filters))
                {
                    list.Add(item.Conjugated.Clone());
                }
            }
            //
            return list;
        }

        public List<ConjugatedItem> AsItemsList()
        {
            List<ConjugatedItem> list = new List<ConjugatedItem>();
            //
            foreach (ConjugatedItem item in Items)
            {
                list.Add(item.Clone());
            }
            //
            return list;
        }

        public List<ConjugatedItem> AsItemsList(params Enum[] filters)
        {
            List<ConjugatedItem> list = new List<ConjugatedItem>();
            //
            foreach (ConjugatedItem item in Items)
            {
                if (item.Matches(filters))
                {
                    list.Add(item.Clone());
                }
            }
            //
            return list;
        }

        public List<string> AsStringList()
        {
            List<string> list = new List<string>();
            //
            foreach (ConjugatedItem item in Items)
            {
                list.Add(item.Conjugated.Word.Trim());
            }
            //
            return list;
        }

        public List<string> AsStringList(params Enum[] filters)
        {
            List<string> list = new List<string>();
            //
            foreach (ConjugatedItem item in Items)
            {
                if (item.Matches(filters))
                {
                    list.Add(item.Conjugated.Word.Trim());
                }
            }
            //
            return list;
        }

        public ConjugationTable SetTense(EnumVerbTenses tense)
        {
            Tense = tense;
            return this;
        }

        public ConjugationTable SetVoice(EnumVerbVoices voice)
        {
            Voice = voice;
            return this;
        }

        public ConjugationTable SetMode(EnumVerbModes mode)
        {
            Mode = mode;
            return this;
        }

        public ConjugationTable SetDefiniteness(EnumVerbDefinitenesses definiteness)
        {
            Definiteness = definiteness;
            return this;
        }

    }
}
