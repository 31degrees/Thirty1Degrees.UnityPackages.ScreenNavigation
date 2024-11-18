namespace Thirty1Degrees.ScreenNavigation
{
    /// <summary>
    /// Screen controller repository.
    /// </summary>
    public interface IScreenControllerRepository
    {
        /// <summary>
        /// Register the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        void Register(ScreenControllerBase screenController);

        /// <summary>
        /// Gets the screen.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The screen.</returns>
        T Get<T>()
            where T : ScreenControllerBase;
    }
}