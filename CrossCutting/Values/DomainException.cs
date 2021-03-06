using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Solution.CrossCutting.Values
{
	[Serializable]
	public class DomainException : Exception
	{
		public DomainException() { }

		public DomainException(string message) : base(message) { }

		public DomainException(string message, Exception inner) : base(message, inner) { }

		protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			ResourceReferenceProperty = info.GetString(nameof(ResourceReferenceProperty));
		}

		public string ResourceReferenceProperty { get; set; }

		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null) { throw new ArgumentNullException(nameof(info)); }
			info.AddValue(nameof(ResourceReferenceProperty), ResourceReferenceProperty);
			base.GetObjectData(info, context);
		}
	}
}
