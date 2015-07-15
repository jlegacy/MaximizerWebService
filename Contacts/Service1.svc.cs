using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            string sqlString = "SELECT TOP " + Settings.Default.maxRecords + " * FROM Business where BName  LIKE  '%" + name + "%'" + " order by BName";
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
                            myGetBusinessObject.BState = (row["BState"].ToString());
                            myGetBusinessObject.BZip = (row["BZip"].ToString());
                            myGetBusinessObject.BPhone1 = (row["BPhone1"].ToString());
                            myGetBusinessObject.BPhone2 = (row["BPhone2"].ToString());
                            myGetBusinessObject.BFax1 = (row["BFax1"].ToString());
                            myGetBusinessObject.BEmail = (row["BEmail"].ToString());
                            myGetBusinessObject.BDPhone1 = String.Format("{0:(###) ###-####}", (row["BPhone1"]));
                            myGetBusinessObject.BDPhone2 = String.Format("{0:(###) ###-####}", (row["BPhone2"]));
                            myGetBusinessObject.BDFax1 = String.Format("{0:(###) ###-####}", (row["BFax1"]));

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

      //      LogFile logger = new LogFile();

            var dataSet = new DataSet();
            DataRow dr;

            var myGetContactObjectList = new List<DataContractContact>();

            string sqlString = "SELECT * FROM Contact where CBusId = " +
                               "'" + pBusId + "'" + " order by CLastName";

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
                            myGetContactObject.CPhone1Ext = (row["CPhone1Ext"].ToString());
                            myGetContactObject.CPhone2Ext = (row["CPhone2Ext"].ToString());
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
           //     logger.MyLogFile("test", e.ToString());
                return null;
            }

            return myGetContactObjectList.ToArray();
        }

        public DataContractUserDefined[] GetUserDefinedList(string pBusId, string pConId)
        {


        //    LogFile logger = new LogFile();
            
            var dataSet = new DataSet();
            DataRow dr;

            var myList = new List<DataContractUserDefined>();

            string sqlString = "SELECT * FROM UserDefined, UserDefinedCategory where " +
                               "UBusId = " + "'" + pBusId + "'" + " and " +
                               "UConId = " + "'" + pConId + "'" + " and " +
                               "XUserDefId = UUserDefId" +
                               " order by XUserSort";

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
                            myObject.UUserDefId = (row["UUserDefId"].ToString());
                        
                            myList.Add(myObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
           //     logger.MyLogFile("test", e.ToString());
                return null;
            }

            return myList.ToArray();
        }

        public DataContractUserDefinedCategory[] GetUserDefinedCategoriesList()
        {

       //     LogFile logger = new LogFile();

            var dataSet = new DataSet();
            DataRow dr;

            var myList = new List<DataContractUserDefinedCategory>();

            string sqlString = "SELECT * FROM UserDefinedCategory order by XUserSort";

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
                            var myObject = new DataContractUserDefinedCategory();

                            myObject.XUserDefId = (row["XUserDefId"].ToString());
                            myObject.XUserDefText = (row["XUserDefText"].ToString());
                            myObject.XUserSort = (row["XUserSort"].ToString());
                          
                            myList.Add(myObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
       //         logger.MyLogFile("getcatlist: ", e.ToString());
                return null;
            }

            return myList.ToArray();
        }

        public bool DeleteContact(string contact)
        {

        //    LogFile logger = new LogFile();

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
        //        logger.MyLogFile("deletecontact: ", ex.ToString());
                return false;
            }

            return true;
        }


        public bool DeleteBusiness(string business)
        {

     //       LogFile logger = new LogFile();

           


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
      //          logger.MyLogFile("test", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DeleteUserDefined(string user)
        {

     //       LogFile logger = new LogFile();




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
             //   logger.MyLogFile("test", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DeleteUserDefinedCategory(string category)
        {
          //  LogFile logger = new LogFile();
            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command1 = new SqlCommand("spDeleteUserDefinedCategory", connection);

                    command1.CommandType = CommandType.StoredProcedure;

                    command1.Parameters.Add(new SqlParameter("@XUserDefId", SqlDbType.NVarChar, 50));

                    command1.Parameters["@XUserDefId"].Value = category;

                    command1.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
             //  logger.MyLogFile("test", ex.ToString());
                return false;
            }

            return true;
        }

        public Boolean UpdateBusiness(DataContractBusiness business)
        {
        //    LogFile logger = new LogFile();

      //      logger.MyLogFile("test", " Starting");
       //     logger.MyLogFile("busienssId:", business.BBusId);
         

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
        //        logger.MyLogFile("test", e.ToString());
                return false;
            }

            return true;
        }

        public bool AddUserDefinedCategory(DataContractUserDefinedCategory data)
        {
       //     LogFile logger = new LogFile();

            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spInsertUserDefinedCategory", connection);

                    // define the parameters of the stored procedure
                    SetUserDefinedCategoryParamsStructure(ref command1);

                    SetUserDefinedCategoryParamsValues(ref command1, data);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
         //       logger.MyLogFile("error:", e.ToString());
                return false;
            }

            return true;
        }

        public Boolean AddBusiness(DataContractBusiness data)
        {
        //   LogFile logger = new LogFile();

            

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
           //    logger.MyLogFile("error:", e.ToString());
                return false;
            }

            return true;
        }

        public bool UpdateUserDefinedCategory(DataContractUserDefinedCategory user)
        {
       //     LogFile logger = new LogFile();
            
            string connectionString = Settings.Default.connectionString;
            try
            {
                SqlConnection connection;

                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1;

                    command1 = new SqlCommand("spUpdateUserDefinedCategory", connection);

                    // define the parameters of the stored procedure
                    SetUserDefinedCategoryParamsStructure(ref command1);

                    SetUserDefinedCategoryParamsValues(ref command1, user);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
              //          logger.MyLogFile("test", e.ToString());
                return false;
            }

            return true;
        }

        public bool AddContact(DataContractContact data)
        {
    //        LogFile logger = new LogFile();

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
   //             logger.MyLogFile("error:", e.ToString());
                return false;
            } 

            return true;
        }

        public bool AddUserDefined(DataContractUserDefined data)
        {
     //       LogFile logger = new LogFile();

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
        //        logger.MyLogFile("error:", e.ToString());
                return false;
            }

            return true;
        }

        public Boolean UpdateContact(DataContractContact contact)
        {
       //     LogFile logger = new LogFile();

     //       logger.MyLogFile("test", " Starting");
      
    //        logger.MyLogFile("busienssId:", contact.CBusId);
    //        logger.MyLogFile("contactId:", contact.CConId);

       
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
          //      logger.MyLogFile("test", e.ToString());
                return false;
            }

            return true;
        }

        public Boolean UpdateUserDefined(DataContractUserDefined user)
        {
        //    LogFile logger = new LogFile();

         //   logger.MyLogFile("test", " Starting");

     //       logger.MyLogFile("userId:", user.UUsrId);
    //        logger.MyLogFile("busId:", user.UBusId);
           


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

                    SetUserDefinedParamsValues(ref command1, user);

                    command1.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch
                (Exception e)
            {
        //        logger.MyLogFile("test", e.ToString());
                return false;
            }

            return true;
        }

        public bool Test(RequestTest test)
        {
     //       LogFile logger = new LogFile();
    //        logger.MyLogFile("2:", test.Test2);
     //       logger.MyLogFile("1:", test.Test);
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
            command1.Parameters["@UUserDefId"].Value = rowData.UUserDefId;
        }

        private void SetUserDefinedCategoryParamsValues(ref SqlCommand command1, DataContractUserDefinedCategory rowData)
        {
            command1.Parameters["@XUserDefId"].Value = Convert.ToInt32(rowData.XUserDefId);
            command1.Parameters["@XUserDefText"].Value = rowData.XUserDefText;
            command1.Parameters["@XUserSort"].Value = Convert.ToInt32(rowData.XUserSort);
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
            command1.Parameters.Add(new SqlParameter("@UUserDefId", SqlDbType.NVarChar));
        }

        private void SetUserDefinedCategoryParamsStructure(ref SqlCommand command1)
        {
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add(new SqlParameter("@XUserDefId", SqlDbType.Int));
            command1.Parameters.Add(new SqlParameter("@XUserDefText", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@XUserSort", SqlDbType.Int));
        }

        private void SetContactParamsValues(ref SqlCommand command1, DataContractContact rowData)
        {
            command1.Parameters["@CBusId"].Value = rowData.CBusId;
            command1.Parameters["@CConId"].Value = rowData.CConId;
            command1.Parameters["@CFirstName"].Value = rowData.CFirstName;

            command1.Parameters["@CLastName"].Value = rowData.CLastName;

            command1.Parameters["@CPosition"].Value = rowData.CPosition;

            command1.Parameters["@CPhone1"].Value = 0;
            command1.Parameters["@CPhone2"].Value = 0;
            command1.Parameters["@CPhone1Ext"].Value = 0;
            command1.Parameters["@CPhone2Ext"].Value = 0;


            if (rowData.CPhone1.Trim().Length > 0)
            {
                command1.Parameters["@CPhone1"].Value = Convert.ToInt64(rowData.CPhone1);
            }

            if (rowData.CPhone2.Trim().Length > 0)
            {
                command1.Parameters["@CPhone2"].Value = Convert.ToInt64(rowData.CPhone2);
            }

            if (rowData.CPhone1Ext.Trim().Length > 0)
            {
                command1.Parameters["@CPhone1Ext"].Value = Convert.ToInt32(rowData.CPhone1Ext);
            }

            if (rowData.CPhone2Ext.Trim().Length > 0)
            {
                command1.Parameters["@CPhone2Ext"].Value = Convert.ToInt32(rowData.CPhone2Ext);
            }

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
            command1.Parameters.Add(new SqlParameter("@CPhone1Ext", SqlDbType.Int));
            command1.Parameters.Add(new SqlParameter("@CPhone2Ext", SqlDbType.Int));
            command1.Parameters.Add(new SqlParameter("@CPhone1Fax", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CPhone2Fax", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@CEmail", SqlDbType.NVarChar));
        }

        private static void SetBusinessParamsValues(ref SqlCommand command1, DataContractBusiness rowData)
        {
            var phone1 = 0;
            var phone2 = 0;
            
            command1.Parameters["@BBusId"].Value = rowData.BBusId;
            command1.Parameters["@BName"].Value = rowData.BName;
            command1.Parameters["@BAddress"].Value = rowData.BAddress;

            command1.Parameters["@BCity"].Value = rowData.BCity;

            command1.Parameters["@BState"].Value = rowData.BState;

            command1.Parameters["@BPhone1"].Value = 0;
            command1.Parameters["@BPhone2"].Value = 0;
            command1.Parameters["@BFax1"].Value = 0;

       
            if (rowData.BPhone1.Trim().Length > 0)
            {
                command1.Parameters["@BPhone1"].Value = Convert.ToInt64(rowData.BPhone1);
            }

            if (rowData.BPhone2.Trim().Length > 0)
            {
                command1.Parameters["@BPhone2"].Value = Convert.ToInt64(rowData.BPhone2);
            }

            if (rowData.BFax1.Trim().Length > 0)
            {
                command1.Parameters["@BFax1"].Value = Convert.ToInt64(rowData.BFax1);
            }


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
            command1.Parameters.Add(new SqlParameter("@BFax1", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BEmail", SqlDbType.NVarChar));
            command1.Parameters.Add(new SqlParameter("@BZip", SqlDbType.Int));
        }
    }
}