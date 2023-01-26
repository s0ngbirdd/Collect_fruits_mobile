using UnityEngine;

public class FruitDeactivator : MonoBehaviour
{
    // Serialize
    [SerializeField] private string _layerToCompare = "Fruit";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer(_layerToCompare)))
        {
            other.gameObject.SetActive(false);
        }
    }
}
