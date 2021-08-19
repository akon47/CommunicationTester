using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationTester.Communication
{
	public class DataReceivedEventArgs : EventArgs
	{
		public byte[] Data { get; private set; }

		public DataReceivedEventArgs(byte[] data)
		{
			this.Data = data;
		}
	}

	public delegate void DataReceivedHandler(object sender, DataReceivedEventArgs e);
}
