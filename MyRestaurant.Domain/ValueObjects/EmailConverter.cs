using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MyRestaurant.Domain.ValueObjects;

public class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter() : base(
        email => email.Value,
        value => Email.Create(value))
    { }
}
