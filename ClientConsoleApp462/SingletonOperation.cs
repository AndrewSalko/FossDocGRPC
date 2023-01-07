using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp462
{
	public class SingletonOperation: IOperation
	{
		string _Id;

		public SingletonOperation()
		{
			_Id = "Operation Id " + new Guid().ToString();
		}

		public string OperationId => _Id;
	}
}
