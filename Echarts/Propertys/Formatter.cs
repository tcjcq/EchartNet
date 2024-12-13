namespace Echarts
{
	public class Formatter
	{
		public Formatter(string value)
		{
			Value = value;
		}

		public string Value { get; private set; }

		public override string ToString()
		{
			return Value;
		}

		// 隐式转换从 string
		public static implicit operator Formatter(string value)
		{
			return new Formatter(value);
		}
	}
}