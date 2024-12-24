using UnityEngine;

public class ButtonCounter :MonoBehaviour
{
    private float _counter = 0;

    public float Count => _counter;

    public void Increase()
    {
        _counter++;
    }
}
