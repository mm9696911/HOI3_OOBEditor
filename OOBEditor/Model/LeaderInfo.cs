using System.Collections.Generic;

namespace OOBEditor.Model
{
    public class LeaderInfo
    {
        /// <summary>
        /// 将领ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 国家
        /// </summary>        
        public string country { get; set; }

        /// <summary>
        /// 将领类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 当前技能点数
        /// </summary>
        public int skill { get; set; }

        /// <summary>
        /// 最大技能点数
        /// </summary>
        public int max_skill { get; set; }

        /// <summary>
        /// 忠诚度
        /// </summary>
        public decimal loyalty { get; set; }

        /// <summary>
        /// 头像图片名称
        /// </summary>
        public string picture { get; set; }

        /// <summary>
        /// 将领特技
        /// </summary>
        public List<string> add_trait { get; set; }

        /// <summary>
        /// 将领历史
        /// </summary>
        public List<LeaderHistory> history { get; set; }
    }

    public class LeaderHistory
    {
        /// <summary>
        /// 历史时间
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int rank { get; set; }
    }
}
