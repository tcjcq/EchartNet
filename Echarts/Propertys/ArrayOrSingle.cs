using System.Collections.Generic;

using Newtonsoft.Json;

namespace Echarts
{
	[JsonConverter(typeof(ArrayOrSingleConverter))]
	public class ArrayOrSingle
	{
		private readonly bool? _boolValue;
		private readonly List<double> _doubleValues;
		private readonly List<int> _intValues;
		private readonly double? _singleDoubleValue;
		private readonly int? _singleIntValue;
		private readonly string _singleStringValue;
		private readonly List<string> _stringValues;

		public ArrayOrSingle(bool value)
		{
			_boolValue = value;
		}

		public ArrayOrSingle(List<int> intValues)
		{
			_intValues = intValues;
		}

		public ArrayOrSingle(List<double> doubleValues)
		{
			_doubleValues = doubleValues;
		}

		public ArrayOrSingle(int singleIntValue)
		{
			_singleIntValue = singleIntValue;
		}

		public ArrayOrSingle(double singleDoubleValue)
		{
			_singleDoubleValue = singleDoubleValue;
		}

		public ArrayOrSingle(List<string> stringValues)
		{
			_stringValues = stringValues;
		}

		public ArrayOrSingle(string singleStringValue)
		{
			_singleStringValue = singleStringValue;
		}

		public static implicit operator ArrayOrSingle(bool value)
		{
			return new ArrayOrSingle(value);
		}

		// 隐式操作符，允许从单个 int 转换到 ArrayIntOrString
		public static implicit operator ArrayOrSingle(int singleIntValue)
		{
			return new ArrayOrSingle(singleIntValue);
		}

		public static implicit operator ArrayOrSingle(double singleIntValue)
		{
			return new ArrayOrSingle(singleIntValue);
		}

		// 隐式操作符，允许从 List<int> 转换到 ArrayIntOrString
		public static implicit operator ArrayOrSingle(List<int> intValues)
		{
			return new ArrayOrSingle(intValues);
		}

		// 隐式操作符，允许从单个 string 转换到 ArrayIntOrString
		public static implicit operator ArrayOrSingle(string singleStringValue)
		{
			return new ArrayOrSingle(singleStringValue);
		}

		// 隐式操作符，允许从 List<string> 转换到 ArrayIntOrString
		public static implicit operator ArrayOrSingle(List<string> stringValues)
		{
			return new ArrayOrSingle(stringValues);
		}

		public object GetValue()
		{
			if (_boolValue.HasValue) return _boolValue.Value;

			if (_singleIntValue.HasValue) return new List<int> { _singleIntValue.Value };
			if (_singleDoubleValue.HasValue) return new List<double> { _singleDoubleValue.Value };
			if (_doubleValues != null) return _doubleValues;
			if (_intValues != null) return _intValues;
			return _singleStringValue != null
				? new List<string> { _singleStringValue }
				: _stringValues;
		}
	}

	// 自定义JsonConverter支持反序列化
}