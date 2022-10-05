namespace Lithium.BaseEntities;

public record Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public Status()
    {
        IsActive = true;
    }

}