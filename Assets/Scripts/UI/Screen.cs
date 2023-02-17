
using UnityEngine;

namespace UI
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
    
        public virtual void Show()
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public virtual void Hide()
        {
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}
