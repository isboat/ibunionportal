﻿using System;
using System.Data;

namespace Portal.DataAccess.Repositories
{
    public static class DataAccessHelper
    {
        public static bool IsNull(IDataRecord row, string key)
        {
            return row[key] is DBNull || row[key] == null;
        }

        public static int ToInt(IDataRecord row, string column)
        {
            return Convert.ToInt32(row[column]);
        }

        public static DateTime ToDateTime(IDataRecord row, string column)
        {
            return DateTime.ParseExact(row[column].ToString(), "dd/MM/yyyy HH:mm:ss", null);
        }

        public static string ToStr(IDataRecord row, string column)
        {
            return IsNull(row, column) ? null : (string)row[column];
        }
    }
}
