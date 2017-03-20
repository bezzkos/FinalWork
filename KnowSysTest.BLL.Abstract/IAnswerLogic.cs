namespace KnowSysTest.BLL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface IAnswerLogic
    {
        AnswerDTO GetAnswer(Guid id);

        IEnumerable<AnswerDTO> GetAllAnswers();

        IEnumerable<AnswerDTO> GetAllAnswersByFk(Guid fk);

        IEnumerable<AnswerDTO> GetAllCorrectAnswersByFk(Guid fk);

        bool CheckRequiredAnswersCount(Guid fk);

        double GetAllCorrectAnswersCountByFk(Guid fk);

        bool CheckAnswerOnMultiple(Guid fk);

        bool UpdateAnswer(AnswerDTO answer);

        bool DeleteAnswer(Guid id);

        bool CreateAnswer(AnswerDTO answer);

        bool SaveAnswer();
    }
}
