namespace Domain.Models.Responses
{
    public partial class ResponseObject<TResult, TModel>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public TResult Result { get; set; }
        public TModel Model { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }

        public ResponseObject()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ResponseObject(bool success, Dictionary<string, List<string>> errors) : this()
        {
            Success = success;
            Errors = errors;
        }
    }
}
