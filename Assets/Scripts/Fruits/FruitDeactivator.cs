using UnityEngine;

public class FruitDeactivator : MonoBehaviour
{
    // Serialize
    [SerializeField] private string _tagToCompare = "Fruit";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(_tagToCompare))
        {
            other.gameObject.SetActive(false);
        }
    }
}
