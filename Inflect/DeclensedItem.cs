using Collei.Lavi.Morph.Core;
using Collei.Lavi.Morph.Enumerated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collei.Lavi.Morph.Inflect
{
    class DeclensedItem
    {
        public Noun Original { get; }
        public Noun Declensed { get; }
        public EnumNounCases NounCase { get; }
        public EnumNounPersons Person { get; }
        public EnumNounPluralities Plurality { get; }

        public DeclensedItem(Noun noun, EnumNounPersons person, EnumNounCases nounCase, EnumNounPluralities plurality)
        {
            Original = noun;
            Person = person;
            NounCase = nounCase;
            Plurality = plurality;
            Declensed = Original.MakeDeclension(nounCase, plurality);
        }

        private DeclensedItem(Noun noun, Noun declensed, EnumNounPersons person, EnumNounCases nounCase, EnumNounPluralities plurality)
        {
            Original = noun;
            Declensed = declensed;
            Person = person;
            NounCase = nounCase;
            Plurality = plurality;
        }

        public bool Matches(params Enum[] filters)
        {
            bool matched = true;
            //
            for (int i = 0; i < filters.Length; i++)
            {
                matched = matched && (filters[i] == (Enum)Person || filters[i] == (Enum)NounCase || filters[i] == (Enum)Plurality);
            }
            //
            return matched;
        }

        public DeclensedItem Clone()
        {
            return new DeclensedItem(Original, Declensed, Person, NounCase, Plurality);
        }
    }
}
