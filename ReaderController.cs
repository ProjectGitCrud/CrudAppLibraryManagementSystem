using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAppLibraryManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CrudAppLibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //Using IConfiguration we will get our connection string for connectivity with sql server
        public ReaderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Creating API's for CRUD Operation
        [HttpGet]
        [Route("GetAllReaders")]
        public ReaderResponse GetAllReaders()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            ReaderResponse response = new ReaderResponse();

            DAL dal = new DAL();
            response = dal.GetAllReaders(connection);

            return response;
        }

        [HttpGet]
        [Route("GetReaderById/{id}")]
        public ReaderResponse GetReadersById(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            ReaderResponse response = new ReaderResponse();

            DAL dal = new DAL();
            response = dal.GetReadersById(connection, id);

            return response;
        }

        [HttpPost]
        [Route("AddReader")]
        public ReaderResponse AddReader(Reader reader)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            ReaderResponse response = new ReaderResponse();

            DAL dal = new DAL();
            response = dal.AddReader(connection, reader);

            return response;
        }

        [HttpPut]
        [Route("UpdateReader")]
        public ReaderResponse UpdateReader(Reader reader)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            ReaderResponse response = new ReaderResponse();

            DAL dal = new DAL();
            response = dal.UpdateReader(connection, reader);

            return response;
        }

        [HttpDelete]
        [Route("DeleteReader/{id}")]
        public ReaderResponse UpdateReader(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());

            ReaderResponse response = new ReaderResponse();

            DAL dal = new DAL();
            response = dal.DeleteReader(connection, id);

            return response;
        }


    }
}
