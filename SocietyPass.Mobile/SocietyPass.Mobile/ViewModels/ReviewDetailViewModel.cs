using SocietyPass.Mobile.Core.Contracts.Services;
using SocietyPass.Mobile.Core.Contracts.ViewModels;
using SocietyPass.Mobile.Services.Contracts.Services;
using SocietyPass.Mobile.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocietyPass.Mobile.Core.ViewModels
{
    public class ReviewDetailViewModel : BaseViewModel, IReviewDetailViewModel
    {
        private Review _selectedReview;
        private readonly IReviewDataService _reviewDataService;

        public Review SelectedReview
        {
            get => _selectedReview;
            set => SetProperty(ref _selectedReview, value);
        }

        public ReviewDetailViewModel(INavigationService navigationService, IDialogService dialogService, ISettingsService settingsService, IReviewDataService reviewDataService) : base(navigationService, dialogService, settingsService)
        {
            _reviewDataService = reviewDataService;
        }

        public override async Task InitializeAsync(object objectToPass)
        {
            if (objectToPass != null)
            {
                //get all details now
                if (objectToPass is Review review)
                    SelectedReview = await _reviewDataService.GetReviewById(review.Id);
            }
        }
    }
}
