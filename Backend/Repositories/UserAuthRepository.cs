using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Npgsql;

namespace Backend.Repositories
{
    public class UserAuthRepository:CommanRepository
    {  
         public void Register(t_User data)
        {
            NpgsqlCommand cm = new NpgsqlCommand("insert into t_user (c_name,c_email,c_password,c_gender,c_address,c_city,c_contact,c_image,c_istraveler) values(@name,@email,@password,@gender,@address,@city,@contact,@image,@istraveler)",cn);
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
            NpgsqlCommand cm = new NpgsqlCommand("select c_email,c_password from t_user where c_email=@email and c_password=@password", cn);
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
    }
}