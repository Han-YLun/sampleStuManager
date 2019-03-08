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
    public partial class infoAdd : Form
    {
        //用来标记图片是否上传
        public bool isLoad = false;
        //用来保存图片的路径
        string fileName = "";

        public infoAdd()
        {
            InitializeComponent();
        }
      
        private void infoAdd_Load(object sender, EventArgs e)
        {
            //将默认时间设置为当前日期
            dateTimePicker1.Text = DateTime.Now.ToString();
        }

        //用户点击上传照片
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //通过filter过滤掉不是图片的文件
            openFileDialog1.Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif)|*.jpg;*.png;*.jpeg;*.bmp;*.gif";
            //如果用户选择了图片

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //将图片的路径保存赋值给pictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                //将图片保存在项目img文件夹下面
                fileName = openFileDialog1.FileName;
                isLoad = true;
            }
        }

        //当用户点重置
        private void button3_Click_1(object sender, EventArgs e)
        {
            //全部内容清空
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            if (radioButton1.Checked == true)
                radioButton1.Checked = !radioButton1.Checked;
            if (radioButton2.Checked == true)
                radioButton2.Checked = !radioButton2.Checked;

            textBox6.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            dateTimePicker1.Text = DateTime.Now.ToString();
            pictureBox1.Image = infoShow.Properties.Resources.defaultPic;
            isLoad = false;
            fileName = "";
        }

        //用户点击数据提交,提交数据
        private void button2_Click(object sender, EventArgs e)
        {
            //提交数据
            submit();
        }


        //用户提交输入的信息到文本中
        public void submit()
        {
            //健壮性判断
            if (Utils.isEmpty(textBox1.Text))
            {
                MessageBox.Show("姓名不能为空");
                textBox1.Focus();
                return;
            }

            if (!(radioButton1.Checked || radioButton2.Checked))
            {
                MessageBox.Show("性别不能为空");
                return;
            }
            if (Utils.isEmpty(textBox2.Text))
            {
                MessageBox.Show("身份证号不能为空");
                textBox2.Focus();
                return;
            }

            if (!Utils.isID(textBox2.Text))
            {
                MessageBox.Show("身份证号码格式错误,长度应为18位");
                textBox2.Focus();
                return;
            }

            if (Utils.isEmpty(textBox6.Text))
            {
                MessageBox.Show("学号不能为空");
                textBox6.Focus();
                return;
            }



            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("未选择民族");
                comboBox2.Focus();
                return;
            }

            if (comboBox3.SelectedIndex < 0)
            {
                MessageBox.Show("未选择政治面貌");
                comboBox3.Focus();
                return;
            }

            if (Utils.isEmpty(textBox3.Text))
            {
                MessageBox.Show("家庭住址不能为空");
                textBox3.Focus();
                return;
            }

            if(comboBox4.SelectedIndex < 0)
            {
                MessageBox.Show("录取专业不能为空");
                comboBox4.Focus();
                return;
            }


            if (!isLoad)
            {
                MessageBox.Show("图片未上传");
                return;
            }
            //将所有的属性连接起来,并用分隔符'-'连接起来
            string addText = "";
            addText += textBox1.Text + "-";
            if (radioButton1.Checked)
                addText += "男" + "-";
            if (radioButton2.Checked)
                addText += "女" + "-";
            addText += textBox2.Text + "-";
            addText += textBox6.Text + "-";
            addText += dateTimePicker1.Text + "-";
            addText += comboBox2.SelectedItem + "-";
            addText += comboBox4.SelectedItem + "-";
            addText += comboBox3.SelectedItem + "-";
            addText += textBox3.Text + "-";
            addText += fileName;

            //向学生信息中添加一条记录
            Utils.addInfo(addText);
            //提交用户添加成功
            MessageBox.Show("添加成功");

            //文本信息已更新,重新获取文本中的所有信息
            Utils.getStudent();

            //提交成功,清空所有数据
            button3_Click_1(null, null);

        }


        //使窗体设为可编辑/不可编辑
        public void setWidget()
        {
            textBox1.Enabled = !textBox1.Enabled;
            textBox2.Enabled = !textBox2.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
            radioButton1.Enabled = !radioButton1.Enabled;
            radioButton2.Enabled = !radioButton2.Enabled;
            //comboBox1.Enabled = !comboBox1.Enabled;
            comboBox2.Enabled = !comboBox2.Enabled;
            comboBox3.Enabled = !comboBox3.Enabled;
            comboBox4.Enabled = !comboBox4.Enabled;
            dateTimePicker1.Enabled = !dateTimePicker1.Enabled;
        }



        //显示数据
        public void showInfoIndex()
        {
            if (Common.users.Count == 0)
            {
                MessageBox.Show("当前还未录入任何信息！！！");
                return;
            }
            //填充第一个用户的数据
            textBox1.Text = Common.stus[Common.showIndex].Name;
            textBox2.Text = Common.stus[Common.showIndex].ID1;
            textBox3.Text = Common.stus[Common.showIndex].Address;

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

        private void infoAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Common._index.Show();
        }
    }
}
