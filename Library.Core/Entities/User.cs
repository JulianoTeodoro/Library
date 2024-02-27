namespace Library.Core.Entities;

public class User : BaseEntity
{
    public User(string name, string email)
    {
        Name = name;
        Email = email;
        LoansUser = new List<Loan>();
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public List<Loan> LoansUser { get; private set; }
}