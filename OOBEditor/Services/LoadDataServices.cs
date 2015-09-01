using LumenWorks.Framework.IO.Csv;
using OOBEditor.Helper;
using OOBEditor.Model;
using OOBEditor.Model.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OOBEditor.Services
{
    public class LoadDataServices
    {
        PathInfo pathInfo = new PathInfo();
        string countryCode = "";
        static string reader = "";
        int vtemp;
        string[,] leaderarray;
        List<string> unitTypeList = new List<string>();
        int unitId = 1;

        public LoadDataServices(PathInfo pathInfo, string countryCode)
        {
            this.pathInfo = pathInfo;
            this.countryCode = countryCode;
            SetUnitType();
        }
        public LoadDataServices(PathInfo pathInfo)
        {
            this.pathInfo = pathInfo;
            SetUnitType();
        }

        #region 加载国家名称和缩写，从汉化文件
        /// <summary>
        /// 加载国家名称和缩写，从汉化文件
        /// </summary>
        /// <returns></returns>
        public List<CountryInfo> LoadCountry()
        {
            List<CountryInfo> list = new List<CountryInfo>();
            string countryLocalisationPath = RetuenPath(string.Concat(pathInfo.localisationPath, "countries.csv"));

            using (CsvReader csv =
                new CsvReader(new StreamReader(countryLocalisationPath, Encoding.Default), true))
            {
                int i = 0;
                while (csv.ReadNextRecord())
                {
                    string countryStr = csv[0];
                    if (countryStr.ToLower().IndexOf("reb") > -1 || countryStr.ToLower().IndexOf("_adj") > -1)
                    {
                        i++;
                        continue;
                    }
                    CountryInfo countryInfo = new CountryInfo();
                    countryInfo.countryCode = countryStr.Split(';')[0];
                    countryInfo.name = countryStr.Split(';')[1];
                    list.Add(countryInfo);
                    i++;
                }
            }
            return list;
        }
        #endregion

        #region 加载省份名称，从汉化文件
        /// <summary>
        /// 加载省份名称，从汉化文件
        /// </summary>
        /// <returns></returns>
        public List<ProvinceInfo> LoadProvince()
        {
            List<ProvinceInfo> list = new List<ProvinceInfo>();
            using (CsvReader csv =
                new CsvReader(new StreamReader(string.Concat(pathInfo.localisationPath, "province_names.csv"), Encoding.Default), true))
            {
                int i = 0;
                while (csv.ReadNextRecord())
                {
                    string provinceStr = csv[0];
                    if (provinceStr.ToLower().IndexOf("reb") > -1 || provinceStr.ToLower().IndexOf("prov") < 0)
                    {
                        i++;
                        continue;
                    }
                    ProvinceInfo provinceInfo = new ProvinceInfo();
                    provinceInfo.id = provinceStr.Split(';')[0].Remove(0, 4);
                    provinceInfo.name = provinceStr.Split(';')[1];
                    list.Add(provinceInfo);
                    i++;
                }
            }
            return list;
        }
        #endregion

        #region 加载装备类型，从汉化文件
        /// <summary>
        /// 加载装备类型，从汉化文件
        /// </summary>
        /// <returns></returns>
        public List<UnitInfo> LoadUnit()
        {
            List<UnitInfo> list = new List<UnitInfo>();
            using (CsvReader csv = new CsvReader(new StreamReader(string.Concat(pathInfo.localisationPath, "units.csv"), Encoding.Default), true))
            {
                int i = 0;
                while (csv.ReadNextRecord())
                {
                    string unitStr = csv[0];
                    if (unitStr.ToLower().IndexOf("#") > -1)
                    {
                        i++;
                        continue;
                    }
                    UnitInfo unitInfo = new UnitInfo();
                    unitInfo.code = unitStr.Split(';')[0];
                    unitInfo.name = unitStr.Split(';')[1];
                    list.Add(unitInfo);
                    i++;
                }
            }
            string tfhPath = RetuenPath(string.Concat(pathInfo.localisationPath, "tfh.csv"));

            if (File.Exists(tfhPath))
            {
                using (CsvReader csv = new CsvReader(new StreamReader(tfhPath, Encoding.Default), true))
                {
                    int i = 0;
                    while (csv.ReadNextRecord())
                    {
                        string unitStr = csv[0];
                        if (unitStr.ToLower().IndexOf("#") > -1)
                        {
                            i++;
                            continue;
                        }
                        UnitInfo unitInfo = new UnitInfo();
                        unitInfo.code = unitStr.Split(';')[0];
                        unitInfo.name = unitStr.Split(';')[1];
                        list.Add(unitInfo);
                        i++;
                    }
                }
            }
            string tfh_4_0Path = RetuenPath(string.Concat(pathInfo.localisationPath, "tfh_4_0.csv"));

            if (File.Exists(tfh_4_0Path))
            {
                using (CsvReader csv = new CsvReader(new StreamReader(tfh_4_0Path, Encoding.Default), true))
                {
                    int i = 0;
                    while (csv.ReadNextRecord())
                    {
                        string unitStr = csv[0];
                        if (unitStr.ToLower().IndexOf("#") > -1)
                        {
                            i++;
                            continue;
                        }
                        UnitInfo unitInfo = new UnitInfo();
                        unitInfo.code = unitStr.Split(';')[0];
                        unitInfo.name = unitStr.Split(';')[1];
                        list.Add(unitInfo);
                        i++;
                    }
                }
            }
            string v3Path = RetuenPath(string.Concat(pathInfo.localisationPath, "v3.csv"));

            if (File.Exists(v3Path))
            {
                using (CsvReader csv = new CsvReader(new StreamReader(v3Path, Encoding.Default), true))
                {
                    int i = 0;
                    while (csv.ReadNextRecord())
                    {
                        string unitStr = csv[0];
                        if (unitStr.ToLower().IndexOf("#") > -1)
                        {
                            i++;
                            continue;
                        }
                        UnitInfo unitInfo = new UnitInfo();
                        unitInfo.code = unitStr.Split(';')[0];
                        unitInfo.name = unitStr.Split(';')[1];
                        list.Add(unitInfo);
                        i++;
                    }
                }
            }
            return list;
        }
        #endregion

        #region 加载将领数据
        /// <summary>
        /// 加载将领数据
        /// </summary>
        /// <returns></returns>
        public List<LeaderInfo> LoadLeaderInfo()
        {
            string leaderFileFullPath = RetuenPath(string.Concat(pathInfo.leaderPath, countryCode, ".txt"));


            this.vtemp = getfilelength(leaderFileFullPath);
            this.leaderarray = new string[this.vtemp, 3];
            sortfile(leaderFileFullPath, ref this.leaderarray);
            List<LeaderInfo> leaderList = fillleaderfields(this.leaderarray);

            return leaderList;
        }

        /// <summary>
        /// 获取将领信息 并绑定到List
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private List<LeaderInfo> fillleaderfields(string[,] array)
        {
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            string reader;
            List<LeaderInfo> list = new List<LeaderInfo>();
            for (int i = 0; i < array.Length / 3; i++)
            {
                reader = array[i, 0];
                if (!reader.StartsWith("#") && array[i, 2] == "0" && reader.Length > 0)
                {
                    LeaderInfo leaderInfo = new LeaderInfo();
                    object[] objArray = new object[2];
                    string str = reader.Trim(new char[] { '=' });
                    char[] chrArray = new char[] { '}' };
                    leaderInfo.ID = int.Parse(str.Trim(chrArray).Trim().ToString(), CultureInfo.InvariantCulture);
                    leaderInfo.add_trait = new List<string>();
                    i++;
                    while (i < array.Length / 3)
                    {
                        string reader2 = array[i, 0];
                        if (reader2.IndexOf("=") > -1 && reader2.ToLower().IndexOf("history") < 0 && array[i, 1].Trim() == "{")
                        {
                            i--;
                            break;
                        }
                        switch (array[i, 0])
                        {
                            case "name =": leaderInfo.name = array[i, 1].Trim();
                                break;
                            case "country =": leaderInfo.country = array[i, 1].Trim();
                                break;
                            case "type =": leaderInfo.type = array[i, 1].Trim();
                                break;
                            case "skill =": leaderInfo.skill = int.Parse(array[i, 1].Trim(), CultureInfo.InvariantCulture);
                                break;
                            case "max_skill =": leaderInfo.max_skill = int.Parse(array[i, 1].Trim(), CultureInfo.InvariantCulture);
                                break;
                            case "loyalty =": leaderInfo.loyalty = decimal.Parse(array[i, 1].Trim(), CultureInfo.InvariantCulture);
                                break;
                            case "picture =": leaderInfo.picture = array[i, 1].Trim();
                                break;
                            case "add_trait =": leaderInfo.add_trait.Add(array[i, 1].Trim());
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    list.Add(leaderInfo);
                }
            }
            return list;
        }
        #endregion

        #region 加载OOB
        /// <summary>
        /// 加载OOB
        /// </summary>
        /// <param name="scenariosStr">剧本</param>
        /// <returns></returns>
        public List<OOBInfo> LoadOOB(string scenariosStr, out string constructionStr)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();
            OOBInfo oobModel = new OOBInfo() { name = "OOB", id = 0 };
            returnList.Add(oobModel);

            string OOBFileFullPath = string.Concat(pathInfo.OOBPath, countryCode, "_", scenariosStr, ".txt");

            string fileStr = GetFileStream(OOBFileFullPath);
            string anotherStr = "";
            constructionStr = "";
            if (fileStr.IndexOf("military_construction") > -1)
            {
                constructionStr = fileStr.Substring(fileStr.IndexOf("military_construction"));
            }
            string replaceStr = fileStr.Replace("\t", " ").Replace("\n", " ").Replace("\r", " ").Replace(" ", "");

            List<string> theatreTextList = SpiltText(replaceStr, "theatre=", out anotherStr);
            if (theatreTextList.Count > 0)
            {
                List<OOBInfo> theatreList = BindTheatre(theatreTextList, oobModel.id);
                returnList.AddRange(theatreList);
            }
            if (anotherStr.ToLower().IndexOf("armygroup=") > -1)
            {
                List<string> armyGroupTextList = SpiltText(anotherStr, "armygroup=", out anotherStr);
                List<OOBInfo> armyGroupList = BindArmyGroup(armyGroupTextList, oobModel.id);
                returnList.AddRange(armyGroupList);
            }
            if (anotherStr.ToLower().IndexOf("army=") > -1)
            {
                List<string> armyTextList = SpiltText(anotherStr, "army=", out anotherStr);
                List<OOBInfo> armyList = BindArmy(armyTextList, oobModel.id);
                returnList.AddRange(armyList);
            }
            if (anotherStr.ToLower().IndexOf("corps=") > -1)
            {
                List<string> corpsTextList = SpiltText(anotherStr, "corps=", out anotherStr);
                List<OOBInfo> corpsList = BindCorps(corpsTextList, oobModel.id);
                returnList.AddRange(corpsList);
            }
            if (anotherStr.ToLower().IndexOf("division=") > -1)
            {
                List<string> divisionTextList = SpiltText(anotherStr, "division=", out anotherStr);
                List<OOBInfo> divisionList = BindDivision(divisionTextList, oobModel.id);
                returnList.AddRange(divisionList);
            }
            if (anotherStr.ToLower().IndexOf("navy=") > -1)
            {
                List<string> navyTextList = SpiltText(anotherStr, "navy=", out anotherStr);
                List<OOBInfo> navyList = BindNavy(navyTextList, oobModel.id);
                returnList.AddRange(navyList);
            }
            if (anotherStr.ToLower().IndexOf("air=") > -1)
            {
                List<string> airTextList = SpiltText(anotherStr, "air=", out anotherStr);
                List<OOBInfo> airList = BindAir(airTextList, oobModel.id);
                returnList.AddRange(airList);
            }
            return returnList;
        }

        #region OOB
        private List<OOBInfo> BindTheatre(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo theatre = new OOBInfo() { id = unitId };

                unitId++;
                string anotherStr = "";

                theatre.name = GetUnitName(str);
                theatre.location = GetAttributeTypeOfNumber(str, "location");
                theatre.leader = GetAttributeTypeOfNumber(str, "leader");
                theatre.armyType = ArmyTypeEnum.Theatre;
                theatre.parentID = parentID;

                returnList.Add(theatre);

                int regimentLastIndex = GetRegimentLastIndex(str);
                List<string> regimentTextList = SpiltText(str.Substring(0, regimentLastIndex), "regiment=", out anotherStr);
                List<OOBInfo> regimentList = BindRegiment(regimentTextList, theatre.id);
                returnList.AddRange(regimentList);
                anotherStr = str.Substring(regimentLastIndex);

                if (anotherStr.ToLower().IndexOf("armygroup=") > -1)
                {
                    List<string> armyGroupTextList = SpiltText(anotherStr, "armygroup=", out anotherStr);
                    List<OOBInfo> armyGroupList = BindArmyGroup(armyGroupTextList, theatre.id);
                    returnList.AddRange(armyGroupList);
                }
                if (anotherStr.ToLower().IndexOf("army=") > -1)
                {
                    List<string> armyTextList = SpiltText(anotherStr, "army=", out anotherStr);
                    List<OOBInfo> armyList = BindArmy(armyTextList, theatre.id);
                    returnList.AddRange(armyList);
                }
                if (anotherStr.ToLower().IndexOf("corps=") > -1)
                {
                    List<string> corpsTextList = SpiltText(anotherStr, "corps=", out anotherStr);
                    List<OOBInfo> corpsList = BindCorps(corpsTextList, theatre.id);
                    returnList.AddRange(corpsList);
                }
                if (anotherStr.ToLower().IndexOf("division=") > -1)
                {
                    List<string> divisionTextList = SpiltText(anotherStr, "division=", out anotherStr);
                    List<OOBInfo> divisionList = BindDivision(divisionTextList, theatre.id);
                    returnList.AddRange(divisionList);
                }
                if (anotherStr.ToLower().IndexOf("navy=") > -1)
                {
                    List<string> navyTextList = SpiltText(anotherStr, "navy=", out anotherStr);
                    List<OOBInfo> navyList = BindNavy(navyTextList, theatre.id);
                    returnList.AddRange(navyList);
                }
                if (anotherStr.ToLower().IndexOf("air=") > -1)
                {
                    List<string> airTextList = SpiltText(anotherStr, "air=", out anotherStr);
                    List<OOBInfo> airList = BindAir(airTextList, theatre.id);
                    returnList.AddRange(airList);
                }
            }
            return returnList;
        }

        private List<OOBInfo> BindArmyGroup(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo armyGroup = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;

                armyGroup.name = GetUnitName(str);
                armyGroup.location = GetAttributeTypeOfNumber(str, "location");
                armyGroup.leader = GetAttributeTypeOfNumber(str, "leader");
                armyGroup.armyType = ArmyTypeEnum.ArmyGroup;
                armyGroup.parentID = parentID;

                int regimentLastIndex = GetRegimentLastIndex(str);
                List<string> regimentTextList = SpiltText(anotherStr.Substring(0, regimentLastIndex), "regiment=", out anotherStr);

                returnList.Add(armyGroup);
                List<OOBInfo> regimentList = BindRegiment(regimentTextList, armyGroup.id);
                returnList.AddRange(regimentList);
                anotherStr = str.Substring(regimentLastIndex);

                if (anotherStr.ToLower().IndexOf("army=") > -1)
                {
                    List<string> armyTextList = SpiltText(anotherStr, "army=", out anotherStr);
                    List<OOBInfo> armyList = BindArmy(armyTextList, armyGroup.id);
                    returnList.AddRange(armyList);
                }
                if (anotherStr.ToLower().IndexOf("corps=") > -1)
                {
                    List<string> corpsTextList = SpiltText(anotherStr, "corps=", out anotherStr);
                    List<OOBInfo> corpsList = BindCorps(corpsTextList, armyGroup.id);
                    returnList.AddRange(corpsList);
                }
                if (anotherStr.ToLower().IndexOf("division=") > -1)
                {
                    List<string> divisionTextList = SpiltText(anotherStr, "division=", out anotherStr);
                    List<OOBInfo> divisionList = BindDivision(divisionTextList, armyGroup.id);
                    returnList.AddRange(divisionList);
                }
                if (anotherStr.ToLower().IndexOf("navy=") > -1)
                {
                    List<string> navyTextList = SpiltText(anotherStr, "navy=", out anotherStr);
                    List<OOBInfo> navyList = BindNavy(navyTextList, armyGroup.id);
                    returnList.AddRange(navyList);
                }
                if (anotherStr.ToLower().IndexOf("air=") > -1)
                {
                    List<string> airTextList = SpiltText(anotherStr, "air=", out anotherStr);
                    List<OOBInfo> airList = BindAir(airTextList, armyGroup.id);
                    returnList.AddRange(airList);
                }
            }
            return returnList;
        }

        private List<OOBInfo> BindArmy(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo army = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;

                army.name = GetUnitName(str);
                army.location = GetAttributeTypeOfNumber(str, "location");
                army.leader = GetAttributeTypeOfNumber(str, "leader");
                army.armyType = ArmyTypeEnum.Army;
                army.parentID = parentID;

                int regimentLastIndex = GetRegimentLastIndex(str);
                List<string> regimentTextList = SpiltText(anotherStr.Substring(0, regimentLastIndex), "regiment=", out anotherStr);

                returnList.Add(army);
                List<OOBInfo> regimentList = BindRegiment(regimentTextList, army.id);
                returnList.AddRange(regimentList);
                anotherStr = str.Substring(regimentLastIndex);

                if (anotherStr.ToLower().IndexOf("corps=") > -1)
                {
                    List<string> corpsTextList = SpiltText(anotherStr, "corps=", out anotherStr);
                    List<OOBInfo> corpsList = BindCorps(corpsTextList, army.id);
                    returnList.AddRange(corpsList);
                }
                if (anotherStr.ToLower().IndexOf("division=") > -1)
                {
                    List<string> divisionTextList = SpiltText(anotherStr, "division=", out anotherStr);
                    List<OOBInfo> divisionList = BindDivision(divisionTextList, army.id);
                    returnList.AddRange(divisionList);
                }
                if (anotherStr.ToLower().IndexOf("navy=") > -1)
                {
                    List<string> navyTextList = SpiltText(anotherStr, "navy=", out anotherStr);
                    List<OOBInfo> navyList = BindNavy(navyTextList, army.id);
                    returnList.AddRange(navyList);
                }
                if (anotherStr.ToLower().IndexOf("air=") > -1)
                {
                    List<string> airTextList = SpiltText(anotherStr, "air=", out anotherStr);
                    List<OOBInfo> airList = BindAir(airTextList, army.id);
                    returnList.AddRange(airList);
                }


            }
            return returnList;
        }

        private List<OOBInfo> BindCorps(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo corps = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;
                corps.name = GetUnitName(str);
                corps.location = GetAttributeTypeOfNumber(str, "location");
                corps.leader = GetAttributeTypeOfNumber(str, "leader");
                corps.armyType = ArmyTypeEnum.Corps;
                corps.parentID = parentID;

                int regimentLastIndex = GetRegimentLastIndex(str);
                List<string> regimentTextList = SpiltText(anotherStr.Substring(0, regimentLastIndex), "regiment=", out anotherStr);
                returnList.Add(corps);
                List<OOBInfo> regimentList = BindRegiment(regimentTextList, corps.id);
                returnList.AddRange(regimentList);
                anotherStr = str.Substring(regimentLastIndex);
                if (anotherStr.ToLower().IndexOf("division=") > -1)
                {
                    List<string> divisionTextList = SpiltText(anotherStr, "division=", out anotherStr);
                    List<OOBInfo> divisionList = BindDivision(divisionTextList, corps.id);
                    returnList.AddRange(divisionList);
                }
                if (anotherStr.ToLower().IndexOf("navy=") > -1)
                {
                    List<string> navyTextList = SpiltText(anotherStr, "navy=", out anotherStr);
                    List<OOBInfo> navyList = BindNavy(navyTextList, corps.id);
                    returnList.AddRange(navyList);
                }
                if (anotherStr.ToLower().IndexOf("air=") > -1)
                {
                    List<string> airTextList = SpiltText(anotherStr, "air=", out anotherStr);
                    List<OOBInfo> airList = BindAir(airTextList, corps.id);
                    returnList.AddRange(airList);
                }
            }
            return returnList;
        }

        private List<OOBInfo> BindDivision(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo division = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;

                division.name = GetUnitName(str);
                division.location = GetAttributeTypeOfNumber(str, "location");
                division.leader = GetAttributeTypeOfNumber(str, "leader");
                division.armyType = ArmyTypeEnum.Division;
                division.parentID = parentID;
                division.is_reserve = GetIsReserve(str);

                List<string> regimentTextList = SpiltText(str, "regiment=", out anotherStr);
                List<OOBInfo> regimentList = BindRegiment(regimentTextList, division.id);


                returnList.Add(division);
                returnList.AddRange(regimentList);
            }
            return returnList;
        }

        private List<OOBInfo> BindRegiment(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo regiment = new OOBInfo() { id = unitId };
                unitId++;

                regiment.name = GetUnitName(str);
                regiment.experience = GetAttributeTypeOfNumber(str, "experience");
                regiment.type = GetUnitType(str);
                regiment.historical_model = GetAttributeTypeOfNumber(str, "historical_model");
                regiment.armyType = ArmyTypeEnum.Regiment;
                regiment.parentID = parentID;
                returnList.Add(regiment);
            }
            return returnList;
        }

        private List<OOBInfo> BindNavy(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo navy = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;

                navy.name = GetUnitName(str);
                navy.location = GetAttributeTypeOfNumber(str, "location");
                navy.leader = GetAttributeTypeOfNumber(str, "leader");
                navy.baseID = GetAttributeTypeOfNumber(str, "base");
                navy.armyType = ArmyTypeEnum.Navy;
                navy.parentID = parentID;

                List<string> shipTextList = SpiltText(str, "ship=", out anotherStr);
                List<OOBInfo> shipList = BindShip(shipTextList, navy.id);


                returnList.Add(navy);
                returnList.AddRange(shipList);
            }
            return returnList;
        }

        private List<OOBInfo> BindShip(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();
            List<OOBInfo> airList = new List<OOBInfo>();
            foreach (string str in list)
            {
                OOBInfo ship = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;
                bool isHaveChildAir = str.IndexOf("air=") > -1;
                if (isHaveChildAir)
                {
                    List<string> airTextList = SpiltText(str, "air=", out anotherStr);
                    airList.AddRange(BindAir(airTextList, ship.id));
                }
                ship.name = GetUnitName(anotherStr);
                ship.experience = GetAttributeTypeOfNumber(anotherStr, "experience");
                ship.type = GetUnitType(anotherStr);
                ship.historical_model = GetAttributeTypeOfNumber(anotherStr, "historical_model");
                ship.armyType = ArmyTypeEnum.Ship;
                ship.parentID = parentID;
                returnList.Add(ship);
                if (isHaveChildAir)
                {
                    returnList.AddRange(airList);
                }
            }
            return returnList;
        }

        private List<OOBInfo> BindAir(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo air = new OOBInfo() { id = unitId };
                unitId++;
                string anotherStr = str;

                air.name = GetUnitName(str);
                air.location = GetAttributeTypeOfNumber(str, "location");
                air.leader = GetAttributeTypeOfNumber(str, "leader");
                air.baseID = GetAttributeTypeOfNumber(str, "base");
                air.armyType = ArmyTypeEnum.Air;
                air.parentID = parentID;

                List<string> wingTextList = SpiltText(str, "wing=", out anotherStr);
                List<OOBInfo> wingList = BindWing(wingTextList, air.id);


                returnList.Add(air);
                returnList.AddRange(wingList);
            }
            return returnList;
        }

        private List<OOBInfo> BindWing(List<string> list, int parentID)
        {
            List<OOBInfo> returnList = new List<OOBInfo>();

            foreach (string str in list)
            {
                OOBInfo wing = new OOBInfo() { id = unitId };
                unitId++;

                wing.name = GetUnitName(str);
                wing.experience = GetAttributeTypeOfNumber(str, "experience");
                wing.type = GetUnitType(str);
                wing.historical_model = GetAttributeTypeOfNumber(str, "historical_model");
                wing.armyType = ArmyTypeEnum.Wing;
                wing.parentID = parentID;
                returnList.Add(wing);
            }
            return returnList;
        }

        private int GetRegimentLastIndex(string str)
        {
            int armyGroupStartIndex = str.ToLower().IndexOf("armygroup=");
            int armyStartIndex = str.ToLower().IndexOf("army=");
            int corpsStartIndex = str.ToLower().IndexOf("corps=");
            int divisionStartIndex = str.ToLower().IndexOf("division=");
            int navyStartIndex = str.ToLower().IndexOf("navy=");
            int airStartIndex = str.ToLower().IndexOf("air=");
            int regimentStartIndex = str.ToLower().IndexOf("regiment=");

            List<int> startIndexList = new List<int>() { armyGroupStartIndex, armyStartIndex, corpsStartIndex, divisionStartIndex, navyStartIndex, airStartIndex };
            int regimentLastIndex = startIndexList.FindAll(e => e > -1).Count > 0 ? startIndexList.FindAll(e => e > -1).Min() : str.Length;

            return regimentLastIndex;
        }

        #region 通用方法
        private List<string> SpiltText(string str, string matchStr, out string anotherStr)
        {
            int stratIndex;
            int leftBraceStratIndex = 0;
            int leftBraceNum = 0;
            int rightBraceNum = 0;
            int rightBraceStratIndex = 0;
            List<string> returnList = new List<string>();
            List<int> startIndexList = new List<int>();
            List<int> endIndexList = new List<int>();
            anotherStr = str;

            if (str.ToLower().IndexOf(matchStr) > -1)
            {
                stratIndex = str.ToLower().IndexOf(matchStr);
                if (stratIndex >= 0)
                {
                    leftBraceStratIndex = str.IndexOf("{", stratIndex);
                    leftBraceNum = 1;

                    char[] textCharArray = str.ToCharArray(0, str.Length);

                    for (int i = leftBraceStratIndex + 1; i < textCharArray.Length; i++)
                    {
                        bool isOk = false;
                        if (textCharArray[i] == '{' && i >= stratIndex)
                        {
                            leftBraceNum += 1;
                            isOk = true;
                        }
                        else if (textCharArray[i] == '}' && i >= stratIndex)
                        {
                            rightBraceNum += 1;
                            isOk = true;
                        }

                        if (leftBraceNum == rightBraceNum && isOk)
                        {
                            rightBraceStratIndex = i;
                            //returnList.Add(str.Substring(leftBraceStratIndex+1, (rightBraceStratIndex - leftBraceStratIndex-1)));
                            returnList.Add(str.Remove(rightBraceStratIndex).Remove(0, leftBraceStratIndex + 1));
                            startIndexList.Add(stratIndex);
                            endIndexList.Add(rightBraceStratIndex + 1);

                            stratIndex = str.ToLower().IndexOf(matchStr, rightBraceStratIndex);
                            if (stratIndex > -1)
                            {
                                leftBraceStratIndex = str.IndexOf("{", stratIndex);
                                isOk = false;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    for (int startNum = startIndexList.Count - 1; startNum >= 0; startNum--)
                    {
                        anotherStr = anotherStr.Remove(startIndexList[startNum], endIndexList[startNum] - startIndexList[startNum]);
                    }
                }
            }
            return returnList;
        }

        private string GetUnitName(string str)
        {
            int index = str.ToLower().IndexOf("name");
            if (index < 0)
                return "";

            return str.Substring(index).Split('"')[1];
        }

        private string GetAttributeTypeOfNumber(string str, string attributeName)
        {
            int index = str.ToLower().IndexOf(attributeName);
            if (index < 0)
                return "";

            Regex reg = new Regex(@"[0-9][0-9,.]*");
            MatchCollection mc = reg.Matches(str.Substring(index));
            if (mc.Count == 0)
                return "";

            return mc[0].Value;
        }

        private string GetUnitType(string str)
        {
            int index = str.ToLower().IndexOf("type");
            if (index < 0)
                return "";

            foreach (string type in unitTypeList)
            {
                if (type.ToLower().IndexOf("transport") > -1)
                {
                    if (str.ToLower().Contains(string.Concat("=", "transport_ship")))
                        return "transport_ship";
                    if (str.ToLower().IndexOf("transport_plane") > -1)
                        return "transport_plane";
                }
                if (type.ToLower().IndexOf("waffenss_brigade") > -1)
                {
                    if (str.ToLower().Contains(string.Concat("=", "waffen_brigade")))
                        return "waffen_brigade";
                }
                if (str.ToLower().Contains(string.Concat("=", type)))
                    return type;
            }
            return "";
        }

        private bool GetIsReserve(string str)
        {
            int index = str.ToLower().IndexOf("is_reserve");
            if (index < 0)
                return false;

            return true;
        }

        /// <summary>
        /// 获取单位类型，存入unitTypeList
        /// </summary>
        private void SetUnitType()
        {
            string unitsTypePath = pathInfo.unitPath;
            string[] files = Directory.GetFiles(unitsTypePath);
            foreach (string file in files)
            {
                if (file.Split('.')[1].Equals("txt"))
                {
                    string type = file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0];
                    unitTypeList.Add(type);
                }
            }
        }
        #endregion

        #endregion
        #endregion

        #region 加载军队类型
        public List<MilitaryTypeInfo> LoadMilitaryType(LocalisationInfo localisationModel, string countryCode)
        {
            List<MilitaryTypeInfo> militaryTypeList = new List<MilitaryTypeInfo>();
            string[] files = Directory.GetFiles(pathInfo.unitPath);
            //装备型号文件的类型（arm,ships planes）
            string unitModelFileType = "";
            foreach (string file in files)
            {
                if (file.Split('.')[1].Equals("txt"))
                {
                    string type = file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0];
                    if (type.ToLower() == "transport")
                    {
                        type = "transport_ship";
                    }
                    if (type.ToLower().IndexOf("waffenss_brigade") > -1)
                    {
                        type = "waffen_brigade";
                    }
                    UnitInfo unitInfo = localisationModel.UnitList.Find(u => u.code.ToLower() == type.ToLower());
                    if (unitInfo == null)
                        continue;
                    MilitaryTypeInfo militaryTypeInfo = new MilitaryTypeInfo();
                    militaryTypeInfo.name = unitInfo.name;
                    militaryTypeInfo.type = unitInfo.code;
                    //类型所属的军种
                    string typeInfoStr = GetFileStream(file);
                    if (typeInfoStr.Replace(" ", "").ToLower().IndexOf("type=land") > -1)
                    {
                        militaryTypeInfo.bigType = "land";
                        unitModelFileType = "Arm";
                    }
                    else if (typeInfoStr.Replace(" ", "").ToLower().IndexOf("type=naval") > -1)
                    {
                        militaryTypeInfo.bigType = "naval";
                        unitModelFileType = "Ships";
                    }
                    else if (typeInfoStr.Replace(" ", "").ToLower().IndexOf("type=air") > -1)
                    {
                        militaryTypeInfo.bigType = "air";
                        unitModelFileType = "Planes";
                    }

                    #region 获取全部汉化过的型号
                    string modelLocalisationPath = RetuenPath(string.Concat(pathInfo.localisationPath, "models.csv"));


                    List<LocalUnitModelInfo> localUnitModelList = new List<LocalUnitModelInfo>();
                    using (CsvReader csv =
                        new CsvReader(new StreamReader(modelLocalisationPath, Encoding.Default), true))
                    {
                        int i = 0;
                        while (csv.ReadNextRecord())
                        {
                            string modelStr = csv[0];
                            LocalUnitModelInfo localUnitModelInfo = new LocalUnitModelInfo();
                            localUnitModelInfo.code = modelStr.Split(';')[0];
                            localUnitModelInfo.name = modelStr.Split(';')[1];
                            localUnitModelList.Add(localUnitModelInfo);
                            i++;
                        }
                    }
                    List<string> modelPathList = ReturnModelPath(string.Concat(pathInfo.unitPath, "models\\", countryCode, " - ", unitModelFileType, ".txt"));
                    string modelFileTFHPath = modelPathList[0];
                    string modelOraginalFilePath = modelPathList[1];


                    string modelTFHFileStr = GetFileStream(modelFileTFHPath);
                    List<string> modelNumList = GetValueListByAttributeName(modelTFHFileStr, type);
                    if (!string.IsNullOrEmpty(modelOraginalFilePath) && modelNumList == null)
                    {
                        if (File.Exists(modelOraginalFilePath))
                        {
                            string modelOraginalFileStr = GetFileStream(modelOraginalFilePath);
                            modelNumList = GetValueListByAttributeName(modelOraginalFileStr, type);
                        }
                    }
                    List<UnitModelInfo> list = new List<UnitModelInfo>();
                    if (modelNumList != null)
                    {
                        list = GetDefaultModel(unitInfo.name);
                        foreach (string modelNumStr in modelNumList)
                        {
                            UnitModelInfo m = list.Find(mc => mc.modelNum == modelNumStr);
                            //默认型号
                            List<string> defaultYear = new List<string>();
                            defaultYear = new XmlHelper().GetXmlChildValue("DefaultModelYear");
                            string ContainsStr = string.Concat(countryCode, "_", type, "_", modelNumStr);
                            LocalUnitModelInfo localUnitModelInfo2 = localUnitModelList.Find(l => l.code.ToLower().Contains(ContainsStr.ToLower()));
                            //if (localUnitModelInfo2 == null)
                            //{
                            //    if (Convert.ToInt32(modelNumStr) < defaultYear.Count)
                            //    {
                            //        //默认型号填充
                            //        m.name = defaultYear[Convert.ToInt32(modelNumStr)] + "年_" + unitInfo.name;
                            //    }
                            //    else
                            //    {
                            //        //不存在默认型号，拼接字符串
                            //        m.name = ContainsStr;
                            //    }
                            //}
                            //else
                            if (localUnitModelInfo2 != null)
                            {
                                m.name = localUnitModelInfo2.name;
                            }
                            //m.modelNum = modelNumStr;
                            //list.Add(m);
                        }
                    }
                    else
                    {
                        //默认型号
                        list = GetDefaultModel(unitInfo.name);
                        //List<string> defaultYear = new List<string>();
                        //defaultYear = new XmlHelper().GetXmlChildValue("DefaultModelYear");
                        //for (int defaultModelNum = 0; defaultModelNum < defaultYear.Count; defaultModelNum++)
                        //{
                        //    UnitModelInfo defaultUnitModelInfo = new UnitModelInfo();
                        //    defaultUnitModelInfo.name = defaultYear[defaultModelNum] + "年_" + unitInfo.name;
                        //    defaultUnitModelInfo.modelNum = defaultModelNum.ToString();
                        //    list.Add(defaultUnitModelInfo);
                        //}
                    }
                    militaryTypeInfo.unitModelList = list;
                    militaryTypeList.Add(militaryTypeInfo);

                    #endregion

                }
            }
            return militaryTypeList;
        }
        #endregion

        #region 通用方法

        private string GetFileStream(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            FileInfo fileInfo = new FileInfo(path);
            //创建文件流，path为文本文件路径  
            StreamReader file = new StreamReader(path, Encoding.Default);
            string fileText = file.ReadToEnd();
            file.Dispose();
            return fileText;
        }

        private static int getfilelength(string path)
        {
            int num = 0;
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    while (!streamReader.EndOfStream)
                    {
                        reader = streamReader.ReadLine();
                        num++;
                    }
                }
            }
            return num;
        }

        private void sortfile(string path, ref string[,] array)
        {
            int vtemp = 0;
            string reader;
            string reader2;
            int stringlength;
            string xtemp;
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    while (!streamReader.EndOfStream)
                    {
                        reader = streamReader.ReadLine();
                        stringlength = reader.IndexOf('=');
                        reader2 = reader.Substring(stringlength + 1);
                        if (reader != "" && reader.Length > stringlength + 1)
                        {
                            reader = reader.Remove(stringlength + 1);
                        }
                        xtemp = Convert.ToString(stringlength - reader.Trim().Length + 1);
                        array[vtemp, 0] = reader.Trim();
                        array[vtemp, 1] = reader2.Replace("\"", "");
                        if (array[vtemp, 1] != null && array[vtemp, 1].Contains<char>('#') && array[vtemp, 0].Length > 0)
                        {
                            array[vtemp, 1] = array[vtemp, 1].Remove(array[vtemp, 1].IndexOf('#'));
                        }
                        array[vtemp, 2] = xtemp;
                        vtemp = vtemp + 1;
                    }
                }
            }
        }

        /// <summary>
        /// 传入文件路径判断是否存在，如果不存在判断移除TFH文件夹名字
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string RetuenPath(string path)
        {
            string returnPath = path;
            if (!File.Exists(path))
            {
                if (!File.Exists(returnPath) && path.ToLower().IndexOf("tfh") > -1)
                {
                    returnPath = path.Remove(path.ToLower().IndexOf("tfh"), 4);
                }

            }
            return returnPath;
        }

        private List<string> ReturnModelPath(string path)
        {
            List<string> returnList = new List<string>();
            string modelTFHFilePath = "";   //TFH路径
            string modelOraginalFilePath = "";//
            //判断是否含有TFH
            if (modelTFHFilePath.IndexOf("tfh") > -1)
            {
                //在路径里移除TFH
                modelOraginalFilePath = modelTFHFilePath.Remove(modelTFHFilePath.IndexOf("tfh"), 4);
            }

            returnList.Add(modelTFHFilePath);
            returnList.Add(modelOraginalFilePath);
            return returnList;
        }

        /// <summary>
        /// 获取默认装备型号
        /// </summary>
        /// <returns></returns>
        private List<UnitModelInfo> GetDefaultModel(string name)
        {
            List<UnitModelInfo> list = new List<UnitModelInfo>();

            List<string> defaultYear = new List<string>();
            defaultYear = new XmlHelper().GetXmlChildValue("DefaultModelYear");
            for (int defaultModelNum = 0; defaultModelNum < defaultYear.Count; defaultModelNum++)
            {
                UnitModelInfo defaultUnitModelInfo = new UnitModelInfo();
                defaultUnitModelInfo.name = defaultYear[defaultModelNum] + "年_" + name;
                defaultUnitModelInfo.modelNum = defaultModelNum.ToString();
                list.Add(defaultUnitModelInfo);
            }
            return list;
        }
        #endregion

        #region 根据传入的属性名获取值，类型为数字的
        /// <summary>
        /// 根据传入的属性名获取值，类型为数字的
        /// </summary>
        /// <param name="str"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        private List<string> GetValueListByAttributeName(string str, string attributeName)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(attributeName))
            {
                return null;
            }
            List<string> returnList = new List<string>();
            string replaceStr = str.Replace(" ", "");
            int index = replaceStr.ToLower().IndexOf(attributeName);
            if (index < 0)
                return null;

            Regex reg = new Regex(@"\W" + attributeName + ".[0-9][0-9,.]*=");
            MatchCollection mc = reg.Matches(string.Concat(" ", replaceStr.Substring(index)));
            if (mc.Count == 0)
                return null;
            for (int i = 0; i < mc.Count; i++)
            {
                Regex valueReg = new Regex(@"[0-9][0-9,.]*");
                MatchCollection mcValue = valueReg.Matches(mc[i].Value);
                returnList.Add(mcValue[0].Value);
            }
            return returnList;
        }
        #endregion

        #region 加载将领技能
        public List<LeaderTraitInfo> LoadTraits(List<UnitInfo> localisationModelList)
        {
            List<LeaderTraitInfo> list = new List<LeaderTraitInfo>();
            string traitPath = RetuenPath(pathInfo.leadertraitsPath);

            this.vtemp = getfilelength(traitPath);
            this.leaderarray = new string[this.vtemp, 3];
            sortfile(traitPath, ref this.leaderarray);
            list = fillLeaderTraitsfields(this.leaderarray, localisationModelList);
            return list;
        }
        private List<LeaderTraitInfo> fillLeaderTraitsfields(string[,] array, List<UnitInfo> localisationModelList)
        {
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            string reader;
            List<LeaderTraitInfo> list = new List<LeaderTraitInfo>();
            for (int i = 0; i < array.Length / 3; i++)
            {
                reader = array[i, 0];
                if (!reader.StartsWith("#") && array[i, 2] == "0" && reader.Length > 0)
                {
                    LeaderTraitInfo leaderTraitInfo = new LeaderTraitInfo();
                    object[] objArray = new object[2];
                    string str = reader.Trim(new char[] { '=' });
                    char[] chrArray = new char[] { '}' };
                    leaderTraitInfo.traitCode = str.Trim(chrArray).Trim().ToString();
                    UnitInfo unitInfo = localisationModelList.FindLast(l => l.code == leaderTraitInfo.traitCode);
                    leaderTraitInfo.traitName = unitInfo == null ? str.Trim(chrArray).Trim().ToString() : unitInfo.name;
                    list.Add(leaderTraitInfo);
                }
            }
            return list;
        }
        #endregion
    }
}
