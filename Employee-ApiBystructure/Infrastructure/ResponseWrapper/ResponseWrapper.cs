namespace Employee_ApiBystructure.Infrastructure.ResponseWrapper
{
    public class ResponseWrapper<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public ResponseWrapper()
        {
        
        
        
        }

        public ResponseWrapper(T result)
        {
            Result = result;
        }
        public ResponseWrapper(Exception ex)
        {
            IsError= true;
            ErrorMessage= ex?.Message;
        }
        public ResponseWrapper(string message, T result) : this(result) 
        {
                
            Message= message;
        }
        public void set(T result)
        {
            Result = result;
        }
        public void set(Exception ex)
        {
            IsError= true;
            ErrorMessage = ex?.Message;
        }
        public void set(string message, T result){
            Message = message;
            set(result);
        }
    }
}
