﻿
using QuanLy.Forms;
using QuanLy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy
{
    public partial class StudentTab : Form
    {
        public StudentTab()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.Visible = true;

            Static.controller.LoadDataToDataGridView(dgvStudent, Static.controller.bindingSourceStudent);
        }


        private void closeButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm(LoaiNguoiDung.SinhVien);
            createUserForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvStudent.SelectedRows[0];
            string ID = row.Cells[0].Value.ToString();
            User user = Static.controller.GetUserByID(ID);
            if (user == null)
            {
                MessageBox.Show("Có lỗi!!!! Người dùng không tồn tại.");
                return;
            }
            EditUserForm editUserForm = new EditUserForm(user);
            editUserForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvStudent.SelectedRows[0];

            string ID = row.Cells[0].Value.ToString();
            
            if (ID == null)
            {
                MessageBox.Show("Có lỗi!!!! Cần chọn người dùng để xóa.");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc xóa tài khoản ["+ Static.controller.GetUserByID(ID).HoTen + "] không!!!", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Static.controller.DeleteUser(ID);
                MessageBox.Show("Xóa tài khoản thành công.");
            }
            
        }

        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            Static.controller.LoadDataToDataGridView(dgvStudent, Static.controller.SearchUser(LoaiNguoiDung.SinhVien, txtSearchStudent.Text));
        }
    }
}
