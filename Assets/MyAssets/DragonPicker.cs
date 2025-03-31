using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
	public GameObject energyShieldPrefab;
	public int energyShieldCount = 3;
	public float energyShieldBottomY = -6f;
	public float energyShieldRadius = 1.5f;
	public List<GameObject> shieldList;

	void Start()
	{
		shieldList = new List<GameObject>();

		for (int i = 1; i <= energyShieldCount; i++)
		{
			GameObject shieldInstance = Instantiate<GameObject>(energyShieldPrefab);
			shieldInstance.transform.position = new Vector3(0, energyShieldBottomY, 0);
			shieldInstance.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
			shieldList.Add(shieldInstance);
		}
	}

	void Update()
	{
	}

	public void DragonEggDestroyed()
	{
		Debug.Log("ShieldDestroyed");

		GameObject[] dragonEggs = GameObject.FindGameObjectsWithTag("DragonEgg");
		foreach (GameObject egg in dragonEggs)
		{
			Destroy(egg);
		}

		int shieldIndex = shieldList.Count - 1;
		GameObject shieldInstance = shieldList[shieldIndex];
		shieldList.RemoveAt(shieldIndex);
		Destroy(shieldInstance);

		if (shieldList.Count == 0)
		{
			SceneManager.LoadScene("_Scene_0");
		}

	}

}
