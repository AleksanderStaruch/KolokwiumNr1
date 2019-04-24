using KolokwiumNr1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumNr1.DAL
{
    public class DB
    {
        pjatkDb pjatkDb;
        public DB()
        {
            pjatkDb = new pjatkDb();
        }

        public List<EMP> GetEmps()
        {
            var emp = pjatkDb.EMPs;

            return emp.ToList();
        }

        public List<DEPT> GetDepts()
        {
            var dept = pjatkDb.DEPTs;

            return dept.ToList();
        }


        public void AddEmp(EMP emp)
        {
            var id = (from EMP in pjatkDb.EMPs
                     select EMP.EMPNO).Max();
            emp.EMPNO = id + 1;
            
            pjatkDb.EMPs.Add(emp);

            pjatkDb.SaveChanges();
        }


    }
}
