using UnityEngine;
using System.Collections;

public class s_DestroyPE : MonoBehaviour
	
{
    #region Fields

    #endregion

    #region Properties

    #endregion

    #region Functions
    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
