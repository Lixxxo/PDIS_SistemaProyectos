using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaProyectos.Database
{
    public class MSSQLConection
    {
        public int id { get; set; }
        public string host { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string port { get; set; }
        public string dbName { get; set; }

        public MSSQLConection(
            string host, string user, string pass, string port, string dbName)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
            this.port = port;
            this.dbName = dbName;
        }
    }

 }
