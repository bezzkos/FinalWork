namespace KnowSysTest.DAL.Abstract
{
    using System;
    using System.Collections.Generic;

    using KnowSysTest.Entities;

    public interface IAnswerDAL
    {
        AnswerDTO Get(Guid id);

        IEnumerable<AnswerDTO> GetAll();

        IEnumerable<AnswerDTO> GetAllByFk(Guid fk);

        bool Update(AnswerDTO answer);

        bool Delete(Guid id);

        bool Create(AnswerDTO answer);

        bool Save();
    }
}
