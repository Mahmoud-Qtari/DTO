﻿namespace CRUD2.DTOs.Employees
{
    public class RemoveEmpDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
    }
}
