namespace WebSystem.Core
{
    public class SystemResultViewModel<T>
    {
        public SystemResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }
        public SystemResultViewModel(T data) => Data = data;
        public SystemResultViewModel(List<string> errors) => Errors = errors;
        public SystemResultViewModel(string error) => Errors.Add(error);
        public SystemResultViewModel(){}

        public T Data { get; private set; }  
        public List<string> Errors { get; private set; } = new();
    }
}
