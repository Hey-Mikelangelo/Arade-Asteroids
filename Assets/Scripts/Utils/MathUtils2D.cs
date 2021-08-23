using UnityEngine;

public static class MathUtils2D
{
    public static Vector2 GetVectorFromTo(Vector2 from, Vector2 to)
    {
        return to - from;
    }

    public static Quaternion GetRotationToPoint(Vector2 origin, Vector2 target)
    {
        Vector2 vectorToTarget = GetVectorFromTo(origin, target);
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        return q;
    }

    public static bool Contains(this LayerMask layermask, int layer)
    {
        return layermask == (layermask | (1 << layer));
    }

    public static Vector2 GetVectorByAngle(float angle)
    {
        return new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
    }

    public static bool RandomBool()
    {
        return Random.Range(0, 2) == 1;
    }

    public static Vector2 GetRandomPointInsideRect(Rect rect)
    {
        float randX = Random.Range(rect.xMin, rect.xMax);
        float randY = Random.Range(rect.yMin, rect.yMax);
        return new Vector2(randX, randY);

    }
    public static Vector2 GetRandomPointBetweenRects(Rect insideRect, Rect outsideRect)
    {
        bool topBottom = MathUtils2D.RandomBool();
        float randomY, randomX;
        if (topBottom)
        {
            bool top = MathUtils2D.RandomBool();
            if (top)
            {
                randomY = Random.Range(insideRect.yMax, outsideRect.yMax);
                randomX = Random.Range(outsideRect.xMin, insideRect.xMax);
            }
            //if bottom
            else
            {
                randomY = Random.Range(outsideRect.yMin, insideRect.yMin);
                randomX = Random.Range(insideRect.xMin, outsideRect.xMax);
            }
        }
        //if rightLeft
        else
        {
            bool right = MathUtils2D.RandomBool();
            if (right)
            {
                randomY = Random.Range(insideRect.yMin, outsideRect.yMax);
                randomX = Random.Range(insideRect.xMax, outsideRect.xMax);
            }
            //if left
            else
            {
                randomY = Random.Range(outsideRect.yMin, insideRect.yMax);
                randomX = Random.Range(outsideRect.xMin, insideRect.xMin);
            }
        }
        return new Vector2(randomX, randomY);
    }

    public static Rect GetRectFromMinMax(Vector2 rectMin, Vector2 rectMax)
    {
        return new Rect(rectMin.x, rectMin.y, rectMax.x - rectMin.x, rectMax.y - rectMin.y);
    }

    public static Rect GetRectCameraWorld(Camera camera)
    {
        Vector3 rectMin = camera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 rectMax = camera.ViewportToWorldPoint(new Vector2(1, 1));

        Rect rect = GetRectFromMinMax(rectMin, rectMax);
        return rect;
    }

    public static Rect GetExpanded(this Rect rect, float up, float down, float right, float left)
    {
        Vector2 leftBottomExpand = new Vector2(left, down);
        Vector2 position = rect.position - leftBottomExpand;
        Vector2 size = rect.size + leftBottomExpand + new Vector2(right, up);
        return new Rect(position, size);
    }
}

