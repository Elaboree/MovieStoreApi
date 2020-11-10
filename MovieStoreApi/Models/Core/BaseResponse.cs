namespace MovieStoreApi.Models.Core
{
    public class BaseResponse
    {
        public object Data { get; set; }
        public bool IsSucceeded { get; set; }
        public string ErrorMessage { get; set; }
    }
}
