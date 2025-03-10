namespace Echarts;

public class Formatter(string value)
{
	public string Value { get; } = value;

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