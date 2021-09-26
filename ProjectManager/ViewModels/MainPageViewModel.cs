using System.Collections.ObjectModel;
using System.Windows;
using Ninject;
using ProjectManager.BL.DTO;
using ProjectManager.BL.Interfaces;
using ProjectManager.UI.Common;
using ProjectManager.UI.Views;
using ProjectManager.UI.Views.Pages;

namespace ProjectManager.UI.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        private UserDto _user;
        private MainWindow _window;

        private IProjectService _projectService;
        private ITaskService _taskService;
        private IMessenger _messenger;

        private RelayCommand _addTask, _updateTask, _removeTask, _addProject, _updateProject, _deleteProject;
        private ObservableCollection<ProjectDto> _projects;
        private ProjectDto _currentProject, _selectedProject;
        private TaskDto _selectedTask;

        public MainPageViewModel(UserDto user)
        {
            _projectService = App.Container.Get<IProjectService>();
            _taskService = App.Container.Get<ITaskService>();
            _messenger = App.Container.Get<IMessenger>();
            _user = user;
            _window = Application.Current.MainWindow as MainWindow;
            Projects = _user.Projects;
        }

        public ObservableCollection<ProjectDto> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        public ProjectDto CurrentProject
        {
            get => _currentProject;
            set
            {
                _currentProject = value;
                OnPropertyChanged(nameof(CurrentProject));  
            }
        }

        public ProjectDto SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        public TaskDto SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public RelayCommand AddProjectCommand
        {
            get
            {
                return _addProject ?? (_addProject = new RelayCommand( _ =>
                {
                    var p = new ProjectDto();
                    var projectSettings = new ProjectSettings();
                    var settings = new CreateProjectViewModel(p);
                    projectSettings.DataContext = settings;

                    _window?.Frame.Navigate(projectSettings);
                }));
            }
        }

        public RelayCommand UpdateProjectCommand
        {
            get
            {
                return _updateProject ?? (_updateProject = new RelayCommand( _ =>
                {
                    if (SelectedProject == null)
                    {
                        _messenger.SendMessage(Properties.Resources.ChooseRecord);
                        return;
                    }

                    var projectSettings = new ProjectSettings();
                    var settings = new UpdateProjectViewModel(SelectedProject);
                    projectSettings.DataContext = settings;

                    _window?.Frame.Navigate(projectSettings);
                }
                ));
            }
        }

        public RelayCommand DeleteProjectCommand
        {
            get
            {
                return _deleteProject ?? (_deleteProject = new RelayCommand(async _ =>
                {
                    if (SelectedProject == null)
                    {
                        _messenger.SendMessage(Properties.Resources.ChooseRecord);
                        return;
                    }

                    if (await _messenger.SendConfirmMessageAsync(Properties.Resources.DelRecordConfirm))
                    {
                        await _projectService.DeleteProjectAsync(SelectedProject);
                        Projects.Remove(SelectedProject);
                    }
                }));
            }
        }

        public RelayCommand AddTaskCommand
        {
            get
            {
                return _addTask ?? (_addTask = new RelayCommand(async _ =>
                    {
                        if (CurrentProject == null)
                        {
                            _messenger.SendMessage(Properties.Resources.ChooseRecord);
                            return;
                        }

                        var createTaskViewModel = new CreateTaskViewModel(CurrentProject.Id);

                        _window?.Frame.Navigate(new CreateTask(createTaskViewModel));
                    }
                ));
            }
        }

        public RelayCommand UpdateTaskCommand
        {
            get
            {
                return _updateTask ?? (_updateTask = new RelayCommand(_ =>
                {
                    if(SelectedTask == null)
                    {
                        _messenger.SendMessage(Properties.Resources.ChooseRecord);
                        return;
                    }

                    var updateTaskViewModel = new UpdateTaskViewModel(SelectedTask);

                    _window?.Frame.Navigate(new UpdateTask(updateTaskViewModel));
                }
                ));
            }
        }

        public RelayCommand RemoveTaskCommand
        {
            get
            {
                return _removeTask ?? (_removeTask = new RelayCommand(async _ =>
                {
                    if (SelectedTask == null)
                    {
                        _messenger.SendMessage(Properties.Resources.ChooseRecord);
                        return;
                    }

                    if(await _messenger.SendConfirmMessageAsync(Properties.Resources.DelRecordConfirm))
                    {
                        await _taskService.DeleteTaskAsync(SelectedTask);
                        CurrentProject.Tasks.Remove(SelectedTask);
                    }   
                }));
            }
        }
    }
}