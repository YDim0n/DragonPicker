using TMPro;
using UnityEngine;


public class EnergyShield : MonoBehaviour
{
	public TextMeshProUGUI scoreTable;

	void Start()
	{
		GameObject scoreInstance = GameObject.Find("Score");
		scoreTable = scoreInstance.GetComponent<TextMeshProUGUI>();
		scoreTable.text = "0";
	}

	void Update()
	{
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	private void OnCollisionEnter(Collision c)
	{
		GameObject collidedObj = c.gameObject;

		Debug.Log("Колізія з: " + collidedObj.name);


		if (collidedObj.tag == "DragonEgg")
		{
			collidedObj.SetActive(false); // Приховуємо, щоб уникнути повторної колізії
			Destroy(collidedObj, 0.1f);  // Видаляємо із затримкою

			int score = int.Parse(scoreTable.text);
			score += 1;
			Debug.Log("Egg Catched");
			scoreTable.text = score.ToString();
		}
	}
}
