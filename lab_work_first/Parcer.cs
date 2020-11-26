using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_first
{
    class Parcer
    {
        //Создаем словарь(секци,словарь(ключ-значение))
        private Dictionary<string, Dictionary<string, object>> sections = new Dictionary<string, Dictionary<string, object>>();
        //Конструктор
        public Parcer(string file)
        {
            //Проверка на существование файла
            if (File.Exists(file) == false)
                throw new Exception("File does not exist");
            //Проверка на правильность формата файла
            if (!file.EndsWith(".ini"))
                throw new Exception("Wrong format of the file");
            //Создается поток чтения
            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            //удаляем пробелы сначала и конца строки
            line = line.Trim();
            //заполняем главный словарь
            while (!sr.EndOfStream)
            {
                if (line.StartsWith("["))
                {
                    line = ReadSectionName(line);
                    //словарь(ключ-значение)
                    Dictionary<string, object> key_value = new Dictionary<string, object>();
                    sections.Add(line, key_value);
                    line = sr.ReadLine();

                    //считывыаем все содеримое секции в словарь(ключ-значение)
                    while (!line.StartsWith("["))
                    {
                        //вырезаем часть комментария из строчки
                        if (line.IndexOf(';') != -1)
                        {
                            int indexOfChar = line.IndexOf(';');
                            line = line.Substring(0, indexOfChar - 1);
                        }
                        string[] arr = line.Split('=');
                        string key = arr[0].Trim();
                        string value = arr[1];
                        object val = GetValue(value);
                        key_value.Add(key, val);
                        line = sr.ReadLine();
                        //Если файл кончился - закрываем поток чтения
                        if (line == null) { break; }
                        //игнорируем пустые строки и комментарии
                        while (line == "" || line.StartsWith(";")) { line = sr.ReadLine(); }
                    }
                }
            }
            sr.Close();
        }
        //записывавет название секции
        private string ReadSectionName(string line)
        {
            int first = line.IndexOf("[");
            int second = line.IndexOf("]");
            string name = line.Substring(first + 1, second - first - 1);
            return name;
        }

        public object FindValue(string nameSection, string nameValue, Type type)
        {
            if (!sections.ContainsKey(nameSection)) throw new Exception("File does not contain this section");
            var section = sections[nameSection];
            if (!section.ContainsKey(nameValue)) throw new Exception("File does not contain this value");
            var value = section[nameValue];
            if (value.GetType() != type) throw new Exception("Not correct type");
            return value;
        }

        //преобразуем значение
        private object GetValue(string value)
        {
            int val;
            if (int.TryParse(value, out val)) return val;
            double d_val;
            if (double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out d_val)) return d_val;
            return value;
        }
    }
}
