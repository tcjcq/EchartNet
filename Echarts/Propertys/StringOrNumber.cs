using System;

using Newtonsoft.Json;

namespace Echarts;

[JsonConverter(typeof(StringOrNumberConverter))]
public class StringOrNumber
{
	private object _value;

	public StringOrNumber()
	{
	}


	public StringOrNumber(string value)
	{
		_value = value;
	}

	public StringOrNumber(double value)
	{
		_value = value;
	}

	[JsonIgnore]
	public object Value
	{
		get => _value;
		set
		{
			if (value is string || value is double || value == null || value is int || value is long ||
				value is float)
				_value = value;
			else
				throw new ArgumentException("值必须是 string 或 数值类型。");
		}
	}

	public override string ToString()
	{
		return _value.ToString();
	}

	// 隐式转换从 string
	public static implicit operator StringOrNumber(string value)
	{
		return new StringOrNumber(value);
	}

	// 隐式转换从 double
	public static implicit operator StringOrNumber(double value)
	{
		return new StringOrNumber(value);
	}

	public static StringOrNumber FromObject(object value)
	{
		return value switch
		{
			null => new StringOrNumber(),
			string stringValue => stringValue,
			double doubleValue => doubleValue,
			int intValue => (double)intValue,
			float floatValue => (double)floatValue,
			decimal decimalValue => (double)decimalValue,
			_ => new StringOrNumber()
		};
	}
}