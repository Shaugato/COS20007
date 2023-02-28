using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Take_Command : Command
    {
        public Take_Command() : base(new string[] { "take" })
        { 
        
        
        }

        private bool StringNeedContain(string searchedfor, string[] value)
        {
            foreach(string strng in value)
            {
                if(searchedfor.Contains(strng))
                {
                    return true;
                }
                
            }
            return false;
        }
        private IHaveInventory FetchContainer(Player player , string containerId)
        {
            return player.Locate(containerId) as IHaveInventory;
        }

        private String TakeItemFromCommand(Player player, string thinfId , IHaveInventory container )
        {
            if(container.Locate(thinfId) == null)
            {
                return"Sorry , we could not find " + thinfId  +  "\n\n";
            }

            GameObject itemToFind = container.Locate(thinfId);
            Item itemTaken = container.Take_Command(thinfId) as Item;

            if(itemTaken == null)
            {
                return "Sorry , You can't take out " + itemTaken.ShortDescription;
            }

            player.Inventory.Put(itemTaken);
            return "You have Taken the folowing item " + thinfId + ".\n";
            }

        public override string Execute(Player player, string[] text)
        {
            //throw new NotImplementedException();
            
            IHaveInventory _container = null;

            string itemToFind;

            switch(text.Length)
            {
                case 1:
                    return "What do you want to take ";

                case 2:
                    if (StringNeedContain(text[1].ToLower(),  new string[] {"north", "south", "east", "west"}))
                    {
                        return "Cannot " + text[0] + " direction!";
                    }
                    else
                    {
                        itemToFind = text[1];
                        _container = player.Location;
                    }
                    break;
                case 3:
                    if (text[1].ToLower() != "at")
                    {
                        return "What do you want to move the item from";
                    }
                    _container = player.Location;
                    itemToFind = text[2];
                    break;

                case 4:
                    _container = FetchContainer(player, text[3]);
                    if (_container == null)

                    {
                        return "Could not able to find " + text[3] + ".\n ";
                    }

                    itemToFind = text[1];
                    break;
                    default:

                    _container = null;
                    return "Error in Input";
            }

            return TakeItemFromCommand(player, itemToFind, _container);
            


        }
    }
}

