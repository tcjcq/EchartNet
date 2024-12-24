using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 例如 series-parallel.data 中有如下数据：
        /// [
        ///     [1,  55,  9,   56,  0.46,  18,  6,  '良'],
        ///     [2,  25,  11,  21,  0.65,  34,  9,  '优'],
        ///     [3,  56,  7,   63,  0.3,   14,  5,  '良'],
        ///     [4,  33,  7,   29,  0.33,  16,  6,  '优'],
        ///     { // 数据项也可以是 Object，从而里面能含有对线条的特殊设置。
        ///         value: [5,  42,  24,  44,  0.76,  40,  16, '优']
        ///         lineStyle: {...},
        ///     }
        ///     ...
        /// ]
        /// 
        /// 数据中，每一行是一个『数据项』，每一列属于一个『维度』。（例如上面数据每一列的含义分别是：『日期』,『AQI指数』, 『PM2.5』, 『PM10』, 『一氧化碳值』, 『二氧化氮值』, 『二氧化硫值』）。
    /// </summary>
    public class SeriesParallel_Data
    {
        /// <summary>
        /// 数据项名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 数据项值。
        /// </summary>
        [JsonProperty("value")]
        public double[] Value { get; set; }

        /// <summary>
        /// 线条样式。
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle1 LineStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("emphasis")]
        public Emphasis9 Emphasis { get; set; }

    }
 }
