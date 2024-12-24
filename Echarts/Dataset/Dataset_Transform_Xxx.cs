using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 除了上述的内置的数据转换器外，我们也可以使用外部的数据转换器。外部数据转换器能提供或自己定制更丰富的功能。
        /// 参见 数据变换教程
    /// </summary>
    public class Dataset_Transform_Xxx
    {
        /// <summary>
        /// 内置数据转换器没有名空间（如 type: 'filter', type: 'sort'）。
        /// 外部数据转换器须有名空间（如 type: 'ecStat:regression'）。
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="xxx:xxx";

        /// <summary>
        /// 这里设置每个数据转换器所须的参数。每种数据转换器有自己的参数格式定义。
        /// </summary>
        [JsonProperty("config")]
        public object Config { get; set; }

        /// <summary>
        /// 使用 transform 时，有时候我们会配不对，显示不出来结果，并且不知道哪里错了。所以，这里提供了一个配置项 transform.print 方便 debug 。这个配置项只在开发环境中生效。如下例：
        /// option = {
        ///     dataset: [{
        ///         source: [ ... ]
        ///     }, {
        ///         transform: {
        ///             type: 'filter',
        ///             config: { ... }
        ///             // 配置为 `true` 后， transform 的结果
        ///             // 会被 console.log 打印出来。
        ///             print: true
        ///         }
        ///     }],
        ///     ...
        /// }
        /// </summary>
        [JsonProperty("print")]
        public bool? Print { get; set; }

    }
 }
