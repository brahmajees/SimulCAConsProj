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

namespace IepfCAConsProj
{
    public partial class IEPFCAConsForm : Form
    {
        public IEPFCAConsForm()
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
            SqlCommand cmd = new SqlCommand("select * from IepfNSDLHeaderRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from IepfNSDLDetailRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from IepfNSDLDetailDistRecord", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void btnSave01_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into IepfNSDLHeaderRecord (Record_Identification,File_Identification,RTA_IntRefNo,Credit_ISIN,Debit_ISIN,CA_Type,BApproval_Dt,CA_Description,Execution_Date,TotCrQty_FLinBl,TotDrQty_FLinBl,TotCrQty_Lin,TotDrQty_Lin,Tot_detrec,CIN_BCIN_No,FY_WAmtRel,MasterUniqNo) " +
                "values (@Record_Identification, @File_Identification, @RTA_IntRefNo, @Credit_ISIN, @Debit_ISIN, @CA_Type, " +
                "@BApproval_Dt, @CA_Description, @Execution_Date, @TotCrQty_FLinBl, @TotDrQty_FLinBl, @TotCrQty_Lin, " +
                "@TotDrQty_Lin, @Tot_detrec, @CIN_BCIN_No, @FY_WAmtRel,@MasterUniqNo)", con);

            cmd.Parameters.AddWithValue("@Record_Identification", txtRecidentification.Text);
            cmd.Parameters.AddWithValue("@File_Identification", txtFileidentification.Text);
            cmd.Parameters.AddWithValue("@RTA_IntRefNo", txtIntrefno.Text);
            cmd.Parameters.AddWithValue("@Credit_ISIN", txtCreditisin.Text);
            cmd.Parameters.AddWithValue("@Debit_ISIN", txtDebitisin.Text);
            var caty = comboBox1.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@CA_Type", caty);
            cmd.Parameters.AddWithValue("@BApproval_Dt", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            var alldesc = comboBox1aadesc.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@CA_Description", alldesc);
            cmd.Parameters.AddWithValue("@Execution_Date", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@TotCrQty_FLinBl", txtTotalcrqtyfli.Text);
            cmd.Parameters.AddWithValue("@TotDrQty_FLinBl", txtTotaldrqtyfli.Text);
            cmd.Parameters.AddWithValue("@TotCrQty_Lin", txtTotalcrqtyli.Text);
            cmd.Parameters.AddWithValue("@TotDrQty_Lin", txtTotaldrqtylin.Text);
            cmd.Parameters.AddWithValue("@Tot_detrec", txtTotalnoofrec.Text);
            //+REPLICATE('0', 16 - LEN(convert(bigint, allotment_quantity) * convert(bigint, Issue_Price))) + CONVERT(VARCHAR, convert(bigint, allotment_quantity) * convert(bigint, Issue_Price)) + '00'
            cmd.Parameters.AddWithValue("@CIN_BCIN_No", txtCinBcinNo.Text);
            cmd.Parameters.AddWithValue("@FY_WAmtRel", txtFyAmtRel.Text);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtIepfmun01.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in IepfNSDLHeaderRecord database");

        }

        private void btnSave02_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into IepfNSDLDetailRecord (" +
                "Record_IDentification,Detail_Record_Line_No,Credit_DP_ID,Credit_Client_ID,CrClient_AccCat,Debit_DP_ID," +
                "Debit_Client_ID,DrClient_AccCat,Cr_Qty,Dr_Qty,CrQty_LinReasonCd,CrQty_Lin_RelDt,DrQty_LinReasonCd," +
                "DrQty_Lin_RelDt,MasterUniqNo) " +
                "values(@Record_IDentification,@Detail_Record_Line_No,@Credit_DP_ID,@Credit_Client_ID,@CrClient_AccCat," +
                "@Debit_DP_ID,@Debit_Client_ID,@DrClient_AccCat,@Cr_Qty,@Dr_Qty,@CrQty_LinReasonCd,@CrQty_Lin_RelDt," +
                "@DrQty_LinReasonCd,@DrQty_Lin_RelDt,@MasterUniqNo)", con);
            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecordIdentification.Text);
            cmd.Parameters.AddWithValue("@Detail_Record_Line_No", txtDetailrecno.Text);
            cmd.Parameters.AddWithValue("@Credit_DP_ID", txtCrDpid.Text);
            cmd.Parameters.AddWithValue("@Credit_Client_ID", txtCrclid.Text);
            var crclaccat = comboBox2.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@CrClient_AccCat", crclaccat);
            cmd.Parameters.AddWithValue("@Debit_DP_ID", txtDrdpid.Text);
            cmd.Parameters.AddWithValue("@Debit_Client_ID", txtDrclid.Text);
            var drclaccat = comboBox6.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@DrClient_AccCat", drclaccat);
            //var crqty = txtCrquantity.Text;
            cmd.Parameters.AddWithValue("@Cr_Qty", txtCrqty.Text);
            //var drqty = txtDrquantity.Text;
            cmd.Parameters.AddWithValue("@Dr_Qty", txtDrqty.Text);
            var crlinrc = comboBox5.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@CrQty_LinReasonCd", crlinrc);
            cmd.Parameters.AddWithValue("@CrQty_Lin_RelDt", dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            // cmd.Parameters.AddWithValue("@Credit_Quantity_Lockin_Release_Date", txtCrqtylinreleasedate.Text);
            var drlinrc = comboBox4.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@DrQty_LinReasonCd", drlinrc);
            cmd.Parameters.AddWithValue("@DrQty_Lin_RelDt", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun02.Text);
         
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in IepfNSDLDetailRecord database");
            
        }

        //e.Handled = !Char.IsDigit(e.KeyChar);
        private void btnSave03_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into IepfNSDLDetailDistRecord " +
                "(Record_IDentification,Detail_Record_Line_No,ISIN,DRCRINDICATOR,From_DistNo_NSDL,To_DistNo_NSDL,Quantity,Flag_status_DN_Range,CA_Type,MasterUniqNo) " +
                "values(@Record_IDentification,@Detail_Record_Line_No,@ISIN," +
                "@DRCRINDICATOR,@From_DistNo_NSDL,@To_DistNo_NSDL,@Quantity,@Flag_status_DN_Range," +
                "@CA_Type,@MasterUniqNo)", con);
            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecident03.Text);
            cmd.Parameters.AddWithValue("@Detail_Record_Line_No", txtDetailrecordno.Text);
            cmd.Parameters.AddWithValue("@ISIN", txtISIN.Text);
            var drcrind3 = comboBox2drcrindicator.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@DRCRINDICATOR", drcrind3);
            cmd.Parameters.AddWithValue("@From_DistNo_NSDL", txtFromdistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@To_DistNo_NSDL", txtTodistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            var flagdnr = comboBox1flagdnrange.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Flag_status_DN_Range", flagdnr);
            var cacode3 = comboBox3.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@CA_Type", cacode3);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun03.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in IepfNSDLDetailDistRecord database");
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
