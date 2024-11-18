using System;
using System.Collections.Generic;

namespace Thirty1Degrees.ScreenNavigation.Internal
{
    /// <summary>
    /// Screen controller repository.
    /// </summary>
    public class ScreenControllerRepository : IScreenControllerRepository
    {
        private readonly Dictionary<Type, ScreenControllerBase> screenControllersByType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenControllerRepository"/> class.
        /// </summary>
        public ScreenControllerRepository()
        {
            screenControllersByType = new Dictionary<Type, ScreenControllerBase>();
        }

        /// <summary>
        /// Register the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        public void Register(ScreenControllerBase screenController)
        {
            Type screenControllerType = screenController.GetType();

            if (screenControllersByType.ContainsKey(screenControllerType))
            {
                throw new ArgumentException($"ScreenController of type '{screenControllerType.Name}' has already been registered.");
            }

            screenControllersByType.Add(screenControllerType, screenController);
        }

        /// <summary>
        /// Gets the screen.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The screen.</returns>
        public T Get<T>()
            where T : ScreenControllerBase
        {
            if (!screenControllersByType.ContainsKey(typeof(T)))
            {
                throw new KeyNotFoundException($"Screen Controller of type '{typeof(T).Name}' has not been registered.");
            }

            return (T)screenControllersByType[typeof(T)];
        }
    }
}