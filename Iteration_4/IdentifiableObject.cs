using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_4_3
{
    public class IdentifiableObject
    {
        // A list of identifiers associated with the object
        private List<string> _identifiers = new List<string>();

        // Constructor that adds the given array of identifiers to the list
        public IdentifiableObject(string[] idents)
        {
            foreach (string id in idents)
            {
                // Add each identifier to the list, converting to lowercase to make comparisons case-insensitive
                _identifiers.Add(id.ToLower());
            }
        }

        // Checks whether the given identifier matches any of the identifiers in the list
        // Returns true if a match is found (case-insensitive comparison is used)
        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        // Returns the first identifier in the list (or an empty string if the list is empty)
        public string FirstId
        {
            get
            {
                string identifier = "";
                if (_identifiers.Count != 0)
                {
                    identifier = _identifiers[0];
                }
                return identifier;
            }
        }


        // Adds a new identifier to the list (case-insensitive)
        public void AddIdentifier(string id)
        {
            // Convert the identifier to lowercase and add it to the list
            _identifiers.Add(id.ToLower());
        }
    }
}
