using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic
{
	public abstract class ContainmentVessel
	{
		protected HotWaterSupply HotWaterSupply;
		public ControlPanel ControlPanel { get; set; }
		public bool PlateIsOn { get; private set; }

		protected ContainmentVessel(HotWaterSupply hotWaterSupply)
		{
			HotWaterSupply = hotWaterSupply;
		}

		public abstract Boolean AreYouReady();

		protected void HandlePotState(PotState potState)
		{
			State = potState;
			switch (State)
			{
				case PotState.None:
					HotWaterSupply.Pause();
					break;
				case PotState.Empty:
					HandlePotEmpty();
					break;
				case PotState.NotEmpty:
					PlateIsOn = true;
					break;
				default:
					throw new ArgumentOutOfRangeException("potState");
			}
		}

		public PotState State { get; protected set; }

		private void HandlePotEmpty()
		{
			PlateIsOn = false;
			if (HotWaterSupply.State == BoilerState.NotEmpty)
			{
				HotWaterSupply.Resume();
			}
			else
			{
				ControlPanel.Done();
			}
		}
	}
}
