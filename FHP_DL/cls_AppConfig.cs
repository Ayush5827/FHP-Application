//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace FHP_DL
//{
//    public  class cls_AppConfig
//    {
        
//            public static void InitializeStorage()
//            {
//            string iniFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");

//            // Check if the INI file already exists
//            if (!File.Exists(iniFilePath))
//            {
//                // Create the INI file and write default configuration
//                using (StreamWriter writer = File.CreateText(iniFilePath))
//                {
//                    writer.WriteLine("[Storage]");
//                    writer.WriteLine("Type=DataBase"); // Initial configuration
//                }

//                MessageBox.Show("INI file created successfully.");
//            }
//            else
//            {
//                MessageBox.Show("INI file already exists.");
//            }

//            AppConfig config = new AppConfig("config.ini");
//                string storageType = config.ReadSetting("Storage", "Type");

//                if (storageType.Equals("FlatFile", StringComparison.OrdinalIgnoreCase))
//                {
//                    FlatFileStorage storage = new FlatFileStorage();
//                    // Now you can use 'storage' to interact with flat file storage
//                    MessageBox.Show("Initialized FlatFileStorage");
//                }
//                else if (storageType.Equals("DataBase", StringComparison.OrdinalIgnoreCase))
//                {
//                    //DatabaseStorage storage = new DatabaseStorage();
//                cls_FileHandling dbOperations = new cls_FileHandling();

//                // Example: Read data from the database
//                string dataFromDatabase = cls_FileHandling.dbOperations.GetAllEmployee();

//                // Example: Write data to the database
//                dbOperations.AddEmployeeInfoIntoFile("Data to write to database");

//                MessageBox.Show("Initialized DatabaseStorage");
//                // Now you can use 'storage' to interact with database storage
//                MessageBox.Show("Initialized DatabaseStorage");
//                }
//                else
//                {
//                // Handle unknown storage type
//                    MessageBox.Show("Unknown storage type specified in config.ini");
//                }
//            }
//        }

//        public class AppConfig
//        {
//            private string iniPath;

//            public AppConfig(string fileName)
//            {
//                iniPath = fileName;

//                // If the INI file doesn't exist, create it with default values
//                if (!File.Exists(iniPath))
//                {
//                    // Default configuration
//                    string defaultConfig = "[Storage]\nType=FlatFile";
//                    File.WriteAllText(iniPath, defaultConfig);
//                }
//            }

//            public string ReadSetting(string section, string key)
//            {
//                // Your implementation for reading settings from config.ini
//                // In this example, we simply read the content of the INI file
//                string[] lines = File.ReadAllLines(iniPath);
//                foreach (string line in lines)
//                {
//                    if (line.StartsWith($"{section}=", StringComparison.OrdinalIgnoreCase))
//                    {
//                        string[] parts = line.Split('=');
//                        if (parts.Length == 2 && parts[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
//                            return parts[1].Trim();
//                    }
//                }
//                return null; // Setting not found
//            }
//        }

//        public class FlatFileStorage
//        {
//            // Placeholder for FlatFileStorage class
//        }

//        public class DatabaseStorage
//        {
//            // Placeholder for DatabaseStorage class
//        }
//    }

