using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    public LevelManager lm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !lm.gameOver && lm.startGame)
        {
            //Debug.Log("Clicked");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                lm.IncrementHits();
                if (hit.collider.gameObject.transform.position.x < (Screen.width / 2))
                    lm.LeftSideTargets += 1;
                else lm.RightSideTargets += 1;
                if (hit.collider.gameObject.transform.position.y > (Screen.height / 2))
                    lm.DownSideTargets += 1;
                else lm.TopSideTargets += 1;
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
