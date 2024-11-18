namespace Thirty1Degrees.ScreenNavigation
{
    /// <summary>
    /// Screen stack repository.
    /// </summary>
    public interface IScreenStackRepository
    {
        /// <summary>
        /// Push to the stack.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        void Push(ScreenControllerBase screenController);

        /// <summary>
        /// Pop form the top of the stack.
        /// </summary>
        /// <returns>The screen controller.</returns>
        ScreenControllerBase Pop();

        /// <summary>
        /// Peak at the stack.
        /// </summary>
        /// <returns>The screen controller.</returns>
        ScreenControllerBase Peak();

        /// <summary>
        /// Clear the stack.
        /// </summary>
        void Clear();
    }
}