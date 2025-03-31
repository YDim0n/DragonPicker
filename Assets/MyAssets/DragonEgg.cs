using UnityEngine;

public class DragonEgg : MonoBehaviour
{
	public static float BottomY = -30f;
	void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		ParticleSystem ps = GetComponent<ParticleSystem>();
		var em = ps.emission;
		em.enabled = true;
		Renderer rend = GetComponent<Renderer>();
		rend.enabled = false;
	}


	void Update()
	{
		if (transform.position.y < BottomY)
		{
			Destroy(gameObject);
			DragonPicker dragonPicker = Camera.main.GetComponent<DragonPicker>();
			dragonPicker.DragonEggDestroyed();
		}
	}
}
