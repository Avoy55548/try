﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class AddBooks : Form
    {
        
        public AddBooks()
        {
            InitializeComponent();
        }
        // User input validation
        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtBookPubAB.Text) || String.IsNullOrEmpty(this.txtBookAuthorAB.Text) ||
                String.IsNullOrEmpty(this.txtBookNameAB.Text) || String.IsNullOrEmpty(this.txtISBNNoAB.Text) ||
                String.IsNullOrEmpty(this.txtBookQuantityAB.Text) || String.IsNullOrEmpty(this.txtBookPriceAB.Text))
            {
                return false;
            }

            else
            {
                return true;
            }
        }
//After saving data
        private void ClearAll()
        {
            this.txtBookPubAB.Clear();
            this.txtBookAuthorAB.Clear();
            this.txtBookNameAB.Clear();
            this.txtISBNNoAB.Clear();
            this.txtBookQuantityAB.Clear();
            this.txtBookPriceAB.Clear();
        }

        // 
        private void btnSaveAB_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information"); // checking validation
                    return;
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=DESKTOP-HQ509SI\SQLEXPRESS01;Initial Catalog=Library_Management_System;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();  //database connection
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Book (Name,Author,Publication,ISBN,Quantity,Price) values ('" + this.txtBookNameAB.Text + "','" + this.txtBookAuthorAB.Text + "','" + this.txtBookPubAB.Text + "', '" + this.txtISBNNoAB.Text + "'," + this.txtBookQuantityAB.Text + ", " + this.txtBookPriceAB.Text + " )";
                cmd.ExecuteNonQuery();   // adding parameter
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearAll();   // success message
            }
            catch (Exception exc)
            {
                MessageBox.Show("There is an error in your input: " + exc.Message); // error handling
            }
        }

        private void btnCancelAB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Remove your all unsaved data", "Are you sure to perform this?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }


    }
}
