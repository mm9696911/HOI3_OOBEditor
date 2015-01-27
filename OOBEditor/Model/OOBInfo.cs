using OOBEditor.Model.Enum;

namespace OOBEditor.Model
{
    public class OOBInfo
    {
        public int id { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 级别等级
        /// </summary>
        public string historical_model { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 经验
        /// </summary>
        public string experience { get; set; }
        /// <summary>
        /// 位置代码
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 是否预备役
        /// </summary>
        public bool? is_reserve { get; set; }
        /// <summary>
        /// 将领代码
        /// </summary>
        public string leader { get; set; }
        /// <summary>
        /// 部队类型 Theatre，ArmyGroup...
        /// </summary>
        public ArmyTypeEnum armyType { get; set; }
        /// <summary>
        /// 海空军 基地代码
        /// </summary>
        public string baseID { get; set; }

        /// <summary>
        /// 上级部队代码
        /// </summary>
        public int parentID { get; set; }
    }
}
