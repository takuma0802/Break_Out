using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PenetrateBlock : MonoBehaviour {

	public Subject<int> OnBroken = new Subject<int>();
	public ReactiveProperty<int> HitPoint { get; private set; } = new ReactiveProperty<int>(1);
	public int Score { get; private set; } = 20;

	private void Awake()
	{
		// ぶつかったらHPを減らす
		this.OnCollisionEnterAsObservable()
			.TakeUntilDestroy(this)
			.Subscribe(
				collision =>
				{
					this.HitPoint.Value--;
				}
			);

		this.HitPoint
			.Where(hp => hp <= 0)
			.TakeUntilDestroy(this)
			.Subscribe(
				_ =>
				{
					this.OnBroken.OnNext(this.Score);
					this.OnBroken.OnCompleted();
					Destroy(this.gameObject);
				}
			);
	}
}
