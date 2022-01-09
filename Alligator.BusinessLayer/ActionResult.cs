namespace Alligator.BusinessLayer
{
    public class ActionResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public ActionResult(bool success, T data)
        {
            Success = success;
            Data = data;
        }

    }
}
