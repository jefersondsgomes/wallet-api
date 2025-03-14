namespace Core.Entities;

public readonly struct Email(string address)
{
    public readonly string? Address { get; } = address;

    public static implicit operator Email(string address)
    {
        return new(address);
    }

    public static implicit operator string(Email email)
    {
        return email.Address!;
    }

    public override string ToString()
    {
        return Address!;
    }

    //private static void Validate(string address)
    //{
    //    var validator = Validator.Start();

    //    validator
    //        .FailIfIsNullOrWhiteSpace(address, nameof(Email.Address))
    //        .Validate();

    //    var isValid = _emailRegex.IsMatch(address);

    //    validator
    //        .FailIfIsInvalid(isValid, nameof(Email.Address))
    //        .Validate();
    //}
}
