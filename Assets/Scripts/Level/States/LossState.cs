using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class LossState : State<LevelCore>
    {
        public LossState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            Debug.Log("LossState");
            core.lossScreen.Show();
            core.lossScreen.onRestart += OnRestart;
        }

        public override void OnExit()
        {
            core.lossScreen.onRestart -= OnRestart;
            core.lossScreen.Hide();
        }
        
        private void OnRestart()
        {
            ChangeState(new ClearLevelState(core));
        }
    }
}