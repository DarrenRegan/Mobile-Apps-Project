using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace myApp.Models
{
    public interface SQLiteInterface
    {
        SQLiteConnection GetConnection();
    }
}
