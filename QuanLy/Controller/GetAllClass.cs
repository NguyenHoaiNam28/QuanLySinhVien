﻿using QuanLy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy
{
   
    partial class Controller
    {
        public List<Class> GetAllClass()
        {
            List<Class> classes = new List<Class>();

            Static.mock.Data.classes.Values.ToList().ForEach(c => {
                Class classs = new Class();
                classs.ID = c.ID;
                classs.TenLop = c.TenLop;
                classs.Khoa = c.Khoa;
                classs.GiaoVien = c.GiaoVien;
                classs.NamHoc = c.NamHoc;
                classs.GiaoVien = GetUserByID(classs.GiaoVien).HoTen;
                classes.Add(classs);
            });

            return classes;
        }
    }
}
