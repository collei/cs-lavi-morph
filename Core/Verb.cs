using Collei.Lavi.Morph.Enumerated;
using Collei.Lavi.Morph.Inflect;
using System;

namespace Collei.Lavi.Morph.Core
{
    public class Verb
    {
        private Term _word;
        private Term _stem;

        /// <summary>
        /// The textual representation of the <see cref="Verb"/> itself.
        /// </summary>
        public string Word
        {
            get
            {
                return _word.Word;
            }
        }

        /// <summary>
        /// The textual representation of the <see cref="Verb"/>'s stem.
        /// </summary>
        public string Stem
        {
            get
            {
                return _stem.Word;
            }
        }

        /// <summary>
        /// The harmony type the <see cref="Verb"/> stem belongs to.
        /// </summary>
        public EnumHarmony Harmony
        {
            get
            {
                return this._stem.Harmony;
            }
        }

        /// <summary>
        /// Indicates whether the <see cref="Stem"/> ends with a vowel or not.
        /// </summary>
        public bool Vocalic
        {
            get
            {
                return this._stem.Vocalic;
            }
        }

        public Verb(Term term)
        {
            int stemLength = term.Word.Length - 2;
            this._word = new Term(term.Word);
            this._stem = new Term(term.Word.Substring(0, stemLength));
        }

        public Verb(string term) : this(new Term(term))
        {
            if (String.IsNullOrEmpty(term))
            {
                throw new ArgumentException("Não é possível criar uma instância de Verb com null ou uma string vazia!", nameof(term));
            }
        }

        public Term Conjugate(EnumVerbModes mode, EnumVerbPersons person, EnumVerbTenses tense, EnumVerbVoices voice, EnumVerbDefinitenesses definiteness)
        {
            string conjugated;
            //
            if (mode == EnumVerbModes.Desiderative)
            {
                conjugated = ConjugatorHelper.MakeDesiderative(this, person, tense, voice, definiteness);
            }
            else if (mode == EnumVerbModes.Imperative)
            {
                conjugated = ConjugatorHelper.MakeImperative(this, person, definiteness);
            }
            else
            {
                conjugated = ConjugatorHelper.MakeFactual(this, person, tense, voice, definiteness);
            }
            //
            return new Term(conjugated, EnumPartsOfSpeech.Verb);
        }

        internal Verb Clone()
        {
            return new Verb(this.Word);
        }

        /// <summary>
        /// Checks for equality of the textual representation of this instance with another <see cref="Verb"/> instance. Comparison is case insensitive.
        /// </summary>
        /// <param name="verb">Another <see cref="Verb"/> instance to be checked against.</param>
        /// <returns>True if <paramref name="verb"/> is instance of <see cref="Verb"/> and have the same text, false otherwise.</returns>
        public override bool Equals(object verb)
        {
            Verb another = verb as Verb;
            //
            if (another == null)
            {
                return false;
            }
            //
            return (Word.ToLower() == another.Word.ToLower()) && (Stem.ToLower() == another.Stem.ToLower());
        }


    }
}
