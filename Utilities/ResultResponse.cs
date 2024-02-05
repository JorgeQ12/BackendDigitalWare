
namespace GamblingBackDW.Utilities
{
    public class ResultResponse<T>
    {
        public bool IsSucces { get; set; }
        public T Data { get; set; }
        public string Message {get; set;}

        public ResultResponse(bool isSucces, List<string> validationErrors)
        {
            IsSucces = isSucces;
            Message = validationErrors.ToString();
        }
        public ResultResponse(bool isSucces, string message)
        {
            IsSucces = isSucces;
            Message = message;
        }
        public ResultResponse(bool isSucces, T data)
        {
            IsSucces = isSucces;
            Data = data;
        }
    }
}
