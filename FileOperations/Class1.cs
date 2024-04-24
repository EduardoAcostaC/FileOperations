using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
    public class FileHelper
    {
        private string logFilePath = "log.txt";

      

        public void MoveExcelFile(string excelFilePath, string newFileName, string destinationPath)
        {
            try
            {
                string destinationFolderPath = Path.Combine(destinationPath, "Archivos Procesados");

                if(!Directory.Exists(destinationFolderPath))
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }
                string newFilePath = Path.Combine (destinationFolderPath, newFileName);
                File.Move(excelFilePath, newFilePath);
                LogToFile($"Archivo de Excel movido a: {newFilePath}");
            }
            catch (Exception ex)
            {
                LogToFile($"Error al mover archivo de Excel: {ex.Message}");
            }
        }


        private void LogToFile(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }


    }
}
