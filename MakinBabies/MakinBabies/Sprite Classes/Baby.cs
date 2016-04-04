using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakinBabies
{
    class Baby : GameSprite
    {
        #region Declarations
        private Texture2D babyImage;
        private Texture2D fluidImage;

        private QualityBar qualityBar;
        private bool isUnderChute;
        private bool isStopped;

        private bool moveLock1;
        private bool moveLock2;
        private bool moveLock3;
        #endregion

        #region Gets/Sets
        public Texture2D BabyImage
        {
            get { return babyImage; }
            set { babyImage = value; }
        }
        public Texture2D FluidImage
        {
            get { return fluidImage; }
            set { fluidImage = value; }
        }
        public bool IsUnderChute
        {
            get { return isUnderChute; }
            set { isUnderChute = value; }
        }
        public bool IsStopped
        {
            get { return isStopped; }
            set { isStopped = value; }
        }
        public bool MoveLock1
        {
            get { return moveLock1; }
            set { moveLock1 = value; }
        }
        public bool MoveLock2
        {
            get { return moveLock2; }
            set { moveLock2 = value; }
        }
        public bool MoveLock3
        {
            get { return moveLock3; }
            set { moveLock3 = value; }
        }
        #endregion

        #region Methods
        public Baby(ContentManager Content)
        {
            baseImage = Content.Load<Texture2D>("Baby Jar");
            position = new Vector2(-100, 768);
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);

            qualityBar = new QualityBar(Content, position);

            isStopped = false;
            isUnderChute = false;
            MoveLock1 = true;
            MoveLock2 = true;
            MoveLock3 = true;
        }
        public void Movement()
        {
            if (!isStopped) position.X += 1;
            if (isUnderChute) position.Y -= 10;
        }
        public void Update()
        {
            qualityBar.Update(position);
            this.Movement();
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(baseImage, bounds, Color.White);
            sb.End();
            qualityBar.Draw(sb);
        }
        #endregion
    }
}