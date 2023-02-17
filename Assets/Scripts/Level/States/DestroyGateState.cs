using System;
using System.Collections;
using UnityEngine;
using Utils.StateMachineTool;

namespace Level.States
{
    public class DestroyGateState : State<LevelCore>
    {
        public DestroyGateState(LevelCore core) : base(core) {}

        public override void OnEnter()
        {
            core.factoryService.gate.Release(core.model.gateView);
            
            //core.StartCoroutine(Delay(1.0f, () => ChangeState(new VictoryState(core))));
        }

        private IEnumerator Delay(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action?.Invoke();
        }
    }
}