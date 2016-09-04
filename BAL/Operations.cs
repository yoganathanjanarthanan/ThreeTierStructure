using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using BEL;
using System.Data;
using System.Data.SqlClient;

namespace BAL
{
    public class Operations
    {
        public Dbconnection db = new Dbconnection();
        public Informations info = new Informations();
        public Informations trcinfo = new Informations();
        public Informations imginfo = new Informations();
        // here we declare the queries and db operations needed for the application


        public int insertEmp(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO employee VALUES ('"+info.name+"','"+info.gender+"','"+info.dob+"','"+info.address+"','"+info.education+"','"+info.username+"','"+info.password+"')";
            return db.ExeNonQuery(cmd);
        }

        public DataTable login(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from employee where Username='"+info.username+"'and Password='"+info.password +"'";
            return db.ExeReader(cmd);
        }

        public DataTable viewemployee(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="select * from employee where Username='"+info.username+"'";
            return db.ExeReader(cmd);
        }

        public int insertwave(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO m_instument VALUES ('" + info.track1 + "','" + info.track2 + "','" + info.track3 + "','" + info.track4 + "','" + info.track5 + "','" + info.track6 + "','" + info.track7 + "','" + info.track8 + "','" + info.track9 + "','" + info.track10 + "','" + info.track11 + "','" + info.track12 + "','" + info.track13 + "')";
            return db.ExeNonQuery(cmd);
        }
       
    }
}
