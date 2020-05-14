namespace Lemontech.DataLayer.Models
{
    public class ResponseModel
    {
        public int Code { get; set; } = 200;
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
