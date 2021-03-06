﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakinBabies
{
    class QualityBar : GameSprite
    {
        #region Declarations
        private int quality;
        #endregion

        #region Gets/Sets
        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }
        #endregion

        #region Methods
        public QualityBar(ContentManager Content, Vector2 babyPos)
        {
            quality = 100;

            baseImage = Content.Load<Texture2D>("Conveyor");
            position = new Vector2((int)babyPos.X + 10, (int)babyPos.Y - 10);
            bounds = new Rectangle((int)position.X, (int)position.Y, quality, 5);

        }
        public void Update(Vector2 babyPos)
        {
            if (quality > 200) quality = 200;
            if (quality < 0) quality = 0;
            bounds = new Rectangle((int)babyPos.X + 10, (int)babyPos.Y - 10, quality/2, 5);
        }
        #endregion
    }
}
