﻿using ProductDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProductDemo.Web.DAL
{
    public class RegisterDataLayer
    {
        public string SignUpUser(UserModel model)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("proc_RegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName",model.UserName);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Mobile", model.Mobile);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save successfully");
            }
            catch(Exception ex)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}