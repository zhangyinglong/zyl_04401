using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.database
{
    public class DataContextBase : DataContext
    {
        private static MappingSource _mappingSource = new AttributeMappingSource();
        public string DataBasePath { private set; get; }//= @"Data Source=Feiliao.sdf";

        public DataContextBase(string connection) :
            base(connection, _mappingSource)
        {
            this.DataBasePath = FilePath(connection);  
        }

        public DataContextBase(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
            this.DataBasePath = FilePath(connection); 
        }

        private string FilePath(string path)
        {
            int startPos = path.IndexOf('=') + 1;
            return path.Substring(startPos, path.Length - startPos);
        }

        public Table<Contact> TableContact
        {
            get
            {
                return this.GetTable<Contact>();
            }
        }
    }
}
