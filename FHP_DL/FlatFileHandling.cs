//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;
//using FHP_VO;
//using Resources;


//namespace FHP_DL
//{
//    public class FlatFileHandling
//    {


//    }
//    /// <summary>
//    /// Represents a file handling utility for managing employee records.
//    /// </summary>
//    public class RecordFileManager
//    {

//        /* private string filePath;

//         public RecordFileManager(string filePath)
//         {
//             this.filePath = filePath;
//         }*/
//        FileInformation file = new FileInformation();

//        /// <summary>
//        /// Adds a new employee record to the file.
//        /// </summary>      
//        public void AddRecord(EmployeeData record)
//        {
//            try
//            {
//                byte[] recordBytes = record.ToBytes();
//                string filePath = file.FilePath();
//                using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
//                {
//                    fileStream.Write(recordBytes, 0, recordBytes.Length);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error writing to file: {ex.Message}");
//            }
//        }
//        /// <summary>
//        /// Reads all employee records from the file.
//        /// </summary>
//        public List<EmployeeData> ReadAllRecords()
//        {
//            List<EmployeeData> records = new List<EmployeeData>();

//            try
//            {
//                string filePath = file.FilePath();
//                byte[] fileBytes = File.ReadAllBytes(filePath);

//                for (int i = 0; i < fileBytes.Length; i += Marshal.SizeOf<EmployeeData>())
//                {
//                    byte[] recordBytes = new byte[Marshal.SizeOf<EmployeeData>()];
//                    Array.Copy(fileBytes, i, recordBytes, 0, Marshal.SizeOf<EmployeeData>());

//                    EmployeeData record = EmployeeData.FromBytes(recordBytes);
//                    records.Add(record);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error reading from file: {ex.Message}");
//            }
//            return records;
//        }

//        public void UpdateRecord(long srNo, EmployeeData updatedRecord)
//        {
//            try
//            {
//                List<EmployeeData> allRecords = ReadAllRecords();

//                int index = allRecords.FindIndex(record => record.SrNo == srNo);

//                if (index != -1)
//                {
//                    allRecords[index] = updatedRecord;
//                    string filePath = file.FilePath();
//                    File.WriteAllText(filePath, string.Empty);

//                    foreach (var record in allRecords)
//                    {
//                        AddRecord(record);
//                    }
//                }
//                else
//                {
//                    Console.WriteLine($"Record with SrNo {srNo} not found.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error updating record: {ex.Message}");
//            }
//        }

//    }
//}