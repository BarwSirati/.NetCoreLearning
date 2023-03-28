namespace FoodPool.share.types;

public class Response<T>
{
    public T? Data { get; set; }
    public bool Status { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}