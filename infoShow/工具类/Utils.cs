using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infoShow.javabean;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using infoShow.数据实体类;

namespace infoShow
{
    class Utils
    {

        //退出程序,弹出dialog,用户选择确认关闭,返回1
        //选择取消关闭,返回0
        public static int exit()
        {
            DialogResult result = MessageBox.Show("确认关闭吗?",
                "关闭",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            //result为Yes的时候,用户选择了确认关闭,返回1
            if(result == DialogResult.Yes)
            {
                return 1;
            }
            //否则返回0
            return 0;
        }

        //判断字符串是否为空
        public static bool isEmpty(string s)
        {
            if (s == "")
                return true;
            return false;
        }

        //获取到所有的登录和密码信息
        public static void getUser()
        {
            
            //通过Common类中的登录帐号密码的文件地址创建字节读入流
            StreamReader sr = new StreamReader(Common.loginPath);
            //保存每行的数据
            string line;
            //一次读取每行,直至读取到的line为空
            while ((line = sr.ReadLine()) != null)
            {
                //每行为一个用户,用'-'进行分隔
                User u = new User();
                //使用'-'切割,返回一个数组,数组第一个元素为帐号,
                //第二个元素为密码
                u.UserName = split(line, '-')[0];
                u.Pwd = split(line, '-')[1];
                //把每次查询到的用户添加到list<User>中
                Common.users.Add(u);
            }
            //关闭数据流
            sr.Close();

        }

        //向帐号文本中新添一条记录
        public static void addUser(string s)
        {
            //以追加的方式通过登录文件的信息创建一个文件流
            FileStream fs = new FileStream(Common.loginPath, FileMode.Append);
            //创建一个写入流
            StreamWriter sw = new StreamWriter(fs);
            //将传过来的信息写入到文本中
            sw.WriteLine(s);
            //关闭文件流和写入流
            sw.Close();
            fs.Close();
        }

        //获取到所有的学生信息
        public static void getStudent()
        {
            //先清空学生信息中的所有数据
            Common.stus.RemoveRange(0,Common.stus.Count);
            int j = 0;
            //通过Common类中的用户信息的文件地址创建字节读入流
            StreamReader sr = new StreamReader(Common.infoPath);
            //保存每行的数据
            string line;
            //一次读取每行,直至读取到的line为空
            while ((line = sr.ReadLine()) != null)
            {
                //j用来记录每次切割完的下标,
                j = 0;
                //每行都为一个学生的信息
                Student s = new Student();
                //使用'-'切割,返回一个数组
                //数组元素对应的是相应的信息
                string[] info = line.Split('-');

                s.Name = info[j++];
                s.Gender = info[j++];
                s.ID1 = info[j++];
                s.SchoolId = info[j++];
                s.Admission_time = info[j++];
                s.Ethnic = info[j++];
                s.Major = info[j++];
                s.Political = info[j++];
                s.Address = info[j++];
                s.FileName = info[j];
                //把每次查询到的用户添加到list<Student>中
                Common.stus.Add(s);
            }
            //关闭数据流
            sr.Close();
        }

        //向信息文本中新增一条记录
        public static void addInfo(string s)
        {
            //以追加的方式通过登录文件的信息创建一个文件流
            FileStream fs = new FileStream(Common.infoPath, FileMode.Append);
            //创建一个写入流
            StreamWriter sw = new StreamWriter(fs);

            //将传过来的信息写入到文本中
            sw.WriteLine(s);

            //关闭文件流和写入流
            sw.Close();
            fs.Close();
        }

        //切割字符串返回前一个后一个字符
        public static string[] split(string s, char sep)
        {
            string[] result = new string[2];

            result = s.Split(sep);

            return result;
        }

        //判断用户名/密码是否合法
        public static bool isLegal(string s)
        {
            //用户名/密码标准为6-16位长度,并且帐号/密码至少要有数字和字母
            if(s.Length >16 || s.Length<6)
                return false;
            return true;
        }

        //判断是否为身份证号
        public static bool isID(string s)
        {
            //身份证号为18位,通过正则判断是否符合要求
            string pattern = "\\d{17}[0-9a-zA-Z]";
            //符合此要求,返回true,否则返回false
            return Regex.IsMatch(s,pattern);
        }

        //判断用户名是否存在
        public static bool isExistSchoolId(string s)
        {
            getStudent();
            for(int i=0;i<Common.stus.Count;i++)
            {
                if (s == Common.stus[i].SchoolId)
                    return true;
            }
            return false;
        }

        //运行前将所有资料清空
        public static void ceEmpty(string path)
        {
            FileStream fs = new FileStream(path,FileMode.Create);
            fs.Close();
        }
        
    }
}
