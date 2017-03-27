namespace Project1.Common.Enums
{
    public sealed class UserRole
    {
        public string Name { get; private set; }
        public string Permission { get; private set; }

        public static readonly UserRole None = new UserRole("none", ";none;");
        public static readonly UserRole User = new UserRole("user", ";user;");
        public static readonly UserRole Manager = new UserRole("manager", ";manager;");

        private UserRole(string name, string permission)
        {
            Name = name;
            Permission = permission;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}