using Codebase.Infrastructure.StateMachine;
using UnityEngine;

namespace Codebase.Core.Grown.PlantStates
{
    public class WaitSeedState : IState
    {
        private readonly PlantStateMachine _plantStateMachine;
        private readonly Plant _plant;
        private readonly PlantView _plantView;

        public WaitSeedState(PlantStateMachine plantStateMachine, Plant plant, PlantView plantView)
        {
            _plantStateMachine = plantStateMachine;
            _plant = plant;
            _plantView = plantView;
        }

        public void Exit()
        {
            _plant.InteractEvent -= Plant_OnInteractEvent;
        }

        private void Plant_OnInteractEvent()
        {
            Debug.Log("Seed planted");
            _plantStateMachine.Enter<WaitWaterState>();
        }

        public void Enter()
        {
            _plantView.SetPlantSize();
            _plantView.SetFruitSize();
            _plantView.SetButton(ButtonType.Plant);
            _plant.InteractEvent += Plant_OnInteractEvent;
        }
    }
}