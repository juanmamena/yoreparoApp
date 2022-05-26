using System;
namespace yoreparoApp.Models
{
    public class BodyOut
    {
        public User user { get; set; }
        public Boolean operationSuccesfull { get; set; }
        public ErrorOut error { get; set; }
    }
}
