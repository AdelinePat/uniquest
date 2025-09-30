using UnityEngine;  // REQUIRED for MonoBehaviour and Debug.Log

// Must be public and inherit from MonoBehaviour
public class TestScript : MonoBehaviour
{
    // Runs automatically when the GameObject starts
    void Start()
    {
        Debug.Log("Hello World, Welcome to C#!");

        string name = "John";
        int age = 25;

        Debug.Log($"Name: {name}, Age: {age}");
    }
}