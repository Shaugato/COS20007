using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Path: GameObject
    {
       // private bool _Blocked;
       private  Location _destination , _source ;

        public Path(string[] idents , string name, string description, Location source, Location destination) : base(idents, name, description)
        {
            _source = source;
            _destination = destination;
           // _Blocked = false; 

            foreach(string s in name.Split(""))
            {
                AddIdentifier(s);
            }
        }


        public override string ShortDescription
        {
            get { return Name; }
        }
        public Location Source
            { get { return _source; } }

        public Location Destination
        {
            get { return _destination; }
        }


      /*  public bool Blocked
        {
            get { return _Blocked; }
            set { _Blocked = value; }
        }
      */
        


    }
}
