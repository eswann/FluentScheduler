using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentScheduler
{
	public interface ITask
	{
		Task Execute();
	}
}
