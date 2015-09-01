using OOBEditor.Model;
using System;
using System.IO;

namespace OOBEditor.Helper
{
    /// <summary>
    /// 获取路径类
    /// </summary>
    public class PathHelper
    {
        PathInfo pathInfo = new PathInfo();

        #region 设置文件路径

        public PathInfo checkDirectory(out string errorMessage)
        {
            try
            {
                if (!File.Exists(string.Concat(System.Environment.CurrentDirectory, "\\Setting.xml")))
                {
                    errorMessage = "请先设置游戏路径";
                    return pathInfo;
                }
                string gamePath = new XmlHelper().GetXmlValue("GamePath");
                pathInfo = checkpaths(gamePath, out errorMessage);

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return pathInfo;
        }

        private PathInfo checkpaths(string gamePath, out string errorMessage)
        {
            errorMessage = "";
            if (Directory.Exists(string.Concat(gamePath, "\\history\\units")))
            {
                pathInfo.OOBPath = string.Concat(gamePath, "\\history\\units\\");
            }
            else
            {
                errorMessage += "找不到history\\units文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\history\\provinces")))
            {
                pathInfo.provincePath = string.Concat(gamePath, "\\history\\provinces\\");
            }
            else
            {
                errorMessage += "找不到provinces文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\common")))
            {
                pathInfo.commonPath = string.Concat(gamePath, "\\common\\");
            }
            else
            {
                errorMessage += "找不到common文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\history\\leaders")))
            {
                pathInfo.leaderPath = string.Concat(gamePath, "\\history\\leaders\\");
            }
            else
            {
                errorMessage += "找不到leaders文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\map")))
            {
                pathInfo.mapPath = string.Concat(gamePath, "\\map\\");
            }
            else
            {
                errorMessage += "找不到map文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\units")))
            {
                pathInfo.unitPath = string.Concat(gamePath, "\\units\\");
            }
            else
            {
                errorMessage += "找不到units文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\gfx")))
            {
                pathInfo.gfxPath = string.Concat(gamePath, "\\gfx\\");
            }
            else
            {
                errorMessage += "找不到gfx文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\history\\countries")))
            {
                pathInfo.countriesPath = string.Concat(gamePath, "\\history\\countries\\");
            }
            else
            {
                errorMessage += "找不到countries文件夹\n";
            }

            if (Directory.Exists(string.Concat(gamePath, "\\localisation")))
            {
                pathInfo.localisationPath = string.Concat(gamePath, "\\localisation\\");
            }
            else
            {
                errorMessage += "找不到localisation文件夹\n";
            }

            if (File.Exists(string.Concat(gamePath, "\\common\\traits.txt")))
            {
                pathInfo.leadertraitsPath = string.Concat(gamePath, "\\common\\traits.txt");
            }
            else
            {
                errorMessage += "找不到traits.txt文件\n";
            }

            #region 暂时注销代码 等待拓展
            //if (!Directory.Exists(string.Concat(gamePath, "\\technologies")))
            //{
            //    pathInfo.technologyPath = string.Concat(gamePath, "\\technologies\\");
            //}
            //else
            //{
            //    errorMessage += "找不到technologies文件夹\n";
            //}
            //if (!Directory.Exists(string.Concat(gamePath, "\\common\\countries")))
            //{
            //    pathInfo.ministerPath = string.Concat(gamePath, "\\common\\countries\\");
            //}
            //else
            //{
            //    errorMessage += "找不到countries文件夹\n";
            //}
            //if (!File.Exists(string.Concat(gamePath, "\\common\\ideologies.txt")))
            //{
            //    pathInfo.idealogoiesPath = string.Concat(gamePath, "\\common\\ideologies.txt");
            //}
            //else
            //{
            //    errorMessage += "找不到ideologies.txt文件\n");
            //}
            //if (!File.Exists(string.Concat(gamePath, "\\common\\minister_types.txt")))
            //{
            //    pathInfo.ministertypesPath = string.Concat(gamePath, "\\common\\minister_types.txt");
            //}
            //else
            //{
            //    errorMessage += "找不到minister_types.txt文件\n");
            //}
            //if (!File.Exists(string.Concat(gamePath, "\\common\\government_positions.txt")))
            //{
            //    pathInfo.governmentpositionsPath = string.Concat(gamePath, "\\common\\government_positions.txt");
            //}
            //else
            //{
            //    errorMessage += "找不到government_positions.txt文件\n");
            //}
            //if (File.Exists(string.Concat(gamePath, "\\common\\technology.txt")))
            //{
            //    pathInfo.commontechnologyPath = string.Concat(gamePath, "\\common\\technology.txt");
            //    return;
            //}
            #endregion

            return pathInfo;
        }
        #endregion
    }
}
