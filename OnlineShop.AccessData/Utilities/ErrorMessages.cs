using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.AccessData.Utilities
{
    public static class ErrorMessages
    {
        public const string INVALID_FILE_FORMAT = "Invalid file format. Please choose another file!";
        public const string INVALID_FILE_SIZE = "Invalid file size. Please choose another file!";
        public const string DELETE_FAILD = "Can not deleted this record!";
        public const string STRING_DELETE_STATEMENT_CONFLICTED = "The DELETE statement conflicted with the REFERENCE";
        public const string STRING_FILES_EMPTY = "Please select at least one file!";
        public const string STRING_UPDATE_FAILD = "Can't not update this record!";
        public const string INVALID_STATUS = " is invalid status, please choose again!";
    }
}
