
namespace OOBEditor.Model
{
    /// <summary>
    /// 路径信息
    /// </summary>
    public class PathInfo
    {
        /// <summary>
        /// Mod名字
        /// </summary>
        public string modName { get; set; }
        /// <summary>
        /// 将领文件路径
        /// </summary>
        public string leaderPath { get; set; }

        /// <summary>
        /// 省份文件路径
        /// </summary>
        public string provincePath { get; set; }

        /// <summary>
        /// 兵种文件路径
        /// </summary>
        public string unitPath { get; set; }

        /// <summary>
        /// 公共文件路径
        /// </summary>
        public string commonPath { get; set; }

        /// <summary>
        /// 地图文件路径
        /// </summary>
        public string mapPath { get; set; }

        /// <summary>
        /// 图片文件路径
        /// </summary>
        public string gfxPath { get; set; }

        /// <summary>
        /// 国家文件路径
        /// </summary>
        public string countriesPath { get; set; }

        /// <summary>
        /// 汉化文件路径
        /// </summary>
        public string localisationPath { get; set; }

        /// <summary>
        /// 军队编制文件路径
        /// </summary>
        public string OOBPath { get; set; }

        /// <summary>
        /// 将领技能文件
        /// </summary>
        public string leadertraitsPath { get; set; }

        #region 暂时注销代码 等待拓展
        //public string technologyPath { get; set; }

        //public string ministerPath { get; set; }

        //public string idealogoiesPath { get; set; }

        //public string ministertypesPath { get; set; }

        //public string governmentpositionsPath { get; set; }

        //public string commontechnologyPath { get; set; }
        #endregion
    }
}
