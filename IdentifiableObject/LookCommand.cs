using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class LookCommand : Command
    {
        public LookCommand() : base(ids: new string[] {"Look" })
        {

        }
/*        public override string Execute(Player p, string[] text)
        {
           // throw new NotImplementedException();

            if (!new[] {3,5}.Contains(text.Length))
            {
                return "I don't know how to look like that\n";
            }
            if (text[0] != "Look")
            {
                return "Error in look input\n";
            }
            if (text[1]!= "at")
            {
                return "What do you want to look at\n";
            }
            if(text.Length == 5)
            {
                if (text[3] != "in")
                { return "What do you want to look in\n"; }
            }
            if(text.Length ==1)
            {
                if(text[0] == "Look")
                {
                    return LookAtIn("Location", p as IHaveInventory);
                }
            }
            if (text.Length == 3)
            {
                string itemToFind = text[2];
                return LookAtIn(itemToFind, p as IHaveInventory);
            }

            if (text.Length == 5)
            {
                string itemToFind = text[2];
                string placeToLookIn = text[4];
                IHaveInventory container = FetchContainer(p, placeToLookIn);
                if (container is null)
                {
                    return $"I cannot find the {placeToLookIn}\n";
                }
                return LookAtIn(itemToFind, container);
            }

            return "Success";
        }//*/

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container;
            string _itemid;
            string error = "Error in look input.";

            if (text[0].ToLower() != "look")
                return error;

            switch (text.Length)
            {
                case 1:
                    _container = p;
                    _itemid = "room";
                    break;

                case 3:
                    if (text[1].ToLower() != "at")
                        return "What do you want to look at?";
                    _container = p;
                    _itemid = text[2];
                    break;

                case 5:
                    _container = FetchContainer(p, text[4]);
                    if (_container == null)
                        return "Could not find " + text[4] + ".";
                    _itemid = text[2];
                    break;

                default:
                    return error;
            }
            return LookAtIn(_itemid, _container);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
           // if (p.AreYou(containerId))
           // {
           //     return p;
           // }

            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }

            return $"I can't find the {thingId}";
        }

    }

}

