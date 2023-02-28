using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach(string ids in idents)
            {
                _identifiers.Add(ids.ToLower());
            }
        }
        public bool AreYou(string id)
        {
            if(_identifiers.Contains(id.ToLower()))
            { return true; }
            else
            {
                return false;
            }
        }

        public string FirstId
        {
            //return _identifiers.First();
            get
            {
                string identifier = "";
                if(_identifiers.Count != 0)
                {
                    identifier = _identifiers[0];
                }
                return identifier;
            }
            
        }
        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
