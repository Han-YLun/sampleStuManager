using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infoShow.窗口程序
{
    public partial class infoShows : Form
    {
        public infoShows()
        {
            InitializeComponent();
        }

        private void infoShows_Load(object sender, EventArgs e)
        {
            //获取所有的学生信息
             Utils.getStudent();
            //将控件设置为不可编辑
            setWidget();
            //默认显示第一条信息
            showInfoIndex();
            //设置上一个/下一个按钮的状态
            setNextOrPre();
        }


        //使窗体设为不可编辑
        public void setWidget()
        {
            textBox1.Enabled = !textBox1.Enabled;
            textBox2.Enabled = !textBox2.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
            textBox6.Enabled = !textBox6.Enabled;
            radioButton1.Enabled = !radioButton1.Enabled;
            radioButton2.Enabled = !radioButton2.Enabled;
            comboBox2.Enabled = !comboBox2.Enabled;
            comboBox3.Enabled = !comboBox3.Enabled;
            comboBox4.Enabled = !comboBox4.Enabled;
            dateTimePicker1.Enabled = !dateTimePicker1.Enabled;
        }

        //当用户点击上一个按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //如果上一个按钮此时是可以点击的
            if (button2.Enabled)
            {
                //就把显示的内容的索引减一
                --Common.showIndex;
                //显示此时索引的信息
                showInfoIndex();
                //重新设置上一个下一个按钮的可编辑性
                setNextOrPre();
            }
        }

        //设置上一个和下一个按钮是否可以被点击
        public void setNextOrPre()
        {
            //如果是第一个,button2不可点击
            if (Common.showIndex == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            //如果是最后,button3不可点击
            if (Common.showIndex == Common.stus.Count - 1)
            {
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
        }

        //显示数据
        public void showInfoIndex()
        {
            //填充第一个用户的数据
            textBox1.Text = Common.stus[Common.showIndex].Name;
            textBox2.Text = Common.stus[Common.showIndex].ID1;
            textBox3.Text = Common.stus[Common.showIndex].Address;
            textBox6.Text = Common.stus[Common.showIndex].SchoolId;

            if (Common.stus[Common.showIndex].Gender == "男")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            comboBox2.Text = Common.stus[Common.showIndex].Ethnic;
            comboBox3.Text = Common.stus[Common.showIndex].Political;
            comboBox4.Text = Common.stus[Common.showIndex].Major;

            dateTimePicker1.Text = Common.stus[Common.showIndex].Admission_time;
            //加载保存的图片
            //MessageBox.Show(Common.stus[Common.showIndex].FileName);
            pictureBox1.Image = Image.FromFile(Common.stus[Common.showIndex].FileName);
        }

        //当用户点击下一个按钮
        private void button3_Click(object sender, EventArgs e)
        {
            //如果下一个按钮可以点击
            if (button3.Enabled)
            {
                //就把显示的内容的索引加一
                ++Common.showIndex;
                //显示此时索引的信息
                showInfoIndex();
                //重新设置上一个下一个按钮的可编辑性
                setNextOrPre();
            }
        }

        private void infoShows_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Common._index.ShowDialog();
        }
    }
}
