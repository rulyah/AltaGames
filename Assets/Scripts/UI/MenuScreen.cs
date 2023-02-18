using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuScreen : Screen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        public event Action onPlay;
        public event Action onClose;
        
        public override void Show()
        {
            base.Show();
            _playButton.onClick.AddListener(OnPlayClick);
            _exitButton.onClick.AddListener(OnExitClick);
        }

        public override void Hide()
        {
            _playButton.onClick.RemoveListener(OnPlayClick);
            _exitButton.onClick.RemoveListener(OnExitClick);
            base.Hide();
        }

        private void OnPlayClick()
        {
            onPlay?.Invoke();
        }

        private void OnExitClick()
        {
            onClose?.Invoke();
        }
    }
}