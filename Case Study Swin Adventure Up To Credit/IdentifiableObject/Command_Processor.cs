using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Command_Processor : Command
    {
        private List<Command> _commands;

        public Command_Processor() : base(new string[] { "move" })
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new Move_Command());
            _commands.Add(new Take_Command());
        }
        public override string Execute(Player player, string[] text)
        {
            // throw new NotImplementedException();
            foreach (Command command in _commands)
            {
                if (command.AreYou(text[0].ToLower()))
                {
                    return command.Execute(player, text);
                }
            }
            return "Sorry !!!Error in command input.";
        }
    }

}
