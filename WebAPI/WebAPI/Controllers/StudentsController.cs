using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentRepository _studentRepository = new StudentRepository();      
		//This is get request
        // Get api/students
        [HttpGet]
        public IHttpActionResult GetStudents()
        {
            var students = _studentRepository.SelectAll();
            if(students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet]
        // Get api/students/id
        public IHttpActionResult GetStudentById(int id)
        {
            var student = _studentRepository.SelectById(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}