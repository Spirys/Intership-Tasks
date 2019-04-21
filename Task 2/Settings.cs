using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    static class Settings
    {
        // Data Source=KOGITATOR\\SQLEXPRESS;Initial Catalog=test_db;User ID=test_user;Password=123456
        private static string dataSource = null;
        private static string initialCatalog = null;
        private static string userID = null;
        private static string password = null;

        public static string connectionString { get => $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={userID};Password={password}"; }

        public enum TermCodes
        {
            Success,
            ParsingError,
            SettingsFileDoesNotExist,
            SettinsFileCreated
        }

        /// <summary>
        /// Initialize settings
        /// </summary>
        /// <returns>
        /// Termination code:
        /// 0 - settings successfully setted
        /// 1 - error while parsing settings file
        /// 2 - settings file does not exist
        /// 3 - template settings file created
        /// </returns>
        public static int Init()
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length == 5)
            {
                dataSource = args[1];
                initialCatalog = args[2];
                userID = args[3];
                password = args[4];

                return (int)TermCodes.Success;
            }
            else if (args.Length == 2)
            {
                var settingsPath = args[1];

                if (System.IO.File.Exists(settingsPath))
                {
                    if (ParseSettings(settingsPath))
                    {
                        return (int)TermCodes.Success;
                    }
                    else
                    {
                        return (int)TermCodes.ParsingError;
                    }
                }
                else
                {
                    return (int)TermCodes.SettingsFileDoesNotExist;
                }
            }
            else if (System.IO.File.Exists("settings.txt"))
            {
                if (ParseSettings("settings.txt"))
                {
                    return (int)TermCodes.Success;
                }
                else
                {
                    return (int)TermCodes.ParsingError;
                }
            }
            else
            {
                CreateSettings();

                return (int)TermCodes.SettinsFileCreated;
            }
        }

        private static void CreateSettings()
        {
            System.IO.File.WriteAllText("settings.txt", "Data Source=<server address>\nInitial Catalog=<db name>\nUser ID=<user>\nPassword=<password>");
        }

        private static bool ParseSettings(string path)
        {
            var settings = System.IO.File.ReadAllLines(path)
                .Select(x => x.Split('=')[1])
                .ToArray();

            if (settings.Length != 4)
            {
                return false;
            }

            dataSource = settings[0];
            initialCatalog = settings[1];
            userID = settings[2];
            password = settings[3];

            return true;
        }
    }
}
