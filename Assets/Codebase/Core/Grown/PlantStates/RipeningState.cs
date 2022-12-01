using System.Collections;
using Codebase.Infrastructure;
using Codebase.Infrastructure.StateMachine;
using UnityEngine;

namespace Codebase.Core.Grown.PlantStates
{
    public class RipeningState : IState
    {
        private readonly PlantStateMachine _plantStateMachine;
        private readonly Plant _plant;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly PlantView _plantView;

        private float _ripePercent = 0;
        
        private const float RipeTime = 2;

        public RipeningState(PlantStateMachine plantStateMachine, Plant plant, ICoroutineRunner coroutineRunner,
            PlantView plantView)
        {
            _plantStateMachine = plantStateMachine;
            _plant = plant;
            _coroutineRunner = coroutineRunner;
            _plantView = plantView;
        }

        public void Enter()
        {
            _ripePercent = 0;
            _coroutineRunner.StartCoroutine(RipeningCoroutine(1, RipeTime, _plant.RipeningCurve));
        }

        public void Exit()
        {
            
        }

        private IEnumerator RipeningCoroutine(float target, float duration, AnimationCurve curve)
        {
            float startValue = _ripePercent;
            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                _ripePercent = Mathf.Lerp(
                    startValue,
                    target,
                    curve.Evaluate(time / duration));
                
                _plantView.SetFruitSize(_ripePercent);


                yield return null;
            }

            _ripePercent = target;
            _plantView.SetFruitSize(_ripePercent);

            _plantStateMachine.Enter<WaitHarvestingState>();
        }
    }
}