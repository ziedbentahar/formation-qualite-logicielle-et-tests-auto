using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticLightSwitcher
{
    partial class LightSwitcher
    {
        public static LightSwitcher Instance { get; } = new LightSwitcher();

        public bool IsTurnedOn { get; private set; }

        public bool TurnOn()
        {
            IsTurnedOn = true;
            return true;
        }
        public bool TurnOff()
        {
            IsTurnedOn = false;
            return false;
        }
}
