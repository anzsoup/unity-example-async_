using UnityEngine;
using System.Collections;
using System.Threading;

public class AsyncTest_Coroutine : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(Run(10));
	}

	IEnumerator Run(int count)
	{
		int result = 0;
		bool isDone = false;

		// 람다식을 사용하면 변수 스코프를 공유할 수 있는 장점이 있다.
		// 스레드에서 실행되는 함수는 result와 isDone 변수에 접근할 수 있다.
		(new Thread(() =>
		{
			for (int i = 0; i < count; ++i)
			{
				Debug.Log(i);
				result += i;
				Thread.Sleep(1000);
			}

			// 작업이 끝났음을 알린다.
			isDone = true;
		}))
		.Start();

		// isDone == true 가 될 때까지 대기한다.
		while (!isDone) yield return null;

		Debug.Log("Result : " + result);
	}
}
