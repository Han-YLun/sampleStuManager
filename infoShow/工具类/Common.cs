using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infoShow.javabean;
using infoShow.数据实体类;
using System.Collections;
using infoShow.窗口程序;

namespace infoShow
{
    public class Common
    {
        
        //记录用户帐号信息的位置
        public static string loginPath = "loginInfo.txt";
        //记录用户学生信息的位置
        public static string infoPath = "info.txt";
        //记录登录者的信息
        public static User loginUser = new User();
        //记录注册者的信息
        public static User registerUser = new User();
        //保存文本中所有用户账号的信息
        public static List<User> users = new List<User>();
        //保存文本中所有学生信息的信息
        public static List<Student> stus = new List<Student>();
        //记录显示的学生的序号
        public static int showIndex = 0;

        public static infoAdd _iAdd = new infoAdd();//添加学生信息
        public static login _iLogin = new login();//用户登录
        public static infoShows _iShows = new infoShows();//显示学生信息
        public static About _about = new About();//关于软件
        public static search _search = new search();//搜索学生信息
        public static index _index = new index();//搜索学生信息
    }
}
