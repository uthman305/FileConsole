using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Implementation
{
    public class CompanyManager : ICompanyManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\company.txt";
        public static List<Company> CompanyDb = new List<Company>();
        public Company Get(string name)
        {
            foreach (var company in CompanyDb)
            {
                if (company.CompanyName == name)
                {
                    return company;
                }
            }
            return null;
        }

        public Company Get(int id)
        {
            foreach (var company in CompanyDb)
            {
                if (company.Id == id)
                {
                    return company;
                }
            }
            return null;
        }
        public Company Add(Company company)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(company.ToString());
            }
            CompanyDb.Add(company);
            return company;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                CompanyDb.Add(ConvertToCompanyObject(item));

            }
        }
        private Company ConvertToCompanyObject(string data)
        {
            var newData = data.Split(' ');
            return new Company(int.Parse(newData[0]), newData[1], (int.Parse(newData[2])));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var company in CompanyDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(company.ToString());
                }
            }
        }
    }
}