public interface IJumpable : IDynamic
{
    void Jump();
    float JumpForce { get; set; }
}
