using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offscreen : MonoBehaviour
{

    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if(!GeometryUtility.TestPlanesAABB(planes,spriterenderer.bounds))
        {
            if (transform.position.x - Camera.main.transform.position.x < 0.0f)
            {
                checktile();
            }
        }
    }

    void checktile()
    {
        if(this.tag == mytags.road)
        {
            change(ref MapGenerator.instance.lastposofroadtile,
                new Vector3(1.5f, 0, 0), ref MapGenerator.instance.lastorderofroadtile);
        }
        else if(this.tag == mytags.topneargrass)
        {
            change(ref MapGenerator.instance.lastposoftopneargrass,
                new Vector3(1.2f, 0, 0), ref MapGenerator.instance.lastorderoftopneargrass);
        }
        else if(this.tag == mytags.topfargrass)
        {
            change1(ref MapGenerator.instance.lastposoftopfargrass,
                new Vector3(4.8f, 0,0), ref MapGenerator.instance.lastorderoftopfargrass);
        }
        else if(this.tag == mytags.bottomneargrass)
        {
            change(ref MapGenerator.instance.lastposofbottomneargrass,
                new Vector3(1.2f, 0, 0), ref MapGenerator.instance.lastorderofbottomneargrass);
        }
        else if(this.tag == mytags.bottomfarland1)
        {
            change(ref MapGenerator.instance.lastposofbottomfarlandf1,
                new Vector3(1.6f, 0, 0), ref MapGenerator.instance.lastorderofbottomfarlandf1);
        }
        else if (this.tag == mytags.bottomfarland2)
        {
            change(ref MapGenerator.instance.lastposofbottomfarlandf2,
                new Vector3(1.6f, 0, 0), ref MapGenerator.instance.lastorderofbottomfarlandf2);
        }
        else if (this.tag == mytags.bottomfarland3)
        {
            change(ref MapGenerator.instance.lastposofbottomfarlandf3,
                new Vector3(1.6f, 0, 0), ref MapGenerator.instance.lastorderofbottomfarlandf3);
        }
        else if (this.tag == mytags.bottomfarland4)
        {
            change(ref MapGenerator.instance.lastposofbottomfarlandf4,
                new Vector3(1.6f, 0, 0), ref MapGenerator.instance.lastorderofbottomfarlandf4);
        }
        else if (this.tag == mytags.bottomfarland5)
        {
            change(ref MapGenerator.instance.lastposofbottomfarlandf5,
                new Vector3(1.6f, 0, 0), ref MapGenerator.instance.lastorderofbottomfarlandf5);
        }
    }

    void change(ref Vector3 pos, Vector3 offset, ref int orderlayer)
    {
        transform.position = pos;
        pos += offset;
        spriterenderer.sortingOrder = orderlayer;
        orderlayer++;
    }
    void change1(ref Vector3 pos, Vector3 offset, ref int orderlayer)
    {
        transform.position = pos;
        pos += offset;
        spriterenderer.sortingOrder = 0;
    }
}
