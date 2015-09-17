using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDevisionName
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate();

            Console.Write("\n继续：1\t\t关闭：2");
            int inputContinue = 0;
            int.TryParse(Console.ReadLine(), out inputContinue);

            switch (inputContinue)
            {
                case 1:
                    Console.Clear();
                    Generate();
                    break;
                case 2:
                    break;

            }
        }

        static void Generate()
        {
            Console.Write("输入生成师类型：");
            string devisionType = Console.ReadLine();

            Console.Write("\n输入生成师数量：");
            int num = 100;
            int.TryParse(Console.ReadLine(), out num);

            Console.Write("\n输入起始番号：");
            int startNum = 0;
            int.TryParse(Console.ReadLine(), out startNum);


            Console.Write("\n正在生成.....");

            StringBuilder sb = new StringBuilder();
            for (int i = startNum; i <= startNum+num; i++)
            {
                if (i != startNum && i % 8 == 0)
                {
                    sb.Append("\n\t\t");
                }
                sb.Append(string.Format("\"国防军第{0}{1}师\"", i, devisionType));
            }

            FileStream fs1 = new FileStream(string.Concat(System.IO.Directory.GetCurrentDirectory(), "GenerateDevision", ".txt"), FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1, Encoding.Default);
            sw.WriteLine(sb.ToString());//开始写入值

            sw.Close();
            fs1.Close();
            //Console.Write("\n" + sb.ToString());

            Console.Write("\n生成完成.....");
        }
    }
}
