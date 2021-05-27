using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using lab6_kpi;


namespace lab6_tests
{
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CategoriesMap : ClassMap<Category>
    {
        public CategoriesMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.Id).Name("Id");
          
        }
    }
    
    public class CsvHandler<T>
    {
        public static void CsvEx(IList records,string path)
        {

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CategoriesMap>();
                csv.WriteRecords(records);
            }
        }

        public static List<T> ReadCsv(string path)
        {
            var records = new List<T>();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CategoriesMap>();
                records = csv.GetRecords<T>().ToList();
            }
            return records;
        }
    }
}