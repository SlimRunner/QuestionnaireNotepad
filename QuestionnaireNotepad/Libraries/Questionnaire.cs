using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuestionnaireNotepad.Libraries
{
    class Questionnaire
    {
        public Questionnaire(string sourceName, Dictionary<string, List<IAnswerType>> chapterItems)
        {
            SourceName = sourceName ?? throw new ArgumentNullException(nameof(sourceName));
            ChapterItems = chapterItems ?? throw new ArgumentNullException(nameof(chapterItems));
        }

        public string SourceName { get; set; }
        public Dictionary<string, List<IAnswerType>> ChapterItems
        {
            get
            {
                return ChapterItems;
            }

            set
            {
                ChapterItems = value;
                ChapterItems[""][5].GetItem(5);
            }
        }

        public bool Load(string path)
        {
            StreamReader inFile = null;

            try
            {
                if (File.Exists(path))
                {
                    inFile = File.OpenText(path);

                    //parse line by line to retrieve data

                    inFile.Close();
                    return true;
                }
                else
                {
                    //TODO:
                    return false;
                }
            }
            catch (Exception)
            {
                //TODO: error handling
                throw;
            }
        }
    }
}
