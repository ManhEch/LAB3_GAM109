using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bai 1:");
            string path = "example.txt";

            // Nhập dữ liệu từ bàn phím
            Console.Write("Nhập username: ");
            string username = Console.ReadLine();

            Console.Write("Nhập password: ");
            string password = Console.ReadLine();

            // Ghi dữ liệu vào file
            using (FileStream fs = new FileStream(path, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine("username: " + username);
                sw.WriteLine("password: " + password);
            }

            Console.WriteLine("\nDữ liệu đã được ghi vào file.\n");

            // Đọc và hiển thị nội dung file
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                Console.WriteLine("Nội dung trong file:");
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("Bai 2:");
            string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            string content;

            // Ghi dữ liệu bằng StringWriter
            using (StringWriter sw = new StringWriter())
            {
                sw.WriteLine("username: " + username);
                sw.WriteLine("password: " + password);
                sw.WriteLine("time save: " + time);

                // Lấy chuỗi nội dung đã ghi
                content = sw.ToString();
            }

            Console.WriteLine("== Noi dung da ghi (chuoi content) ==");
            Console.WriteLine(content);

            // Đọc dữ liệu bằng StringReader
            using (StringReader sr = new StringReader(content))
            {
                string line;
                Console.WriteLine("== Doc lai bang StringReader ==");
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("Bai 3:");
            // Bước 1: Nhập thông tin từ người dùng
            Console.Write("Nhập MSVV: ");
            string msvv = Console.ReadLine();

            Console.Write("Nhập Họ và tên: ");
            string hoTen = Console.ReadLine();

            // Bước 2: Tạo thư mục "data"
            string sourceDir = "data";
            Directory.CreateDirectory(sourceDir);

            // Bước 3: Tạo file "data.txt" và ghi dữ liệu người dùng
            string filePath = Path.Combine(sourceDir, "data.txt");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Msvv: " + msvv);
                sw.WriteLine("Họ và tên: " + hoTen);
            }

            Console.WriteLine("\nDữ liệu đã được ghi vào data/data.txt");

            // Bước 4: Tạo thư mục "data2"
            string targetDir = "data2";
            Directory.CreateDirectory(targetDir);

            // Bước 5: Copy file từ "data" sang "data2"
            DirectoryInfo dirInfo = new DirectoryInfo(sourceDir);
            FileInfo[] files = dirInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                string targetFilePath = Path.Combine(targetDir, file.Name);
                file.CopyTo(targetFilePath, true); // true = ghi đè nếu file đã tồn tại
            }

            Console.WriteLine("Đã sao chép toàn bộ file từ 'data' sang 'data2'.");
        
        }
    }
}
