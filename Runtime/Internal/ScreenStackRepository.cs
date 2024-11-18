using System.Collections.Generic;
using System.Linq;

namespace Thirty1Degrees.ScreenNavigation.Internal
{
    /// <summary>
    /// Screen stack repository.
    /// </summary>
    public class ScreenStackRepository : IScreenStackRepository
    {
        private readonly Stack<ScreenControllerBase> screenStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenStackRepository"/> class.
        /// </summary>
        public ScreenStackRepository()
        {
            screenStack = new Stack<ScreenControllerBase>();
        }

        /// <summary>
        /// Push to the stack.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        public void Push(ScreenControllerBase screenController)
        {
            screenStack.Push(screenController);
        }

        /// <summary>
        /// Pop form the top of the stack.
        /// </summary>
        /// <returns>The screen controller.</returns>
        public ScreenControllerBase Pop()
        {
            return screenStack.Pop();
        }

        /// <summary>
        /// Peak at the stack.
        /// </summary>
        /// <returns>The screen controller.</returns>
        public ScreenControllerBase Peak()
        {
            return screenStack.Any() ? screenStack.Peek() : null;
        }

        /// <summary>
        /// Clear the stack.
        /// </summary>
        public void Clear()
        {
            screenStack.Clear();
        }
    }
}