using System;
using ProjectManager.DAL.Models;

namespace ProjectManager.BL.DTO
{
    public class TaskDto: NotifyObject
    {
        private string _description;
        private int _progressInPercents;


        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public int ProgressInPercents
        {
            get => _progressInPercents;
            set
            {
                _progressInPercents = value;
                OnPropertyChanged(nameof(ProgressInPercents));
            }
        }
    }
}