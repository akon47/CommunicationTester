using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationTester.Communication
{
	public enum Status
	{
		None,
		Opened,
		Closed,
		Listening,
		Connected,
		Disconnected,
		WaitForData
	}
}
