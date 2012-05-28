using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;

namespace ConsoleApplicationTest.database
{
    public static class DataBaseHelper
    {
        private static StreamWriter _databaseLog = new StreamWriter(@"database_log.txt", false); // Append

        public static void InitializeDatabase(DataContextBase db, bool isCreateNew)
        {
            if (File.Exists(db.DataBasePath))
            {
                if (isCreateNew)
                {
                    File.Delete(db.DataBasePath);
                    CreateDatabase(db);
                }
            } 
            else
            {
                CreateDatabase(db);
            }
        }

        public static void CreateDatabase(DataContextBase db)
        {
            try
            {
                // Generate the database (with structure) from the code-based data context
                db.CreateDatabase();

                // Populate the database with system data
                GenerateDefaultData(db);
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error while creating the DB: " + ex.Message);
            }
        }

        private static void GenerateDefaultData(DataContextBase db)
        {
            //Add Contact
            db.TableContact.InsertOnSubmit(new Contact());
            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Make some adjustments.
                // ...
                // Try again.
                //db.SubmitChanges();
            }
        }

        public static void EnableDatabaseLog(DataContextBase db)
        {
            if (db.Log == null)
            {
                db.Log = _databaseLog;
            }
        }

        public static void DisableDatabaseLog(DataContextBase db)
        {
            if (db.Log != null)
            {
                db.Log.Close();
                db.Log = null;
            }
        }
    }
}
