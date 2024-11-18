using System.Collections;
using UnityEngine;

namespace Thirty1Degrees.ScreenNavigation
{
    public interface ICoroutineService
    {
        /// <summary>
        /// Start the coroutine.
        /// </summary>
        /// <param name="coroutine">The routine.</param>
        /// <returns>Coroutine.</returns>
        Coroutine Begin(IEnumerator coroutine);

        /// <summary>
        /// Stops the coroutine.
        /// </summary>
        /// <param name="coroutine">The coroutine.</param>
        void End(Coroutine coroutine);
    }
}