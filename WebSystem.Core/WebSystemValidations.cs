
namespace WebSystem.Core
{
    public class WebSystemValidations : Exception
    {
        public WebSystemValidations(string error): base(error){}

        public static void When(bool hasError, string error)
        {
            if(hasError)
                throw new WebSystemValidations(error);
        }
    }
}