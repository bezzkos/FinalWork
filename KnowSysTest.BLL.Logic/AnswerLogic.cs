namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities;

    public class AnswerLogic : IAnswerLogic
    {
        private IAnswerDAL dal;
        private readonly int reqAnswersCount;

        public AnswerLogic(IAnswerDAL dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("dal", "DAL as parameter is null");
            }

            this.dal = dal;
            this.reqAnswersCount = int.Parse(ConfigurationManager.AppSettings["RequiredAnswersCount"]);
        }

        public AnswerDTO GetAnswer(Guid id)
        {
            return this.dal.Get(id);
        }

        public IEnumerable<AnswerDTO> GetAllAnswers()
        {
            return this.dal.GetAll();
        }

        public IEnumerable<AnswerDTO> GetAllAnswersByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk);
        }

        public IEnumerable<AnswerDTO> GetAllCorrectAnswersByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Where(answer => answer.IsCorrect).ToList();
        }

        public bool CheckRequiredAnswersCount(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Count() >= this.reqAnswersCount && this.dal.GetAllByFk(fk).Count(answer => answer.IsCorrect) >= 1;
        }

        public double GetAllCorrectAnswersCountByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Count(answer => answer.IsCorrect);
        }

        public bool CheckAnswerOnMultiple(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Count(answer => answer.IsCorrect) > 1;
        }

        public bool UpdateAnswer(AnswerDTO answer)
        {
            return this.dal.Update(answer);
        }

        public bool DeleteAnswer(Guid id)
        {
            return this.dal.Delete(id);
        }

        public bool CreateAnswer(AnswerDTO answer)
        {
            return this.dal.Create(answer);
        }

        public bool SaveAnswer()
        {
            return this.dal.Save();
        }
    }
}
