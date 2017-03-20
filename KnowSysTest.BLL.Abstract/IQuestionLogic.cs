namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface IQuestionLogic
    {
        QuestionDTO GetQuestion(Guid id);

        IEnumerable<QuestionDTO> GetAllQuestions();

        IEnumerable<QuestionDTO> GetAllQuestionsByFk(Guid fk);

        IEnumerable<QuestionDTO> GetAllActiveQuestionsByFk(Guid fk);

        IEnumerable<QuestionDTO> GetAllRequiredQuestionsByFk(Guid fk);

        bool CheckRequiredActiveQuestionsCount(Guid fk);

        bool UpdateQuestion(QuestionDTO question);

        bool DeleteQuestion(Guid id);

        bool CreateQuestion(QuestionDTO question);

        bool SaveQuestion();
    }
}
