using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration_4_3
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);
        
        string Name
        {
            get;
        }
    }
}
