using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class AsyncTest_Lambda : MonoBehaviour
{
	void Start()
	{
		Debug.Log("Run() invoked in Start()");
		Run(10);
		Debug.Log("Run() returns");
	}

	void Update()
	{
		Debug.Log("Update()");
	}

	async void Run(int count)
	{
		int result = 0;

		await Task.Run(() =>
		{
			for (int i = 0; i < count; ++i)
			{
				Debug.Log(i);
				result += i;
				Thread.Sleep(1000);
			}
		});

		Debug.Log("Result : " + result);
	}
}
