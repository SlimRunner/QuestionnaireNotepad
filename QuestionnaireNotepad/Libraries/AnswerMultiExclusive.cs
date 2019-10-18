using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    class AnswerMultiExclusive : IAnswerType<string>
    {
        //TODO: Implement position independent values

        /// <summary>
        /// Value of unselected answer.
        /// </summary>
        private const int EMPTY_PICK = -1;

        /// <summary>
        /// Contains the text of each answer item.
        /// </summary>
        public List<string> Choices
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
        /// Selected item from Choices.
        /// </summary>
        public int Pick
        {
            get
            {
                return Pick;
            }

            set
            {
                if (value < Choices.Count && value >= EMPTY_PICK)
                {
                    Pick = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnswerMultiExclusive()
        {
            Choices = new List<string>();
            Pick = EMPTY_PICK;
        }

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="choices">New set of values to be assigned to Choices and a single Pick value.</param>
        public AnswerMultiExclusive(List<string> choices, int pick)
        {
            Choices = choices ?? throw new ArgumentNullException(nameof(choices));
            Pick = pick;
        }

        /// <summary>
        /// Returns a formatted plain-text value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        public string GetFlatText()
        {
            string retval = "";

            foreach (var item in Choices)
            {
                retval += item + "$,";
            }
            retval += "$:" + Pick;

            return retval;
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
        AnswerTypes IAnswerType<string>.GetType()
        {
            return AnswerTypes.MULTI_EX;
        }
    }
}
