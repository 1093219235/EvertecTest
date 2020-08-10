using PlacetoPay.Integrations.Library.CSharp.Contracts;
using PlacetoPay.Integrations.Library.CSharp.Entities;
using PlacetoPay.Integrations.Library.CSharp.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using P2P = PlacetoPay.Integrations.Library.CSharp.PlacetoPay;
namespace UserInterfaceEvertecTest.clases
{
    public class paymentProcess
    {
        Gateway gateway = new P2P(WebConfigurationManager.AppSettings["USER_PAYMENT_SERVICE"].ToString(),
                             WebConfigurationManager.AppSettings["PASS_PAYMENT_SERVICE"].ToString(),
                              new Uri(WebConfigurationManager.AppSettings["PAYMENT_SERVICE_URL"].ToString()),
                              Gateway.TP_REST);
        public string[] CreatePayment(string  reference,string description, double amountValue, string userIP,string userAgent, string id_order)
        {
            string return_url = WebConfigurationManager.AppSettings["RETURN_BASE_URL"].ToString();
            string[] responseProcess= new string[4];
            Amount amount = new Amount(amountValue);
            Payment payment = new Payment(reference, description, amount);
            RedirectRequest request = new RedirectRequest(payment,
                return_url + id_order,
               userIP,
                userAgent,
               DateTime.Now.AddHours(1).ToString("dd-MM-yyyy HH:mm:ss"));
            RedirectResponse response = gateway.Request(request);
            responseProcess[0] = response.Status.Message;
            responseProcess[1] = response.RequestId;
            responseProcess[2]= response.ProcessUrl;
            responseProcess[3] = response.Status.status;
            return responseProcess;
        }

        public string[] statusRequest(string request_id)
        {

            string[] responseProcess = new string[2];
            RedirectInformation responseR = gateway.Query(request_id);
            responseProcess[0]= responseR.Status.status;
            responseProcess[1] = responseR.Status.Message;
            return responseProcess;
        }
    }
}