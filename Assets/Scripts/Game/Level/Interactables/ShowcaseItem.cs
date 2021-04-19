using UnityEngine;

public class ShowcaseItem : MonoBehaviour
{

    #region Internal Attributes

    /// <summary>
    /// Internal handle to text mesh
    /// </summary>
    private TextMesh priceText;

    /// <summary>
    /// Handler to the sound effect
    /// </summary>
    public VolumeSE volumeSE;

    #endregion

    #region External Attributes

    public enum ItemType
    {
        None,
        ExtraLife
    }

    /// <summary>
    /// Item type
    /// </summary>
    public ItemType itemType;

    /// <summary>
    /// Item price
    /// </summary>
    public uint itemPrice;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        DisplayPrice();
    }

    // Display price
    void DisplayPrice()
    {
        priceText = GetComponentInChildren<TextMesh>();
        priceText.text = "Price: " + itemPrice.ToString();
    }

    // Display price and item in the GUI
    public void DisplayPriceAndItem()
    {
        priceText = GetComponentInChildren<TextMesh>();
        priceText.text = "Item: " + itemType.ToString() + ", Price: " + itemPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, GameEngine.interactableRotationSpeed * Time.deltaTime, 0);

        priceText.gameObject.transform.Rotate(eulerAngles);
    }
}
