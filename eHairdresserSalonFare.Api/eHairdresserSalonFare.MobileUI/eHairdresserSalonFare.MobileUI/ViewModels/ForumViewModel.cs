using eHairdresserSalonFare.MobileUI.APIServices;
using eHairdresserSalonFare.Model.Requests.Comment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eHairdresserSalonFare.MobileUI.ViewModels
{
    public class ForumViewModel : BaseViewModel
    {
        private readonly BaseAPIService _commentsApiService = new BaseAPIService("comments");

        public ForumViewModel()
        {
            InitCommand = new Command(async () => await Init());
            CommentCommand = new Command(async () => await AddComment());
        }
        public ICommand InitCommand { get; set; }
        public ICommand CommentCommand { get; set; }

        public ObservableCollection<Model.Comment> _comments { get; set; } = new ObservableCollection<Model.Comment>();

        public async Task Init()
        {
            List<Model.Comment> _commentslist = await _commentsApiService.GetAll<List<Model.Comment>>(null);
            _comments.Clear();

            foreach (var item in _commentslist)
            {
                _comments.Add(item);
            }
        }

        string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public async Task AddComment()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Comment text field is required !", "OK");
                return;
            }

            CommentInsertRequest comment = new CommentInsertRequest
            {
                Date = DateTime.UtcNow,
                UserId = BaseAPIService.Id,
                Text = Text
            };

            Model.Comment newComment = await _commentsApiService.Insert<Model.Comment>(comment);

            if (newComment != null)
            {
                _comments.Add(newComment);
                Text = string.Empty;
                await Application.Current.MainPage.DisplayAlert("Success", "Comment added successfuly!", "OK");
            }
        }
    }
}
