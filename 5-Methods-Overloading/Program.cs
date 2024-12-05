var MedicalAppointment = new MedicalAppointment("Jhon", new DateTime(2023, 4, 3));

Console.ReadKey();

class MedicalAppointment
{
    private string _paitentName;
    private DateTime _date;

    // ctor kullanın uzunlamasına yazmayın teşekkürler.
    public MedicalAppointment(string paitentName, DateTime dateTime)
    {
        this._date = dateTime;
        this._paitentName = paitentName;
    }

    public void Reschedule(DateTime dateTime)
    {
        _date = dateTime;
    }

    public void Reschedule(int month, int day)
    {
        _date = new DateTime(_date.Year, month, day);
    }
}