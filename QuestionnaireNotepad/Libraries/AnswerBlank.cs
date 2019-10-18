using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    /// <summary>
    /// Defines a blank field for student-typed answers.
    /// </summary>
    class AnswerBlank : IAnswerType<string>
    {
        /// <summary>
        /// Contains the body of text of the answer.
        /// </summary>
        public string BodyText { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnswerBlank()
        {
            BodyText = "";
        }

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="newValue">Value to be assigned for this item</param>
        /// <exception cref="ArgumentException"></exception>
        public AnswerBlank(string newValue)
        {
            BodyText = newValue;
        }

        /// <summary>
        /// Returns a plain-text friendly value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        public string GetFlatText()
        {
            return BodyText;
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
                return GetFlatText();
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
            return 1;
        }

        /// <summary>
        /// Returns the type of this answer.
        /// </summary>
        /// <returns>Returns an value defined by the enumeration AnswerTypes</returns>
        AnswerTypes IAnswerType<string>.GetType()
        {
            return AnswerTypes.BLANK;
        }
    }
}
