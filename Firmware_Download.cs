using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoControlApp
{
    public static  class Firmware_Download
    {

       public static void Main_fw()
        {
            string hexFilePath = "C:\\path_to_hex_file\\your_file.hex";
            string stm32ProgrammerPath = "C:\\Program Files\\STMicroelectronics\\STM32Cube\\STM32CubeProgrammer\\bin\\STM32_Programmer_CLI.exe";

            // Belleği temizleme komutu
            string eraseCommand = $"-c port=usb1 -e all";

            // .hex dosyasını yükleme komutu
            string uploadCommand = $"-c port=usb1 -d \"{hexFilePath}\" -v -ob displ";

            try
            {
                // Belleği temizle
                ExecuteCommand(stm32ProgrammerPath, eraseCommand);

                // .hex dosyasını yükle
                ExecuteCommand(stm32ProgrammerPath, uploadCommand);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

       public static void ExecuteCommand(string filePath, string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = filePath;
            startInfo.Arguments = arguments;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
}
