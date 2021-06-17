using CSLaviMorph.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLaviMorph.Core
{

    class Term
    {
        public string Word { get; private set; }
        public EnumPartsOfSpeech PartOfSpeech { get; }
        public EnumHarmony Harmony { get; }
        public bool Vocalic { get; private set; }

        public Term(string term) : this(term, null)
        {
        }

        public Term(string term, EnumPartsOfSpeech partOfSpeech)
        {
            this.Word = term;
            this.PartOfSpeech = partOfSpeech;
            this.Harmony = this.CalculateHarmony(term);
            this.DefineVocalicy();
        }


        private EnumHarmony CalculateHarmony(string term)
        {
            return null;
        }

        private void DefineVocalicy()
        {
            this.Vocalic = (this.Word.EndsWith('a') || this.Word.EndsWith('e') || this.Word.EndsWith('o') ||
                this.Word.EndsWith('ö') || this.Word.EndsWith('u') || this.Word.EndsWith('ü') || this.Word.EndsWith('i'));
        }

        public bool EndsWith(string suffix)
        {
            return Word.EndsWith(suffix);
        }

        public void AppendSuffix(string suffix)
        {
            this.Word += suffix;
            this.DefineVocalicy();
        }

        public bool Equals(Term term)
        {
            return this.Word.Equals(term.Word, StringComparison.Ordinal);
        }


    }
}
