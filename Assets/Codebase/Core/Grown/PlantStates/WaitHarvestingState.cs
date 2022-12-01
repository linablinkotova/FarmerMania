using Codebase.Infrastructure.StateMachine;
using UnityEngine;

namespace Codebase.Core.Grown.PlantStates
{
    public class WaitHarvestingState : IState
    {
        private readonly PlantStateMachine _plantStateMachine;
        private readonly Plant _plant;
        private readonly PlantView _plantView;

        public WaitHarvestingState(PlantStateMachine plantStateMachine, Plant plant, PlantView plantView)
        {
            _plantStateMachine = plantStateMachine;
            _plant = plant;
            _plantView = plantView;
        }

        public void Enter()
        {
            _plantView.SetButton(ButtonType.Harvest);
            _plant.InteractEvent += Plant_OnInteractEvent;
        }

        private void Plant_OnInteractEvent()
        {
            Debug.Log("Plant harvested");
            _plantView.SetFruitSize();
            _plantStateMachine.Enter<RipeningState>();
        }

        public void Exit()
        {
            _plant.InteractEvent -= Plant_OnInteractEvent;
        }
    }
}