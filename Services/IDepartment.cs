using MVCNew_project.Models;

namespace MVCNew_project.Services
{
    public interface IDepartment
    {
        public List<Department> GetAll();
        public void DeleteById(int id);
        public void update(Department std);
        public Department Find(int? id);
        public void Add(Department st);

    }
}
