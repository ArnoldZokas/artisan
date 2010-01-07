using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace Xunit.Specifications
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class SpecificationAttribute : FactAttribute
	{
		protected override IEnumerable<ITestCommand> EnumerateTestCommands(IMethodInfo method)
		{
			try
			{
				object obj = method.CreateInstance();
				method.Invoke(obj, null);
				return SpecificationContext.ToTestCommands(method);
			}
			catch (Exception ex)
			{
				return new ITestCommand[] {new ExceptionTestCommand(method, ex)};
			}
		}
	}
}