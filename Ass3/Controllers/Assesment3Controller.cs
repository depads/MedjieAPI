using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text;
using System.Data;
namespace Ass3.Controllers
{
    public class Assesment3Controller : ApiController
    {
        private HttpResponseMessage response; //Global variable for response
        DataSet ds = new DataSet(); //GLOBAL VARIABLE FOR DATASET

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        //API ROUTE: api/employee/list
        [Route("api/employee/list", Name = "Get_Employee_List")]
        public IHttpActionResult GetChromiumSchoolyearList()
        {
            List<ModEmployeeList> stats = new List<ModEmployeeList>();
            using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    try
                    {

                        sqlConn.Open();
                        using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee", sqlConn))
                        {
                            using (MySqlDataReader dtReader = msqlcom.ExecuteReader())
                            {
                                if (dtReader.HasRows)

                                {

                                    while (dtReader.Read())

                                    {

                                        ModEmployeeList dataObj = new ModEmployeeList();
                                        dataObj.imployee_id = dtReader["imployee_id"].ToString();
                                        dataObj.employee_last_name = dtReader["employee_last_name"].ToString();
                                        dataObj.employee_first_name = dtReader["employee_first_name"].ToString();
                                        dataObj.employee_username = dtReader["employee_username"].ToString();
                                        dataObj.employee_password = dtReader["employee_password"].ToString();
                                        dataObj.employee_account_status = dtReader["employee_account_status"].ToString();

                                        stats.Add(dataObj);

                                    }

                                    return Ok(stats);

                                }
                                else
                                {

                                    return NotFound();
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                        return Content(HttpStatusCode.InternalServerError, ex);
                    }
                }
                else
                {
                    return InternalServerError();
                }
            }
        }

        //CLASS MODEL FOR THE EMPLOYEE LIST
        public class ModEmployeeList
        {

            public string imployee_id { get; set; }
            public string employee_last_name { get; set; }
            public string employee_first_name { get; set; }
            public string employee_username { get; set; }
            public string employee_password { get; set; }
            public string employee_account_status { get; set; }
        }
        [Route("api/employee/details", Name = "Get_Employee_Details")]
        public IHttpActionResult Get_Employee_Details(string imployee_id)
        {
            List<ModEmployeeList> stats = new List<ModEmployeeList>();
            using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    try
                    {

                        sqlConn.Open();

                        using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee WHERE imployee_id = @imployee_id LIMIT 1", sqlConn))

                        {
                            msqlcom.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
                            using (MySqlDataReader dtReader = msqlcom.ExecuteReader())

                            {

                                if (dtReader.HasRows)
                                {
                                    while (dtReader.Read())

                                    {

                                        ModEmployeeList dataObj = new ModEmployeeList();
                                        dataObj.imployee_id = dtReader["imployee_id"].ToString();
                                        dataObj.employee_last_name = dtReader["employee_last_name"].ToString();
                                        dataObj.employee_first_name = dtReader["employee_first_name"].ToString();
                                        dataObj.employee_username = dtReader["employee_username"].ToString();
                                        dataObj.employee_password = dtReader["employee_password"].ToString();
                                        dataObj.employee_account_status = dtReader["employee_account_status"].ToString();

                                        stats.Add(dataObj);
                                    }

                                    return Ok(stats);

                                }
                                else
                                {
                                    return NotFound();
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                        return Content(HttpStatusCode.InternalServerError, ex);
                    }
                }
                else
                {
                    return InternalServerError();
                }
            }
        }
        [Route("api/employee/Edit", Name = "Get_Employee_Edit")]
        public IHttpActionResult Get_Employee_Edit(string imployee_id)
        {
            List<ModEmployeeList> stats = new List<ModEmployeeList>();
            using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                if (sqlConn.State == ConnectionState.Closed)
                {
                    try
                    {

                        sqlConn.Open();

                        using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee WHERE imployee_id = @imployee_id LIMIT 1", sqlConn))

                        {
                            msqlcom.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
                            using (MySqlDataReader dtReader = msqlcom.ExecuteReader())

                            {

                                if (dtReader.HasRows)
                                {
                                    while (dtReader.Read())

                                    {

                                        ModEmployeeList dataObj = new ModEmployeeList();
                                        dataObj.imployee_id = dtReader["imployee_id"].ToString();
                                        dataObj.employee_last_name = dtReader["employee_last_name"].ToString();
                                        dataObj.employee_first_name = dtReader["employee_first_name"].ToString();
                                        dataObj.employee_username = dtReader["employee_username"].ToString();
                                        dataObj.employee_password = dtReader["employee_password"].ToString();
                                        dataObj.employee_account_status = dtReader["employee_account_status"].ToString();

                                        stats.Add(dataObj);
                                    }

                                    return Ok(stats);

                                }
                                else
                                {
                                    return NotFound();
                                }
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                        return Content(HttpStatusCode.InternalServerError, ex);
                    }
                }
                else
                {
                    return InternalServerError();
                }
            }
        }
        //API ROUTE:api/employee/add?imployee_id=145&employee_last_name=as&employee_first_name=yene&employee_username=enn&employee_password=ypas&employee_account_status=inactive
        [Route("api/employee/add", Name = "Post_Employee_Add")]
        public HttpResponseMessage Post_Employee_Add(string imployee_id, string employee_last_name, string employee_first_name, string employee_username, string employee_password ,string employee_account_status)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)

                    {

                        SQLCON.Open();

                        MySqlCommand sqlComm = new MySqlCommand();

                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "INSERT INTO `employee`(`imployee_id`, `employee_last_name`, `employee_first_name`, `employee_username`, `employee_password`, `employee_account_status`) VALUES (@imployee_id, @employee_last_name, @employee_first_name, @employee_username, @employee_password, @employee_account_status)";

                        sqlComm.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
                        sqlComm.Parameters.Add(new MySqlParameter("@employee_last_name", employee_last_name));
                        sqlComm.Parameters.Add(new MySqlParameter("@employee_first_name", employee_first_name));
                        sqlComm.Parameters.Add(new MySqlParameter("@employee_username", employee_username));
                        sqlComm.Parameters.Add(new MySqlParameter("@employee_password", employee_password));
                        sqlComm.Parameters.Add(new MySqlParameter("@employee_account_status", employee_account_status));
                        //sqlComm.Parameters.Add(new MySqlParameter("@employee_account_status", employee_account_status));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Saved");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }
        //API ROUTE: api/employee/update?imployee_id=143&employee_password=newpass
        [Route("api/employee/update", Name = "Put_Employee_Update_Passoword")]
        public HttpResponseMessage Put_Employee_Update_Passoword(string imployee_id, string employee_password)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)
                    {
                        SQLCON.Open();

                        MySqlCommand sqlComm = new MySqlCommand();

                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "UPDATE `employee` SET `employee_password` = @employee_password WHERE `imployee_id` = @imployee_id LIMIT 1";

                        sqlComm.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
                        sqlComm.Parameters.Add(new MySqlParameter("@employee_password", employee_password));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Updated");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }
        //[Route("api/employee/post", Name = "post_Employee")]
        //public IHttpActionResult post_Employee(string imployee_id)
        //{
        //    List<ModEmployeeList> stats = new List<ModEmployeeList>();
        //    using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
        //    {
        //        if (sqlConn.State == ConnectionState.Closed)
        //        {
        //            try
        //            {

        //                sqlConn.Open();

        //                using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee WHERE imployee_id = @imployee_id LIMIT 1", sqlConn))

        //                {
        //                    msqlcom.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
        //                    using (MySqlDataReader dtReader = msqlcom.ExecuteReader())

        //                    {

        //                        if (dtReader.HasRows)
        //                        {
        //                            while (dtReader.Read())

        //                            {

        //                                ModEmployeeList dataObj = new ModEmployeeList();
        //                                dataObj.imployee_id = dtReader["imployee_id"].ToString();
        //                                dataObj.employee_last_name = dtReader["employee_last_name"].ToString();
        //                                dataObj.employee_first_name = dtReader["employee_first_name"].ToString();
        //                                dataObj.employee_username = dtReader["employee_username"].ToString();
        //                                dataObj.employee_password = dtReader["employee_password"].ToString();
        //                                dataObj.employee_account_status = dtReader["employee_account_status"].ToString();

        //                                stats.Add(dataObj);
        //                            }

        //                            return Ok(stats);

        //                        }
        //                        else
        //                        {
        //                            return NotFound();
        //                        }
        //                    }
        //                }
        //            }

        //            catch (Exception ex)
        //            {

        //                return Content(HttpStatusCode.InternalServerError, ex);
        //            }
        //        }
        //        else
        //        {
        //            return InternalServerError();
        //        }
        //    }
        //}
        //[Route("api/employee/Delete", Name = "Delete_Employee")]
        //public IHttpActionResult Delete_Employee(string imployee_id)
        //{
        //    List<ModEmployeeList> stats = new List<ModEmployeeList>();
        //    using (MySqlConnection sqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
        //    {
        //        if (sqlConn.State == ConnectionState.Closed)
        //        {
        //            try
        //            {

        //                sqlConn.Open();

        //                using (MySqlCommand msqlcom = new MySqlCommand("SELECT *FROM employee WHERE imployee_id = @imployee_id LIMIT 1", sqlConn))

        //                {
        //                    msqlcom.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
        //                    using (MySqlDataReader dtReader = msqlcom.ExecuteReader())

        //                    {

        //                        if (dtReader.HasRows)
        //                        {
        //                            while (dtReader.Read())

        //                            {

        //                                ModEmployeeList dataObj = new ModEmployeeList();
        //                                dataObj.imployee_id = dtReader["imployee_id"].ToString();
        //                                dataObj.employee_last_name = dtReader["employee_last_name"].ToString();
        //                                dataObj.employee_first_name = dtReader["employee_first_name"].ToString();
        //                                dataObj.employee_username = dtReader["employee_username"].ToString();
        //                                dataObj.employee_password = dtReader["employee_password"].ToString();
        //                                dataObj.employee_account_status = dtReader["employee_account_status"].ToString();

        //                                stats.Add(dataObj);
        //                            }

        //                            return Ok(stats);

        //                        }
        //                        else
        //                        {
        //                            return NotFound();
        //                        }
        //                    }
        //                }
        //            }

        //            catch (Exception ex)
        //            {

        //                return Content(HttpStatusCode.InternalServerError, ex);
        //            }
        //        }
        //        else
        //        {
        //            return InternalServerError();
        //        }
        //    }
        //}
        //API ROUTE: api/employee/remove?imployee_id=143
        [Route("api/employee/remove", Name = "Delete_Employee_Remove")]
        public HttpResponseMessage Delete_Employee_Remove(string imployee_id)
        {
            using (MySqlConnection SQLCON = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                try
                {
                    if (SQLCON.State == ConnectionState.Closed)

                    {

                        SQLCON.Open();
                        MySqlCommand sqlComm = new MySqlCommand();
                        sqlComm.Connection = SQLCON;

                        sqlComm.CommandText = "UPDATE `employee` SET `employee_account_status` = 'inactive' WHERE `imployee_id` = @imployee_id LIMIT 1";

                        sqlComm.Parameters.Add(new MySqlParameter("@imployee_id", imployee_id));
                        sqlComm.ExecuteNonQuery(); //EXECUTE MYSQL QUEUE STRING
                        response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent("Successfully Removed");

                        return response;
                    }
                    else
                    {

                        response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                        response.Content = new StringContent("Unable to connect to the database server", Encoding.UTF8);

                        return response;
                    }
                }
                catch (Exception ex)
                {
                    response = Request.CreateResponse(HttpStatusCode.InternalServerError);

                    response.Content = new StringContent("There is an error in performing this action: " + ex.ToString(), Encoding.Unicode);

                    return response;
                }
                finally //ALWAYS CLOSE AND DISPOSE THE CONNECTION AFTER USING
                {
                    SQLCON.Close();
                    SQLCON.Dispose();

                }
            }
        }
    }
}