using Utils.StateMachineTool;

namespace Level.States
{
    public class VictoryState : State<LevelCore>
    {
        public VictoryState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.victoryScreen.Show();
            core.victoryScreen.onNextClick += OnNext;
        }

        public override void OnExit()
        {
            core.victoryScreen.onNextClick -= OnNext;
            core.victoryScreen.Hide();
        }

        private void OnNext()
        {
            ChangeState(new ClearLevelState(core));
        }
    }
}