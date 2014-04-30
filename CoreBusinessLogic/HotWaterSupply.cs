using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic
{
	public abstract class HotWaterSupply
	{
		public ControlPanel ControlPanel { get; set; }
		public BoilerState State { get; protected set; }

		public abstract void Start();
		public abstract void Pause();
		public abstract void Resume();

		public abstract Boolean AreYouReady();

		protected void HandleBoilerState(BoilerState boilerState)
		{
			State = boilerState;
			switch (State)
			{
				case BoilerState.Empty:
					ControlPanel.Ready();
					break;
				case BoilerState.NotEmpty:
					break;
				default:
					throw new ArgumentOutOfRangeException("boilerState");
			}
		}
	}
}
