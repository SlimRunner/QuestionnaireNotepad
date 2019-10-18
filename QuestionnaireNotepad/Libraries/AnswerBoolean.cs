using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    /// <summary>
    /// Defines a true/false field for answers.
    /// </summary>
    class AnswerBoolean : IAnswerType<string>
    {
        /// <summary>
        /// Contains the boolean assertion of the question.
        /// </summary>
        public TriStateQuestion Value { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnswerBoolean()
        {
            Value = TriStateQuestion.EMPTY;
        }

        /// <summary>
        /// Full constructor.
        /// </summary>
        /// <param name="newValue">Value to be assigned for this item</param>
        /// <exception cref="ArgumentException"></exception>
        public AnswerBoolean(TriStateQuestion newValue)
        {
            switch (newValue)
            {
                case TriStateQuestion.EMPTY:
                case TriStateQuestion.FALSE:
                case TriStateQuestion.TRUE:
                    Value = newValue;
                    break;
                default:
                    throw new ArgumentException("Object cannot initialize with the value provided.", "newValue");
            }
        }

        /// <summary>
        /// Returns a plain-text friendly value for this object.
        /// </summary>
        /// <returns>A string that represents the content of the object</returns>
        /// <exception cref="Exception"></exception>
        public string GetFlatText()
        {
            switch (Value)
            {
                case TriStateQuestion.EMPTY:
                    return "";
                case TriStateQuestion.FALSE:
                    return "False";
                case TriStateQuestion.TRUE:
                    return "True";
                default:
                    throw new Exception("Invalid internal state. Object has corrupt data.");
            }
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
            return AnswerTypes.BOOLEAN;
        }
    }
}
