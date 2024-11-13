namespace CRUD2.DTOs.Employees
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
    }
}
