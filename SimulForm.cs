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
            SqlCommand cmd = new SqlCommand("insert into SimulCAHeaderRecord (Record_Identification,File_Identification,RTA_Internal_Reference_No," +
                "Cr_Isin,Dr_Isin,Ca_Type,Allotment_Dt,Allot_alloc_Desc,Execution_dt,TotCrQty_Flin,TotDrQty_Flin," +
                "TotCrQty_Lin,TotDrQty_Lin,TotDetRec,Issue_pr,Paidup_pr,TotIssAmtaa_CrIsin,TotpdAmtaa_CrIsin,StampDuty_Pay," +
                "BcStampDuty,MasterUniqNo) " +
                "values (@Record_Identification,@File_Identification,@RTA_Internal_Reference_No,@Cr_Isin,@Dr_Isin,@Ca_Type,@Allotment_Dt," +
                "@Allot_alloc_Desc,@Execution_dt,@TotCrQty_Flin,@TotDrQty_Flin,@TotCrQty_Lin,@TotDrQty_Lin,@TotDetRec," +
                "@Issue_pr,@Paidup_pr,@TotIssAmtaa_CrIsin,@TotpdAmtaa_CrIsin,@StampDuty_Pay,@BcStampDuty,	 @MasterUniqNo)", con);
            cmd.Parameters.AddWithValue("@Record_Identification", txtRecidentification.Text);
            cmd.Parameters.AddWithValue("@File_Identification", txtFileidentification.Text);
            cmd.Parameters.AddWithValue("@RTA_Internal_Reference_No", textBox1.Text);
            cmd.Parameters.AddWithValue("@Cr_Isin", txtCreditisin.Text);
            cmd.Parameters.AddWithValue("@Dr_Isin", txtDebitisin.Text);
            var caty = comboBox1.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@Ca_Type", caty);
            cmd.Parameters.AddWithValue("@Allotment_Dt", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            var alldesc = comboBox1aadesc.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@Allot_alloc_Desc", alldesc);
            cmd.Parameters.AddWithValue("@Execution_dt", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@TotCrQty_Flin", txtTotalcrqtyfli.Text);
            cmd.Parameters.AddWithValue("@TotDrQty_Flin", txtTotaldrqtyfli.Text);
            cmd.Parameters.AddWithValue("@TotCrQty_Lin", txtTotalcrqtyli.Text);
            cmd.Parameters.AddWithValue("@TotDrQty_Lin", txtTotaldrqtylin.Text);
            cmd.Parameters.AddWithValue("@TotDetRec", txtTotalnoofrec.Text);
            cmd.Parameters.AddWithValue("@Issue_pr", txtIP.Text);
            cmd.Parameters.AddWithValue("@Paidup_pr", txtPP.Text);

            //+REPLICATE('0', 16 - LEN(convert(bigint, allotment_quantity) * convert(bigint, Issue_Price))) + CONVERT(VARCHAR, convert(bigint, allotment_quantity) * convert(bigint, Issue_Price)) + '00'

            cmd.Parameters.AddWithValue("@TotIssAmtaa_CrIsin", txtIssamt01.Text);
            cmd.Parameters.AddWithValue("@TotpdAmtaa_CrIsin", txtPaidamt01.Text);
            var stmp = comboBox2stampdutypayable.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@StampDuty_Pay", stmp);
            var bstmp = comboBox3basiscalcstampduty.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@BcStampDuty", bstmp);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun01.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in SimulCAHeaderRecord database");
            
        }

        private void btnSave02_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=VCCIPL-TECH\\VENTURESQLEXP;Initial Catalog=VCCIPL;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into SimulCADetailRecord (Record_IDentification, DetRec_Line_No, " +
                "Credit_DP_ID, CrClient_ID, CrClient_AccCat, DrDP_ID, DrClient_ID, DrClient_AccCat, Cr_Quantity, " +
                "Dr_Quantity, CrQty_LinRCd, CrQty_LnRDt, drQty_LinRCd, drQty_LnRDt, IssPraaCr_ISIN, IssAmtaaCr_isin, " +
                "PupPraaCr_ISIN, PupAmtaaCr_Isin, MasterUniqNo\r\n) " +
                "values(@Record_IDentification,@DetRec_Line_No,@Credit_DP_ID,@CrClient_ID,@CrClient_AccCat,@DrDP_ID," +
                "@DrClient_ID,@DrClient_AccCat,@Cr_Quantity,@Dr_Quantity,@CrQty_LinRCd,@CrQty_LnRDt,@drQty_LinRCd," +
                "@drQty_LnRDt,@IssPraaCr_ISIN,@IssAmtaaCr_isin,@PupPraaCr_ISIN,@PupAmtaaCr_Isin,@MasterUniqNo)", con);
            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecordIdentification.Text);
            cmd.Parameters.AddWithValue("@DetRec_Line_No", txtDetailrecno.Text);
            cmd.Parameters.AddWithValue("@Credit_DP_ID", txtCrDpid.Text);
            cmd.Parameters.AddWithValue("@CrClient_ID", txtCrclid.Text);
            var crclaccat = comboBox2.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@CrClient_AccCat", crclaccat);
            cmd.Parameters.AddWithValue("@DrDP_ID", txtDrdpid.Text);
            cmd.Parameters.AddWithValue("@DrClient_ID", txtDrclid.Text);
            var drclaccat = comboBox6.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@DrClient_AccCat", drclaccat);
            //var crqty = txtCrquantity.Text;
            cmd.Parameters.AddWithValue("@Cr_Quantity", txtCrqty.Text);
            //var drqty = txtDrquantity.Text;
            cmd.Parameters.AddWithValue("@Dr_Quantity", txtDrqty.Text);
            var crlinrc = comboBox5.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@CrQty_LinRCd", crlinrc);
            cmd.Parameters.AddWithValue("@CrQty_LnRDt", dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            // cmd.Parameters.AddWithValue("@Credit_Quantity_Lockin_Release_Date", txtCrqtylinreleasedate.Text);
            var drlinrc = comboBox4.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@drQty_LinRCd", drlinrc);
            cmd.Parameters.AddWithValue("@drQty_LnRDt", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            var issuepricecr = txtIaaacrisin.Text;
            var issueamountcr = txtIaaacrisin.Text;
            cmd.Parameters.AddWithValue("@IssPraaCr_ISIN", txtip02.Text);
            var totcrqty_IssueAmtCalc =
                (Convert.ToInt32(txtCrqty.Text) * Convert.ToInt32(txtip02.Text));
            cmd.Parameters.AddWithValue("@IssAmtaaCr_isin", totcrqty_IssueAmtCalc);
            var totalpaidupprice = Convert.ToString(Convert.ToInt32(txtCrqty.Text) * Convert.ToInt32(txtip02.Text));
            var totalpaidupamount = Convert.ToString(Convert.ToInt32(txtDrqty.Text) * Convert.ToInt32(txtIaaacrisin.Text));
            cmd.Parameters.AddWithValue("@PupPraaCr_ISIN", txtpp02.Text);
            cmd.Parameters.AddWithValue("@PupAmtaaCr_Isin", txtPaaacrisin.Text);
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

            SqlCommand cmd = new SqlCommand("insert into SimulCADetailDistRecord (Record_IDentification, DetRec_Line_No, " +
                "DrCr_ISIN, DrCr_Indicator, FromDistNo_NSDL,ToDistNo_NSDL, Quantity, Flag_status_DN_Range, " +
                "CA_Code, MasterUniqNo) " +
                "values(@Record_IDentification, @DetRec_Line_No, @DrCr_ISIN, @DrCr_Indicator, @FromDistNo_NSDL, " +
                "@ToDistNo_NSDL, @Quantity, @Flag_status_DN_Range, @CA_Code, @MasterUniqNo)", con);
          

            cmd.Parameters.AddWithValue("@Record_IDentification", txtRecident03.Text);
            cmd.Parameters.AddWithValue("@DetRec_Line_No", txtDetailrecordno.Text);
            cmd.Parameters.AddWithValue("@DrCr_ISIN", txtDrcrisin.Text);
            var drcrind3 = comboBox2drcrindicator.Text.Substring(0, 1);
            cmd.Parameters.AddWithValue("@DrCr_Indicator", drcrind3);
            cmd.Parameters.AddWithValue("@FromDistNo_NSDL", txtFromdistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@ToDistNo_NSDL", txtTodistinctivenonsdl.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            var flagdnr = comboBox1flagdnrange.Text.Substring(0, 2);
            cmd.Parameters.AddWithValue("@Flag_status_DN_Range", flagdnr);
            var cacode3 = comboBox3.Text.Substring(0, 4);
            cmd.Parameters.AddWithValue("@CA_Code", cacode3);
            cmd.Parameters.AddWithValue("@MasterUniqNo", txtMun03.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has saved in SimulCADetailDistRecord database");
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

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            if (txtIP.Text.Length > 0)
            {
                txtIssamt01.Text = Convert.ToString(Convert.ToInt32(txtIP.Text) * Convert.ToInt32(txtTotalcrqtyfli.Text));
            }
        }

        private void txtPP_TextChanged(object sender, EventArgs e)
        {
            if (txtPP.Text.Length > 0)
            {
                txtPaidamt01.Text = Convert.ToString(Convert.ToInt32(txtPP.Text) * Convert.ToInt32(txtTotalcrqtyfli.Text));
            }
        }

        private void txtIaaacrisin_TextChanged(object sender, EventArgs e)
        {
            if (txtip02.Text.Length > 0)
            {
                txtIaaacrisin.Text = Convert.ToString(Convert.ToInt32(txtip02.Text) * Convert.ToInt32(txtCrqty.Text));
            }
        }

        private void txtPaaacrisin_TextChanged(object sender, EventArgs e)
        {
            if (txtpp02.Text.Length > 0)
            {
                txtPaaacrisin.Text = Convert.ToString(Convert.ToInt32(txtpp02.Text) * Convert.ToInt32(txtCrqty.Text));
            }
        }

        private void txtip02_TextChanged(object sender, EventArgs e)
        {
            if (txtip02.Text.Length > 0)
            {
                txtIaaacrisin.Text = Convert.ToString(Convert.ToInt32(txtip02.Text) * Convert.ToInt32(txtCrqty.Text));
            }

        }

        private void txtpp02_TextChanged_1(object sender, EventArgs e)
        {
            if (txtpp02.Text.Length > 0)
            {
                txtPaaacrisin.Text = Convert.ToString(Convert.ToInt32(txtpp02.Text) * Convert.ToInt32(txtCrqty.Text));
            }

        }
    }
   
}
