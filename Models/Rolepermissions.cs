namespace InvoiceAppApi.Models
{
    public class Rolepermissions
    {
        public int ID { get; set; }
        public string Menu { get; set; }
        public int Add { get; set; }
        public int Edit { get; set; }
        public int Delete { get; set; }
        public int View { get; set; }
        public int RoleID { get; set; }

    }
}
