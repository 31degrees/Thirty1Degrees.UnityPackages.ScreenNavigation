using System.Collections;
using UnityEngine;

namespace Thirty1Degrees.ScreenNavigation.Internal
{
    /// <summary>
    /// Coroutine service.
    /// </summary>
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        /// <summary>
        /// Start the coroutine.
        /// </summary>
        /// <param name="coroutine">The routine.</param>
        /// <returns>Coroutine.</returns>
        public Coroutine Begin(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        /// <summary>
        /// Stops the coroutine.
        /// </summary>
        /// <param name="coroutine">The coroutine.</param>
        public void End(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
