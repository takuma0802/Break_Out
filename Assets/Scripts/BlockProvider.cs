using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProvider : MonoBehaviour
{
	[SerializeField] private GameObject _normalBlock;
	[SerializeField] private GameObject _hardBlock;
	[SerializeField] private GameObject _penetrateBlock;

	public NormalBlock NormalCreate(Transform parent, Vector3 position)
	{
		var go = Instantiate(_normalBlock, parent) as GameObject;
		var block = go.GetComponent<NormalBlock>();
		go.transform.position = position;

		return block;
	}
}
