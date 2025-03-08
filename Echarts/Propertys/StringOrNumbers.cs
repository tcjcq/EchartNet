using System;
using Newtonsoft.Json;

namespace Echarts;

[JsonConverter(typeof(StringOrNumbersConverter))]
public class StringOrNumbers
{
	private object _value;

	public StringOrNumbers(string value)
	{
		_value = value;
	}

	public StringOrNumbers(double value)
	{
		_value = value;
	}

	public StringOrNumbers(double[] value)
	{
		_value = value;
	}

	[JsonIgnore]
	public object Value
	{
		get => _value;
		set
		{
			if (value is string || value is double || value is double[])
				_value = value;
			else
				throw new ArgumentException("值必须是 string、double 或 double[] 类型。");
		}
	}

	public override string ToString()
	{
		if (_value is double[] array) return "[" + string.Join(", ", array) + "]";
		return _value.ToString();
	}

	// 隐式转换
	public static implicit operator StringOrNumbers(string value)
	{
		return new StringOrNumbers(value);
	}

	public static implicit operator StringOrNumbers(double value)
	{
		return new StringOrNumbers(value);
	}

	public static implicit operator StringOrNumbers(double[] value)
	{
		return new StringOrNumbers(value);
	}
}