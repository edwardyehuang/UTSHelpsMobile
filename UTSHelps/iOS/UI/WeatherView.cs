using System;
using System.Drawing;
using CoreMotion;
using Foundation;
using SceneKit;
using SpriteKit;
using UIKit;
using CoreGraphics;

using System.Drawing;

namespace UTSHelps.iOS
{
	public class WeatherView : SKView
	{
		public WeatherView (CGRect frame) : base(frame)
		{
			ShowsFPS = true;
			ShowsNodeCount = true;
			ShowsDrawCount = true;

			var scene = new WeatherScene (Frame.Size);
			scene.ScaleMode = SKSceneScaleMode.AspectFill;
			PresentScene (scene);
		}

		public class WeatherScene : SKScene
		{
			SKSpriteNode backgroundSprite;

			public WeatherScene(CGSize size) : base(size)
			{
				backgroundSprite = SKSpriteNode.FromImageNamed ("b11.png");

				backgroundSprite.Position = new CGPoint (Size.Width / 2, Size.Height / 2);
				backgroundSprite.Size = new CGSize(this.Size.Height / backgroundSprite.Size.Height * backgroundSprite.Size.Width, Size.Height);

				AddChild(backgroundSprite);
			}

		}
	}
}

