using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Maximizer
{

  
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetBusiness/?Filter={filter}")]
        GetBusiness[] GetBusinessList(String filter);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetContacts/?Business={pBusId}")]
        DataContractContact[] GetContactsList(String pBusId);


        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetUserDefined/?Business={pBusId}&Contact={pConId}")]
        DataContractUserDefined[] GetUserDefinedList(String pBusId, String pConId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateBusiness")]
        bool UpdateBusiness(DataContractBusiness business);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateContact")]
        bool UpdateContact(DataContractContact contact);


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateUserDefined")]
        bool UpdateUserDefined(DataContractUserDefined user);


      [OperationContract]
      [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "AddContact")]
        bool AddContact(DataContractContact contact);


      [OperationContract]
      [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "AddUserDefined")]
      bool AddUserDefined(DataContractUserDefined user);

      [OperationContract]
      [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "AddBusiness")]
      bool AddBusiness(DataContractBusiness business);


      [OperationContract]
      [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "DeleteContact/?Contact={contact}")]
      bool DeleteContact(String contact);

      [OperationContract]
      [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "DeleteBusiness/?Business={business}")]
      bool DeleteBusiness(String business);

      [OperationContract]
      [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "DeleteUserDefined/?User={user}")]
      bool DeleteUserDefined(String user);

        
              [OperationContract]
          [WebInvoke(Method = "POST",
          ResponseFormat = WebMessageFormat.Json,
          RequestFormat = WebMessageFormat.Json,
          UriTemplate = "test")]
          bool Test(RequestTest test);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}