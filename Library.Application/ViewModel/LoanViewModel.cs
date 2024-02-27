using Library.Core.Enums;

namespace Library.Application.ViewModel;

public class LoanViewModel
{
    public LoanViewModel(string bookName, string userName, DateTime startLoan, int daysLoan, StatusLoan status)
    {
        BookName = bookName;
        UserName = userName;
        StartLoan = startLoan;
        DaysLoan = daysLoan;
        Status = status;
    }
    public string BookName { get; private set; }
    public string UserName { get; private set; }
    public DateTime StartLoan { get; private set; }
    public int DaysLoan { get; private set; }
    public StatusLoan Status { get; private set; }
}