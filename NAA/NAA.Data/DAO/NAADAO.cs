using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAA.Data.DAO
{
    public abstract class NAADAO
    {
        public NAAEntities _context;

        public NAADAO()
        {
            _context = new NAAEntities();
        }
    }
}
