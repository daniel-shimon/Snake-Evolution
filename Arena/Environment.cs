using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Evolution
{
    public struct Line
    {
        public readonly Vector2 p1, p2;
        public readonly float A, B, C, distance, angle;
        public Line(Vector2 p1, Vector2 p2)
        {
            if (p1.X < p2.X || (p1.X == p2.X && p1.Y < p2.Y)) { this.p1 = p1; this.p2 = p2; }
            else { this.p1 = p2; this.p2 = p1; }
            if (p1.X == p2.X)
            {
                this.A = 1;
                this.B = 0;
                this.C = -p1.X;
            }
            else
            {
                this.A = (p1.Y - p2.Y) / (p2.X - p1.X);
                this.B = 1;
                this.C = -A * p1.X - p1.Y;
            }
            this.distance = Environment.Distance(p1, p2);
            if (B == 0) this.angle = MathHelper.ToRadians(90);
            else this.angle = (float)Math.Atan(-A / B);
        }   
    }

    public struct Circle
    {
        public readonly Vector2 origin;
        public readonly int radius;
        public Circle(Vector2 origin, int radius = 0)
        {
            this.origin = origin;
            if (radius == 0)
                this.radius = 4 * Player.StepSize;
            else
                this.radius = radius;
        }
    }

    public class Environment
    {
        public static int wallWidth = 10;
        private readonly List<Circle> foods;
        private readonly Random rnd;
        public static int foodCount = 2;
        public Environment()
        {
            Walls = new List<Line>();
            foods = new List<Circle>();
            rnd = new Random();
            RefreshParameters();
        }
        public List<Line> Walls { get; }
        public void AddWall(Line wall) { this.Walls.Add(wall); }
        public void AddFood(Vector2 foodOrigin) { this.foods.Add(new Circle(foodOrigin)); }
        public Vector2 CurrentFood
        {
            get { return foods[0].origin; }
        }
        public float WallDistance(Player player)
        {
            float minDistance = float.MaxValue;
            foreach (Line wall in Walls)
            {
                float distance = Distance(player, wall);
                if (distance < minDistance) minDistance = distance;
            }
            return minDistance;
        }
        public float FoodDistanceFront(Player player)
        {
            float minDistance = float.MaxValue;
            foreach (Circle food in foods)
            {
                float distance = Distance(player, food);
                if (distance < minDistance) minDistance = distance;
            }
            return minDistance;
        }
        public float FoodDistance(Player player)
        {
            float minDistance = float.MaxValue;
            foreach (Circle food in foods)
            {
                float distance = Distance(player.Position, food);
                if (distance < minDistance) minDistance = distance;
            }
            return minDistance;
        }
        public void UpdateLocation(Player mainPlayer)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                if (Distance(mainPlayer.Position, foods[i].origin) <= foods[i].radius)
                {
                    foods.RemoveAt(i);
                    NewRandomFood();
                    mainPlayer.AddLife();
                }
            }
        }
        public void DrawWalls(SpriteBatch spriteBatch, Texture2D texture)
        {
            foreach (Line wall in Walls)
            {
                Rectangle wallRect = new Rectangle(Convert.ToInt32(wall.p1.X + wallWidth * Math.Sin(wall.angle) / 2),
                    Convert.ToInt32(wall.p1.Y - wallWidth * Math.Cos(wall.angle) / 2),
                    Convert.ToInt32(wall.distance),
                    wallWidth);
                spriteBatch.Draw(texture,
                    wallRect,
                    null,
                    Color.White,
                    (float)wall.angle,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0);
            }
        }
        public void RefreshParameters()
        {
            Walls.Clear();
            AddWall(new Line(new Vector2(0, 0), new Vector2(SemenGame.ScreenWidth, 0)));
            AddWall(new Line(new Vector2(0, 0), new Vector2(0, SemenGame.ScreenHeight)));
            AddWall(new Line(new Vector2(SemenGame.ScreenWidth, 0), new Vector2(SemenGame.ScreenWidth, SemenGame.ScreenHeight)));
            AddWall(new Line(new Vector2(0, SemenGame.ScreenHeight), new Vector2(SemenGame.ScreenWidth, SemenGame.ScreenHeight)));
            ShuffleFood();
        }
        public void DrawFood(SpriteBatch spriteBatch, Texture2D texture)
        {
            foreach (Circle food in foods)
            {
                Rectangle wallRect = new Rectangle(Convert.ToInt32(food.origin.X- food.radius),
                    Convert.ToInt32(food.origin.Y-food.radius),
                    Convert.ToInt32(2 * food.radius),
                    Convert.ToInt32(2 * food.radius));
                spriteBatch.Draw(texture, wallRect, Color.White);
            }
        }
        public void ShuffleFood()
        {
            foods.Clear();
            for (int i = 0; i < foodCount; i++)
                NewRandomFood();
        }
        public void NewRandomFood()
        {
            Circle new_food;
            new_food = new Circle(new Vector2(rnd.Next(SemenGame.ScreenWidth), rnd.Next(SemenGame.ScreenHeight)));
            foods.Add(new_food);
        }
        public static float Distance(Player player, Line wall)
        {
            float A1 = player.A;
            float B1 = player.B;
            float C1 = player.C;
            float A2 = wall.A;
            float B2 = wall.B;
            float C2 = wall.C;
            // Find crossing point
            Vector2 crossingPoint = new Vector2();
            if (A1 == A2 && B1 == B2 && C1 == C2)
            {
                if ((player.Position.X == wall.p1.X && player.Position.Y == wall.p1.Y)
                    ||
                    (player.Position.X == wall.p2.X && player.Position.Y == wall.p2.Y))
                {
                    return 0;
                }
            }
            else
            {
                crossingPoint.Y = (A1 * C2 - A2 * C1) / (A2 * B1 - A1 * B2);
                if (A1 != 0) crossingPoint.X = -(B1 * crossingPoint.Y + C1) / A1;
                else crossingPoint.X = -(B2 * crossingPoint.Y + C2) / A2;
            }
            if (IsInFront(player, crossingPoint)) return Distance(player.Position, crossingPoint);
            return float.MaxValue;
        }
        public static float Distance(Player player, Circle food)
        {
            float A = player.A;
            float B = player.B;
            float C = player.C;
            float a = food.origin.X;
            float b = food.origin.Y;
            float r = food.radius;
            Vector2 crossingPoint = new Vector2();
            if (A == 0)
            {
                crossingPoint.Y = -C / B;
                crossingPoint.X = food.origin.X;
            }
            else
            {
                float alef = (float)(Math.Pow(A, 2) + Math.Pow(B, 2));
                float bet = B * C + A * a * B - (float)Math.Pow(A, 2) * b;
                float gimmel = C * (C + 2 * A * a) + (float)Math.Pow(A, 2) * (a * a + b * b - r * r);
                float root = (float)Math.Pow(bet, 2) - alef * gimmel;
                if (root < 0) return float.MaxValue;
                if (root == 0)
                {
                    crossingPoint.Y = -bet / alef;
                    crossingPoint.X = (-B * crossingPoint.Y - C) / A;
                }
                else
                {
                    float y1 = (-bet + (float)Math.Sqrt(root)) / alef;
                    float y2 = (-bet - (float)Math.Sqrt(root)) / alef;
                    float x1 = (-B * y1 - C) / A;
                    float x2 = (-B * y2 - C) / A;
                    if (Distance(player.Position, new Vector2(x1, y1)) < Distance(player.Position, new Vector2(x2, y2)))
                    {
                        crossingPoint.X = x1;
                        crossingPoint.Y = y1;
                    }
                    else
                    {
                        crossingPoint.X = x2;
                        crossingPoint.Y = y2;
                    }
                }
            }
            if (IsInFront(player, crossingPoint)) return Distance(player.Position, crossingPoint);
            return float.MaxValue;
        }
        public static float Distance(Vector2 p1, Circle food)
        {
            return Distance(p1, food.origin) + food.radius;
        }
        public static float Distance(Vector2 p1, Vector2 p2)
        {
            float xDistance = (float)Math.Pow(p1.X - p2.X,2); //(float)Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
            float yDistance = (float)Math.Pow(p1.Y - p2.Y,2);
            float distance = (float)Math.Sqrt(xDistance + yDistance);
            if (Math.Abs(distance) <= 0.1)
            {
                return 0;
            }
            return distance;
        }
        private static bool IsInFront(Player player, Vector2 point)
        {
            return (
                (point.X != float.NaN && point.Y != float.NaN)
                &&
                (((270 < player.Direction || player.Direction < 90) && (player.Position.X <= point.X))
                ||
                ((90 < player.Direction && player.Direction < 270) && (player.Position.X >= point.X))
                ||
                (player.Direction == 90 && player.Position.Y <= point.Y)
                ||
                (player.Direction == 270 && player.Position.Y >= point.Y)
                ));
        }
    }
}
