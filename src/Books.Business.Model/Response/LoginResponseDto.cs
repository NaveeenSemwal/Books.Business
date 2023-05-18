namespace Books.Business.Model.Response
{
    public class LoginResponseDto
    {
        public MemberDto User { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
