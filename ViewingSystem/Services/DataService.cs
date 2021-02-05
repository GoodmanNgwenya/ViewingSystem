using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ViewingSystem.Models;

namespace ViewingSystem.Services
{
    public class DataService
    {

        OleDbConnection Conn;
        OleDbCommand Cmd;
        string FilePath;
        public DataService()
        {
            //If your file is located on C Drive call this file path
           //FilePath = @"C:\\TechnicalAssesmentData.xlsx";
           
           //Calling File located Under folder called FileData
           FilePath = Path.Combine(Environment.CurrentDirectory, @"..\\..\\..\\FileData\TechnicalAssesmentData.xlsx");

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 12.0;Persist Security Info=True";
            Conn = new OleDbConnection(connectionString);
        }

        /// <summary>
        /// Login Method
        /// </summary>
        /// <returns></returns>
        public async Task<User> LoginAsync(string username, string password)
        {
            User user = new User();

            await Conn.OpenAsync();
            Cmd = new OleDbCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * From [UserDetails$] where Name='" + username + "' and Password='" + password + "'";
            var Reader = await Cmd.ExecuteReaderAsync();

            while (Reader.Read())
            {
                user.Id = Convert.ToInt32(Reader["UserID"]);
                user.Name = Reader["Name"].ToString();
                user.Surname = Reader["Surname"].ToString();
                user.DateOfBirth = Convert.ToDateTime(Reader["Date Of Birth"]);
            }
            Reader.Close();
            Conn.Close();
            return user;
        }

        /// <summary>
        /// Get all record for  calls from UserDetails 
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Caller>> GetAllCallsAsync()
        {
            ObservableCollection<Caller> Calls = new ObservableCollection<Caller>();

            await Conn.OpenAsync();
            Cmd = new OleDbCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * From [Details$]";
            var Reader = await Cmd.ExecuteReaderAsync();

            while (Reader.Read())
            {
                if (Reader["UserID"] != null && !(Reader["UserID"] is DBNull))
                {
                    Calls.Add(new Caller()
                    {
                        Outbound = Reader[0].ToString(),
                        Extension = Reader[1].ToString(),
                        CallerNumber = Reader["Caller Number"].ToString(),
                        Recording = Convert.ToInt32(Reader["Recording"]),
                        Date = Convert.ToDateTime(Reader["Date"]),
                        Time = Convert.ToDateTime(Reader["Time"]),
                        Duration = Convert.ToDateTime(Reader["Duration"]),
                        TimeBetweenCalls = Convert.ToDateTime(Reader["Time Between Calls"])
                    });
                }
            }
            Reader.Close();
            Conn.Close();
            return Calls;

        }

        /// <summary>
        /// Get All call per UserID
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Caller>> GetCallsByIdAsync(int userid)
        {
            ObservableCollection<Caller> Calls = new ObservableCollection<Caller>();

            await Conn.OpenAsync();
            Cmd = new OleDbCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * From [Details$] where UserID='"+userid+"'";
            var Reader = await Cmd.ExecuteReaderAsync();

            while (Reader.Read())
            {
                    Calls.Add(new Caller()
                    {
                        Outbound = Reader[0].ToString(),
                        Extension = Reader[1].ToString(),
                        CallerNumber = Reader["Caller Number"].ToString(),
                        Recording = Convert.ToInt32(Reader["Recording"]),
                        Date = Convert.ToDateTime(Reader["Date"]),
                        Time = Convert.ToDateTime(Reader["Time"]),
                        Duration = Convert.ToDateTime(Reader["Duration"]),
                        TimeBetweenCalls = Convert.ToDateTime(Reader["Time Between Calls"]),
                        UserId = Convert.ToInt32(Reader["UserID"])
                    });
            }
            Reader.Close();
            Conn.Close();
            return Calls;

        }
    }
}
