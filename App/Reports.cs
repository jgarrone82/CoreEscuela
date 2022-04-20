using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entities;

namespace CoreEscuela.App
{
    public class Reports
    {

        Dictionary<keyDictionary, IEnumerable<BaseSchoolObj>> _dictionary;

        public Reports(Dictionary<keyDictionary, IEnumerable<BaseSchoolObj>> dicSchoolObj)
        {
            if (dicSchoolObj == null)
            {
                throw new ArgumentNullException(nameof(dicSchoolObj));
            }                

            _dictionary = dicSchoolObj; 
        }

    }
}