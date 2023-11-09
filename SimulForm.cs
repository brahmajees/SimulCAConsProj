using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace SimulCAConsProj
{
    public partial class SimulCAConsForm : Form
    {
        public SimulCAConsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SimulCAHeaderRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SimulCADetailRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from SimulCADetailDistRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void btnSave01_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SimulCAHeaderRecord (Record_Identification, File_Identification, " +
                "RTA_Internal_Reference_No, Credit_ISIN, Debit_ISIN, CA_Type, Allotment_Date,Allotment_Allocation_Description," +
                "Execution_Date, Total_Credit_Quantity_Free_Lockin, Total_Debit_Quantity_Free_Lockin, Total_Credit_Quantity_Lockin," +
                "Total_Debit_Quantity_Lockin, Total_number_detail_records, Total_Issued_Amount_Allotment_Allocation_Credit_ISIN," +
                "Total_Paidup_Amount_Allotment_Allocation_Credit_ISIN, Stamp_Duty_Payable,Basis_calculation_Stamp_Duty,MasterUniqNo) " +
                "values (@rec_id, @file_idn, @Rta_irno, @Credit_ISIN, @Debit_ISIN, @Ca_type, @Allot_Date," +
                " @Allotment_Allocation_Description, @Exec_Date, @Total_Credit_Quantity_Free_Lockin, " +
                "@Total_Debit_Quantity_Free_Lockin,@Total_Credit_Quantity_Lockin, @Total_Debit_Quantity_Free_Lockin, " +
                "@Total_number_detail_records, @Total_Issued_Amount_Allotment_Allocation_Credit_ISIN, " +
                "@Total_Paidup_Amount_Allotment_Allocation_Credit_ISIN, @Stamp_Duty_Payable, @Basis_calculation_Stamp_Duty,@MasterUniqNo)", con);

            cmd.Parameters.AddWithValue("@rec_id", txtRecidentification.Text);
            cmd.Parameters.AddWithValue("@file_idn", txtFileidentification.Text);
            cmd.Parameters.AddWithValue("@Rta_irno", textBox1.Text);
            cmd.Parameters.AddWithValue("@Credit_ISIN", txtCreditisin.Text);
            cmd.Parameters.AddWithValue("@Debit_ISIN", txtDebitisin.Text);
            var caty = comboBox1.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@Ca_type", caty);
            cmd.Parameters.AddWithValue("@Allot_Date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            var alldesc = comboBox1aadesc.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@Allotment_Allocation_Description", alldesc);
            cmd.Parameters.AddWithValue("@Exec_Date", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Total_Credit_Quantity_Free_Lockin", txtTotalcrqtyfli.Text);
            cmd.Parameters.AddWithValue("@Total_Debit_Quantity_Free_Lockin", txtTotaldrqtyfli.Text);
            cmd.Parameters.AddWithValue("@Total_Credit_Quantity_Lockin", txtTotalcrqtyli.Text);
            cmd.Parameters.AddWithValue("@Total_Debit_Quantity_Lockin", txtTotaldrqtylin.Text);
            cmd.Parameters.AddWithValue("@Total_number_detail_records", txtTotalnoofrec.Text);

            //+REPLICATE('0', 16 - LEN(convert(bigint, allotment_quantity) * convert(bigint, Issue_Price))) + CONVERT(VARCHAR, convert(bigint, allotment_quantity) * convert(bigint, Issue_Price)) + '00'
            
            cmd.Parameters.AddWithValue("@Total_Issued_Amount_Allotment_Allocation_Credit_ISIN", txtTotalissamtaacrisin.Text);
            cmd.Parameters.AddWithValue("@Total_Paidup_Amount_Allotment_Allocation_Credit_ISIN", txtTotalpaidamtaacrisin.Text);
            var stmp = comboBox2stampdutypayable.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@Stamp_Duty_Payable", stmp);
            var bstmp = comboBox3basiscalcstampduty.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Basis_calculation_Stamp_Duty", bstmp);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun01.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in SimulCAHeaderRecord database");

        }

        private void btnSave02_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SimulCADetailRecord (Record_IDentification,Detail_Record_Line_No,Credit_DP_ID,Credit_Client_ID,Credit_Client_Account_Category,Debit_DP_ID,Debit_Client_ID,Debit_Client_Account_Category,Credit_Quantity,Debit_Quantity,Credit_Quantity_Lockin_Reason_Code,Credit_Quantity_Lockin_Release_Date,Debit_Quantity_Lockin_Reason_Code,Debit_Quantity_Lockin_Release_Date,Issue_Price_Allotment_Allocation_Credit_ISIN,Issued_Amount_Allotment_Allocation_Credit_ISIN,Paidup_Price_Allotment_Allocation_Credit_ISIN,Paidup_Amount_Allotment_Allocation_Credit_ISIN,MasterUniqNo\r\n) " +
                "values(@Record_IDentification,@Detail_Record_Line_No,@Credit_DP_ID,@Credit_Client_ID,@Credit_Client_Account_Category,@Debit_DP_ID,@Debit_Client_ID,@Debit_Client_Account_Category,@Credit_Quantity,@Debit_Quantity,@Credit_Quantity_Lockin_Reason_Code,@Credit_Quantity_Lockin_Release_Date,@Debit_Quantity_Lockin_Reason_Code,@Debit_Quantity_Lockin_Release_Date,@Issue_Price_Allotment_Allocation_Credit_ISIN,@Issued_Amount_Allotment_Allocation_Credit_ISIN,@Paidup_Price_Allotment_Allocation_Credit_ISIN,@Paidup_Amount_Allotment_Allocation_Credit_ISIN,@MasterUniqNo)", con);

            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecordIdentification.Text);
            cmd.Parameters.AddWithValue("@Detail_Record_Line_No", txtDetailrecno.Text);

            cmd.Parameters.AddWithValue("@Credit_DP_ID", txtCrDpid.Text);
            cmd.Parameters.AddWithValue("@Credit_Client_ID", txtCrclid.Text);
            var crclaccat = comboBox2.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Credit_Client_Account_Category", crclaccat);
            cmd.Parameters.AddWithValue("@Debit_DP_ID", txtDrdpid.Text);
            cmd.Parameters.AddWithValue("@Debit_Client_ID", txtDrclid.Text);
            var drclaccat = comboBox6.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Debit_Client_Account_Category", drclaccat);
            //var crqty = txtCrquantity.Text;
            cmd.Parameters.AddWithValue("@Credit_Quantity", txtCrqty.Text);
            //var drqty = txtDrquantity.Text;
            cmd.Parameters.AddWithValue("@Debit_Quantity", txtDrqty.Text);
            var crlinrc = comboBox5.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Credit_Quantity_Lockin_Reason_Code", crlinrc);
            cmd.Parameters.AddWithValue("@Credit_Quantity_Lockin_Release_Date", dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            // cmd.Parameters.AddWithValue("@Credit_Quantity_Lockin_Release_Date", txtCrqtylinreleasedate.Text);
            var drlinrc = comboBox4.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Debit_Quantity_Lockin_Reason_Code", drlinrc);
            cmd.Parameters.AddWithValue("@Debit_Quantity_Lockin_Release_Date", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
         


            var issuepricecr = txtIaaacrisin.Text;
            var issueamountcr = txtIaaacrisin.Text;
            cmd.Parameters.AddWithValue("@Issue_Price_Allotment_Allocation_Credit_ISIN", txtIpaacrisin.Text);
            var totcrqty_IssueAmtCalc = 
                (Convert.ToInt32(txtCrqty.Text) * Convert.ToInt32(txtIpaacrisin.Text));
            cmd.Parameters.AddWithValue("@Issued_Amount_Allotment_Allocation_Credit_ISIN", totcrqty_IssueAmtCalc);
            var totalpaidupprice = Convert.ToString(Convert.ToInt32(txtCrqty.Text) * Convert.ToInt32(txtIpaacrisin.Text));
            var totalpaidupamount = Convert.ToString(Convert.ToInt32(txtDrqty.Text) * Convert.ToInt32(txtIaaacrisin.Text));
            cmd.Parameters.AddWithValue("@Paidup_Price_Allotment_Allocation_Credit_ISIN", txtPpaacrisin.Text);
            cmd.Parameters.AddWithValue("@Paidup_Amount_Allotment_Allocation_Credit_ISIN", txtPaaacrisin.Text);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun02.Text);
         
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in SimulCADetailRecord database");
        }

        //e.Handled = !Char.IsDigit(e.KeyChar);
        private void btnSave03_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into SimulCADetailDistRecord (Record_IDentification,Detail_Record_Line_No,Debit_Credit_ISIN,Debit_Credit_Indicator,From_Distinctive_No_NSDL,To_Distinctive_No_NSDL,Quantity,Flag_status_DN_Range,CA_Code,MasterUniqNo) " +
                "values(@Record_IDentification,@Detail_Record_Line_No,@Debit_Credit_ISIN,@Debit_Credit_Indicator,@From_Distinctive_No_NSDL,@To_Distinctive_No_NSDL,@Quantity,@Flag_status_DN_Range,@CA_Code,@MasterUniqNo)", con);
            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecident03.Text);
            cmd.Parameters.AddWithValue("@Detail_Record_Line_No", txtDetailrecordno.Text);
            cmd.Parameters.AddWithValue("@Debit_Credit_ISIN", txtDrcrisin.Text);
            var drcrind3 = comboBox2drcrindicator.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@Debit_Credit_Indicator", drcrind3);
            cmd.Parameters.AddWithValue("@From_Distinctive_No_NSDL", txtFromdistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@To_Distinctive_No_NSDL", txtTodistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            var flagdnr = comboBox1flagdnrange.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Flag_status_DN_Range", flagdnr);
            var cacode3 = comboBox3.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@CA_Code", cacode3);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun03.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in database");
        }

        private void txtMun01_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtMun02_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtMun03_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }
        private void txtTotaldrqtylin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTotalcrqtyli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTotaldrqtyfli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTotalnoofrec_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTotalissamtaacrisin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTotalpaidamtaacrisin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTotalcrqtyfli_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled= !char.IsNumber(e.KeyChar);
        }

        private void txtCrclid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtDrclid_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtCrqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtDrqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtIpaacrisin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtIaaacrisin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtPpaacrisin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtPaaacrisin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar);
        }

        private void txtTodistinctivenonsdl_TextChanged(object sender, EventArgs e)
        {
            if (txtFromdistinctivenonsdl.Text.Length > 0 && txtTodistinctivenonsdl.Text.Length > 0)
            {
                txtQuantity.Text = Convert.ToString(Convert.ToInt32(txtTodistinctivenonsdl.Text) - Convert.ToInt32(txtFromdistinctivenonsdl.Text) + 1);
            }
        }
    }
}
