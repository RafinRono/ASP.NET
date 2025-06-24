using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static void Create(StudentDTO st)
        {
            var catRepo = new StudentRepo();
            catRepo.Create(Convert(st));
        }

        public static void Update(StudentDTO st)
        {
            var catRepo = new StudentRepo();
            catRepo.Update(Convert(st));
        }

        public static void Delete(int id)
        {
            var catRepo = new StudentRepo();
            catRepo.Delete(id);
        }

        public static List<StudentDTO> Get()
        {
            var catRepo = new StudentRepo();
            var data = catRepo.Get();

            return Convert(data);
        }

        public static StudentDTO Get(int id)
        {
            var catRepo = new StudentRepo();
            var data = catRepo.Get(id);

            return Convert(data);
        }

        public static StudentDTO Convert(Student data)
        {
            if (data == null) return null;
            else
            {
                StudentDTO st = new StudentDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Cgpa = data.Cgpa,
                };
                return st;
            }
        }

        public static Student Convert(StudentDTO data)
        {
            if (data == null) return null;
            else
            {
                Student st = new Student()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Cgpa = data.Cgpa,
                };
                return st;
            } 
        }

        public static List<StudentDTO> Convert(List<Student> data)
        {
            List<StudentDTO> list = new List<StudentDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public static List<Student> Convert(List<StudentDTO> data)
        {
            List<Student> list = new List<Student>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
    }
}
