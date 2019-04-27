using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFogController : MonoBehaviour
{
    BossData bossData;
    public ParticleSystem bossFog;

	// Use this for initialization
	void Start ()
    {
        bossData = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossData>();
        bossFog = GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(bossData.IsAlive == false)
        {
            var em = bossFog.emission;
            em.enabled = false;
        }
	}
}
