using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitchManger : MonoBehaviour
{
    [SerializeField] private GameObject plat1;
    [SerializeField] private GameObject plat0;

    [SerializeField] private GameObject ind1;
    [SerializeField] private GameObject ind0;

    [SerializeField] private DeathManger death;
    // Start is called before the first frame update
    void Start()
    {
        plat1.SetActive(true);
        plat0.SetActive(false);

        death = GameObject.FindGameObjectWithTag("Logic").GetComponent<DeathManger>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("switch") && death.playerDead == false)
        {
            plat1.SetActive(!plat1.activeInHierarchy);
            plat0.SetActive(!plat0.activeInHierarchy);
        }

        ind1.SetActive(!plat1.activeInHierarchy);
        ind0.SetActive(!plat0.activeInHierarchy);
    }

    public void resetPlatforms(bool plat1Reset)
    {
        if (plat1Reset)
        {
            plat1.SetActive(true);
            plat0.SetActive(false);
        }
        else
        {
            plat1.SetActive(false);
            plat0.SetActive(true);
        }

        ind1.SetActive(!plat1.activeInHierarchy);
        ind0.SetActive(!plat0.activeInHierarchy);
    }
}
