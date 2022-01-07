using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using WebAPI.Controllers;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPIUnitTest
{
    [TestClass]
    public class StudentsControllerTest
    {
        public static StudentsController studentController = new StudentsController();
        [TestMethod]
        public void GetStudents_ReturnListStudents()
        {  
            var result = studentController.GetStudents();
            Assert.IsNotNull(result);
          
        }

        [TestMethod]
        public void GetStudentsById_ReturnStudent()
        {
            var result = studentController.GetStudentById(1);
            var student = result as OkNegotiatedContentResult<Student>;
            Assert.IsNotNull(result);
            Assert.AreEqual("Tibbetts", student.Content.LastName);
            Assert.AreEqual("Tests", student.Content.FirstName);
        }
    }
}
