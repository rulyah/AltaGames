using Level.Processes;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class InputState : State<LevelCore>
    {
        public InputState(LevelCore core) : base(core) {}
        private PlayerInputProcess _inputProcess;
        public override void OnEnter()
        {
            Debug.Log("InputState");
            core.gameScreen.Show();
            _inputProcess = new PlayerInputProcess(core);
            _inputProcess.Start();
            _inputProcess.onFire += OnFire;

        }

        private void OnFire()
        {
            //core.model.bulletView = core.factoryService.bullet.Produce();
            var bullet = core.model.bulletView;
            //var scale = new Vector3(chargeTime, chargeTime, chargeTime);
            //bullet.transform.localScale = scale;
            //bullet.transform.position =
                //new Vector3(core.model.playerView.transform.position.x, bullet.transform.localScale.y / 2.0f,
                    //core.model.playerView.transform.position.z);
            //bullet.transform.rotation = Quaternion.identity;
            bullet.Move(core.config.bulletSpeed);
            
            //core.model.playerView.ChangSize(scale);
            core.model.roadView.ChangeScale(core.model.playerView.transform.localScale.x);
            ChangeState(new CheckBulletCollisionState(core));

            /*if (core.model.playerView.transform.localScale.x <= 0.0f)
            {
                ChangeState(new LossState(core));
            }
            else
            {
                var player = core.model.playerView.transform;
                player.position = new Vector3(player.position.x, player.localScale.x / 2.0f, player.position.z);
                ChangeState(new CheckBulletCollisionState(core));
            }*/
        }

        public override void OnExit()
        {
            //core.gameScreen.onPauseClick -= OnPause;
            _inputProcess.onFire -= OnFire;
            _inputProcess.Stop();
        }
    }
}