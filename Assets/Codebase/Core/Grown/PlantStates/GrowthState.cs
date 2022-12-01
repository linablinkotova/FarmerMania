using System.Collections;
using Codebase.Infrastructure;
using Codebase.Infrastructure.StateMachine;
using UnityEngine;

namespace Codebase.Core.Grown.PlantStates
{
    public class GrowthState : IState
    {
        private readonly PlantStateMachine _plantStateMachine;
        private readonly Plant _plant;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly PlantView _plantView;

        private float _growthPercent = 0.1f;
        
        private const float GrowthTime = 2;

        public GrowthState(PlantStateMachine plantStateMachine, Plant plant, ICoroutineRunner coroutineRunner,
            PlantView plantView)
        {
            _plantStateMachine = plantStateMachine;
            _plant = plant;
            _coroutineRunner = coroutineRunner;
            _plantView = plantView;
        }

        public void Enter()
        {
            _growthPercent = 0.1f;
            _coroutineRunner.StartCoroutine(GrowthCoroutine(1, GrowthTime, _plant.GrowthCurve));
        }

        public void Exit()
        {
        }

        private IEnumerator GrowthCoroutine(float target, float duration, AnimationCurve curve)
        {
            float startValue = _growthPercent;
            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                _growthPercent = Mathf.Lerp(
                    startValue,
                    target,
                    curve.Evaluate(time / duration));
                
                _plantView.SetPlantSize(_growthPercent);

                yield return null;
            }

            _growthPercent = target;
            _plantView.SetPlantSize(_growthPercent);

            _plantStateMachine.Enter<RipeningState>();
        }
    }
}