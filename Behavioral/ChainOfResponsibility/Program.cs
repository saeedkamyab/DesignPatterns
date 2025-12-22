
public class HttpRequest
{
}
public abstract class RequestHandler
{
    protected RequestHandler? Next;

    public RequestHandler SetNext(RequestHandler next)
    {
        Next = next;
        return next;
    }

    public abstract bool Handle(HttpRequest request);
}
public class AuthHandler : RequestHandler
{
    public override bool Handle(HttpRequest request)
    {
        if (!request.Headers.ContainsKey("Authorization"))
            return false;

        return Next?.Handle(request) ?? true;
    }
}
public class ValidationHandler : RequestHandler
{
    public override bool Handle(HttpRequest request)
    {
        if (string.IsNullOrEmpty(request.Query["id"]))
            return false;

        return Next?.Handle(request) ?? true;
    }
}
public class RateLimitHandler : RequestHandler
{
    public override bool Handle(HttpRequest request)
    {
        // فرض کن چک شده
        return Next?.Handle(request) ?? true;
    }
}


public class Program
{

    static void Main(string[] args)
    {
        var auth = new AuthHandler();
        var validation = new ValidationHandler();
        var rate = new RateLimitHandler();

        auth.SetNext(validation)
            .SetNext(rate);
        if (!auth.Handle(Request))
        {
            return StatusCode(400);
        }

        // ادامه پردازش
        return Ok();

    }
}