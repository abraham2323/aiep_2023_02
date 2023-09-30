namespace Pro401.Services
{
    public class BusinessService : IBusinessService
    {
        public bool PrimeraLetraMayuscula(string color)
        {

            if (char.IsUpper(color[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

    }
}
