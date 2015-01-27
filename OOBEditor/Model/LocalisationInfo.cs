using System.Collections.Generic;

namespace OOBEditor.Model
{
    public class LocalisationInfo
    {
        public List<ProvinceInfo> ProvinceList { get; set; }
        public List<UnitInfo> UnitList { get; set; }
    }

    /// <summary>
    /// 省份信息
    /// </summary>
    public class ProvinceInfo
    {
        public string id { get; set; }

        public string name { get; set; }
    }

    /// <summary>
    /// 军队类型信息
    /// </summary>
    public class UnitInfo
    {
        public string code { get; set; }

        public string name { get; set; }
    }

    /// <summary>
    /// 汉化装备型号
    /// </summary>
    public class LocalUnitModelInfo
    {

        public string code { get; set; }

        public string name { get; set; }
    }
}
