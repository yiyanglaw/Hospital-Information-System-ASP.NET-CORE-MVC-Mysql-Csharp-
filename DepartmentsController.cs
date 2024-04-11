using Microsoft.AspNetCore.Mvc;
using HospitalInformationSystem.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HospitalInformationSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly string _connectionString = "Server=localhost;Database=HospitalInformationSystem;Uid=root;Pwd=Yiyanglaw@2003;";

        public IActionResult Index()
        {
            var departments = GetAllDepartments();
            return View(departments);
        }

        public IActionResult Doctors(int id)
        {
            var doctors = GetDoctorsByDepartmentId(id);
            return View(doctors);
        }

        // Helper method to retrieve all departments from the database
        private List<Department> GetAllDepartments()
        {
            var departments = new List<Department>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Department";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                Name = reader["Name"].ToString()
                            });
                        }
                    }
                }
            }
            return departments;
        }

        // Helper method to retrieve doctors by department id from the database
        private List<Doctor> GetDoctorsByDepartmentId(int departmentId)
        {
            var doctors = new List<Doctor>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Doctor WHERE DepartmentId = @DepartmentId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentId", departmentId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                DoctorId = Convert.ToInt32(reader["DoctorId"]),
                                Name = reader["Name"].ToString(),
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                Specialization = reader["Specialization"].ToString()
                            });
                        }
                    }
                }
            }
            return doctors;
        }
    }
}
