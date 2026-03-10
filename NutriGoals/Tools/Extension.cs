using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace NutriGoals
{
    public partial class NutriGoalsDataContext
    {
        public NutriGoalsDataContext() :
        base(ConfigurationManager.ConnectionStrings["NutriGoalsConnectionString"].ConnectionString, mappingSource)
        {
            OnCreated();
        }
    }
}