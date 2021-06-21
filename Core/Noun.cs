
using Collei.Lavi.Morph.Enumerated;
using Collei.Lavi.Morph.Inflect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Core
{
    public class Noun : Term
    {
        /// <summary>
        /// Creates a new instance of <see cref="Noun"/> with the given string <paramref name="term"/>.
        /// </summary>
        /// <param name="term">textual representation of the term.</param>
        public Noun(string term) : base(term, EnumPartsOfSpeech.Noun)
        {
            if (String.IsNullOrEmpty(term))
            {
                throw new ArgumentException("Não é possível criar uma instância de Noun com null ou uma string vazia!", nameof(term));
            }
        }

        /// <summary>
        /// Generates a new <see cref="Noun"/> which is the declensed version of the current.
        /// </summary>
        /// <param name="nounCase">The case the <see cref="Noun"/> should be declensed to.</param>
        /// <returns>The declensed version of the <see cref="Noun"/>.</returns>
        public Noun MakeDeclension(EnumNounCases nounCase)
        {
            return this.MakeDeclension(nounCase, EnumNounPluralities.Singular);
        }

        /// <summary>
        /// Generates a new <see cref="Noun"/> which is the declensed version of the current.
        /// </summary>
        /// <param name="nounCase">The case the <see cref="Noun"/> should be declensed to.</param>
        /// <param name="plurality">The desired plurality (<see cref="Singular"/>, <see cref="Dual"/> or <see cref="Plural"/>) of the new <see cref="Noun"/>.</param>
        /// <returns></returns>
        public Noun MakeDeclension(EnumNounCases nounCase, EnumNounPluralities plurality)
        {
            string declensed = DeclensorHelper.MakeDeclension(this, nounCase, plurality);
            return new Noun(declensed);
        }

        /// <summary>
        /// Generates a possessive declensed version of the current <see cref="Noun"/>.
        /// </summary>
        /// <param name="person">The discourse person the noun should be declensed to.</param>
        /// <returns>The possessive version of the current <see cref="Noun"/></returns>
        public Noun MakePossessive(EnumNounPersons person)
        {
            return this.MakePossessive(person, EnumNounPluralities.Singular);
        }

        /// <summary>
        /// Generates a possessive declensed version of the current <see cref="Noun"/>.
        /// </summary>
        /// <param name="person">The discourse person the noun should be declensed to.</param>
        /// <param name="plurality">The desired plurality (<see cref="Singular"/>, <see cref="Dual"/> or <see cref="Plural"/>) of the possessive version of the <see cref="Noun"/>.</param>
        /// <returns></returns>
        private Noun MakePossessive(EnumNounPersons person, EnumNounPluralities plurality)
        {
            String declensed = DeclensorHelper.MakePossessive(this, person, plurality);
            return new Noun(declensed);
        }
    }
}
