using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.binarytree
{
    class Employee : IComparable<Employee>
    {
        public uint Id { set; get; }
        public string Name { set; get; }
        public UInt64 PhoneNumber { set; get; }
        public string Province { set; get; }

        public override string ToString()
        {
            return String.Format("Id:{0} Name:{1} PhoneNumber:{2} Province:{3}", this.Id, this.Name, this.PhoneNumber, this.Province);
        }

        public override bool Equals(object obj) //判断与之比较的类型是否为null。这样不会造成递归的情况
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Employee e = (Employee)obj;
            return this.Id == e.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Employee lhs, Employee rhs)
        {
            return Object.Equals(lhs, rhs);
        }

        public static bool operator !=(Employee lhs, Employee rhs)
        {
            return !Object.Equals(lhs, rhs);
        }

        int IComparable<Employee>.CompareTo(Employee other)
        {
            int ret;
            if (this.Id > other.Id)
            {
                ret = 1;
            }
            else if (this.Id == other.Id)
            {
                ret = 0;
            }
            else
            {
                ret = -1;
            }
            return ret;
        }
    }
}
