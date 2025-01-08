using Dropbox.Interfaces;
using Dropbox.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;

namespace Dropbox.Tests.SystemTests
{
    [TestClass]
    public class FileSyncTests
    {
        private readonly string InputPath = @"C:\Input";
        private readonly string TargetPath = @"C:\Target";
        
        private Mock<IFileWatcherService>? _mockFileWatcherService;
        private Mock<IFolderHelper>? _mockFolderHelper;
        private Mock<IFileHelper>? _mockFileHelper;
        private Mock<IModel>? _mockModel;

        private IFileManager? _fileManager;

        public FileSyncTests()
        {
            _mockFileWatcherService = new Mock<IFileWatcherService>();
            _mockFolderHelper = new Mock<IFolderHelper>();
            _mockFileHelper = new Mock<IFileHelper>();
            _mockModel = new Mock<IModel>();

            _fileManager = new FileManager(_mockFileWatcherService.Object, _mockFolderHelper.Object, _mockFileHelper.Object, _mockModel.Object);
        }

        [TestInitialize]
        public void Setup()
        {
            _mockFileHelper!.Setup(m => m.FileExists(It.IsAny<string>())).Returns(true);

            _mockModel!.SetupGet(m => m.TargetFolderPath).Returns(TargetPath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockFileHelper!.Invocations.Clear();
            _mockModel!.Invocations.Clear();
        }

        [TestMethod]
        public void FileSync_FileAddedToInput_TargetFileAddedAndLogMessageCreated()
        {
            // Arrange
            var filename = "TestFile";
            var inputPath = Path.Combine(InputPath, filename);
            var targetPath = Path.Combine(TargetPath, filename);

            // Act
            _mockFileWatcherService!.Raise(s => s.FileAdded += null, inputPath);

            //Assert
            _mockModel!.Verify(m => m.AddLogMessage($"'{filename}' added to Input"), Times.Once());
            _mockFileHelper!.Verify(m => m.CopyFile(inputPath, targetPath, true), Times.Once());
            _mockModel!.Verify(m => m.AddLogMessage($"'{filename}' successfully synchronised with Target"), Times.Once());
        }

        [TestMethod]
        public void FileSync_FileRemovedFromInput_TargetFileDeletedAndLogMessageCreated()
        {
            // Arrange
            var filename = "TestFile";
            var inputPath = Path.Combine(InputPath, filename);
            var targetPath = Path.Combine(TargetPath, filename);

            // Act
            _mockFileWatcherService!.Raise(s => s.FileRemoved += null, inputPath);

            //Assert
            _mockModel!.Verify(m => m.AddLogMessage($"'{filename}' removed from Input"), Times.Once());
            _mockFileHelper!.Verify(m => m.DeleteFile(targetPath), Times.Once());
            _mockModel!.Verify(m => m.AddLogMessage($"'{filename}' no longer in Target"), Times.Once());
        }

        [TestMethod]
        public void FileSync_FileRemovedFromInputButFileNotInTarget_FileNotDeletedAndNoLogMessageCreated()
        {
            // Arrange
            var filename = "TestFile";
            var inputPath = Path.Combine(InputPath, filename);
            var targetPath = Path.Combine(TargetPath, filename);

            _mockFileHelper!.Setup(m => m.FileExists(It.IsAny<string>())).Returns(false);   // Removed input file not in target folder.

            // Act
            _mockFileWatcherService!.Raise(s => s.FileRemoved += null, inputPath);

            //Assert
            _mockModel!.Verify(m => m.AddLogMessage($"'{filename}' removed from Input"), Times.Once());
            _mockFileHelper!.Verify(m => m.DeleteFile(It.IsAny<string>()), Times.Never());
            _mockModel!.Verify(m => m.AddLogMessage(string.Empty), Times.Once());
        }
    }
}
