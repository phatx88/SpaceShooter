using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplodeAnimation : MonoBehaviour
{
    [SerializeField] List<Sprite> listAnimationSprites = new List<Sprite>();
    [SerializeField] SpriteRenderer imgExplode;
    public void RunAnimation()
    {
        StartCoroutine(Animation());
    }

    public IEnumerator Animation()
    {
        foreach(Sprite sprite in listAnimationSprites)
        {
            imgExplode.sprite = sprite;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
