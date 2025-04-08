namespace DentLabTrack.WebApi.Models
{
    //This class is used to represent the response of the login operation
    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
