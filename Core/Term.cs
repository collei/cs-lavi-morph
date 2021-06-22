using Collei.Lavi.Morph.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Core
{
    /// <summary>
    /// Represents any word in the Lavi language.
    /// </summary>
    public class Term
    {
        /// <summary>
        /// The internal representation of the <see cref="Term"/> as a string.
        /// </summary>
        public string Word { get; private set; }

        /// <summary>
        /// The part of speech the <see cref="Term"/> instance is or belongs to.
        /// </summary>
        public EnumPartsOfSpeech PartOfSpeech { get; }

        /// <summary>
        /// The harmony type the <see cref="Term"/> instance is.
        /// </summary>
        public EnumHarmony Harmony { get; }

        /// <summary>
        /// It returns true if the term ends with a vowel (a,e,i,o,ö,u,ü), false otherwise.
        /// </summary>
        public bool Vocalic { get; private set; }

        /// <summary>
        /// Clones the content of this instance in a brand new instance of <see cref="Term"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="Term"/> with the same content.</returns>
        internal Term Clone()
        {
            return new Term(this.Word, this.PartOfSpeech);
        }

        /// <summary>
        /// Instantiates a new <see cref="Term"/> with the given <paramref name="term"/>.
        /// </summary>
        /// <param name="term">The term of the instance.</param>
        public Term(string term) : this(term, EnumPartsOfSpeech.Undefined)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="Term"/> with the given <paramref name="term"/> and <paramref name="partOfSpeech"/>.
        /// </summary>
        /// <param name="term">The term of the instance.</param>
        /// <param name="partOfSpeech">The part of speech the term is or belongs to.</param>
        public Term(string term, EnumPartsOfSpeech partOfSpeech)
        {
            if (String.IsNullOrEmpty(term))
            {
                throw new ArgumentException("Não é possível criar um Term com null ou uma string vazia!", nameof(term));
            }

            this.Word = term;
            this.PartOfSpeech = partOfSpeech;
            this.Harmony = this.CalculateHarmony(term);
            this.DefineVocalicy();
        }

        /// <summary>
        /// Returns whether the harmony type of the <paramref name="term"/> is BACK or FRONT. It may return UNDEFINED if no back or front vowels are found.
        /// </summary>
        /// <param name="term">The term to be verified.</param>
        /// <returns>the harmony type of the term.</returns>
        private EnumHarmony CalculateHarmony(string term)
        {
            char[] letters = term.ToCharArray();
            int last = letters.Length - 1;
            //
            for (int i = last; i >= 0; i--)
            {
                switch (letters[i])
                {
                    case 'a':
                    case 'o':
                    case 'u':
                        return EnumHarmony.Back;
                    case 'e':
                    case 'ö':
                    case 'ü':
                        return EnumHarmony.Front;
                }
            }
            //
            return EnumHarmony.Undefined;
        }

        private void DefineVocalicy()
        {
            this.Vocalic = this.EndsWith("a", "e", "o", "ö", "u", "ü", "i");
        }

        /// <summary>
        /// Returns true if this instance of <see cref="Term"/> ends with the given <paramref name="suffix"/>, false otherwise.
        /// </summary>
        /// <param name="suffix">The string to be checked against the <see cref="Term"/> instance.</param>
        /// <returns>true if the <see cref="Term"/> ends with <paramref name="suffix"/>, false otherwise.</returns>
        public bool EndsWith(string suffix)
        {
            return Word.EndsWith(suffix);
        }

        /// <summary>
        /// Returns true if this instance of <see cref="Term"/> ends with one of the given <paramref name="suffixes"/>, false otherwise.
        /// </summary>
        /// <param name="suffixes">A comma-separated list of suffixes as strings.</param>
        /// <returns>true if the <see cref="Term"/> ends with one of the given <paramref name="suffixes"/>, false otherwise.</returns>
        public bool EndsWith(params string[] suffixes)
        {
            for (int i=0; i<suffixes.Length; i++)
            {
                if (this.Word.EndsWith(suffixes[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Appends the given <paramref name="suffix"/> to this current instance of <see cref="Term"/>.
        /// It also changes the <see cref="Vocalic"/> property accordingly. 
        /// </summary>
        /// <param name="suffix">the suffix to be attached to this <see cref="Term"/> instance.</param>
        public void AppendSuffix(string suffix)
        {
            this.Word += suffix;
            this.DefineVocalicy();
        }

        /// <summary>
        /// Checks for equality of this <see cref="Term"/> with the given <paramref name="term"/>. Comparison is case insensitive.
        /// </summary>
        /// <param name="term">Another instance of <see cref="Term"/> to be checked against to.</param>
        /// <returns>True if <paramref name="term"/> is an instance of <see cref="Term"/> and have the same text, false otherwise.</returns>
        public override bool Equals(object term)
        {
            Term another = term as Term;
            //
            if (another == null)
            {
                return false;
            }
            //
            return Word.ToLower() == another.Word.ToLower();
        }

        /// <summary>
        /// Returns its internal representation, i.e., the text contained inside.
        /// </summary>
        /// <returns>the same text accessed through the <see cref="Word"/> property.</returns>
        public override string ToString()
        {
            return Word;
        }

    }
}
