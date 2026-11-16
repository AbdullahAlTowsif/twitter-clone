namespace TwitterClone.Domain.Entities
{
    public class RolePermission: BaseEntity
    {
        public RolePermission(Guid id) : base(id)
        {
        }

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}
