using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowSysTest.Entities.Helpers
{
    public class AnswerComparer : IEqualityComparer<AnswerDTO>
    {
        public bool Equals(AnswerDTO x, AnswerDTO y)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether the products' properties are equal. 
            return x != null && y != null && x.Id.Equals(y.Id) && x.Answer.Equals(y.Answer);
        }

        public int GetHashCode(AnswerDTO obj)
        {
            //Get hash code for the Name field if it is not null. 
            int hashProductName = obj.Answer == null ? 0 : obj.Answer.GetHashCode();

            //Get hash code for the Code field. 
            int hashProductCode = obj.Id.GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }
    }
}
