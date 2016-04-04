using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MakinBabies
{
    public class GameSprite
    {
        #region Declarations
        protected Texture2D baseImage;
        protected Vector2 position;
        protected Rectangle bounds;
        protected Vector2 velocity;
        protected int animationframes;
        protected int currentAnimationTime;
        protected int animationTimeMax;
        protected Vector2 origin;
        protected float rotation = 0;
        #endregion

        #region Gets/Sets
        public Texture2D BaseImage
        {
            get { return baseImage; }
            set { baseImage = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }
        #endregion

        #region Methods
        //public GameSprite(Texture2D initialTexture, Vector2 initialPosition, int frames, int animTime)
        //{
        //    animationframes = frames;
        //    animationTimeMax = animTime;
        //    baseImage = initialTexture;
        //    position = initialPosition;
        //    origin = new Vector2(baseImage.Width / 2 / animationframes, baseImage.Height / 2);
        //}

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(baseImage, bounds, Color.White);
            sb.End();
        }

        public void DrawAnimated(SpriteBatch batch)
        {
            if (animationTimeMax <= 0) return;
            while (currentAnimationTime > animationTimeMax) currentAnimationTime -= animationTimeMax;
            int currentFrame = (animationframes * currentAnimationTime) / animationTimeMax;
            int pixelsPerFrame = baseImage.Width / animationframes;
            Rectangle animRect = new Rectangle(currentFrame * pixelsPerFrame, 0, pixelsPerFrame, baseImage.Height);
            batch.Draw(baseImage, position + origin, animRect, Color.White, rotation, origin, 1, SpriteEffects.None, 0);
        }

        public bool Collision(GameSprite target)
        {
            if (target == null) return false;
            Rectangle sourceRectangle = new Rectangle(
                (int)(position.X - origin.X), (int)(position.Y - origin.Y),
                baseImage.Width / animationframes, baseImage.Height / animationframes);
            Rectangle targetRectangle = new Rectangle(
                (int)(target.position.X - target.origin.X), (int)(target.position.Y - target.origin.Y),
                target.baseImage.Width / target.animationframes, target.baseImage.Height / target.animationframes);
            return (sourceRectangle.Intersects(targetRectangle));
        }
        #endregion
    }

}
