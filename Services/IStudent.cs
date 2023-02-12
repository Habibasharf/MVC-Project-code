using MVCNew_project.Models;

namespace MVCNew_project.Services
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public void DeleteById(int id);
        public void update(Student std);
        public Student Find(int? id);
        public void Add(Student st);

    }
}
