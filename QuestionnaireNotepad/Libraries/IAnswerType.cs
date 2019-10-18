using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    /// <summary>
    /// Interface for types of answers supported
    /// </summary>
    interface IAnswerType<T>
    {
        /// <summary>
        /// Returns a plain-text friendly value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        string GetFlatText();

        /// <summary>
        /// Returns a string with the text of only one item at the selected index.
        /// </summary>
        /// <param name="index">Index of the answer to retrieve.</param>
        /// <returns>A string that represents the content of one item in the object</returns>
        /// <exception cref="ArgumentException"></exception>
        T GetItem(int index);

        /// <summary>
        /// Gets the number of answers this object contains
        /// </summary>
        /// <returns>Integer that represents an index</returns>
        int GetTotalChoices();

        /// <summary>
        /// Returns the type of this answer.
        /// </summary>
        /// <returns>Returns an value defined by the enumeration AnswerTypes</returns>
        AnswerTypes GetType();
    }
}
