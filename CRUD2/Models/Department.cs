namespace CRUD2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int empId { get; set; }
        public ICollection<Employeee> emp {  get; set; }
    }
}
