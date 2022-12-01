using System;
using Codebase.Core.Grown.PlantStates;
using Codebase.Infrastructure;
using UnityEngine;

namespace Codebase.Core.Grown
{
    public class Plant : MonoBehaviour, ICoroutineRunner
    {
        [field: SerializeField] public AnimationCurve GrowthCurve { get; private set; }
        [field: SerializeField] public AnimationCurve RipeningCurve { get; private set; }

        private PlantStateMachine _plantStateMachine;
        private int _plantId = 0;

        public event Action InteractEvent;

        private void Awake()
        {
            _plantStateMachine = new PlantStateMachine(this, GetComponent<PlantView>());
            _plantStateMachine.Enter<WaitSeedState>();
        }

        public void SetSeed(int id)
        {
            _plantId = id;
        }

        public void Interact()
        {
            InteractEvent?.Invoke();
        }
    }
}