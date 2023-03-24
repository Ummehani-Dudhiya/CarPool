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
    public class CityRepository:CommanRepository
    {
         public List<t_City> GetAll()
        {
            DataTable dt = new DataTable();
            NpgsqlCommand cm = new NpgsqlCommand("Select * from t_city",cn);
            cn.Open();
            NpgsqlDataReader datar = cm.ExecuteReader();
            if (datar.HasRows)
            {
                dt.Load(datar);
            }
            List<t_City> clist = new List<t_City>();
            clist = (from DataRow dr in dt.Rows
                     select new t_City()
                     {
                         CityId = Convert.ToInt32(dr["c_cityid"]),
                         CityName = dr["c_cityname"].ToString(),
                      
                        
                     }).ToList();
            datar.Close();
            cn.Close();
            return clist;
        }
    }
}