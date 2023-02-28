using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public  class Move_Command : Command
    {
        public Move_Command() : base(new string[] {"move","go","head","leave"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            //throw new NotImplementedException();
           

            string _moveToDirection;

            switch(text.Length)
            {
                case 1:
                    return "Move where?";
                case 2: 
                    _moveToDirection = text[1].ToLower();
                    break;
                case 3:
                    _moveToDirection = text[2].ToLower();
                    break ;
                default:
                    return "Sorry Your command is wrong!!!!";
            }
            GameObject _pathCommand = p.Location.Locate(_moveToDirection);
            if (_pathCommand != null)
            {

                if (_pathCommand.GetType() != typeof(Path))
                {
                    return "Sorry!!! The program can not find the path " + _pathCommand.Name;
                }
                p.MoveTo((Path)_pathCommand);
                return "You have successfully moved " + _pathCommand.FirstId + " From " + _pathCommand.Name + p.Location.Name + "\n\n\n" + "Now New location is " + p.Location.FullDescription;
            }

            else
            {
                return "Sorry Your command is wrong!!!!";
            }
        }

    }
}

