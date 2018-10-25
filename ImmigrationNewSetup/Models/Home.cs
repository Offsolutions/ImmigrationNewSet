using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImmigrationNewSetup.Models
{
    public class Home
    {
    }
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "You must provide a valid email address.")]
        public string email { get; set; }
        [Display(Name = "Contact No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string contact { get; set; }
        [Display(Name = "User Name")]
        public string login { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "User Type")]
        public string UserType { get; set; }
        [Display(Name = "Status")]
        public bool status { get; set; }
    }
    public enum UserType
    {
        Admin,
        Receptionist,
        Scanner
    }
    public class studentdetail
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Enter Your Name")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "DOB")]
        public Nullable<System.DateTime> dob { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Father Name")]
        public string fathername { get; set; }
        [Display(Name = "Mother Name")]
        public string mothername { get; set; }
        [AllowHtml]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Please Enter Your 10 Digit Mobile no")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No.")]
        public string phone { get; set; }
        //[Required(ErrorMessage = "Please Enter Your 10 Digit Mobile no")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone 2")]
        public string phone2 { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public string email { get; set; }
        [Display(Name = "Marital Status")]
        public string married { get; set; }
        [Display(Name = "Board")]
        public string board { get; set; }
        [Display(Name = "Last Qualification")]
        public string qualification { get; set; }
        [Display(Name = "Marks")]
        public string marks { get; set; }
        [Display(Name = "Gap")]
        public string gap { get; set; }
        [Display(Name = "Gap Detail")]
        public string gapdetail { get; set; }
        [Display(Name = "Refusal")]
        public string refusal { get; set; }
        [Display(Name = "Refusal Detail")]
        public string refusaldetail { get; set; }
        [Display(Name = "File Type")]
        public string filetype { get; set; }
        [Display(Name = "Country Name")]
        public string country { get; set; }
        [Display(Name = "Intake")]
        public string intake { get; set; }
        [Display(Name = "Year")]
        public string year { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }
        [Display(Name = "ITR")]
        public string itr { get; set; }
        [Display(Name = "Entry By")]
        public int uid { get; set; }
       
        [Display(Name = "Tracking Id")]
        public string TrackingID { get; set; }
       
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Logs Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Editingdate { get; set; }
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
    public enum gender
    {
        Male,
        Female
    }
    public enum board
    {
        CBSE,
        PSEB,
        ICSE,
        Other
    }
    public enum filetype
    {
        Study,
        PR,
        Visitor,
        Multiple,
        Other
    }
    public enum intake
    {
        Jan,
        Feb,
        March,
        April,
        May,
        June,
        July,
        Aug,
        Sept,
        Oct,
        Nov,
        Dec
    }
    public class Studentdocs
    {
        [Key]
        public int Id { get; set; }    
        public int StudentId { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Profile Pic")]
        public string profile { get; set; }
        [Display(Name = "Educational Documents")]
        public string education { get; set; }
        [Display(Name = "Family Documents")]
        public string family { get; set; }
        [Display(Name = "Other Documents")]
        public string other { get; set; }
    }
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        public string Name { get; set; }
    }
    public class AssignedFiles
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Assigned To")]
        public int UserID { get; set; }
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Display(Name = "Assigned By")]
        public int uid { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
    }
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Inserted By")]
        public int uid { get; set; }
        [Display(Name ="Message")]
        public string message { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

    }
}