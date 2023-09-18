using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuola.DAL
{
    public interface IDal<Z>
    {
        public List<Z> findAll();
        public Z? findById(int id);
        public bool insert(Z z);
        public bool update(Z z);
        public bool delete(int id);
    }
}
