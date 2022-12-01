using UnityEngine;

namespace Codebase.Core.Grown
{
    public class PlantView : MonoBehaviour
    {
        [SerializeField] private Transform _plantPivot;
        [SerializeField] private Transform _fruitPivot;

        [SerializeField] private GameObject[] _buttons;

        public void SetButton(ButtonType type)
        {
            foreach (var button in _buttons)
            {
                button.SetActive(false);
            }
            _buttons[(int)type].SetActive(true);
        }

        public void SetPlantSize(float sizePercent = 0)
        {
            _plantPivot.localScale = Vector3.one * sizePercent;
        }
        
        public void SetFruitSize(float sizePercent = 0)
        {
            _fruitPivot.localScale = Vector3.one * sizePercent;
        }
    }

    public enum ButtonType
    {
        Plant = 0,
        Water = 1,
        Harvest = 2
    }
}