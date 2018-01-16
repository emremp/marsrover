using System;
using System.Reflection;
using System.ComponentModel;

namespace Business
{
	public static class EnumFuncs
	{
		public static string GetDescription(this Enum value)
		{            
			FieldInfo field = value.GetType().GetField(value.ToString());

			DescriptionAttribute attribute
			= Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
				as DescriptionAttribute;

			return attribute == null ? value.ToString() : attribute.Description;
		}

	}
}

