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
        private Rectangle babyBounds;

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
        public QualityBar QualityBar
        {
            get { return qualityBar; }
            set { qualityBar = value; }
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
            baseImage = Content.Load<Texture2D>("Jar");
            babyImage = Content.Load<Texture2D>("Baby");
            position = new Vector2(-100, 650);
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width * 2, baseImage.Height * 2);
            babyBounds = new Rectangle((int)position.X + 30, (int)position.Y + 30, baseImage.Width, baseImage.Height);

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
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width * 2, baseImage.Height * 2);
            babyBounds = new Rectangle((int)position.X + 35, (int)position.Y + 50, baseImage.Width, baseImage.Height);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(baseImage, bounds, Color.White);
            sb.Draw(babyImage, babyBounds, Color.White);
            qualityBar.Draw(sb);
        }
        #endregion
    }
}