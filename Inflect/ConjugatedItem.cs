using Collei.Lavi.Morph.Core;
using Collei.Lavi.Morph.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Inflect
{
    public class ConjugatedItem
    {
        public Verb Original { get; }
        public Term Conjugated { get; }
        public EnumVerbPersons Person { get; }
        public EnumVerbTenses Tense { get; }
        public EnumVerbVoices Voice { get; }
        public EnumVerbModes Mode { get; }
        public EnumVerbDefinitenesses Definiteness { get; }

        public ConjugatedItem(Verb verb, EnumVerbPersons person, EnumVerbTenses tense, EnumVerbVoices voice, EnumVerbModes mode, EnumVerbDefinitenesses definiteness)
        {
            Original = verb;
            Person = person;
            Tense = tense;
            Voice = voice;
            Mode = mode;
            Definiteness = definiteness;
            Conjugated = Original.Conjugate(mode, person, tense, voice, definiteness);
        }

        private ConjugatedItem(Verb verb, Term conjugated, EnumVerbPersons person, EnumVerbTenses tense, EnumVerbVoices voice, EnumVerbModes mode, EnumVerbDefinitenesses definiteness)
        {
            Original = verb.Clone();
            Conjugated = conjugated.Clone();
            Person = person;
            Tense = tense;
            Voice = voice;
            Mode = mode;
            Definiteness = definiteness;
        }

        public bool Matches(params Enum[] filters)
        {
            bool matched = true;
            //
            for (int i = 0; i < filters.Length; i++)
            {
                string filter = filters[i].ToString();
                matched = matched && (
                    (filter == Person.ToString()) ||
                    (filter == Tense.ToString()) ||
                    (filter == Voice.ToString()) ||
                    (filter == Mode.ToString()) ||
                    (filter == Definiteness.ToString())
                );
            }
            //
            return matched;
        }

        public ConjugatedItem Clone()
        {
            return new ConjugatedItem(Original, Conjugated, Person, Tense, Voice, Mode, Definiteness);
        }

    }
}
