using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public interface IHaveInventory
    {
        GameObject Locate(String iD);
        GameObject Take_Command(String iD);


        public string Name
        {
            get;
        }
    }
}
