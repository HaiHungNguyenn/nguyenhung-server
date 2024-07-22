namespace NguyenHung.Common.Exceptions;

public class BadRequestException: Exception, IBadRequestException
{
    public BadRequestException() : base() { }

    public BadRequestException(string message) : base(message) { }
}