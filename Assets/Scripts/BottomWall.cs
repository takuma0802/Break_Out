using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomWall : MonoBehaviour
{
	[SerializeField] private GameController _gameController;
	[SerializeField] private GameObject _ballPrefab;
	private readonly Vector3 _ballPosition = new Vector3(0f, 0.6f, -7f);

	void OnCollisionEnter(Collision collision)
	{
		Destroy(collision.gameObject);

		if (_gameController.Life.Value > 0)
		{
			Instantiate(_ballPrefab, _ballPosition, Quaternion.identity);
			_gameController.Life.Value--;
		}
		else if (_gameController.Life.Value == 0)
		{
			SceneManager.LoadScene("GameOver");
		}
	}
}
