using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class GameController : MonoBehaviour {

	public UIManager UIManager { get; private set; }
	public BlockProvider BlockProvider { get; private set; }
	[SerializeField] private GameObject _blockArea;
	public ReactiveProperty<int> Life = new ReactiveProperty<int>(3);
	
	void Start()
	{
		UIManager = GetComponent<UIManager>();
		BlockProvider = GetComponent<BlockProvider>();

		InitializeStage();

		// ライフが変化した時のUI処理
		this.Life
			.TakeWhile(life => life >= 0)
			.Subscribe(life => this.UIManager.UpdateLife(life));
	}

	private void InitializeStage()
	{
		var blocks = new List<NormalBlock>();

		var startPosX = _blockArea.transform.position.x;
		var startPosZ = _blockArea.transform.position.z;
		var width = 6;
		var height = 2;

		for (int i = 0; i < 4; i++)
		{
			var posZ = startPosZ - height * i;
			for (int j = 0; j < 6; j++)
			{
				var posX = startPosX + width * j;
				var position = new Vector3(posX, 0.5f, posZ);
				var block = BlockProvider.NormalCreate(_blockArea.transform, position);
				blocks.Add(block);

				// ブロックが壊れた時の処理
				block.OnBroken
					.TakeUntilDestroy(block)
					.Subscribe(
						score => this.UIManager.UpdateScore(score)
					);
			}
		}
		// 全てのブロックが壊れたらクリア
		var stream = blocks.Select(block => block.OnBroken);
		Observable.WhenAll(stream).Subscribe(_ => GameClear());
	}
	
	// クリア処理
	private void GameClear()
	{
		Debug.Log("ゲームクリア!!");
	}
}
