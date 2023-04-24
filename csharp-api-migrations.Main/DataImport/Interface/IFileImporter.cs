using csharp_api_migrations.Main.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_api_migrations.Main.DataImport.Interface
{
    public interface IFileImporter
    {
        List<Customer> ProcessCustomerCsvFile(string path);
        List<Customer> ProcessProductsCsvFile(string path);
    }
}
