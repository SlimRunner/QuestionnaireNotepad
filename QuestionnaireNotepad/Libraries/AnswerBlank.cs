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
    class AnswerBlank : IAnswerType
    {
        /// <summary>
        /// Contains the body of text of the answer.
        /// </summary>
        public string BodyText { get; set; }

        /// <summary>
        /// Returns a plain-text friendly value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        public string GetFlatText() => BodyText;

        /// <summary>
        /// Returns a string with the text of only one item at the selected index.
        /// </summary>
        /// <param name="index">Index of the answer to retrieve.</param>
        /// <returns>A string that represents the content of one item in the object</returns>
        public string GetItem(int index)
        {
            if (index <= GetTotalChoices())
            {
                return BodyText;
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
        public int GetTotalChoices() => 1;

        /// <summary>
        /// Returns the type of this answer.
        /// </summary>
        /// <returns>Returns an value defined by the enumeration AnswerTypes</returns>
        AnswerTypes IAnswerType.GetType() => AnswerTypes.BLANK;
    }
}
