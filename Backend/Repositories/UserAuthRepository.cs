using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Npgsql;
using System.Data;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Backend.Repositories
{
    public class UserAuthRepository : CommanRepository
    {
        public void Register(t_User data)
        {
            NpgsqlCommand cm = new NpgsqlCommand("insert into t_user (c_name,c_email,c_password,c_gender,c_address,c_city,c_contact,c_image,c_istraveler) values(@name,@email,@password,@gender,@address,@city,@contact,@image,@istraveler)", cn);
            cm.Parameters.AddWithValue("@name", data.Name);
            cm.Parameters.AddWithValue("@email", data.Email);
            cm.Parameters.AddWithValue("@password", data.Password);
            cm.Parameters.AddWithValue("@gender", data.Gender);
            cm.Parameters.AddWithValue("@address", data.Address);
            cm.Parameters.AddWithValue("@city", data.City);
            cm.Parameters.AddWithValue("@contact", data.Contact);
            cm.Parameters.AddWithValue("@image", data.Image);
            cm.Parameters.AddWithValue("@istraveler", data.isTraveler);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public bool Login(vm_Login data)
        {
            NpgsqlCommand cm = new NpgsqlCommand("select c_userid,c_email,c_password from t_user where c_email=@email and c_password=@password", cn);
            cm.Parameters.AddWithValue("@email", data.Email);
            cm.Parameters.AddWithValue("@password", data.Password);
            cn.Open();
            NpgsqlDataReader datar = cm.ExecuteReader();
            if (datar.Read())
            {
                return true;
            }
            cn.Close();
            return false;
        }

        public t_User GetProfile(int id)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select c_userid,c_name,c_email,c_password,c_gender,c_address,c_city,c_contact,c_image,c_istraveler from t_user", cn);
            cn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "t");
            t_User userList = (from DataRow dr in ds.Tables["t"].Rows
                               where int.Parse(dr["c_userid"].ToString()) == id
                               select new t_User()
                               {
                                   UserId = Convert.ToInt32(dr["c_userid"]),
                                   Name = dr["c_name"].ToString(),
                                   Email = dr["c_email"].ToString(),
                                   Password = dr["c_password"].ToString(),
                                   Gender = dr["c_gender"].ToString(),
                                   Address = dr["c_address"].ToString(),
                                   City = dr["c_city"].ToString(),
                                   Contact = dr["c_contact"].ToString(),
                                   Image = dr["c_image"].ToString(),
                                   isTraveler = Convert.ToBoolean(dr["c_istraveler"])
                               }).ToList().FirstOrDefault();
            cn.Close();
            return userList;
        }

        public void ChangeProfile(t_User data, int id)
        {
            NpgsqlCommand cm = new NpgsqlCommand(@"update t_user set c_name=@nam,c_gender=@gen,c_address=@adr,c_city=@ct,c_contact=@cn where c_userid=@id", cn);
            cm.Parameters.AddWithValue("@id", id);
            cm.Parameters.AddWithValue("@nam", data.Name);
            cm.Parameters.AddWithValue("@gen", data.Gender);
            cm.Parameters.AddWithValue("@adr", data.Address);
            cm.Parameters.AddWithValue("@ct", data.City);
            cm.Parameters.AddWithValue("@cn", data.Contact);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public int ChangePassword(ChangePassword data, int id)
        {
            if (data.NewPassword == data.ConfirmPassword)
            {
                NpgsqlCommand cm = new NpgsqlCommand(@"update t_user set c_password=@newpwd where c_userid=@id and c_password=@oldpwd", cn);
                cm.Parameters.AddWithValue("@id", id);
                cm.Parameters.AddWithValue("@newpwd", data.NewPassword);
                cm.Parameters.AddWithValue("@oldpwd", data.OldPassword);
                cn.Open();
                int ans = cm.ExecuteNonQuery();
                cn.Close();
                return ans;
            }
            else
            {
                return -1;
            }
        }
    }
}