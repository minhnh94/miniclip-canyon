using System;

public class Grid
{
	public bool isRoad;
	public bool isBuildable;

	public Grid(bool isRoad)
	{
		this.isRoad = isRoad;
		isBuildable = !isRoad;
	}
}
