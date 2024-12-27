using System;
using Newtonsoft.Json;

namespace Echarts
{
	[JsonConverter(typeof(StringOrBoolConverter))]
	public class StringOrBool
	{
		private object _value;

		public StringOrBool(string value)
		{
			_value = value;
		}

		public StringOrBool(bool value)
		{
			_value = value;
		}

		[JsonIgnore]
		public object Value
		{
			get => _value;
			set
			{
				if (value is string || value is bool)
					_value = value;
				else
					throw new ArgumentException("值必须是 string 或 bool 类型。");
			}
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		// 隐式转换
		public static implicit operator StringOrBool(string value)
		{
			return new StringOrBool(value);
		}

		public static implicit operator StringOrBool(bool value)
		{
			return new StringOrBool(value);
		}
	}
}