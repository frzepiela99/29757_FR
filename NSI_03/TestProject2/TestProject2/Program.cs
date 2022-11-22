public class AlaMaKota
{
    public string GetOutput(int number)
    {
        if ((number % 2 == 0) && (number % 6 == 0))
            return "AlaMaKota";

        if (number % 2 == 0)
            return "Ala";

        if (number % 6 == 0)
            return "MaKota";

        return number.ToString();
    }

    public class WalidacjaMaila
    {
        public bool IsValidate(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                return false;

            }
            else
            {
                return true;
            }
        }
    }
}


