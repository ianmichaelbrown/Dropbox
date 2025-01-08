using Dropbox.Commands;
using Dropbox.Enums;
using Dropbox.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dropbox.Tests.UnitTests
{
    [TestClass]
    public class SelectFolderCommandTests
    {
        private Mock<IFolderHelper>? _mockFolderHelper;
        private Mock<IModel>? _mockModel;
        private string _folder = "Folder";

        private SelectFolderCommand? _command;

        public SelectFolderCommandTests()
        {
            _mockFolderHelper = new Mock<IFolderHelper>();
            _mockModel = new Mock<IModel>();

            _command = new SelectFolderCommand(_mockFolderHelper.Object, _mockModel.Object);
        }

        [TestInitialize]
        public void Setup()
        {
            _mockFolderHelper!.Setup(m => m.GetFolderPathAsync()).ReturnsAsync(_folder);

            _mockModel!.Setup(m => m.IsSyncing).Returns(false);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockModel!.Invocations.Clear();
        }

        [TestMethod]
        public void SelectFolderCommand_InputFolderSelected_SetsInputPathInModel()
        {
            // Arrange
            _command!.FolderType = FolderType.Input;

            // Act
            _command.Execute(null);

            //Assert
            _mockModel!.Verify(m => m.SetInputPath(_folder), Times.Once());
        }

        [TestMethod]
        public void SelectFolderCommand_TargetFolderSelected_SetsTargetPathInModel()
        {
            // Arrange
            _command!.FolderType = FolderType.Target;

            // Act
            _command.Execute(null);

            //Assert
            _mockModel!.Verify(m => m.SetTargetPath(_folder), Times.Once());
        }

        [TestMethod]
        public void SelectFolderCommand_NoFolderSelected_NoPathsSetInModel()
        {
            // Arrange
            _mockFolderHelper!.Setup(m => m.GetFolderPathAsync()).ReturnsAsync(string.Empty);

            // Act
            _command!.Execute(null);

            //Assert
            _mockModel!.Verify(m => m.SetInputPath(It.IsAny<string>()), Times.Never());
            _mockModel!.Verify(m => m.SetTargetPath(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void SelectFolderCommand_SyncRunning_CannotExecuteCommand()
        {
            // Arrange
            _mockModel!.Setup(m => m.IsSyncing).Returns(true);

            // Act
            var canExecute = _command!.CanExecute(null);

            //Assert
            Assert.IsFalse(canExecute);
        }
    }
}
