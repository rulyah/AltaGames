using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class MenuState : State<LevelCore>
    {
        public MenuState(LevelCore core) : base(core) {}
        
        public override void OnEnter()
        {
            core.menuScreen.Show();
            core.menuScreen.onPlay += OnPlay;
            core.menuScreen.onClose += OnClose;
        }
        
        public override void OnExit()
        {
            core.menuScreen.onClose -= OnClose;
            core.menuScreen.onPlay -= OnPlay;
            core.menuScreen.Hide();
        }

        private void OnPlay()
        {
            ChangeState(new PrepareLevelState(core));
        }

        private void OnClose()
        {
            Application.Quit();
        }
    }
}