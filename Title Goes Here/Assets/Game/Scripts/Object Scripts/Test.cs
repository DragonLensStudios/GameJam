using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
	public void LogToConsole(string _logMessage)
	{
		Debug.Log (_logMessage);
	}

	public void MovePlayer(Transform _playerPos)
	{
		_playerPos.position += Vector3.up;
	}

    public void KillPlayer(GameObject _player)
    {
        Destroy(_player);
    }

    public void DisplayMessage(GameObject _gameobject)
    {
        StartCoroutine(IE_DisplayMessage(_gameobject));
    }

    public void FadeMessage(Text _text)
    {
        _text.CrossFadeAlpha(0,2f,false);
    }

    public void FadeGraphic(Image _image)
    {
        _image.CrossFadeAlpha(0,2f,false);
    }

    public IEnumerator IE_DisplayMessage(GameObject _gameobject)
    {
        _gameobject.SetActive(true);
        yield return new WaitForSeconds(2);
        _gameobject.SetActive(false);
    }


}
