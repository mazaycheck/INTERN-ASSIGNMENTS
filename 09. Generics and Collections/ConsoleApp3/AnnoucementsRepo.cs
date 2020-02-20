using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp3
{
    class AnnoucementsRepo : GenericRepository<Annoucement, int>
    {
        public IEnumerable<Annoucement> GetByUserName(string username)
        {
            return base.GetAll().Where(m => m.User.Name == username);
        }
    }
}
