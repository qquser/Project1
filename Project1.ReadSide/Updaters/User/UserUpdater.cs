//using System.Threading.Tasks;
//using Project1.Common.Enums;
//using Project1.Common.Events.UserAdded;
//using Project1.ReadSide.Helpers;
//using Project1.ReadSide.Interfaces;
//using Project1.ReadSide.Models;
//using MassTransit;

//namespace Project1.ReadSide.Updaters.User
//{
//    internal class UserUpdater :
//        IConsumer<IUserAdded>,
//        IConsumer<IUserAssignedToProject>,
//        IConsumer<IUserPromoted>,
//        IConsumer<IUserDemoted>
//    {
//        private readonly IModelUpdater _context;

//        public UserUpdater(IModelUpdater context)
//        {
//            _context = context;
//        }

//        public async Task Consume(ConsumeContext<IUserAdded> context)
//        {
//            var user = new UserModel(context.Message.Id)
//            {
//                FirstName = context.Message.FirstName,
//                LastName = context.Message.LastName,
//                Role = context.Message.Role
//            };
//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Consume(ConsumeContext<IUserAssignedToProject> context)
//        {
//            var user = _context.Users.FindAggregate(context.Message.UserId);
//            var project = _context.Projects.FindAggregate(context.Message.ProjectId);
//            user.AssignedProjects.Add(project);
//            await _context.SaveChangesAsync();
//        }

//        public async Task Consume(ConsumeContext<IUserPromoted> context)
//        {
//            var user = _context.Users.FindAggregate(context.Message.UserId);
//            user.Role = UserRole.Manager;
//            await _context.SaveChangesAsync();
//        }

//        public async Task Consume(ConsumeContext<IUserDemoted> context)
//        {
//            var user = _context.Users.FindAggregate(context.Message.UserId);
//            user.Role = UserRole.Engineer;
//            await _context.SaveChangesAsync();
//        }
//    }
//}