using Ninject;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.UI.Common;
using ProjectManager.UI.Views;
using ProjectManager.UI.Views.Pages;
using System.Windows;
using ProjectManager.UI.Properties;

namespace ProjectManager.UI.ViewModels
{

    public class CreateProjectViewModel: BaseViewModel
    {
        private RelayCommand _addProject;

        private IProjectService _projectService;
        private IMessenger _messenger;
        public ProjectDto Project { get; set; }

        public CreateProjectViewModel(ProjectDto project)
        {
            _projectService = App.Container.Get<IProjectService>();
            _messenger = App.Container.Get<IMessenger>();
            Project = project;
        }

        public RelayCommand ActionProjectCommand
        {
            get
            {
                return _addProject ?? (_addProject = new RelayCommand(async _ =>
                {
                    if (string.IsNullOrWhiteSpace(Project.Name))
                    {
                        _messenger.SendMessage(Resources.EmptyProjectName);
                        return;
                    }

                    Project.UserId = App.User.Id;
                    await _projectService.CreateProjectAsync(Project);
                    App.User.Projects.Add(Project);

                    var window = Application.Current.MainWindow as MainWindow;
                    window?.Frame.Navigate(new MainPage(App.User));
                }));
            }
        }
    }
}