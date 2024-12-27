using System;
using Newtonsoft.Json;

namespace Echarts
{
	[JsonConverter(typeof(NumberOrBoolConverter))]
	public class NumberOrBool
	{
		private object _value;

		// 构造函数
		public NumberOrBool(object value)
		{
			if (value is bool || value is int || value is double)
				_value = value;
			else
				throw new ArgumentException("值必须是 bool、int 或 double 类型。");
		}

		[JsonIgnore]
		public object Value
		{
			get => _value;
			set
			{
				if (value is bool || value is int || value is double)
					_value = value;
				else
					throw new ArgumentException("值必须是 bool、int 或 double 类型。");
			}
		}

		// 隐式转换操作符
		public static implicit operator NumberOrBool(bool value)
		{
			return new NumberOrBool(value);
		}

		public static implicit operator NumberOrBool(int value)
		{
			return new NumberOrBool(value);
		}

		public static implicit operator NumberOrBool(double value)
		{
			return new NumberOrBool(value);
		}
	}
}