using Library.Core.Enums;

namespace Library.Core.Entities;

public class Loan : BaseEntity
{

    public Loan(int idBook, int idUser, int daysLoan)
    {
        IdBook = idBook;
        IdUser = idUser;
        //ValueForDay = valueForDay;
        DaysLoan = daysLoan;
        StartLoan = DateTime.Now;

        Status = StatusLoan.Started;
    }
    public int IdBook { get; private set; }
    public Book Book { get; private set; }
    public int IdUser { get; private set; }
    public User User { get; private set; }
    public DateTime StartLoan { get; private set; }
    public DateTime EndLoan { get; private set; }
    public int DaysLoan { get; private set; }
  //  public decimal ValueForDay { get; private set; }
    public StatusLoan Status { get; set; }
    
    public void Delayed()
    {
        var TempoAtraso = EndLoan - StartLoan.AddDays(DaysLoan);
        
        if (TempoAtraso.Days > 0) Status = StatusLoan.Delayed;
    }
    
    public bool FinishedLoan()
    {
        if(Status == StatusLoan.Delayed) return false;
        
        Status = StatusLoan.Finished;

        return true;
    }
}