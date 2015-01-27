using System.Collections.Generic;

namespace OOBEditor.Model
{
    public class MilitaryTypeInfo
    {
        public string name { get; set; }
        /// <summary>
        /// 大类型(陆军、空军、海军）
        /// </summary>
        public string bigType { get; set; }
        public string type { get; set; }
        public List<UnitModelInfo> unitModelList { get; set; }
    }
    public class UnitModelInfo
    {
        public string name { get; set; }
        public string modelNum { get; set; }
    }
}
