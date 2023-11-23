using System.IO;
using System.Text;

namespace Lesson_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
                return;
            if (args.Length == 2)
            {
                string dir = args[0];
                string fileName = args[1];
                Console.WriteLine(Find(dir, fileName));
            }
            else if (args.Length == 3)
            {
                Console.WriteLine(FindTextInFile(args[0], args[1], args[2]));
            }
        }
        private static string Find(string dir, string nameFile)
        {
            if (!Directory.Exists(dir))
                return "Такой директории не существует!";
            DirectoryInfo dirInf = new DirectoryInfo(dir);
            return RecursionFind(dirInf, nameFile);
        }
        private static string RecursionFind(DirectoryInfo dir, string nameFile)
        {
            var dirs = dir.GetDirectories();
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                if (file.Name.Equals(nameFile))
                    return file.FullName;
            }
            foreach (var dirF in dirs)
            {
                string find = RecursionFind(dirF, nameFile);
                if (find != null)
                {
                    return find;
                }
            }
            return null;
        }

        private static string FindTextInFile(string dir, string extensoin, string text)
        {
            if (!Directory.Exists(dir))
                return "Такой директории не существует!";
            string res = FindTextFileExtension(new DirectoryInfo(dir), extensoin, text);
            return res;
        }
        private static string FindTextFileExtension(DirectoryInfo dir, string extensoin, string text)
        {
            var files = dir.GetFiles("*" + extensoin);
            string result = null;
            foreach (var file in files)
            {
                using (FindFile ff = new FindFile(file))
                {
                    result = ff.ReadAll();
                    if (result.Contains(text))
                        return file.FullName;
                }
            }
            return "Нету (";
        }
        private static string FindStringInFile(DirectoryInfo dir, string extensoin, string text)
        {
            var files = dir.GetFiles("*" + extensoin);
            string result = null;
            foreach (var file in files)
            {
                byte[] buff = new byte[10];
                using (FindFile ff = new FindFile(@"G:\Metamit.com\Содержание.txt"))
                {
                    buff = new byte[10];
                    int len = ff.Read(buff, 0, (int)ff.Length);
                    buff = ff.Buffer;
                    if (len == buff.Length)
                    {
                        result = Encoding.Default.GetString(buff);
                        if (result.Contains(text))
                            return file.FullName;
                    }

                }
            }
            return "Нету (";
        }
    }
}