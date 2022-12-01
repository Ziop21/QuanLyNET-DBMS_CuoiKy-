using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DefinedFunction
    {
        [EdmFunction("NETModel.Store", "sf_DangNhapTaiKhoan")]
        public static string sf_DangNhapTaiKhoan(string taikhoan_input, string matkhau_input)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}

