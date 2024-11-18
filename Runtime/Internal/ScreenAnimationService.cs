using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thirty1Degrees.ScreenNavigation.Internal
{
    /// <summary>
    /// Screen animation service.
    /// </summary>
    public class ScreenAnimationService : IScreenAnimationService
    {
        private readonly ICoroutineService coroutineService;

        private readonly IDictionary<ScreenControllerBase, Coroutine> screenControllerByCoroutine = new Dictionary<ScreenControllerBase, Coroutine>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenAnimationService"/> class.
        /// </summary>
        /// <param name="coroutineService">Coroutine service.</param>
        public ScreenAnimationService(ICoroutineService coroutineService)
        {
            this.coroutineService = coroutineService;
        }

        /// <summary>
        /// Show the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        public void Show(ScreenControllerBase screenController)
        {
            // Stop any existing coroutines, disable the gameobject and call the OnDidHide callback.
            if (screenControllerByCoroutine.TryGetValue(screenController, out Coroutine activeCoroutine))
            {
                coroutineService.End(activeCoroutine);
                screenController.gameObject.SetActive(false);
                screenController.OnDidHide();
            }

            // Make sure the screen is visable.
            screenController.RectTransform.anchorMin = Vector2.zero;
            screenController.RectTransform.anchorMax = Vector2.one;
            screenController.RectTransform.anchoredPosition = Vector2.zero;

            // Call the on will show callback and set the screen active.
            screenController.OnWillShow();
            screenController.gameObject.SetActive(true);

            // Start the show animation.
            Coroutine coroutine = coroutineService.Begin(ShowAsync(screenController));

            // Add the coroutine to the active coroutines dictionary.
            screenControllerByCoroutine[screenController] = coroutine;
        }

        /// <summary>
        /// Hide the screen.
        /// </summary>
        /// <param name="screenController">The screen controller.</param>
        public void Hide(ScreenControllerBase screenController)
        {
            if (screenController == null)
            {
                return;
            }

            // Stop any existing coroutines and call the OnDidShow callback.
            if (screenControllerByCoroutine.TryGetValue(screenController, out Coroutine activeCoroutine))
            {
                coroutineService.End(activeCoroutine);
                screenController.OnDidShow();
            }

            // Call the on will hide callback and start the hide animation.
            screenController.OnWillHide();
            Coroutine coroutine = coroutineService.Begin(HideAsync(screenController));

            // Add the coroutine to the active coroutines dictionary.
            screenControllerByCoroutine[screenController] = coroutine;
        }

        private IEnumerator ShowAsync(ScreenControllerBase screenController)
        {
            yield return coroutineService.Begin(screenController.ScreenAnimation.Show());
            screenController.OnDidShow();

            // Remove from the active coroutines.
            screenControllerByCoroutine.Remove(screenController);
        }

        private IEnumerator HideAsync(ScreenControllerBase screenController)
        {
            yield return coroutineService.Begin(screenController.ScreenAnimation.Hide());
            screenController.gameObject.SetActive(false);
            screenController.OnDidHide();

            // Remove from the active coroutines list.
            screenControllerByCoroutine.Remove(screenController);
        }
    }
}