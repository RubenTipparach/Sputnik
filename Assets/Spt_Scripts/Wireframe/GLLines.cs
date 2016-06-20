using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class GLLines
{
	public static void LineDrawing(Material lineMaterial, Color color, Action lineDrawer)
	{
		lineMaterial.SetPass(0);
		GL.Color(color);

		GL.Begin(GL.LINES);

		// Implementation happens here.
		lineDrawer();

		GL.End();
	}

	public static void LineDrawing(Material lineMaterial, Color color, Vector3 source, Vector3 destination)
	{
		//lineMaterial.color = Color.red;
		lineMaterial.SetColor("_TintColor", color);
		lineMaterial.SetPass(0);

		//GL.Color(Color.yellow);
		GL.Begin(GL.LINES);

		// Implementation happens here.
		GL.Vertex3(source.x, source.y, source.z);
		GL.Vertex3(destination.x, destination.y, destination.z);

		GL.End();
	}

	/// <summary>
	/// Not done yet.
	/// </summary>
	/// <param name="lineMaterial"></param>
	/// <param name="color"></param>
	/// <param name="source"></param>
	/// <param name="destination"></param>
	public static void PathDrawing(Material lineMaterial, Color color, Vector3 source, Vector3 destination)
	{
	}


	/// <summary>
	/// Draws a circle thingy.
	/// </summary>
	/// <param name="lineMaterial">The line material.</param>
	/// <param name="color">The color.</param>
	/// <param name="iteration">The iteration.</param>
	/// <param name="radius">The radius.</param>
	/// <param name="s">The s.</param>
	/// <param name="q">The q.</param>
	public static void CircleDrawing(Material lineMaterial, Color color, int iteration, float radius, Vector3 source, Quaternion rotatiom)
	{
		lineMaterial.SetColor("_TintColor", color);
		lineMaterial.SetPass(0);

		GL.Begin(GL.LINES);
		for (int i = 1; i <= iteration + 1; i++)
		{
			float dg = i;
			float n = iteration;

			Vector3 v = Vector3.zero;

			v.x = radius * Mathf.Cos((dg / n) * Mathf.PI * 2);
			v.z = radius * Mathf.Sin((dg / n) * Mathf.PI * 2);
			v = rotatiom * v;

			Vector3 v1 = new Vector3(v.x + source.x, v.y + source.y, v.z + source.z);

			GL.Vertex3(v1.x, v1.y, v1.z);

			if (i != 1 && i != iteration + 1)
			{
				GL.Vertex3(v.x + source.x, v.y + source.y, v.z + source.z);
			}
		}

		GL.End();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="lineMaterial"></param>
	/// <param name="color"></param>
	/// <param name="source"></param>
	/// <param name="destination"></param>
	public static void BoxDrawing(Material lineMaterial, Color color, float width, float height, Vector3 position)
	{
		lineMaterial.SetColor("_TintColor", color);
		lineMaterial.SetPass(0);

		GL.Begin(GL.LINES);

		// upper width line
		GL.Vertex3(position.x - width / 2, position.y, position.z + height / 2);
		GL.Vertex3(position.x + width / 2, position.y, position.z + height / 2);

		// right height line
		GL.Vertex3(position.x + width / 2, position.y, position.z + height / 2);
		GL.Vertex3(position.x + width / 2, position.y, position.z - height / 2);

		// lower width line
		GL.Vertex3(position.x + width / 2, position.y, position.z - height / 2);
		GL.Vertex3(position.x - width / 2, position.y, position.z - height / 2);

		//height lines
		GL.Vertex3(position.x - width / 2, position.y, position.z - height / 2);
		GL.Vertex3(position.x - width / 2, position.y, position.z + height / 2);

		GL.End();
	}

	/// <summary>
	/// Draws the relative horizontal circle.
	/// </summary>
	/// <param name="iteration">The iteration.</param>
	/// <param name="radius">The radius.</param>
	/// <param name="source">The source.</param>
	/// <param name="rotation">The rotation.</param>
	public static void DrawRelativeHorizontalCircle(int iteration, float radius, Vector3 source, Quaternion rotation)
	{
		GL.Color(new Color(1f, .1f, .5f, .5f));
		for (int i = 1; i <= iteration + 1; i++)
		{
			float dg = i;
			float n = iteration;

			Vector3 v = Vector3.zero;

			v.x = radius * Mathf.Cos((dg / n) * Mathf.PI * 2);
			v.z = radius * Mathf.Sin((dg / n) * Mathf.PI * 2);

			v = rotation * v;

			Vector3 v1 = new Vector3(v.x + source.x, v.y + source.y, v.z + source.z);

			GL.Vertex3(v1.x, v1.y, v1.z);

			if (i != 1 && i != iteration + 1)
			{
				GL.Vertex3(v.x + source.x, v.y + source.y, v.z + source.z);
			}
		}
	}

		
}

