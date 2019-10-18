using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    using kValPair = KeyValuePair<string, TriStateQuestion>;

    class AnswerMultiInclusive : IAnswerType<kValPair>
    {
        public List<kValPair> Choices
        {
            get
            {
                return Choices;
            }

            set
            {
                Choices = value;
            }
        }

        public AnswerMultiInclusive()
        {
            Choices = new List<kValPair>();
        }

        public AnswerMultiInclusive(List<kValPair> choices)
        {
            Choices = choices ?? throw new ArgumentNullException(nameof(choices));
        }

        public string GetFlatText()
        {
            string retval = "";

            foreach (var item in Choices)
            {
                retval += item + "\n";
            }

            return retval;
        }

        public kValPair GetItem(int index)
        {
            if (index < GetTotalChoices() && index >= 0)
            {
                return Choices[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetTotalChoices()
        {
            return Choices.Count;
        }

        AnswerTypes IAnswerType<kValPair>.GetType()
        {
            return AnswerTypes.MULTI_IN;
        }
    }
}
