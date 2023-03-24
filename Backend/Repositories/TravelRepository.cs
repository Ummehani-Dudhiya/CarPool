using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Npgsql;

namespace Backend.Repositories
{
    public class TravelRepository : CommanRepository
    {
        public List<t_Travel> GetAll()
        {
            DataTable dt = new DataTable();
            NpgsqlCommand cm = new NpgsqlCommand("Select * from t_travel", cn);
            cn.Open();
            NpgsqlDataReader datar = cm.ExecuteReader();
            if (datar.HasRows)
            {
                dt.Load(datar);
            }
            List<t_Travel> clist = new List<t_Travel>();
            clist = (from DataRow dr in dt.Rows
                     select new t_Travel()
                     {
                         TravelId = Convert.ToInt32(dr["c_travelid"]),
                         UserId = Convert.ToInt32(dr["c_userid"]),
                         FromCityId = Convert.ToInt32(dr["c_fromcityid"]),
                         ToCityId = Convert.ToInt32(dr["c_tocityid"]),
                         NoOfSeats = Convert.ToInt32(dr["c_noofseats"]),
                         TravelDate = Convert.ToDateTime(dr["c_traveldate"]),
                         IsActive = Convert.ToBoolean(dr["c_isactive"])

                     }).ToList();
            datar.Close();
            cn.Close();
            return clist;
        }
        public t_Travel GetOne(int id)
        {
            DataTable dt = new DataTable();
            NpgsqlCommand cm = new NpgsqlCommand("Select * from t_travel ", cn);
            cn.Open();
            NpgsqlDataReader datar = cm.ExecuteReader();
            if (datar.HasRows)
            {
                dt.Load(datar);
            }

            t_Travel tlist = (from DataRow dr in dt.Rows
                              where int.Parse(dr["c_userid"].ToString()) == id
                              select new t_Travel()
                              {
                                  TravelId = Convert.ToInt32(dr["c_travelid"]),
                                  UserId = Convert.ToInt32(dr["c_userid"]),
                                  FromCityId = Convert.ToInt32(dr["c_fromcityid"]),
                                  ToCityId = Convert.ToInt32(dr["c_tocityid"]),
                                  NoOfSeats = Convert.ToInt32(dr["c_noofseats"]),
                                  TravelDate = Convert.ToDateTime(dr["c_traveldate"]),
                                  IsActive = Convert.ToBoolean(dr["c_isactive"])

                              }).ToList().FirstOrDefault();

            cn.Close();
            return tlist;
        }
        public void Insert(t_Travel t)
        {
            NpgsqlCommand cm = new NpgsqlCommand(@"INSERT INTO t_travel(c_userid, c_fromcityid, c_tocityid, c_noofseats, c_traveldate, c_isactive)
	        VALUES (@c_userid,@c_fromcityid,@c_tocityid,@c_noofseats,@c_traveldate,@c_isactive)", cn);
            cm.Parameters.AddWithValue("@c_userid", t.UserId);
            cm.Parameters.AddWithValue("@c_fromcityid", t.FromCityId);
            cm.Parameters.AddWithValue("@c_tocityid", t.ToCityId);
            cm.Parameters.AddWithValue("@c_noofseats", t.NoOfSeats);
            cm.Parameters.AddWithValue("@c_traveldate", t.TravelDate);
            cm.Parameters.AddWithValue("@c_isactive", t.IsActive);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
        public bool Update(t_Travel t)
        {

            cn.Open();
            NpgsqlCommand cm = new NpgsqlCommand("select c_isactive from t_travel where c_isactive=@c_isactive", cn);
            cm.Parameters.AddWithValue("@c_isactive", t.IsActive);
            NpgsqlDataReader sdr = cm.ExecuteReader();

            if (sdr.HasRows)
            {
                return false;
            }
            else
            {
                cm = new NpgsqlCommand("Update t_travel set  where c_travelid=@c_travelid", cn);
                cm.Parameters.AddWithValue("@c_userid", t.UserId);
                cm.Parameters.AddWithValue("@c_isactive", t.IsActive);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                return true;
            }

        }
    }
}