using Thirty1Degrees.ScreenNavigation.Types;

namespace Thirty1Degrees.ScreenNavigation.Internal
{
    /// <summary>
    /// Screen navigation service.
    /// </summary>
    public class ScreenNavigationService : IScreenNavigationService
    {
        private readonly IScreenStackRepository screenStackRepository;
        private readonly IScreenAnimationService screenAnimationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenNavigationService"/> class.
        /// </summary>
        /// <param name="screenStackRepository">Screen stack repository.</param>
        /// <param name="screenAnimationService">Screen animation service.</param>
        public ScreenNavigationService(
            IScreenStackRepository screenStackRepository,
            IScreenAnimationService screenAnimationService)
        {
            this.screenStackRepository = screenStackRepository;
            this.screenAnimationService = screenAnimationService;
        }

        /// <summary>
        /// Navigate back up the stack.
        /// </summary>
        public void Back()
        {
            ScreenControllerBase screenController = screenStackRepository.Pop();
            screenAnimationService.Hide(screenController);

            screenController = screenStackRepository.Peak();
            screenAnimationService.Show(screenController);
        }

        /// <summary>
        /// Show the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        /// <param name="viewModel">View model.</param>
        /// <param name="screenStackOptions">The screen stack options.</param>
        public void Show<TViewModel>(ScreenControllerBase<TViewModel> screenController, TViewModel viewModel, ScreenStackOptions screenStackOptions = default)
        {
            screenController.PopulateUi(viewModel);
            Show(screenController, screenStackOptions);
        }

        /// <summary>
        /// Show the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        /// <param name="screenStackOptions">The screen stack options.</param>
        public void Show(ScreenControllerBase screenController, ScreenStackOptions screenStackOptions = default)
        {
            ScreenControllerBase currentScreenController = screenStackRepository.Peak();
            if (currentScreenController == screenController)
            {
                return;
            }

            screenAnimationService.Hide(currentScreenController);

            if (screenStackOptions == ScreenStackOptions.Replace)
            {
                screenStackRepository.Pop();
            }
            else if (screenStackOptions == ScreenStackOptions.Clear)
            {
                screenStackRepository.Clear();
            }

            screenStackRepository.Push(screenController);
            screenAnimationService.Show(screenController);
        }
    }
}