using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class agentstvoEntities : DbContext
    {
        private static agentstvoEntities context;

        public static agentstvoEntities GetContext() 
        {
            if (context == null) context = new agentstvoEntities();
            return context;
        }
    }
}
