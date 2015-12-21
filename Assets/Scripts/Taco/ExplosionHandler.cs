using UnityEngine;
using System.Collections;

public class ExplosionHandler : MonoBehaviour {

	Animator animator;
	AudioSource explosionSfx;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		explosionSfx = GetComponent<AudioSource>();
		explosionSfx.Play();
	}

	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
		{
			animator.StopPlayback();
			Destroy(gameObject);
		}
	}
}
