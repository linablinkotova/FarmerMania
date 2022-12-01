using System;
using System.Collections.Generic;
using Codebase.Core.Grown.PlantStates;
using Codebase.Infrastructure.StateMachine;

namespace Codebase.Core.Grown
{
    public class PlantStateMachine : BaseStateMachine
    {
        public PlantStateMachine(Plant plant, PlantView plantView)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(WaitSeedState)] = new WaitSeedState(this, plant, plantView),
                [typeof(WaitWaterState)] = new WaitWaterState(this, plant, plantView),
                [typeof(GrowthState)] = new GrowthState(this, plant, plant, plantView),
                [typeof(RipeningState)] = new RipeningState(this, plant, plant, plantView),
                [typeof(WaitHarvestingState)] = new WaitHarvestingState(this, plant, plantView)
            };
        }
    }
}