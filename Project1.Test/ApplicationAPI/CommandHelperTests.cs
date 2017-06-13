using NUnit.Framework;
using Project1.Application.API.Commands;
using Project1.Application.API.Helpers;
using Project1.Application.API.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Test.ApplicationAPI
{
    [TestFixture]
    public class CommandHelperTests
    {
        [Test]
        public void Nodes_Is_Cycled_Loop_Test()
        {
            var command = new Command();
            var command1 = new Command1();

            command.DecoratedHandler = command1;
            command1.DecoratedHandler = command;

            Assert.Throws<Exception>(delegate { command.Nodes().ToList(); } );
        }

        [Test]
        public void Nodes_Is_Cycled_Loop_Test2()
        {
            var command3 = new CommandWithThisKeyWord();

            Assert.Throws<Exception>(delegate { command3.Nodes().ToList(); });
        }


        [Test]
        public void Nodes_Is_Cycled_Loop_Test3()
        {
            var command = new Command();
            var command2 = new CommandWithThisKeyWord();

            command.DecoratedHandler = command2;

            Assert.Throws<Exception>(delegate { command.Nodes().ToList(); });
        }

        [Test]
        public void Nodes_Is_Cycled_Loop_Test4()
        {
            var command = new CommandWithNewKeyWord();

            Assert.Throws<Exception>(delegate { command.Nodes().ToList(); });
        }
    }

    class Command : IBaseCommand<RegisterUserModel>
    {
        public IBaseCommand<RegisterUserModel> DecoratedHandler { get; set; }
        public void Handle(RegisterUserModel model)
        {
        }
    }

    class Command1 : IBaseCommand<RegisterUserModel>
    {
        public IBaseCommand<RegisterUserModel> DecoratedHandler { get; set; }
        public void Handle(RegisterUserModel model)
        {
        }
    }

    class CommandWithThisKeyWord : IBaseCommand<RegisterUserModel>
    {
        public IBaseCommand<RegisterUserModel> DecoratedHandler => this;
        public void Handle(RegisterUserModel model)
        {
        }
    }

    class CommandWithNewKeyWord : IBaseCommand<RegisterUserModel>
    {
        public IBaseCommand<RegisterUserModel> DecoratedHandler => new CommandWithNewKeyWord();
        public void Handle(RegisterUserModel model)
        {
        }
    }

}
