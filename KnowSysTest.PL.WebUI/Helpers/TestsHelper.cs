using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowSysTest.PL.WebUI.Helpers
{
    using System.Configuration;

    using KnowSysTest.Entities;
    using KnowSysTest.Entities.Helpers;

    public static class TestsHelper
    {
        private static readonly float passingGrade = float.Parse(ConfigurationManager.AppSettings["TestPassingGrade"]);
        private static readonly float multipleQuestionWeight = float.Parse(ConfigurationManager.AppSettings["MultipleQuestionWeight"]);

        public static bool ManageQuestionActivityState(QuestionDTO question)
        {
            if (!Providers.AnswerBll.CheckRequiredAnswersCount(question.Id) || (Providers.AnswerBll.CheckAnswerOnMultiple(question.Id) && !question.IsMultiple
                 || !Providers.AnswerBll.CheckAnswerOnMultiple(question.Id) && question.IsMultiple) && question.IsActive)
            {
                question.IsActive = false;
                return true;
            }
            if (Providers.AnswerBll.CheckRequiredAnswersCount(question.Id) && (!Providers.AnswerBll.CheckAnswerOnMultiple(question.Id) && !question.IsMultiple
                 || Providers.AnswerBll.CheckAnswerOnMultiple(question.Id) && question.IsMultiple) && !question.IsActive)
            {
                question.IsActive = true;
                return true;
            }

            return false;
        }

        public static bool CheckOnRequiredQuesyionsPass(IList<AnswerDTO> answers, IReadOnlyList<QuestionDTO> reqQuestions)
        {
            AnswerComparer answersComparer = new AnswerComparer();
            return
            reqQuestions.Any(
                reqQuestion => !Providers.AnswerBll.GetAllCorrectAnswersByFk(reqQuestion.Id).Except(answers, answersComparer).Any());
        }

        public static bool CheckTestOnPass(float mark, float highMark)
        {
            return (mark / highMark) >= passingGrade;
        }

        public static float CalculateMark(IReadOnlyList<AnswerDTO> answers, IReadOnlyList<QuestionDTO> questions)
        {
            float mark = 0;
            foreach (var question in questions)
            {
                if (question.IsMultiple)
                {
                    mark += CalculateMultipleQuestionsMark(answers, question);
                }
                else
                {
                    mark += CalculateNonMultipleQuestionsMark(answers, question);
                }
            }

            return mark;
        }

        public static float CalculateHighMark(Guid testId)
        {
            float mark = 0;
            var questions = Providers.QuestionBll.GetAllQuestionsByFk(testId);
            foreach (var question in questions)
            {
                if (question.IsMultiple)
                {
                    mark += multipleQuestionWeight;
                }
                else
                {
                    mark += 1;
                }
            }
            return mark;
        }

        private static float CalculateNonMultipleQuestionsMark(IReadOnlyList<AnswerDTO> answers, QuestionDTO question)
        {
            AnswerComparer answersComparer = new AnswerComparer();

            return Providers.AnswerBll.GetAllCorrectAnswersByFk(question.Id).Except(answers, answersComparer).Any()
                       ? 0
                       : 1;
        }

        private static float CalculateMultipleQuestionsMark(IReadOnlyList<AnswerDTO> answers, QuestionDTO question)
        {
            AnswerComparer answersComparer = new AnswerComparer();
            float mark = 0;
                var answersCount = Providers.AnswerBll.GetAllAnswersByFk(question.Id).Count();
                var correctAnswersCount = Providers.AnswerBll.GetAllCorrectAnswersByFk(question.Id).Count();
                var checkedCorrectAnswersCount =
                    correctAnswersCount - Providers.AnswerBll.GetAllCorrectAnswersByFk(question.Id).Except(answers, answersComparer).Count();
                var checkedIncorrectAnswersCount = answers.Count(answer => answer.QuestionFk == question.Id) - checkedCorrectAnswersCount;

                if (answersCount == 0 || correctAnswersCount == 0)
                {
                    throw new ArgumentException();
                }

                if (correctAnswersCount == checkedCorrectAnswersCount && checkedIncorrectAnswersCount == 0)
                {
                    mark += 1;
                }
                else if (checkedCorrectAnswersCount == 0)
                {
                    mark += 0;
                }
                else
                {
                    var unCheckedCorrectPart = (correctAnswersCount - checkedCorrectAnswersCount) / (float)answersCount;
                    if (checkedIncorrectAnswersCount != 0)
                    {
                        var inCorrectPart = checkedIncorrectAnswersCount / (float)answersCount;
                        if (correctAnswersCount == checkedCorrectAnswersCount)
                        {
                            mark += 1 - inCorrectPart;
                        }
                        else
                        {
                            mark += 1 - inCorrectPart - unCheckedCorrectPart;
                        }
                    }
                    else
                    {
                        mark += 1 - unCheckedCorrectPart;
                    }
                }

            return mark * multipleQuestionWeight;
        }
    }
}