﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace _1YearProject
{
    class DB
    {
        internal string username { get; set; }
        internal string password { get; set; }
        public static DB instance;

        public void CreateUser()
        {
        }
        public void Login()
        {

        }

        private DB()
        {
            CreateDatabase();
        }
        public static DB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DB();
                }
                return instance;
            }
        }
        private void Sqlcommannd(object c)
        {
            try
            {
                string connStr = "Data source=YearProject.db;Version=3";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                conn.Open();
                string sql = c + "";
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                }
            }
            catch (SQLiteException a)
            {
                Console.WriteLine(a.Message);
            }
        }
        public void CreateDatabase()
        {
            if(File.Exists("YearProject.db"))
            {
                SQLiteConnection dbConn = new
                SQLiteConnection("Data Source=YearProject.db;Version=3;");
                dbConn.Open();
            }
            else
            {
                SQLiteConnection.CreateFile("YearProject.db");
                SQLiteConnection dbConn = new
                SQLiteConnection("Data Source=YearProject.db;Version=3;");
                dbConn.Open();
                String connStr = "Data Source=YearProject.db;Version=3";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                Sqlcommannd("Create Table Score(Time int, Wave int, Name string, UserID)");
                Sqlcommannd("Create Table State(Life int, Gold int, Wave int)");
                Sqlcommannd("Create table User(id integer primary key, Password string, Username string, UserID int)");
                Sqlcommannd("Create Table Component(Name string, Position int, Sprite, Type, Upgrade)");
            }
        }
    }
}
