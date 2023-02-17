using System.Collections;
using UnityEngine;

namespace Utils.ProcessTool
{
    public abstract class Process
    {
        private readonly ICoroutineRunner _runner;
        private Coroutine _loopCoroutine;

        protected Process(ICoroutineRunner runner) => _runner = runner;
        
        public Process Start()
        {
            _loopCoroutine = _runner.StartCoroutine(Loop());
            OnStart();
            return this;
        }

        public void Stop()
        {
            if (_loopCoroutine != null)
                _runner.StopCoroutine(_loopCoroutine);
            OnStop();
        }

        private IEnumerator Loop()
        {
            while (true)
            {
                OnUpdate();
                yield return null;
            }
        }

        protected virtual void OnStart() {}
        protected virtual void OnUpdate() {}
        protected virtual void OnStop() {}
    }
}