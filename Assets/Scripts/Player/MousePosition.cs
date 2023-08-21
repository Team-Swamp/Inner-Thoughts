using UnityEngine;

public static class MousePosition
{
    public static Vector2 GetMouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
    }
}
