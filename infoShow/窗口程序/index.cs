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
using infoShow.窗口程序;
using Microsoft.VisualBasic;

namespace infoShow
{
    public partial class index : Form
    {
        
        public index()
        {
            InitializeComponent();
        }

        //初始化页面的数据
        private void index_Load(object sender, EventArgs e)
        {
            //显示登录进来的用户名
            statusStrip1.Items[0].Text = "当前登录用户名为: " + Common.loginUser.UserName;
            //设置一个定时器,1000ms(1s)刷新一次
            timer1.Interval = 1000;
            //开启定时器
            timer1.Start();
            //显示时间
            statusStrip1.Items[1].Text = "  当前时间为: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        //根据定时器的间隔时间刷新页面数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[1].Text = "  当前时间为: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            信息录入ToolStripMenuItem1_Click(null, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            信息搜索ToolStripMenuItem_Click(null, null);
        }

        private void 信息录入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Common._iAdd.ShowDialog();
        }

        private void 信息查看ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Common._iShows.ShowDialog();
        }

        private void 信息搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Common._search.ShowDialog();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Common._about.ShowDialog();
        }

        private void 注销ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Common._iLogin.ShowDialog();
        }

        private void index_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Utils.exit() == 1)
                e.Cancel = false;
            else
                e.Cancel = true;//退出
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            index_FormClosing(null, null);
        }
    }
}
