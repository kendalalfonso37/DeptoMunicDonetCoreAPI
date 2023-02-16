namespace DepartamentosMunicipiosAPI.Wrappers
{
    public class Response<T>
    {
        public Response() { }
        public Response(T data)
        {
            Succeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public bool Succeded { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }
    }
}
