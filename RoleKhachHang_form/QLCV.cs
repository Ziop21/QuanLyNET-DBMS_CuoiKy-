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

namespace RoleKhachHang_form
{
    public partial class QLCV : Form
    {
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;
        DataTable dt = null;
        SqlConnection conn = null;
        public QLCV()
        {
            InitializeComponent();
        }

        public QLCV(String s)
        {
            InitializeComponent();
            username = s;
        }
        String username;
        string connection = "Data Source=LAPTOP-1F69K9NB\\MSSQLSERVER2016;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=newsa;Password=sa";
        //string connection = "Data Source=DESKTOP-DHKSD76;Initial Catalog=NET_NEW;Persist Security Info=True;User ID=sa;Password=123456";

        private void LoadQLCV()
        {
            conn = new SqlConnection(connection);
            string sql = "select * from view_QLCV";
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtID.ReadOnly = true;
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dataGridView1.DataSource, "id");
            txtMNV.DataBindings.Clear();
            txtMNV.DataBindings.Add("Text", dataGridView1.DataSource, "MaNV");
            dtp.DataBindings.Clear();
            dtp.DataBindings.Add("Text", dataGridView1.DataSource, "NgayLamViec");
            txtCLV.DataBindings.Clear();
            txtCLV.DataBindings.Add("Text", dataGridView1.DataSource, "CaLamViec");
            txtGLV.DataBindings.Clear();
            txtGLV.DataBindings.Add("Text", dataGridView1.DataSource, "GioLamViec");
            conn.Close();
        }


        private void QLCV_PQ()
        {
            conn = new SqlConnection(connection);
            conn.Open();
            cmd = new SqlCommand("sp_HoatDongNhanVien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maTK", SqlDbType.VarChar).Value = username;
            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            txtID.ReadOnly = true;
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dataGridView1.DataSource, "id");
            txtMNV.DataBindings.Clear();
            txtMNV.DataBindings.Add("Text", dataGridView1.DataSource, "MaNV");
            dtp.DataBindings.Clear();
            dtp.DataBindings.Add("Text", dataGridView1.DataSource, "NgayLamViec");
            txtCLV.DataBindings.Clear();
            txtCLV.DataBindings.Add("Text", dataGridView1.DataSource, "CaLamViec");
            txtGLV.DataBindings.Clear();
            txtGLV.DataBindings.Add("Text", dataGridView1.DataSource, "GioLamViec");
            conn.Close();
        }

        private void QLCV_Load(object sender, EventArgs e)
        {
            if (username.StartsWith("vs") || username.StartsWith("tn") || username.StartsWith("kt") || username.StartsWith("db"))
            {
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                QLCV_PQ();
            }
            else
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                LoadQLCV();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_ThemQLCV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@maNV", SqlDbType.VarChar).Value = txtMNV.Text;
            cmd.Parameters.Add("@ngayLamViec", SqlDbType.Date).Value = dtp.Value.ToString();
            cmd.Parameters.Add("@caLamViec", SqlDbType.VarChar).Value = txtCLV.Text;
            cmd.Parameters.Add("@gioLamViec", SqlDbType.Int).Value = Int32.Parse(txtGLV.Text);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            LoadQLCV();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_SuaQLCV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = txtID.Text;
            cmd.Parameters.Add("@maNV", SqlDbType.VarChar).Value = txtMNV.Text;
            cmd.Parameters.Add("@ngayLamViec", SqlDbType.Date).Value = dtp.Value.ToString();
            cmd.Parameters.Add("@caLamViec", SqlDbType.VarChar).Value = txtCLV.Text;
            cmd.Parameters.Add("@gioLamViec", SqlDbType.Int).Value = Int32.Parse(txtGLV.Text);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            LoadQLCV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("sp_XoaQLCV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = txtID.Text;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            LoadQLCV();
        }

        private void bntInit_Click(object sender, EventArgs e)
        {
            txtMNV.Text = "";
            dtp.Value = DateTime.Now;
            txtCLV.Text = "";
            txtGLV.Text = "0";
            txtID.ReadOnly = false;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            dtp.CustomFormat = "dd-MM-yyy";
        }
    }
}
