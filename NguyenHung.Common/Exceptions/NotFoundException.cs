namespace NguyenHung.Common.Exceptions;

public class NotFoundException : Exception, INotFoundException
{
    public NotFoundException() : base() { }

    public NotFoundException(string message) : base(message) { }
}