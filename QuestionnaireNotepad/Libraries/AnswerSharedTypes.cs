using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    /// <summary>
    /// Defines the types of answers supported.
    /// </summary>
    public enum AnswerTypes
    {
        /// <summary>
        /// Questions that are typed.
        /// </summary>
        BLANK = 0,
        /// <summary>
        /// True/False Questions
        /// </summary>
        BOOLEAN = 1,
        /// <summary>
        /// Multiple choice questions with only one correct answer
        /// </summary>
        MULTI_EX = 2,
        /// <summary>
        /// Multiple choice questions with multiple possible answers
        /// </summary>
        MULTI_IN = 3
    }

    public enum TriStateQuestion
    {
        EMPTY = -1,
        FALSE = 0,
        TRUE = 1
    }
}
