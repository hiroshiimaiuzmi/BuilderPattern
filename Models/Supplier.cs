namespace BuilderPattern.Models;

public class Supplier
{
    public Supplier(string name, string contactName, string email)
        => (Name, Email, ContactName) = (name, email, contactName);
        
    public string Name { get; set; } = string.Empty;
    public string ContactName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}