using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_del_4.Code
{
    internal class Choice
    {
        public ChoiceEnum UserChoice { get; set; }

        public Choice(string? _choice)
        {
            switch(_choice)
            {
                case "1":
                    UserChoice = ChoiceEnum.AddStudent; break;

                default:
                    UserChoice = ChoiceEnum.Unkown; break;
            }
        }
    }
}
