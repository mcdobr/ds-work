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

namespace Datar
{
    public partial class DatarForm : Form
    {
        private const String CONN_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mircea\Source\Repos\ds-work\Lab9\Datar\DistributedSystemsDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;
        private SqlDataAdapter customerDataAdapter;
        private DataTable table = new DataTable("Customers");

        public DatarForm()
        {
            InitializeComponent();
        }

        private void DatarForm_Load(object sender, EventArgs e)
        {
            /* Connect to RDBMS */
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
            
            dataGridView.DataSource = table;

            customerDataAdapter = new SqlDataAdapter("SELECT * FROM Customers;", conn);
            customerDataAdapter.Fill(table);

        }

        private void DatarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            customerDataAdapter.Update(table);
        }
    }
}
