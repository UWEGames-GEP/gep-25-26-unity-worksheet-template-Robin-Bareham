using UnityEngine;

public class PanelInfo : MonoBehaviour
{
    private Sprite current_sprite;
    private string current_name = "NULL";
    private int current_count = 0;

    public Sprite getSprite() 
    { 
        return current_sprite; 
    }
    public void setSprite(Sprite sprite) 
    { 
        current_sprite = sprite; 
    }
    public string getName() 
    { 
        return current_name; 
    }
    public void setName(string name) 
    { 
        current_name = name; 
    }
    public int getCount() 
    { 
        return current_count; 
    }
    public void setCount(int count) 
    {
        current_count = count; 
    }
  

   

    
}
