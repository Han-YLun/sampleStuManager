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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {
            //初始化页面显示内容
            label1.Text = "用户名:";
            label2.Text = "密码:";
            button1.Text = "注册";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取用户输入的用户名和密码
            string userName = textBox1.Text;
            string pwd = textBox2.Text;
            //如果用户名密码为空时,提示用户用户名或密码为空
            if (Utils.isEmpty(userName) || Utils.isEmpty(pwd))
            {
                MessageBox.Show("用户名和密码不能为空");
                textBox1.Focus();
                return;
            }

            //判断用户名和密码是否合法
            if (!(Utils.isLegal(userName)))
            {
                MessageBox.Show("用户名的长度应为6—16位");
                return;
            }
                
            if (!(Utils.isLegal(pwd)))
            {
                MessageBox.Show("密码的长度应为6—16位");
                return;
            }

            //判断数据库中是否含有此用户名
            for(int i=0;i<Common.users.Count;i++)
            {
                if(Common.users[i] != null)
                {
                    //如果输入的用户名和文本中的任意一个用户相同,则用户名存在
                    if (Common.users[i].UserName == userName)
                    {
                        MessageBox.Show("此用户名已存在！");
                        return;
                    }
                }
                
            }
            //将用户名和密码写入文本中
            User user = new User(userName,pwd);
            //通过分隔符'-'写入文本
            string s = userName+"-" + pwd;
            Utils.addUser(s);
            MessageBox.Show("注册成功,将跳转到登录页面！");

            //注册成功,注册的用户保存下来
            Common.registerUser.UserName = userName;
            Common.registerUser.Pwd = pwd;

            //更新user数组
            Utils.getUser();
            //从注册页面跳转到登录页面
            login l = new login();
            this.Hide();
            l.Show();
        }
        //用户在textBox1按enter键,焦点聚焦在textbox2上面
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }
        //用户在textBox2按enter键,执行注册逻辑
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        
        private void register_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Common._iLogin.ShowDialog();
        }
    }
}
