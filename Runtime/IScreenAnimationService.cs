namespace Thirty1Degrees.ScreenNavigation
{
    /// <summary>
    /// Screen animation service.
    /// </summary>
    public interface IScreenAnimationService
    {
        /// <summary>
        /// Show the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        void Show(ScreenControllerBase screenController);

        /// <summary>
        /// Hide the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        void Hide(ScreenControllerBase screenController);
    }
}