using Microsoft.AspNetCore.Mvc;
using HospitalInformationSystem.Models;
using MySql.Data.MySqlClient;

namespace HospitalInformationSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly string _connectionString = "Server=localhost;Database=HospitalInformationSystem;Uid=root;Pwd=Yiyanglaw@2003;";

        public IActionResult Index()
        {
            var doctors = GetAllDoctors();
            return View(doctors);
        }

        public IActionResult Details(int id)
        {
            var doctor = GetDoctorById(id);
            return View(doctor);
        }

        // Helper method to retrieve all doctors from the database
        private List<Doctor> GetAllDoctors()
        {
            var doctors = new List<Doctor>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Doctor";
                using (var command = new MySqlCommand(query, connection))
                {
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

        // Helper method to retrieve a doctor by id from the database
        private Doctor GetDoctorById(int id)
        {
            Doctor doctor = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Doctor WHERE DoctorId = @DoctorId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doctor = new Doctor
                            {
                                DoctorId = Convert.ToInt32(reader["DoctorId"]),
                                Name = reader["Name"].ToString(),
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                Specialization = reader["Specialization"].ToString()
                            };
                        }
                    }
                }
            }
            return doctor;
        }
    }
}
