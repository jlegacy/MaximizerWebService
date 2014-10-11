using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Maximizer.Properties;

namespace Maximizer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public GetBusiness[] GetBusinessList(String name)
        {
            var dataSet = new DataSet();
            DataRow dr;

            var myGetBusinessObjectList = new List<GetBusiness>();

            string sqlString = "SELECT * FROM Business where BName  LIKE  '%" + name + "%'";
            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(sqlString, connection);
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        dr = dataSet.Tables[0].Rows[0];

                        foreach (DataRow row in dr.Table.Rows)
                        {
                            var myGetBusinessObject = new GetBusiness();

                            myGetBusinessObject.BBusId = (row["BBusId"].ToString());
                            myGetBusinessObject.BName = (row["BName"].ToString());
                            myGetBusinessObject.BAddress = (row["BAddress"].ToString());
                            myGetBusinessObject.BCity = (row["BCity"].ToString());
                            myGetBusinessObject.BZip = (row["BZip"].ToString());
                            myGetBusinessObject.BPhone1 = (row["BPhone1"].ToString());
                            myGetBusinessObject.BPhone2 = (row["BPhone2"].ToString());
                            myGetBusinessObject.BPhone1Fax = (row["BPhone1Fax"].ToString());
                            myGetBusinessObject.BPhone2Fax = (row["BPhone2Fax"].ToString());
                            myGetBusinessObject.BEmail = (row["BEmail"].ToString());

                            myGetBusinessObjectList.Add(myGetBusinessObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return myGetBusinessObjectList.ToArray();
        }

        public DataContractContact[] GetContactsList(string pBusId)
        {
            var dataSet = new DataSet();
            DataRow dr;

            var myGetContactObjectList = new List<DataContractContact>();

            string sqlString = "SELECT * FROM Contact where CBusId = " +
                               "'" + pBusId + "'" + " order by CConid";

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(sqlString, connection);
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        dr = dataSet.Tables[0].Rows[0];

                        foreach (DataRow row in dr.Table.Rows)
                        {
                            var myGetContactObject = new DataContractContact();

                            myGetContactObject.CBusId = (row["CBusId"].ToString());
                            myGetContactObject.CConId = (row["CConId"].ToString());
                            myGetContactObject.CFirstName = (row["CFirstName"].ToString());
                            myGetContactObject.CLastName = (row["CLastName"].ToString());
                            myGetContactObject.CPosition = (row["CPosition"].ToString());
                            myGetContactObject.CPhone1 = (row["CPhone1"].ToString());
                            myGetContactObject.CPhone2 = (row["CPhone2"].ToString());
                            myGetContactObject.CPhone1Fax = (row["CPhone1Fax"].ToString());
                            myGetContactObject.CPhone2Fax = (row["CPhone2Fax"].ToString());
                            myGetContactObject.CEmail = (row["CEmail"].ToString());

                            myGetContactObjectList.Add(myGetContactObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return myGetContactObjectList.ToArray();
        }

        public DataContractUserDefined[] GetUserDefinedList(string pBusId, string pConId)
        {
            var dataSet = new DataSet();
            DataRow dr;

            var myList = new List<DataContractUserDefined>();

            string sqlString = "SELECT * FROM UserDefined where " +
                               "UBusId = " + "'" + pBusId + "'" + " and " +
                               "UConId = " + "'" + pConId + "'" +
                               "order by UField";

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(sqlString, connection);
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        dr = dataSet.Tables[0].Rows[0];

                        foreach (DataRow row in dr.Table.Rows)
                        {
                            var myObject = new DataContractUserDefined();

                            myObject.UBusId = (row["UBusId"].ToString());
                            myObject.UConId = (row["UConId"].ToString());
                            myObject.UUsrId = (row["UUsrId"].ToString());
                            myObject.UField = (row["UField"].ToString());
                            myObject.UItem = (row["UItem"].ToString());
                            myObject.UType = (row["UType"].ToString());
                        
                            myList.Add(myObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return myList.ToArray();
        }

        public bool DeleteContact(string contact)
        {
            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command1 = new SqlCommand("spDeleteContact", connection);

                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.Add(new SqlParameter("@contact", SqlDbType.NVarChar, 50));

                    command1.Parameters["@contact"].Value = contact;

                    command1.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public bool DeleteBusiness(string business)
        {

            LogFile logger = new LogFile();

           


            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command1 = new SqlCommand("spDeleteBusiness", connection);

                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.Add(new SqlParameter("@business", SqlDbType.NVarChar, 50));

                    command1.Parameters["@business"].Value = business;

                    command1.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                logger.MyLogFile("test", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DeleteUserDefined(string user)
        {

            LogFile logger = new LogFile();




            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command1 = new SqlCommand("spDeleteUserDefined", connection);

                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.Add(new SqlParameter("@UUsrId", SqlDbType.NVarChar, 50));

                    command1.Parameters["@UUsrId"].Value = user;

                    command1.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                logger.MyLogFile("test", ex.ToString());
                return false;
            }

            return true;
        }
        public Boolean UpdateBusiness(DataContractBusiness business)
        {
            LogFile logger = new LogFile();

            logger.MyLogFile("test", " Starting");

            var data = new DataContractBusiness();

            logger.MyLogFile("busienssId:", business.BBusId);
         

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spUpdateBusiness", connection);

                    // define the parameters of the stored procedure
                    SetBusinessParamsStructure(ref command1);

                    SetBusinessParamsValues(ref command1, business);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
                logger.MyLogFile("test", e.ToString());
                return false;
            }

            return true;
        }

        public Boolean AddBusiness(DataContractBusiness data)
        {
            LogFile logger = new LogFile();

            

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spInsertBusiness", connection);

                    // define the parameters of the stored procedure
                    SetBusinessParamsStructure(ref command1);

                    SetBusinessParamsValues(ref command1, data);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
                logger.MyLogFile("error:", e.ToString());
                return false;
            }

            return true;
        }

   
        public bool AddContact(DataContractContact data)
        {
            LogFile logger = new LogFile();

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spInsertContact", connection);

                    // define the parameters of the stored procedure
                    SetContactParamsStructure(ref command1);

                    SetContactParamsValues(ref command1, data);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
                logger.MyLogFile("error:", e.ToString());
                return false;
            } 

            return true;
        }

        public bool AddUserDefined(DataContractUserDefined data)
        {
            LogFile logger = new LogFile();

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spInsertUserDefined", connection);

                    // define the parameters of the stored procedure
                    SetUserDefinedParamsStructure(ref command1);

                    SetUserDefinedParamsValues(ref command1, data);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
                logger.MyLogFile("error:", e.ToString());
                return false;
            }

            return true;
        }

        public Boolean UpdateContact(DataContractContact contact)
        {
            LogFile logger = new LogFile();

            logger.MyLogFile("test", " Starting");
            
            var data = new DataContractContact();

            logger.MyLogFile("busienssId:", contact.CBusId);
            logger.MyLogFile("contactId:", contact.CConId);

       
            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spUpdateContact", connection);

                    // define the parameters of the stored procedure
                    SetContactParamsStructure(ref command1);

                    SetContactParamsValues(ref command1, contact);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
                logger.MyLogFile("test", e.ToString());
            }

            return true;
        }

        public Boolean UpdateUserDefined(DataContractUserDefined user)
        {
            LogFile logger = new LogFile();

            logger.MyLogFile("test", " Starting");

            var data = new DataContractUserDefined();

            logger.MyLogFile("userId:", user.UUsrId);
           


            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spUpdateUserDefined", connection);

                    // define the parameters of the stored procedure
                    SetUserDefinedParamsStructure(ref command1);

                    SetUserDefinedParamsValues(ref command1, data);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
                logger.MyLogFile("test", e.ToString());
            }

            return true;
        }

        public bool Test(RequestTest test)
        {
            LogFile logger = new LogFile();
            logger.MyLogFile("2:", test.Test2);
            logger.MyLogFile("1:", test.Test);
            return false;
        }

     
      

    

        private void SetUserDefinedParamsValues(ref SqlCommand command1, DataContractUserDefined rowData)
        {
            command1.Parameters["@UBusId"].Value = rowData.UBusId;
            command1.Parameters["@UConId"].Value = rowData.UConId;
            command1.Parameters["@UUsrId"].Value = rowData.UUsrId;
            command1.Parameters["@UField"].Value = rowData.UField;
            command1.Parameters["@UItem"].Value = rowData.UItem;
            command1.Parameters["@UType"].Value = rowData.UType;
        }

        private void SetUserDefinedParamsStructure(ref SqlCommand command1)
        {
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add(new SqlParameter("@UBusId", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@UUsrId", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@UConId", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@UField", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@UItem", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@UType", SqlDbType.NVarChar));
        }

        private void SetContactParamsValues(ref SqlCommand command1, DataContractContact rowData)
        {
            command1.Parameters["@CBusId"].Value = rowData.CBusId;
            command1.Parameters["@CConId"].Value = rowData.CConId;
            command1.Parameters["@CFirstName"].Value = rowData.CFirstName;

            command1.Parameters["@CLastName"].Value = rowData.CLastName;

            command1.Parameters["@CPosition"].Value = rowData.CPosition;

            command1.Parameters["@CPhone1"].Value = Convert.ToInt64(rowData.CPhone1);

            command1.Parameters["@CPhone2"].Value = Convert.ToInt64(rowData.CPhone2);

            command1.Parameters["@CPhone1Fax"].Value = rowData.CPhone1Fax;

            command1.Parameters["@CPhone2Fax"].Value = rowData.CPhone2Fax;
            command1.Parameters["@CEmail"].Value = rowData.CEmail;
        }

        private void SetContactParamsStructure(ref SqlCommand command1)
        {
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add(new SqlParameter("@CBusId", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CConId", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CFirstName", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CLastName", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CPosition", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CPhone1", SqlDbType.BigInt));
            command1.Parameters.Add(new SqlParameter("@CPhone2", SqlDbType.BigInt));
            command1.Parameters.Add(new SqlParameter("@CPhone1Fax", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CPhone2Fax", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CEmail", SqlDbType.NVarChar));
        }

        private static void SetBusinessParamsValues(ref SqlCommand command1, DataContractBusiness rowData)
        {
            command1.Parameters["@BBusId"].Value = rowData.BBusId;
            command1.Parameters["@BName"].Value = rowData.BName;
            command1.Parameters["@BAddress"].Value = rowData.BAddress;

            command1.Parameters["@BCity"].Value = rowData.BCity;

            command1.Parameters["@BState"].Value = rowData.BState;

            command1.Parameters["@BPhone1"].Value = Convert.ToInt64(rowData.BPhone1);

            command1.Parameters["@BPhone2"].Value = Convert.ToInt64(rowData.BPhone2);

            command1.Parameters["@BPhone1Fax"].Value = rowData.BPhone1Fax;

            command1.Parameters["@BPhone2Fax"].Value = rowData.BPhone2Fax;
            command1.Parameters["@BEmail"].Value = rowData.BEmail;
            command1.Parameters["@BZip"].Value = Convert.ToInt32(rowData.BZip);
        }

        private static void SetBusinessParamsStructure(ref SqlCommand command1)
        {
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add(new SqlParameter("@BBusId", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BName", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BAddress", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BCity", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BState", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BPhone1", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BPhone2", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BPhone1Fax", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BPhone2Fax", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BEmail", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BZip", SqlDbType.Int));
        }
    }
}