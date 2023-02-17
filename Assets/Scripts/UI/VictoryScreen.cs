using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class VictoryScreen : Screen
    {
        [SerializeField] private Button _nextButton;

        public event Action onNextClick;
        
        public override void Show()
        {
            base.Show();
            _nextButton.onClick.AddListener(OnNextClick);
        }

        public override void Hide()
        {
            _nextButton.onClick.RemoveListener(OnNextClick);
            base.Hide();
        }

        private void OnNextClick()
        {
            onNextClick?.Invoke();
        }
    }
}