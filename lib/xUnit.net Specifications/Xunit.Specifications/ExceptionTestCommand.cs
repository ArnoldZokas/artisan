using System;
using System.Reflection;
using System.Xml;
using Xunit.Sdk;

namespace Xunit.Specifications
{
	public class ExceptionTestCommand : ITestCommand
	{
		private readonly Exception _exception;
		private readonly IMethodInfo _method;

		public ExceptionTestCommand(IMethodInfo method, Exception exception)
		{
			_method = method;
			_exception = exception;
		}

		public string Name
		{
			get { return null; }
		}

		#region ITestCommand Members

		public bool ShouldCreateInstance
		{
			get { return false; }
		}

		public MethodResult Execute(object testClass)
		{
			return new FailedResult(_method, _exception, Name);
		}

		public string DisplayName
		{
			get { throw new NotImplementedException(); }
		}

		public virtual XmlNode ToStartXml()
		{
			var doc = new XmlDocument();
			doc.LoadXml("<dummy/>");
			XmlNode testNode = XmlUtility.AddElement(doc.ChildNodes[0], "start");

			string typeName = _method.TypeName;
			string methodName = _method.Name;

			XmlUtility.AddAttribute(testNode, "name", typeName + "." + methodName);
			XmlUtility.AddAttribute(testNode, "type", typeName);
			XmlUtility.AddAttribute(testNode, "method", methodName);

			return testNode;
		}

		#endregion
	}
}