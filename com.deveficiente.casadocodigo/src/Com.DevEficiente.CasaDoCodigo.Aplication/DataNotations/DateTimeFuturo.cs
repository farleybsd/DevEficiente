namespace Com.DevEficiente.CasaDoCodigo.Aplication.DataNotations
{
    public class DateTimeFuturo : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
}