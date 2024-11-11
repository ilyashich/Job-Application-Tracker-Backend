namespace JobApplicationTracker.Errors;

public class Error
{
    public string Description { get; set; }

    public Error(string description)
    {
        Description = description;
    }

}