using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Data.Contracts
{
    public interface ILocalFileProvider
    {
        Task<string> GetFileContents(string filename);
    }
}
