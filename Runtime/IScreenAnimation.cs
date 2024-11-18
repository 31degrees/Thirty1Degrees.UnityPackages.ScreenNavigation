using System.Collections;

namespace Thirty1Degrees.ScreenNavigation
{
    /// <summary>
    /// Screen animation.
    /// </summary>
    public interface IScreenAnimation
    {
        /// <summary>
        /// Run the show animation.
        /// </summary>
        /// <returns>Enumerable.</returns>
        IEnumerator Show();

        /// <summary>
        /// Run the hide animation.
        /// </summary>
        /// <returns>Enumerable.</returns>
        IEnumerator Hide();
    }
}
