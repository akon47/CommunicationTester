using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationTester.Communication
{
	public abstract class BaseCommunication : NotifyPropertyBase, IDisposable
	{
		private Status status = Status.None;
		public Status Status
		{
			get => status;
			protected set => SetProperty(ref status, value);
		}

		public event DataReceivedHandler DataReceived;

		protected void OnDataReceived(byte[] data)
		{
			if(data != null)
			{
				DataReceived?.Invoke(this, new DataReceivedEventArgs(data));
			}
		}

		public virtual void Dispose()
		{
			
		}
	}
}
