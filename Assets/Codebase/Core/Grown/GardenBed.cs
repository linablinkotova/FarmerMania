using UnityEngine;

namespace Codebase.Core.Grown
{
    public class GardenBed : MonoBehaviour
    {
        private Plant _plant;

        private void Awake()
        {
            _plant = GetComponentInChildren<Plant>();
        }

        public void PlantSeed()
        {
            _plant.SetSeed(1);
            _plant.Interact();
        }
        
        public void Water()
        {
            _plant.Interact();
        }

        public void Harvest()
        {
            _plant.Interact();
        }
    }
}