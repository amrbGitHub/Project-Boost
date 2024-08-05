using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Hit a Finish Object");
                break;
            case "Fuel":
                Debug.Log("Hit a Fuel Object");
                break;
            case "Friendly":
                Debug.Log("Hit a Friendly Object");
                break;
            default:
                Debug.Log("Hit Other Object");
                break;
        }
    }
}
