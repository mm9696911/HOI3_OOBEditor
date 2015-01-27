using OOBEditor.Model;
using OOBEditor.Model.Enum;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OOBEditor.Services
{
    public class GenerateServices
    {
        List<OOBInfo> oobList = new List<OOBInfo>();
        string countryCode = "";
        StringBuilder sb = new StringBuilder();
        string constructionStr = "";
        PathInfo pathInfo = new PathInfo();
        string scenariosStr = "";

        public GenerateServices(PathInfo pathInfo, List<OOBInfo> list, string countryCode, string scenariosStr, string constructionStr)
        {
            this.pathInfo = pathInfo;
            this.oobList = list;
            this.countryCode = countryCode;
            this.constructionStr = constructionStr;
            this.scenariosStr = scenariosStr;
        }
        public bool GenerateCode()
        {
            var oobChildList = oobList.FindAll(c => c.parentID == 0 && c.id != 0).OrderBy(co => co.id);
            foreach (OOBInfo oobInfo in oobChildList)
            {
                int tabNum = 0;
                GenerateAdvanced(oobInfo, tabNum);
                sb.Append("\r\n");
            }
            sb.AppendLine(constructionStr);

            string filePath = string.Concat(pathInfo.OOBPath, "\\OOBEdit\\");
            DirectoryInfo Drr = new DirectoryInfo(filePath);
            if (!Drr.Exists)
            {
                Drr.Create();
            }

            FileStream fs1 = new FileStream(string.Concat(filePath, countryCode, "_", scenariosStr, ".txt"), FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1, Encoding.Default);
            sw.WriteLine(sb.ToString());//开始写入值

            sw.Close();
            fs1.Close();
            return true;
        }

        private void GenerateAdvanced(OOBInfo oobInfo, int tabNum)
        {
            AddTab(tabNum);
            int childTabNum = tabNum + 1;
            sb.Append(oobInfo.armyType.ToString().ToLower() + " = {\r\n");

            GeneralAdvancedBasicCode(oobInfo, childTabNum);

            var oobChildList = oobList.FindAll(c => c.parentID == oobInfo.id).OrderBy(co => co.id);
            foreach (OOBInfo oobChildInfo in oobChildList)
            {
                if (oobChildInfo.armyType == ArmyTypeEnum.Regiment || oobChildInfo.armyType == ArmyTypeEnum.Ship || oobChildInfo.armyType == ArmyTypeEnum.Wing)
                {
                    GenerateRegimentOrShipOrWing(oobChildInfo, childTabNum);
                    var oobChildList2 = oobList.FindAll(c => c.parentID == oobChildInfo.id);
                    if (oobChildList2.Count > 0)
                    {
                        foreach (OOBInfo oobChildInfo2 in oobChildList2)
                        {
                            GenerateAdvanced(oobChildInfo2, childTabNum);
                        }
                    }
                    continue;
                }
                GenerateAdvanced(oobChildInfo, childTabNum);
            }
            AddTab(tabNum);
            sb.Append("}\r\n");
        }

        private void GenerateRegimentOrShipOrWing(OOBInfo oobInfo, int tabNum)
        {
            AddTab(tabNum);
            sb.Append(oobInfo.armyType.ToString().ToLower() + " = {");
            sb.Append(" type = " + oobInfo.type);
            if (!string.IsNullOrEmpty(oobInfo.name))
            {
                sb.Append(" name = \"" + oobInfo.name + "\"");
            }
            if (!string.IsNullOrEmpty(oobInfo.experience))
            {
                sb.Append(" experience = " + oobInfo.experience);
            }
            sb.Append(" historical_model = " + oobInfo.historical_model + " }\r\n");
        }

        private void GeneralAdvancedBasicCode(OOBInfo oobInfo, int tabNum)
        {
            AddTab(tabNum);
            sb.Append("name = \"" + oobInfo.name + "\"\r\n");
            AddTab(tabNum);
            sb.Append("location = " + oobInfo.location + "\r\n");
            if (!string.IsNullOrEmpty(oobInfo.leader))
            {
                AddTab(tabNum);
                sb.Append("leader = " + oobInfo.leader + "\r\n");
            }
            if ((oobInfo.armyType == ArmyTypeEnum.Navy || oobInfo.armyType == ArmyTypeEnum.Air) && !string.IsNullOrEmpty(oobInfo.baseID))
            {
                AddTab(tabNum);
                sb.Append("base = " + oobInfo.baseID + "\r\n");
            }
            if (oobInfo.armyType == ArmyTypeEnum.Division && oobInfo.is_reserve.HasValue)
            {
                AddTab(tabNum);
                sb.Append("is_reserve = yes \r\n");
            }
        }

        private void AddTab(int tabNum)
        {
            for (int i = 1; i <= tabNum; i++)
            {
                sb.Append("\t");
            }
        }
    }
}
