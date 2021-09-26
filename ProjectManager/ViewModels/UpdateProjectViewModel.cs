using Ninject;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjectManager.UI.Properties;
using ProjectManager.UI.Views;
using ProjectManager.UI.Views.Pages;

namespace ProjectManager.UI.ViewModels
{
    class UpdateProjectViewModel
    {
        private RelayCommand _updateProject;

        private IProjectService _projectService;
        private IMessenger _messenger;
        public ProjectDto Project { get; set; }

        public UpdateProjectViewModel(ProjectDto project)
        {
            _projectService = App.Container.Get<IProjectService>();
            _messenger = App.Container.Get<IMessenger>();
            Project = project;
        }

        public RelayCommand ActionProjectCommand
        {
            get
            {
                return _updateProject ?? (_updateProject = new RelayCommand(async _ =>
                {
                    if (string.IsNullOrWhiteSpace(Project.Name))
                    {
                        _messenger.SendMessage(Resources.EmptyProjectName);
                        return;
                    }

                    await _projectService.UpdateProjectAsync(Project);

                    var window = Application.Current.MainWindow as MainWindow;
                    window?.Frame.Navigate(new MainPage(App.User));
                }));
            }
        }
    }
}
