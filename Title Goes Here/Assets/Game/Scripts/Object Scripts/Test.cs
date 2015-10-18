using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	
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
		Destroy (_player);
	}


}
