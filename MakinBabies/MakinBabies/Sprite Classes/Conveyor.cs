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
    class Conveyor : GameSprite
    {
        #region Declarations
        #endregion

        #region Gets/Sets
        #endregion

        #region Methods
        public Conveyor(ContentManager Content, Vector2 offSet)
        {
            baseImage = Content.Load<Texture2D>("Conveyor");
            position = new Vector2(0, 900 - baseImage.Height*2 + 10) + offSet;
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width * 2, baseImage.Height * 2);
        }
        #endregion
    }
}
