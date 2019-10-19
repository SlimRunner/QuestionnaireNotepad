using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireNotepad.Libraries
{
    class QuestionItem
    {
        public QuestionItem(string question, IAnswerType answer)
        {
            Question = question ?? throw new ArgumentNullException(nameof(question));
            Answer = answer ?? throw new ArgumentNullException(nameof(answer));
        }

        public string Question
        {
            get
            {
                return Question;
            }

            set
            {
                Question = value;
            }
        }

        public IAnswerType Answer
        {
            get
            {
                return Answer;
            }

            set
            {
                Answer = value;
            }
        }

        public string GetFieldText()
        {
            return Answer.GetType().ToString() + "$;" + Question + "$;" + Answer.GetFlatText();
        }
    }
}
