using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS_DataGridView_CheckBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Product Price";

            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridView1.Rows.Add(row);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Check Data";
            chk.Name = "chk";
            dataGridView1.Rows[2].Cells[3].Value = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //http://stackoverflow.com/questions/7916919/adding-a-button-to-a-winforms-datagridview
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            for (int j = 0; j < 10; j++)
            {
                dt.Rows.Add("");
            }
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].Width = 200;

            /*
             * First method : Convert to an existed cell type such ComboBox cell,etc
             */

            DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();
            ComboBoxCell.Items.AddRange(new string[] { "aaa", "bbb", "ccc" });
            this.dataGridView1[0, 0] = ComboBoxCell;
            this.dataGridView1[0, 0].Value = "bbb";

            DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
            this.dataGridView1[0, 1] = TextBoxCell;
            this.dataGridView1[0, 1].Value = "some text";

            DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
            CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1[0, 2] = CheckBoxCell;
            this.dataGridView1[0, 2].Value = true;

            /*
             * Second method : Add control to the host in the cell
             */
            DateTimePicker dtp = new DateTimePicker();
            dtp.Value = DateTime.Now.AddDays(-10);
            //add DateTimePicker into the control collection of the DataGridView
            this.dataGridView1.Controls.Add(dtp);
            //set its location and size to fit the cell
            dtp.Location = this.dataGridView1.GetCellDisplayRectangle(0, 3, true).Location;
            dtp.Size = this.dataGridView1.GetCellDisplayRectangle(0, 3, true).Size;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15);//欄位字體//https://vectus.wordpress.com/2011/03/20/datagridview-cell-%E5%8F%8A-header-%E5%AD%97%E5%9E%8B-%E5%8F%8A-%E5%A4%A7%E5%B0%8F-%E6%8E%A7%E5%88%B6/
            //https://msdn.microsoft.com/zh-tw/library/z2akwyy7(v=vs.110).aspx
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            //https://msdn.microsoft.com/zh-tw/library/system.windows.forms.datagridviewbuttoncell(v=vs.110).aspx
            dataGridView1.ReadOnly = true;//禁止編輯
            dataGridView1.AllowUserToAddRows = false;//刪除空白列//http://www.programmer-club.com.tw/showSameTitleN/csharp/5354.html
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Product Price";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//欄位標題置中//https://social.msdn.microsoft.com/Forums/zh-TW/9c555078-d4e9-44b2-a430-ffd92d237314/vb2008-datagridview?forum=232
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowTemplate.Height = 50;//設定高度//http://www.programmer-club.com.tw/ShowSameTitleN/csharp/9183.html
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;


            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridView1.Rows.Add(row);
            
            DataGridViewButtonColumn buttonColumn =new DataGridViewButtonColumn();
            buttonColumn.Width = 200;
            buttonColumn.HeaderText = "按鈕";
            buttonColumn.Name = "Status Request";
            buttonColumn.Text = "Request Status";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
            // Add a CellClick handler to handle clicks in the button column.
            dataGridView1.CellClick +=new DataGridViewCellEventHandler(dataGridView1_CellClick);

            /*
            //http://csharp.net-informations.com/datagridview/csharp-datagridview-image.htm
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image image = Image.FromFile("Image Path");
            img.Image = image;
            dataGridView1.Columns.Add(img);
            img.HeaderText = "Image";
            img.Name = "img"; 
            */

        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=dataGridView1.Columns["Status Request"].Index) return;

            // Retrieve the Employee object from the "Assigned To" cell.
            String Strbuf = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();//抓取數值
            MessageBox.Show(Strbuf);
        }

        public DataGridViewColumnSortMode NotSortable { get; set; }

        private void button4_Click(object sender, EventArgs e)
        {
            //DataGridView init start
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 15);//欄位字體//https://vectus.wordpress.com/2011/03/20/datagridview-cell-%E5%8F%8A-header-%E5%AD%97%E5%9E%8B-%E5%8F%8A-%E5%A4%A7%E5%B0%8F-%E6%8E%A7%E5%88%B6/
            //https://msdn.microsoft.com/zh-tw/library/z2akwyy7(v=vs.110).aspx
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
            //dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
            //dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            //https://msdn.microsoft.com/zh-tw/library/system.windows.forms.datagridviewbuttoncell(v=vs.110).aspx
            //dataGridView1.ReadOnly = true;//禁止編輯
            dataGridView1.AllowUserToAddRows = false;//刪除空白列//http://www.programmer-club.com.tw/showSameTitleN/csharp/5354.html
            //dataGridView1.ColumnCount = 4;
            //dataGridView1.Columns[0].Name = "Product ID";
            //dataGridView1.Columns[1].Name = "Product Name";
            //dataGridView1.Columns[2].Name = "Product Price";
            //dataGridView1.Columns[3].Name = "Control Obj";

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//欄位標題置中//https://social.msdn.microsoft.com/Forums/zh-TW/9c555078-d4e9-44b2-a430-ffd92d237314/vb2008-datagridview?forum=232
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowTemplate.Height = 50;//設定高度//http://www.programmer-club.com.tw/ShowSameTitleN/csharp/9183.html
            //dataGridView1.Columns[0].Width = 200;
            //dataGridView1.Columns[1].Width = 200;
            //dataGridView1.Columns[2].Width = 200;
            //dataGridView1.Columns[3].Width = 200;
            //DataGridView init end

            DataTable dt = new DataTable();
            dt.Columns.Add("Product ID");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Product Price");            
            for (int j = 0; j < 10; j++)
            {
                dt.Rows.Add("");
            }
            dataGridView1.DataSource = dt;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Width = 200;
            buttonColumn.HeaderText = "按鈕";
            buttonColumn.Name = "Status Request";
            buttonColumn.Text = "Request Status";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
            // Add a CellClick handler to handle clicks in the button column.
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;

            dataGridView1[0, 0].Value = "01";//y=0,x=0
            dataGridView1[1, 0].Value = "Product 1";//y=1,x=0
            dataGridView1[2, 0].Value = "200000";//y=2,x=0

            dataGridView1[0, 1].Value = "02";
            dataGridView1[1, 1].Value = "Product 2";//y=1,x=0
            DataGridViewComboBoxCell ComboBoxCell_11 = new DataGridViewComboBoxCell();
            ComboBoxCell_11.Items.AddRange(new string[] { "1000", "200", "300" });
            this.dataGridView1[2, 1] = ComboBoxCell_11;
            this.dataGridView1[2, 1].Value = "300";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.Rows.Clear();//只清除資料，欄位還在//https://social.msdn.microsoft.com/Forums/vstudio/en-US/78f584ba-53b4-4272-9d67-5f7fdf0c85ab/how-to-clear-datagridview-all-rows?forum=csharpgeneral
            }
            finally
            {
                dataGridView1.Columns.Clear();//全部清除//https://msdn.microsoft.com/zh-tw/library/system.windows.forms.datagridviewcolumncollection.clear(v=vs.110).aspx
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //*
                if (e.RowIndex == 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[2].Value = "";//寫入數值
                }
                //*/
                dataGridView1.BeginEdit(true);
            }
            else
            {
                dataGridView1.Columns[e.ColumnIndex].ReadOnly = true; 
            }
        }
    }
}
