using System.Linq;
using System.Windows;
using Ninject;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.UI.Common;
using ProjectManager.UI.Properties;
using ProjectManager.UI.Views;
using ProjectManager.UI.Views.Pages;

namespace ProjectManager.UI.ViewModels
{
    public class CreateTaskViewModel
    {
        public TaskDto Task { get; set; }

        private IMessenger _messenger;
        private ITaskService _taskService;

        private RelayCommand _create;

        public CreateTaskViewModel(int projectId)
        {
            _messenger = App.Container.Get<IMessenger>();
            _taskService = App.Container.Get<ITaskService>();
            Task = new TaskDto(){ProjectId = projectId};
        }

        public RelayCommand CreateTaskCommand
        {
            get
            {
                return _create ?? (_create = new RelayCommand(async _ =>
                {
                    if (string.IsNullOrWhiteSpace(Task.Description))
                    {
                        _messenger.SendMessage(Resources.EmptyTaskDescription);
                        return;
                    }

                    await _taskService.CreateTaskAsync(Task);

                    App.User.Projects.First(p=> p.Id == Task.ProjectId).Tasks.Add(Task);

                    var window = Application.Current.MainWindow as MainWindow;
                    window?.Frame.Navigate(new MainPage(App.User));
                }));
            }
        }
    }
}