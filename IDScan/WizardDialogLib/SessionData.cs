using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

//namespace IDScan.Model
//{
    public static class SessionData
    {

        // License Data

        public static int membershipid { get; set; }
        public static int clubid { get; set; }
        public static int scanid { get; set; }
        public static string palmscanid { get; set; }
        public static string first { get; set; }
        public static string middle { get; set; }
        public static string last { get; set; }
        public static Nullable<System.DateTime> dob { get; set; }
        public static string gender { get; set; }
        public static string countrycode { get; set; }
        public static string address1 { get; set; }
        public static string address2 { get; set; }
        public static string city { get; set; }
        public static string stateprov { get; set; }
        public static string zip { get; set; }
        public static string imagepath { get; set; }
        public static Nullable<System.DateTime> applicationdate { get; set; }
        public static Nullable<System.DateTime> approvaldate { get; set; }
        public static Nullable<int> statusid { get; set; }
        public static Nullable<System.DateTime> expirationdate { get; set; }

        public static Nullable<System.DateTime> issuedate { get; set; }

        public static System.DateTime renewdate { get; set; }

        public static System.DateTime createddate { get; set; }

        public static string email { get; set; }
        public static string documentid { get; set; }

        public static string documenttype { get; set; }

        //Palm Secure Data
        public static Byte[] bio_palm_id { get; set; }

    }

//}
