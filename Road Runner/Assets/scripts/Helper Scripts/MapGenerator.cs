using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance;

    [Header("Prefabs")]
    public GameObject roadprefab;
    public GameObject grassprefab;
    public GameObject groundprefab1;
    public GameObject groundprefab2;
    public GameObject groundprefab3;
    public GameObject groundprefab4;
    public GameObject grassbottomprefab;
    public GameObject landprefab1;
    public GameObject landprefab2;
    public GameObject landprefab3;
    public GameObject landprefab4;
    public GameObject landprefab5;
    public GameObject biggrassprefab;
    public GameObject biggrassbottomprefab;
    public GameObject treeprefab1;
    public GameObject treeprefab2;
    public GameObject treeprefab3;
    public GameObject bigtreeprefab;

    [Space(10)]
    [Header("Holders")]
    public GameObject roadholder;
    public GameObject topnearsidewalkholder;
    public GameObject topfarsidewalkholder;
    public GameObject bottomnearsidewalkholder;
    public GameObject bottomfarsidewalkholder;

    [Space(10)]

    [Header("tiles")]
    public int startroadtile;
    public int startgrasstile;
    public int startground3tile;
    public int startlandtile;

    [Space(10)]

    [Header("Parent lists")]
    public List<GameObject> roadtiles;
    public List<GameObject> topneargrasstile;
    public List<GameObject> topfargrasstile;
    public List<GameObject> bottomneargrasstiles;
    public List<GameObject> bottomfarlandf1tile;
    public List<GameObject> bottomfarlandf2tile;
    public List<GameObject> bottomfarlandf3tile;
    public List<GameObject> bottomfarlandf4tile;
    public List<GameObject> bottomfarlandf5tile;

    [Space(10)]

    [Header("Positions of grounds")]
    public int[] posfortopground1;
    public int[] posfortopground2;
    public int[] posfortopground4;

    [Space(10)]

    [Header("Positions of big grass")]
    public int[] posfortopbiggrass;

    [Space(10)]

    [Header("Positions of top trees")]
    public int[] posfortoptree1; 
    public int[] posfortoptree2;
    public int[] posfortoptree3;

    [Space(10)]

    [Header("Positions of top roads")]
    public int posfortoproad1;
    public int posfortoproad2;
    public int posfortoproad3;

    [Space(10)]

    [Header("Positions of big bottom grass")]
    public int[] posforbottombiggrass;

    [Space(10)]

    [Header("Positions of bottom trees")]
    public int[] posforbottomtree1;
    public int[] posforbottomtree2;
    public int[] posforbottomtree3;

    [HideInInspector]
    public Vector3 lastposofroadtile;
    public Vector3 lastposoftopneargrass;
    public Vector3 lastposoftopfargrass;
    public Vector3 lastposofbottomneargrass;
    public Vector3 lastposofbottomfarlandf1;
    public Vector3 lastposofbottomfarlandf2;
    public Vector3 lastposofbottomfarlandf3;
    public Vector3 lastposofbottomfarlandf4;
    public Vector3 lastposofbottomfarlandf5;

    [HideInInspector]
    public int lastorderofroadtile;
    public int lastorderoftopneargrass;
    public int lastorderoftopfargrass;
    public int lastorderofbottomneargrass;
    public int lastorderofbottomfarlandf1;
    public int lastorderofbottomfarlandf2;
    public int lastorderofbottomfarlandf3;
    public int lastorderofbottomfarlandf4;
    public int lastorderofbottomfarlandf5;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        initialize();
    }

    void initialize()
    {
        initializeplatform(roadprefab, ref lastposofroadtile, 
            roadprefab.transform.position,startroadtile,roadholder,
            ref roadtiles,ref lastorderofroadtile, new Vector3(1.5f,0,0));

        initializeplatform(grassprefab, ref lastposoftopneargrass, grassprefab.transform.position,
            startgrasstile, topnearsidewalkholder, ref topneargrasstile,
            ref lastorderoftopneargrass, new Vector3(1.2f,0,0));

        initializeplatform(groundprefab3, ref lastposoftopfargrass,
            groundprefab3.transform.position, startground3tile, topfarsidewalkholder,
            ref topfargrasstile, ref lastorderoftopfargrass, new Vector3(4.8f, 0, 0));

        initializeplatform(grassbottomprefab,ref lastposofbottomneargrass,
            new Vector3(2.0f,grassbottomprefab.transform.position.y,0),
            startgrasstile, bottomnearsidewalkholder,ref bottomneargrasstiles,
            ref lastorderofbottomneargrass,new Vector3(1.2f,0,0));

        initializebottomfarland();

    }

    void initializeplatform(GameObject prefab, ref Vector3 laspos, 
        Vector3 lasposoftile,int amountoftile,GameObject holder, 
        ref List<GameObject> listtile,ref int lastorder,Vector3 offset)
    {
        int orderinlayer = 0;
        laspos = lasposoftile;

        for(int i=0;i<amountoftile;i++)
        {
            GameObject clone = Instantiate(prefab, laspos, 
                prefab.transform.rotation) as GameObject;
            clone.GetComponent<SpriteRenderer>().sortingOrder = orderinlayer;

            if(clone.tag==mytags.topneargrass)
            {
                setnearscene(biggrassprefab, ref clone, ref orderinlayer,
                    posfortopbiggrass, posfortoptree1, posfortoptree2, posfortoptree3);
            }
            else if (clone.tag == mytags.bottomneargrass)
            {
                setnearscene(biggrassbottomprefab, ref clone, ref orderinlayer,
                    posforbottombiggrass, posforbottomtree1, posforbottomtree2,
                    posforbottomtree3);
            }
            else if (clone.tag == mytags.bottomfarland2)
            {
                if(orderinlayer==5)
                {
                    createtreeorground(bigtreeprefab, ref clone, new Vector3(-0.57f, -1.34f, 0));
                }
            }
            else if (clone.tag == mytags.topfargrass)
            {
                createground(ref clone, ref orderinlayer);
            }
            clone.transform.SetParent(holder.transform);
            listtile.Add(clone);

            orderinlayer += 1;
            lastorder = orderinlayer;

            laspos += offset;
        }
    }

    void createscene(GameObject biggrassprefab,ref GameObject tileclone,
        int orderinlayer)
    {
        GameObject clone = Instantiate(biggrassprefab, 
            tileclone.transform.position,biggrassprefab.transform.rotation) as GameObject;
        
        clone.GetComponent<SpriteRenderer>().sortingOrder = orderinlayer;
        clone.transform.SetParent(tileclone.transform);
        clone.transform.localPosition = new Vector3(-0.183f,0.106f,0);

        createtreeorground(treeprefab1, ref clone, new Vector3(0, 1.52f, 0));

        tileclone.GetComponent<SpriteRenderer>().enabled = false;
    }

    void createtreeorground(GameObject prefab,ref GameObject tileclone,Vector3 localpos)
    {
        GameObject clone = Instantiate(prefab, tileclone.transform.position,
            prefab.transform.rotation) as GameObject;
        
        SpriteRenderer tileclonerenderer = tileclone.GetComponent<SpriteRenderer>();
        SpriteRenderer clonerenderer = clone.GetComponent<SpriteRenderer>();

        clonerenderer.sortingOrder = tileclonerenderer.sortingOrder;
        clone.transform.SetParent(tileclone.transform);
        clone.transform.localPosition = localpos;

        if (prefab == groundprefab1 || prefab == groundprefab2 || prefab == groundprefab3
            || prefab == groundprefab4) 
        {
            tileclonerenderer.enabled = false;
        }
    }

    void createground(ref GameObject clone, ref int orderinlayer)
    {
        for(int i=0;i<posfortopground1.Length;i++)
        {
            if(orderinlayer==posfortopground1[i])
            {
                createtreeorground(groundprefab1, ref clone, Vector3.zero);
                break;
            }
        }
        for (int i = 0; i < posfortopground2.Length; i++)
        {
            if (orderinlayer == posfortopground2[i])
            {
                createtreeorground(groundprefab2, ref clone, Vector3.zero);
                break;
            }
        }
        for (int i = 0; i < posfortopground4.Length; i++)
        {
            if (orderinlayer == posfortopground4[i])
            {
                createtreeorground(groundprefab4, ref clone, Vector3.zero);
                break;
            }
        }
    }

    void setnearscene(GameObject biggrassprefab,ref GameObject clone,
        ref int orderinlayer,int[] posforbiggrass,int[] posfortree1,
        int[] posfortree2,int[] posfortree3)
    {
        for(int i=0;i<posforbiggrass.Length;i++)
        {
            if(orderinlayer==posforbiggrass[i])
            {
                createscene(biggrassprefab, ref clone, orderinlayer);
                break;
            }
        }
        for (int i = 0; i < posfortree1.Length; i++)
        {
            if (orderinlayer == posfortree1[i])
            {
                createtreeorground(treeprefab1, ref clone,new Vector3(0,1.15f,0));
                break;
            }
        }
        for (int i = 0; i < posfortree2.Length; i++)
        {
            if (orderinlayer == posfortree2[i])
            {
                createtreeorground(treeprefab2, ref clone, new Vector3(0, 1.15f, 0));
                break;
            }
        }
        for (int i = 0; i < posfortree3.Length; i++)
        {
            if (orderinlayer == posfortree3[i])
            {
                createtreeorground(treeprefab3, ref clone, new Vector3(0, 1.15f, 0));
                break;
            }
        }
    }

    void initializebottomfarland()
    {
        initializeplatform(landprefab1, ref lastposofbottomfarlandf1,
            landprefab1.transform.position, startlandtile, bottomfarsidewalkholder,
            ref bottomfarlandf1tile, ref lastorderofbottomfarlandf1,
            new Vector3(1.6f, 0, 0));
        initializeplatform(landprefab2, ref lastposofbottomfarlandf2,
            landprefab2.transform.position, startlandtile-3, bottomfarsidewalkholder,
            ref bottomfarlandf2tile, ref lastorderofbottomfarlandf2,
            new Vector3(1.6f, 0, 0));
        initializeplatform(landprefab3, ref lastposofbottomfarlandf3,
            landprefab3.transform.position, startlandtile-4, bottomfarsidewalkholder,
            ref bottomfarlandf3tile, ref lastorderofbottomfarlandf3,
            new Vector3(1.6f, 0, 0));
        initializeplatform(landprefab4, ref lastposofbottomfarlandf4,
            landprefab4.transform.position, startlandtile-7, bottomfarsidewalkholder,
            ref bottomfarlandf4tile, ref lastorderofbottomfarlandf4,
            new Vector3(1.6f, 0, 0));
        initializeplatform(landprefab5, ref lastposofbottomfarlandf5,
            landprefab5.transform.position, startlandtile-10, bottomfarsidewalkholder,
            ref bottomfarlandf5tile, ref lastorderofbottomfarlandf5,
            new Vector3(1.6f, 0, 0));
    }
}
