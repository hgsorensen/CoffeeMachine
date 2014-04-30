using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessLogic.Test
{
	[TestClass]
	public class ControlPanelTest
	{
		private TestHotWaterSupply hotWaterSupply;
		private TestContainmentVessel containmentVessel;
		private TestControlPanel controlPanel;

		[TestInitialize]
		public void Setup()
		{
			hotWaterSupply = new TestHotWaterSupply();
			containmentVessel = new TestContainmentVessel(hotWaterSupply);
			controlPanel = new TestControlPanel(hotWaterSupply, containmentVessel);
		}

		[TestMethod]
		public void When_CoffeeReady_LightIsOn()
		{
			controlPanel.CheckButton();
			Assert.IsFalse(controlPanel.CoffeeReady);
			hotWaterSupply.CheckBoiler(BoilerState.Empty);
			Assert.IsTrue(controlPanel.CoffeeReady);
		}

		[TestMethod]
		public void When_CoffeeIsDrunk_MachineIsOff()
		{
			controlPanel.CheckButton();
			Assert.IsFalse(controlPanel.CoffeeReady);
			hotWaterSupply.CheckBoiler(BoilerState.Empty);
			Assert.IsTrue(controlPanel.CoffeeReady);

			containmentVessel.CheckPot(PotState.Empty);
			Assert.IsTrue(controlPanel.MachineOff);
		}

		[TestMethod]
		public void When_PotIsUnempty_PlateIsOn()
		{
			controlPanel.CheckButton();
			containmentVessel.CheckPot(PotState.NotEmpty);
			Assert.IsTrue(containmentVessel.PlateIsOn);
		}

		[TestMethod]
		public void When_PotIsEmpty_PlateIsOff()
		{
			controlPanel.CheckButton();
			containmentVessel.CheckPot(PotState.NotEmpty);
			Assert.IsTrue(containmentVessel.PlateIsOn);
			containmentVessel.CheckPot(PotState.Empty);
			Assert.IsFalse(containmentVessel.PlateIsOn);
		}

		[TestMethod]
		public void When_PotIsRemoveDuringBrewing_BoilerIsPaused()
		{
			controlPanel.CheckButton();
			containmentVessel.CheckPot(PotState.None);
			Assert.IsTrue(hotWaterSupply.IsPaused);
		}

		[TestMethod]
		public void When_EmptyPotIsReturned_BoilerIsResumed()
		{
			controlPanel.CheckButton();
			containmentVessel.CheckPot(PotState.None);
			Assert.IsTrue(hotWaterSupply.IsPaused);

			containmentVessel.CheckPot(PotState.Empty);
			Assert.IsFalse(hotWaterSupply.IsPaused);
		}
	}
}
