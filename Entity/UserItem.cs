using System;
using System.Text.Json;

namespace UsersTestApi.Entity
{
    public class UserItem
    {
        public int Id { get; set; }

        public string Name { get;  set; }

        public string FullName { get; set; }

        public DateTime DateCreated { get;  set; }

        public DateTime DateLastUpdated { get; set; }

        public string Status { get;  set; }

        public static string TestLogItem(UserItem argToLog)
        {
            string toLog = JsonSerializer.Serialize(argToLog);
            Console.WriteLine(toLog);
            return toLog;
        }
    }
}
