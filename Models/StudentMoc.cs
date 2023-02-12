using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using MVCNew_project.Services;

namespace MVCNew_project.Models
{
    public class StudentMoc:IStudent
    {
        List<Student> students = new List<Student>() { new Student() { ID=10,Name="Habiba",Age=20,Email="a@km.sss",ImageName="2.jpg"},
        new Student() { ID=50,Name="Ahmed",Age=30,Email="a@km.sss",ImageName="8.jpg"},
        new Student() { ID=20,Name="Ali",Age=40,Email="a@km.sss",ImageName="60.jpg"},
        new Student() { ID=30,Name="Hani",Age=18,Email="a@km.sss",ImageName="1.jpg"},
        new Student() { ID=40,Name="Radwa",Age=25,Email="a@km.sss", ImageName = "2.jpg"}};

        public List<Student> GetAll()
        {
            return students;
        }
        public void Add(Student st)
        {
            students.Add(st);
        }
        public Student Find(int? id )
        {
            return students.FirstOrDefault(a => a.ID == id);
        }
        public void update(Student std )
        {
            var model = students.FirstOrDefault(a => a.ID == std.ID);
            if (model == null) return;
            
                model.Name = std.Name;
                model.Age = std.Age;
            

        }
        public void DeleteById(int id)
        {
            var model = students.FirstOrDefault(a => a.ID == id);
            if (model == null) return;

            students.Remove(model);


        }
    }
}
