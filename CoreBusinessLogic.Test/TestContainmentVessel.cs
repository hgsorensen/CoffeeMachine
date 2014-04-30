using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic.Test
{
	class TestContainmentVessel : ContainmentVessel
	{
		public TestContainmentVessel(HotWaterSupply hotWaterSupply) : base(hotWaterSupply)
		{
			State = PotState.Empty;
		}

		public override bool AreYouReady()
		{
			return State != PotState.None;
		}

		public void CheckPot(PotState potState)
		{
			HandlePotState(potState);
		}
	}
}
