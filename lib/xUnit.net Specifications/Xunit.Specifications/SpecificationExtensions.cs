using System;

namespace Xunit.Specifications
{
	public static class SpecificationExtensions
	{
		public static void Context(this string message)
		{
			SpecificationContext.Context(message);
		}

		public static void Context(this string message, Action arrange)
		{
			SpecificationContext.Context(message, arrange);
		}

		public static void Do(this string message, Action act)
		{
			SpecificationContext.Do(message, act);
		}

		public static void Assert(this string message, Action assert)
		{
			SpecificationContext.Assert(message, assert);
		}
	}
}