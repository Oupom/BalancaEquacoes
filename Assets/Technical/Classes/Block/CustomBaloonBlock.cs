using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WeightBlocks
{
    public class CustomBaloonBlock : WeightBlockCreator
    {
        [SerializeField] InputField weightField;
        [SerializeField] Dropdown weightUnit;

        int prefabIndex;

        public override void OnPointerDown(PointerEventData eventData)
        {
            _weightValue = float.Parse(weightField.text)*-1;
            _unitValue = weightUnit.value;
            base.OnPointerDown(eventData);
        }
    }
}
