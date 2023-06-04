using System;
using System.Collections.Generic;
using System.Text;

namespace Iteration_4_3
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids)
        {
        }

        public abstract string Execute(Player p, string[] text);
    }
}
