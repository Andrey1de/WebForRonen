using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForRonen.Models
{
    public class PaymentDetail
    {
        //    paymentDetailId: number=0;
        public int PaymentDetailId { get; set; }
        //cardOwnerName: string='';
        public string CardOwnerName { get; set; }
        //cardNumber: string='';
        public string CardNumber { get; set; }
        //expirationDate: string='';
        public string ExpirationDate { get; set; }
        //securityCode: string='';
        public string SecurityCode { get; set; }
    }
}