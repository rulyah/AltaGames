using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameScreen : Screen
    {
        //[SerializeField] private Button _pauseButton;
        //[SerializeField] private TextMeshProUGUI _crystalsCount;

        //public event Action onPauseClick;

        public override void Show()
        {
            //_pauseButton.onClick.AddListener(OnPauseClick);
            base.Show();
        }

        public override void Hide()
        {
            //_pauseButton.onClick.RemoveListener(OnPauseClick);
            base.Hide();
        }

        private void OnPauseClick()
        {
            //onPauseClick?.Invoke();
        }
    }
}