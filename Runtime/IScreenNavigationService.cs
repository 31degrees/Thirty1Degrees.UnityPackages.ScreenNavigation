using Thirty1Degrees.ScreenNavigation.Types;

namespace Thirty1Degrees.ScreenNavigation
{
    /// <summary>
    /// Screen navigation service.
    /// </summary>
    public interface IScreenNavigationService
    {
        /// <summary>
        /// Navigate back up the stack.
        /// </summary>
        void Back();

        /// <summary>
        /// Show the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        /// <param name="viewModel">View model.</param>
        /// <param name="screenStackOptions">The screen stack options.</param>
        void Show<TViewModel>(ScreenControllerBase<TViewModel> screenController, TViewModel viewModel, ScreenStackOptions screenStackOptions = default);

        /// <summary>
        /// Show the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        /// <param name="screenStackOptions">The screen stack options.</param>
        void Show(ScreenControllerBase screenController, ScreenStackOptions screenStackOptions = default);
    }
}