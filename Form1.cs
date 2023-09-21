using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2001215896_LeGiaKiet_BTLCN1
{
    public partial class Form1 : Form
    {
        double result;
        string opr="";
        //Check giá trị textbox khi click operator để thay đổi text của textbox
        bool check1 = true;
        //Check giá trị của textbox khi click 3 phép toán phức tạp để thay đổi label và text của textbox
        bool check2 = false;
        //Check operator hiện tại để thay đổi dấu (chỉ sử dụng cho +/-)
        bool HistoryBoxCheck = true;
        bool MCheck = true;
        double memoryValue = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            if (check1 == true)
            {
                //Xóa text của textbox tránh trường hợp nhập số mới vẫn dính số cũ
                check1 = false;
                textBox1.Clear();
            }
            else if (check2 == true)
            {
                check2 = false;
                textBox2.Text = "";
                textBox1.Clear();
            }
            
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Thực hiện sự kiện button_Click khi btn1,2,3,4.. được bấm
            btn0.Click += new EventHandler(button_Click);
            btn1.Click += new EventHandler(button_Click);
            btn2.Click += new EventHandler(button_Click);
            btn3.Click += new EventHandler(button_Click);
            btn4.Click += new EventHandler(button_Click);
            btn5.Click += new EventHandler(button_Click);
            btn6.Click += new EventHandler(button_Click);
            btn7.Click += new EventHandler(button_Click);
            btn8.Click += new EventHandler(button_Click);
            btn9.Click += new EventHandler(button_Click);
            // Chọn giá trị mặc định
            //HistoryListBox.SelectedIndex = 0;
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            opr = btnCong.Text;
            result = Double.Parse(textBox1.Text);
            textBox2.Text = result + " " + opr;
            check1 = true;
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            opr = btnTru.Text;
            result = Double.Parse(textBox1.Text);
            textBox2.Text = result + " " + opr;
            check1 = true;
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            opr = btnNhan.Text;
            result = Double.Parse(textBox1.Text);
            textBox2.Text = result + " " + opr;
            check1 = true;
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            opr = btnChia.Text;
            result = Double.Parse(textBox1.Text);
            textBox2.Text = result + " " + opr;
            check1 = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Text="";
        }
        private void btnClearlb_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btnKetqua_Click(object sender, EventArgs e)
        {
           
            //result là giá trị sau khi click operator, textbox1 là giá trị hiện tại
            PhepToan pt = new PhepToan(result,Double.Parse(textBox1.Text));
            //hold lấy giá trị hiện tại trên text box để đưa vào x, 8 + x =
            string hold = textBox1.Text;
            if (opr == "+")
            {
                textBox1.Text=pt.Cong().ToString();
                textBox2.Text = result + " " + opr +" "+ hold + " =";
            }
            else if (opr == "-")
            {
                textBox1.Text = pt.Tru().ToString();
                textBox2.Text = result + " " + opr + " " + hold +" =";
            }
            else if (opr == "x")
            {
                textBox1.Text = pt.Nhan().ToString();
                textBox2.Text = result + " " + opr + " " + hold + " =";
            }
            else if (opr == "/")
            {
                textBox1.Text = pt.Chia().ToString();
                textBox2.Text = result + " " + opr + " " + hold + " =";
            }

            check2 = true;          
            HistoryListBox.Items.Add($"{result}  {opr}  {hold} = {textBox1.Text}");
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            PhepToan pt = new PhepToan(result, Double.Parse(textBox1.Text));
            double a = Double.Parse(textBox1.Text);
            textBox1.Text = pt.Can(a).ToString();
            //Tạo riêng check2 cho 3 phép tính phức tạp để linh hoạt chỉnh sửa label cho từng trường hợp
            textBox2.Text = "sqrt(" + a + ")";
            check2 = true;
        }

        private void buttonBinhPhuong_Click(object sender, EventArgs e)
        {
            PhepToan pt = new PhepToan();
            double a = Double.Parse(textBox1.Text);
            textBox1.Text = pt.BinhPhuong(a).ToString();
            //Tạo riêng check2 cho 3 phép tính phức tạp để linh hoạt chỉnh sửa label cho từng trường hợp
            textBox2.Text =a +" x " +a;
            check2 = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PhepToan pt = new PhepToan();
            double a = Double.Parse(textBox1.Text);
            textBox1.Text = pt.MotPhanX(a).ToString();
            //Tạo riêng check2 cho 3 phép tính phức tạp để linh hoạt chỉnh sửa label cho từng trường hợp
            textBox2.Text = "1 / "+a;
            check2 = true;
        }

        private void btnCham_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text = textBox1.Text + btnCham.Text;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void btnDoidau_Click(object sender, EventArgs e)
        {
            double t = Double.Parse(textBox1.Text);
            textBox1.Text = (-1 * t).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Xóa dấu phẩy trong chuỗi hiện tại
            string text = textBox1.Text.Replace(",", "");
            if (long.TryParse(text, out long number))
            {
                // Định dạng lại chuỗi với dấu phẩy
                textBox1.Text = string.Format("{0:N0}", number);
            }
        }

//////////////////////////////////////Xử lý button History////////////////////////////////////////////////////////////
        private void History_Click(object sender, EventArgs e)
        {
            if (HistoryBoxCheck == true)
            {
                HistoryListBox.Visible = true;
                HistoryBoxCheck = false;
            }
            else if (HistoryBoxCheck == false)
            {
                HistoryListBox.Visible = false;
                HistoryBoxCheck = true;
            }
        }

        private void HistoryListBox_Click(object sender, EventArgs e)
        {
            if (HistoryListBox.SelectedItem != null)
            {
                string selected = HistoryListBox.SelectedItem.ToString();
                //tách chuỗi được chọn trong listbox ra thành 2 phần trước dấu = và sau dấu =
                string[] parts = selected.Split('=');
                //kiểm tra chuỗi có tách thành 2 phần thành công không
                if (parts.Length == 2)
                {
                    string resultString = parts[1].Trim();
                    double result;

                    if (double.TryParse(resultString, out result))
                    {
                        textBox2.Text = parts[0].Trim() + " ="; // Hiển thị biểu thức
                        textBox1.Text = result.ToString(); // Hiển thị kết quả
                    }
                }
            }
        }

        //Tắt HistoryBox khi click chỗ trống
        private void Form1_Click(object sender, EventArgs e)
        {
            //Khi ListBox được mở, check sẽ bằng false nên nếu check=false thì khi click ra ngoài sẽ chuyển check về true và tắt listBox
            if (HistoryBoxCheck == false)
            {
                HistoryListBox.Visible = false;
                HistoryBoxCheck = true;
            }
            if (MCheck == false)
            {
                MListBox.Visible = false;
                MCheck = true;
            }
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////


///////////////////////////////////////////Xử lý button Keep on top/////////////////////////////////////////

        private void KeepOnTop_Click(object sender, EventArgs e)
        {
            // Lấy chiều rộng của màn hình chính
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            // Lấy chiều rộng của form
            int formWidth = this.Width;
            this.TopMost = !this.TopMost;
            if (this.TopMost)
            {
                this.Location = new Point(screenWidth - formWidth, 0);
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////
        
///////////////////////////////////////////Xử lý sự kiện M+ M- ..///////////////////////////////////////////////////////////////
        private void btnMCong_Click(object sender, EventArgs e)
        {
            
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            btnM.Enabled = true;
            memoryValue += Double.Parse(textBox1.Text);
            //Nếu ListBox rỗng thêm đúng một giá trị sau đó + hoặc - dựa theo click
            if (MListBox.Items.Count == 0)
            {
                MListBox.Items.Add(memoryValue.ToString());
            }
            MListBox.Items[0] = memoryValue;
        }

        private void btnMTru_Click(object sender, EventArgs e)
        {
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            btnM.Enabled = true;
            memoryValue -= Double.Parse(textBox1.Text);
            //Nếu ListBox rỗng thêm đúng một giá trị sau đó + hoặc - dựa theo click
            if (MListBox.Items.Count == 0)
            {
                MListBox.Items.Add(memoryValue.ToString());
            }
            MListBox.Items[0] = memoryValue;
        }
        private void btnM_Click(object sender, EventArgs e)
        {
            if (MCheck == true)
            {
                MListBox.Visible = true;
                MCheck = false;
            }
            else if (MCheck == false)
            {
                MListBox.Visible = false;
                MCheck = true;
            }
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            MListBox.Items.RemoveAt(0);
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
