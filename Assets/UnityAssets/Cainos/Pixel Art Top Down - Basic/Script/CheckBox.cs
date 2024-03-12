
using UnityEngine;

public class CheckBox : MonoBehaviour
{

    public Color targetColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            if (other.GetComponent<SpriteRenderer>().color == targetColor)
            {
                BoxManager.Instance.BoxUsed(true);
                Debug.Log("Thùng có màu đúng!" + BoxManager.Instance.countTrue);

            }
            else
            {
                BoxManager.Instance.BoxUsed(false);
                Debug.Log("Thùng có màu sai!" + BoxManager.Instance.countFalse);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            if (collision.GetComponent<SpriteRenderer>().color != targetColor)
            {
                if(BoxManager.Instance.countFalse>0)
                {
                    BoxManager.Instance.countFalse--;
                }
                
            }
            else
            {
                if (BoxManager.Instance.countTrue>0)
                {
                    BoxManager.Instance.countTrue--;
                }
                
            }
        }

    }

}
