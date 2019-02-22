using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using infoShow.数据实体类;

namespace infoShow.窗口程序
{
    public partial class search : Form
    {
        private bool isVisible = false;
        public search()
        {
            InitializeComponent();
        }

        private void search_Load(object sender, EventArgs e)
        {
            //获取文本中全部学生的信息
            Utils.getStudent();
            //页面初始化时,控件设置为不可编辑,并且不可见
            setWidget();
            setIsVisible();
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

        //使窗体设为可见/不可见
        public void setIsVisible()
        {
            textBox1.Visible = !textBox1.Visible;
            textBox2.Visible = !textBox2.Visible;
            textBox3.Visible = !textBox3.Visible;
            textBox6.Visible = !textBox6.Visible;
            radioButton1.Visible = !radioButton1.Visible;
            radioButton2.Visible = !radioButton2.Visible;
            comboBox2.Visible = !comboBox2.Visible;
            comboBox3.Visible = !comboBox3.Visible;
            comboBox4.Visible = !comboBox4.Visible;
            dateTimePicker1.Visible = !dateTimePicker1.Visible;
            pictureBox1.Visible = !pictureBox1.Visible;

            label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label4.Visible = !label4.Visible;
            label5.Visible = !label5.Visible;
            label6.Visible = !label6.Visible;
            label7.Visible = !label7.Visible;
            label8.Visible = !label8.Visible;
            label9.Visible = !label9.Visible;
            label10.Visible = !label10.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            string school_id = textBox4.Text.Trim();
            if(Utils.isEmpty(school_id))
            {
                MessageBox.Show("学号不能为空!!!");
                textBox4.Focus();
                return;
            }

            for(int i=0;i<Common.stus.Count;i++)
            {
                if(Common.stus[i].SchoolId == school_id)
                {
                    index = i;
                    break;
                }
            }

            if(index == -1)
            {
                MessageBox.Show("学号不存在,请重新输入!!!");
                textBox4.Clear();
                textBox4.Focus();
                return;
            }

            //如果显示学生的控件未显示,才显示控件并且显示学生信息
            //如果显示学生的控件已显示,才只显示学生信息
            if(!isVisible)
            {
                //学号存在,显示学生的信息
                setIsVisible();
                //显示学生的信息
                showInfoIndex(index);
                isVisible = true;
            }else
                //显示学生的信息
                showInfoIndex(index);

        }

        //显示数据
        public void showInfoIndex(int index)
        {
            //填充第一个用户的数据
            textBox1.Text = Common.stus[index].Name;
            textBox2.Text = Common.stus[index].ID1;
            textBox3.Text = Common.stus[index].Address;
            textBox6.Text = Common.stus[index].SchoolId;

            if (Common.stus[index].Gender == "男")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

            comboBox2.Text = Common.stus[index].Ethnic;
            comboBox3.Text = Common.stus[index].Political;
            comboBox4.Text = Common.stus[index].Major;

            dateTimePicker1.Text = Common.stus[index].Admission_time;
            //加载保存的图片
            //MessageBox.Show(Common.stus[index].FileName);
            pictureBox1.Image = Image.FromFile(Common.stus[index].FileName);
        }

        private void search_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Common._index.ShowDialog();
        }
    }
}
