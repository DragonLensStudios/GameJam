using UnityEngine;
//using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{


    public void ToggleGameobject(GameObject _gameObject)
    {
        _gameObject.SetActive(!_gameObject.activeSelf);
    }
}
