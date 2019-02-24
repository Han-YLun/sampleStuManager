using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using infoShow.javabean;

namespace infoShow
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            //初始化页面需要使用的数据
            initData();
        }

        //初始化数据
        private void initData()
        {
            Utils.getUser();
            //将文本中的用户密码和信息清除掉
            //Utils.ceEmpty(Common.infoPath);
            Utils.ceEmpty(Common.loginPath);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化页面显示内容
            label1.Text = "用户名:";
            label2.Text = "密码:";
            button1.Text = "登录";
            button2.Text = "注册";

            if(Common.registerUser.UserName != "")
            {
                textBox1.Text = Common.registerUser.UserName;
                textBox2.Text = Common.registerUser.Pwd;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //获取用户输入的用户名和密码
            string user = textBox1.Text;
            string pwd = textBox2.Text;
            //如果用户名密码为空时,提示用户用户名或密码为空
            if (Utils.isEmpty(user) || Utils.isEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空");
                textBox1.Focus();
                return;
            }
            //标记用户输入的用户名和密码是否在文本中存在
            int Flag = 0;
            //循环判断用户名和密码是否和用户输入的一样
            for(int i=0;i<Common.users.Count;i++)
            {
                if (Common.users[i] != null)
                {
                    if (Common.users[i].UserName == user && Common.users[i].Pwd == pwd)
                    {
                        Flag = 1;
                        break;
                    }
                }
                
            }
            //当Flag == 1,说明用户名和密码存在且相等
            if(Flag == 1)
            {
                //记录成功的账号和密码
                Common.loginUser.UserName = user;
                Common.loginUser.Pwd = pwd;
                //跳转到index界面
                index info = new index();
                this.Hide();
                info.Show();
            }
            else
            {
                //否则就提示用户用户名或密码错误
                MessageBox.Show("用户名或密码错误");
                //将焦点放在textbox2上面
                textBox2.Focus();
            }
        }

        //用户在textBox1按enter键,焦点聚焦在textbox2上面
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }
        //用户在textBox2按enter键,执行登录逻辑
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //点击button2,跳转到注册页面
        private void button2_Click(object sender, EventArgs e)
        {
            register info = new register();
            this.Hide();
            info.Show();


        }

        //用户点击关闭页面,提示用户是否确认关闭
        //确认的话,e.Cancel = false
        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Utils.exit() == 1)
                e.Cancel = false;
            else
                e.Cancel = true;//退出
        }
    }
}
