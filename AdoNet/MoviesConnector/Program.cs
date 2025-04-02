using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace MoviesConnector
{
    class Program
    {
        static void Main(string[]args)
        {
            const string CONNECTION_STRING =    "Server=.;" +
                                                "TrustServerCertificate=True;" +
                                                "Database=Movies_VPD_311;" +
                                                "User Id= sa;" +
                                                "Password= Zimbo34513451;";
            Connector connector = new Connector(CONNECTION_STRING);
            connector.Select("SELECT* FROM Directors");
            connector.Select("SELECT* FROM Movies");
        }
    }
}

