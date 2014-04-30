using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic.Test
{
	class TestHotWaterSupply : HotWaterSupply
	{
		public TestHotWaterSupply()
		{
			State = BoilerState.NotEmpty;
		}

		public override void Start()
		{
		}

		public override void Pause()
		{
			IsPaused = true;
		}

		public override void Resume()
		{
			IsPaused = false;
		}

		public override bool AreYouReady()
		{
			return State == BoilerState.NotEmpty;
		}

		public void CheckBoiler(BoilerState boilerState)
		{
			HandleBoilerState(BoilerState.Empty);
		}

		public bool IsPaused { get; private set; }
	}
}
