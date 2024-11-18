using Thirty1Degrees.ScreenNavigation.Internal;
using UnityEngine;
using Zenject;

namespace Thirty1Degrees.ScreenNavigation
{
    /// <summary>
    /// Screen controller base with view model.
    /// </summary>
    public abstract class ScreenControllerBase<TViewModel> : ScreenControllerBase
    {
        /// <summary>
        /// Called before On will show.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public virtual void PopulateUi(TViewModel viewModel)
        {
        }
    }

    /// <summary>
    /// Screen controller base.
    /// </summary>
    public abstract class ScreenControllerBase : MonoBehaviour
    {
        [Inject]
        protected readonly IScreenControllerRepository screenControllerRepository = null;

        /// <summary>
        /// Gets or sets the canvas group.
        /// </summary>
        public virtual CanvasGroup CanvasGroup { get; protected set; }

        /// <summary>
        /// Gets or sets the rect transform.
        /// </summary>
        public virtual RectTransform RectTransform { get; protected set; }

        /// <summary>
        /// Gets or sets the screen animation.
        /// </summary>
        public virtual IScreenAnimation ScreenAnimation { get; protected set; }

        /// <summary>
        /// Called before the show animation starts. GameObject is disabled.
        /// </summary>
        public virtual void OnWillShow()
        {
        }

        /// <summary>
        /// Called after the show animation finishes. GameObject is enabled.
        /// </summary>
        public virtual void OnDidShow()
        {
        }

        /// <summary>
        /// Called before the hide animation starts. GameObject is enabled.
        /// </summary>
        public virtual void OnWillHide()
        {
        }

        /// <summary>
        /// Called after the hide animation finishes. GameObject is disabled.
        /// </summary>
        public virtual void OnDidHide()
        {
        }

        /// <summary>
        /// Unity awake function.
        /// </summary>
        protected virtual void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            CanvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
            ScreenAnimation = GetComponent<IScreenAnimation>() ?? new DefaultScreenAnimation();

            screenControllerRepository.Register(this);
        }

        /// <summary>
        /// Unity start function.
        /// </summary>
        protected virtual void Start()
        {
            gameObject.SetActive(false);
        }
    }
}