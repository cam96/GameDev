public class Point
{
	private float _x;
	private float _y;

	public Point(float x, float y) {
		this._x = x;
		this._y = y;
	}

	public float X {
		get
		{
			return this._x;
		}
		set
		{
			this._x = value;
		}
	}

	public float Y {
		get
		{
			return this._y;
		}
		set
		{
			this._y = value;
		}
	}

	public void SetPoint(float x, float y) {
		this._x = x;
		this._y = y;
	}
}

