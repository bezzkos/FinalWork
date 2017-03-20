namespace KnowSysTest.BLL.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using KnowSysTest.BLL.Abstract;
    using KnowSysTest.DAL.Abstract;
    using KnowSysTest.Entities;

    public class QuestionLogic : IQuestionLogic
    {
        private IQuestionDAL dal;
        private readonly int reqActQueCount;

        public QuestionLogic(IQuestionDAL dal)
        {
            if (dal == null)
            {
                throw new ArgumentNullException("dal", "DAL as parameter is null");
            }

            this.dal = dal;
            this.reqActQueCount = int.Parse(ConfigurationManager.AppSettings["RequiredActiveQuestionsCount"]);
        }

        public QuestionDTO GetQuestion(Guid id)
        {
            return this.dal.Get(id);
        }

        public IEnumerable<QuestionDTO> GetAllQuestions()
        {
            return this.dal.GetAll();
        }

        public IEnumerable<QuestionDTO> GetAllQuestionsByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk);
        }

        public IEnumerable<QuestionDTO> GetAllActiveQuestionsByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Where(question => question.IsActive).ToList();
        }

        public IEnumerable<QuestionDTO> GetAllRequiredQuestionsByFk(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Where(question => question.IsRequired).ToList();
        }

        public bool CheckRequiredActiveQuestionsCount(Guid fk)
        {
            return this.dal.GetAllByFk(fk).Count(question => question.IsActive) >= this.reqActQueCount;
        }

        public bool UpdateQuestion(QuestionDTO question)
        {
            return this.dal.Update(question);
        }

        public bool DeleteQuestion(Guid id)
        {
            return this.dal.Delete(id);
        }

        public bool CreateQuestion(QuestionDTO question)
        {
            return this.dal.Create(question);
        }

        public bool SaveQuestion()
        {
            return this.dal.Save();
        }
    }
}
