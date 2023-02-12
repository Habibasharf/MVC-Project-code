using MVCNew_project.Services;

namespace MVCNew_project.Models
{
    public class DepartmentMoc:IDepartment
    {
        List<Department> departments = new List<Department>() { new Department() { DeptID=1,DeptName="OS",Capacity=20},
            new Department() { DeptID=2,DeptName="IS",Capacity=40},
            new Department() { DeptID=3,DeptName="IT",Capacity=22},
            new Department() { DeptID=4,DeptName=".NET",Capacity=24},
            new Department() { DeptID=5,DeptName="CS",Capacity=30}
     };

        public List<Department> GetAll()
        {
            return departments;
        }
        public void Add(Department st)
        {
            departments.Add(st);
        }
        public Department Find(int? id)
        {
            return departments.FirstOrDefault(a => a.DeptID == id);
        }
        public void update(Department std)
        {
            var model = departments.FirstOrDefault(a => a.DeptID == std.DeptID);
            if (model == null) return;

            model.DeptName = std.DeptName;
            model.Capacity = std.Capacity;


        }
        public void DeleteById(int id)
        {
            var model = departments.FirstOrDefault(a => a.DeptID == id);
            if (model == null) return;

            departments.Remove(model);


        }
    }
}
