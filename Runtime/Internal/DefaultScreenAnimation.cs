using System.Collections;

namespace Thirty1Degrees.ScreenNavigation.Internal
{
    /// <summary>
    /// Default screen animation.
    /// </summary>
    public class DefaultScreenAnimation : IScreenAnimation
    {
        /// <inheritdoc />
        public IEnumerator Show()
        {
            yield return null;
        }

        /// <inheritdoc />
        public IEnumerator Hide()
        {
            yield return null;
        }
    }
}
