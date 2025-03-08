using System;
using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     要处理 symbol 属性，它可以接受预定义的字符串值（如 'circle', 'rect', 'triangle' 等），
///     URL 字符串（如 'image://http://...' 或 'image://data:image/gif;base64,...'），
///     以及自定义的矢量路径（如 'path://...'）。此外，它还可以接受字符串数组，表示循环使用数组中的图案。
///     贴花的图案 在 aria.enabled 与 aria.decal.show 都是 true 的情况下才生效。
///     如果为 'none' 表示不使用贴花图案。
///     ECharts 提供的标记类型包括
///     'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
/// </summary>
[JsonConverter(typeof(SymbolPropertyConverter))]
public class SymbolProperty
{
	private object _value;

	public SymbolProperty(string value)
	{
		_value = value;
	}

	public SymbolProperty(string[] value)
	{
		_value = value;
	}

	[JsonIgnore]
	public object Value
	{
		get => _value;
		set
		{
			if (value is string || value is string[])
				_value = value;
			else
				throw new ArgumentException("值必须是 string 或 string[] 类型。");
		}
	}

	public override string ToString()
	{
		return _value is string[] value ? string.Join(", ", value) : _value.ToString();
	}

	// 隐式转换
	public static implicit operator SymbolProperty(string value)
	{
		return new SymbolProperty(value);
	}

	public static implicit operator SymbolProperty(string[] value)
	{
		return new SymbolProperty(value);
	}
}