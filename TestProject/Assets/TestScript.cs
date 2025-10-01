using UnityEngine;  // REQUIRED for MonoBehaviour and Debug.Log

// Must be public and inherit from MonoBehaviour
public class TestScript : MonoBehaviour
{
    // Runs automatically when the GameObject starts
    void Start()
    {
        Debug.Log("Hello World, Welcome to C#!");
        Debug.Log("New test changé hello!");

        string name = "Saya";
        int age = 3;

        
        Debug.Log($"Name: {name}, Age: {age}");
        Debug.Log($"et enfin ça marche je recompile!!!!!");
    }
}