using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.database
{
    [Table(Name = "TableContact")]
    public class Contact : TableBase
    {
        private UInt64 _ContactID;
        private string _ContactName;

        public Contact()
        {
            _ContactID = 1;
            _ContactName = "zhangyinglong";
        }



        [Column(Storage = "_ContactID", DbType = "BIGINT NOT NULL", IsPrimaryKey = true)]
        public UInt64 ContactID
        {
            get
            {
                return this._ContactID;
            }
            set
            {
                if ((this._ContactID != value))
                {
                    this.SendPropertyChanging("ContactID");
                    this._ContactID = value;
                    this.SendPropertyChanged("ContactID");
                }
            }
        }

        [Column(Storage = "_ContactName", DbType = "NVarChar(50) NOT NULL")]
        public string ContactName
        {
            get
            {
                return this._ContactName;
            }
            set
            {
                if ((this._ContactName != value))
                {
                    this.SendPropertyChanging("ContactName");
                    this._ContactName = value;
                    this.SendPropertyChanged("ContactName");
                }
            }
        }
    }
}
