using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuScreen : Screen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        public event Action onPlay;
        public event Action onSettings;
        public event Action onClose;
        
        public override void Show()
        {
            base.Show();
            _playButton.onClick.AddListener(OnPlayClick);
            _settingsButton.onClick.AddListener(OnSettingsClick);
            _exitButton.onClick.AddListener(OnExitClick);
            Debug.Log("show");
        }

        public override void Hide()
        {
            _playButton.onClick.RemoveListener(OnPlayClick);
            _settingsButton.onClick.RemoveListener(OnSettingsClick);
            _exitButton.onClick.RemoveListener(OnExitClick);
            base.Hide();
        }

        private void OnPlayClick()
        {
            onPlay?.Invoke();
        }

        private void OnSettingsClick()
        {
            onSettings?.Invoke();
        }
        
        private void OnExitClick()
        {
            onClose?.Invoke();
        }
    }
}