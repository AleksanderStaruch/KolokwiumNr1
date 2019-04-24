using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumNr1.DAL
{
    public class DB
    {
        PjatkDb pjatkDb;
        public DB()
        {
            pjatkDb = new PjatkDb();
        }

        public List<Emp> GetEmps()
        {
            var emp = pjatkDb.Students;

            return emp.Include(s => s.Study).ToList();
        }

        public List<Dept> GetDept()
        {
            var dept = pjatkDb.Students;

            return dept.ToList();
        }


        public void AddEmp(Emp emp)
        {
            pjatkDb.Students.Add(emp);

            pjatkDb.SaveChanges();
        }


    }
}
