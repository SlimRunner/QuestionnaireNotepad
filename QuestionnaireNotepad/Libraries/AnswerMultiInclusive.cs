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
    class AnswerMultiInclusive : IAnswerType<kValPair>
    {
        /// <summary>
        /// Contains the pair of text and check state of the answer.
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
        /// Returns a plain-text friendly value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        public string GetFlatText()
        {
            string retval = "";

            foreach (var item in Choices)
            {
                retval += item + "\n";
            }

            return retval;
        }

        /// <summary>
        /// Returns a string with the text of only one item at the selected index.
        /// </summary>
        /// <param name="index">Index of the answer to retrieve.</param>
        /// <returns>A string that represents the content of one item in the object</returns>
        /// <exception cref="ArgumentException"></exception>
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
        AnswerTypes IAnswerType<kValPair>.GetType()
        {
            return AnswerTypes.MULTI_IN;
        }
    }
}
