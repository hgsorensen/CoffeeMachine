using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLogic
{
    public abstract class ControlPanel
    {
	    private readonly HotWaterSupply hotWaterSupply;
	    private readonly ContainmentVessel containmentVessel;

	    protected ControlPanel(HotWaterSupply hotWaterSupply, ContainmentVessel containmentVessel)
	    {
		    this.hotWaterSupply = hotWaterSupply;
		    this.hotWaterSupply.ControlPanel = this;

		    this.containmentVessel = containmentVessel;
		    this.containmentVessel.ControlPanel = this;
	    }

	    protected void CoffeeRequested()
	    {
		    if (hotWaterSupply.AreYouReady() && containmentVessel.AreYouReady())
		    {
			    hotWaterSupply.Start();
		    }
	    }

	    public abstract void Ready();
		
	    public abstract void Done();
    }
}
