using UnityEngine;

public class SlimeAnime : MonoBehaviour
{
    public GameObject showObject1; //［表示するオブジェクト］
    public GameObject showObject2; //［表示するオブジェクト］
    int frame = 0;
    bool showParent = true;
    const int FIXED_FRAME_RATE = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = FIXED_FRAME_RATE;
        showObject1.SetActive(true);
        showObject2.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( frame++ > 60) {
            frame = 0;
            showParent = ! showParent;
            if (showObject1 != null) showObject1.SetActive(!showParent); // 表示
            showObject2.SetActive(showParent);
        }
    }
}
