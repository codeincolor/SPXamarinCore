using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Core.Utility;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class ReviewListViewModel : BaseViewModel, IReviewListViewModel
    {
        private ObservableRangeCollection<Review> _reviews;
        private Review _selectedReview;
        private IAsyncCommand _reviewSelectedCommand;
        private IReviewDataService _reviewDataService;

        public ReviewListViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService, IReviewDataService reviewDataService) : base(navigationService, dialogService, settingsService)
        {
            _reviewDataService = reviewDataService;
            Reviews = new ObservableRangeCollection<Review>();
        }

        public ObservableRangeCollection<Review> Reviews
        {
            get => _reviews;
            set
            {
                _reviews = value;
                OnPropertyChanged();
            }
        }

        public Review SelectedReview { get; set; }

        public IAsyncCommand ReviewSelectedCommand => _reviewSelectedCommand ??
                                                          (_reviewSelectedCommand =
                                                              new AsyncCommand<Review>(OnReviewSelectedCommand));

        private async Task OnReviewSelectedCommand(Review review)
        {
            await _navigationService.NavigateToAsync<ReviewDetailViewModel>(review);
        }

        private async Task LoadReviews()
        {
            var reviews = await _reviewDataService.GetAllReviewsForRestaurant();
            Reviews.ReplaceRange(reviews);
        }

        public async override Task InitializeAsync(object objectToPass)
        {
            var reviews = await _reviewDataService.GetAllReviewsForRestaurant();
            Reviews.ReplaceRange(reviews);
        }
    }
}
