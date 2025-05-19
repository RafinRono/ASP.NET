using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo: Repo
    {
        public void Create(Student obj)
        {
            db.Students.Add(obj);
            db.SaveChanges();
        }
        public void Update(Student obj)
        {
            var test = db.Students.Find(obj.Id);
            test.Name = obj.Name;
            test.Cgpa = obj.Cgpa;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = db.Students.Find(id);
            db.Students.Remove(data);
            db.SaveChanges();
        }
        public List<Student> Get()
        {
            return db.Students.ToList();
        }
        public Student Get(int id)
        {
            return db.Students.Find(id);
        }
    }
}
