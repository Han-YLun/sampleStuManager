using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infoShow.数据实体类
{
    public class Student
    {
        string name;//姓名
        string gender;//性别
        string ID;//身份证号
        string school_id;//学号
        string admission_time;//入学时间
        string ethnic;//民族
        string major;//录取专业
        string political;//政治面貌
        string address;//家庭住址
        string fileName;//图片名称




        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }


        public string Admission_time
        {
            get
            {
                return admission_time;
            }

            set
            {
                admission_time = value;
            }
        }

        public string Ethnic
        {
            get
            {
                return ethnic;
            }

            set
            {
                ethnic = value;
            }
        }

        public string Major
        {
            get
            {
                return major;
            }

            set
            {
                major = value;
            }
        }

        public string Political
        {
            get
            {
                return political;
            }

            set
            {
                political = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

       
        public string SchoolId
        {
            get
            {
                return school_id;
            }

            set
            {
                school_id = value;
            }
        }
    }
}
