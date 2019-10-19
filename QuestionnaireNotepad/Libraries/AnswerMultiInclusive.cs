using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    using kValPair = KeyValuePair<string, TriStateQuestion>;

    /// <summary>
    /// Defines a multiple choice answer with all-inclusive answers.
    /// </summary>
    class AnswerMultiInclusive : IAnswerType
    {
        /// <summary>
        /// Contains the pair of text and check state of each answer item.
        /// </summary>
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

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnswerMultiInclusive()
        {
            Choices = new List<kValPair>();
        }

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="choices">New set of values to be assigned to Choices</param>
        public AnswerMultiInclusive(List<kValPair> choices)
        {
            Choices = choices ?? throw new ArgumentNullException(nameof(choices));
        }

        /// <summary>
        /// Returns a formatted plain-text value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        public string GetFlatText()
        {
            StringBuilder retval = new StringBuilder("");

            foreach (var item in Choices)
            {
                retval.Append(item.Key + "$:" + item.Value + "$,");
            }

            return retval.ToString();
        }

        /// <summary>
        /// Returns a string with the text of only one item at the selected index.
        /// </summary>
        /// <param name="index">Index of the answer to retrieve.</param>
        /// <returns>A string that represents the content of one item in the object</returns>
        /// <exception cref="ArgumentException"></exception>
        public string GetItem(int index)
        {
            if (index < GetTotalChoices() && index >= 0)
            {
                return Choices[index].Key + "$:" + Choices[index].Value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void GetItem(int index, out kValPair value)
        {
            if (index < GetTotalChoices() && index >= 0)
            {
                value = Choices[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets the number of answers this object contains
        /// </summary>
        /// <returns>Integer that represents an index</returns>
        public int GetTotalChoices()
        {
            return Choices.Count;
        }

        /// <summary>
        /// Returns the type of this answer.
        /// </summary>
        /// <returns>Returns an value defined by the enumeration AnswerTypes</returns>
        AnswerTypes IAnswerType.GetType()
        {
            return AnswerTypes.MULTI_IN;
        }
    }
}
