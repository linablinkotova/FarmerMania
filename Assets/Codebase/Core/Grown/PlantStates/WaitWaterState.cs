using Codebase.Infrastructure.StateMachine;
using UnityEngine;

namespace Codebase.Core.Grown.PlantStates
{
    public class WaitWaterState : IState
    {
        private readonly PlantStateMachine _plantStateMachine;
        private readonly Plant _plant;
        private readonly PlantView _plantView;

        public WaitWaterState(PlantStateMachine plantStateMachine, Plant plant, PlantView plantView)
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
            Debug.Log("Water plant");
            
            _plantStateMachine.Enter<GrowthState>();
        }

        public void Enter()
        {
            _plantView.SetPlantSize(0.1f);
            _plantView.SetFruitSize();
            _plantView.SetButton(ButtonType.Water);

            _plant.InteractEvent += Plant_OnInteractEvent;
        }
    }
}