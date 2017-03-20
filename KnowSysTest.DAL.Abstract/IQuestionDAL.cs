namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface IQuestionDAL
    {
        QuestionDTO Get(Guid id);

        IEnumerable<QuestionDTO> GetAll();

        IEnumerable<QuestionDTO> GetAllByFk(Guid fk);

        bool Update(QuestionDTO question);

        bool Delete(Guid id);

        bool Create(QuestionDTO question);

        bool Save();
    }
}
