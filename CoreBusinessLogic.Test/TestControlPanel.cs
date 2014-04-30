using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic.Test
{
	class TestControlPanel : ControlPanel
	{
		public TestControlPanel(HotWaterSupply hotWaterSupply, ContainmentVessel containmentVessel) : base(hotWaterSupply, containmentVessel)
		{
		}

		public void CheckButton()
		{
			CoffeeRequested();
		}

		public bool CoffeeReady { get; private set; }
		public override void Ready()
		{
			CoffeeReady = true;
		}

		public override void Done()
		{
			MachineOff = false;
		}

		public Boolean MachineOff { get; private set; }
	}
}
