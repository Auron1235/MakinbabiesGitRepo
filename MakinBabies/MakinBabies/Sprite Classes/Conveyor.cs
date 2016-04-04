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
            position = new Vector2(50, 780) + offSet;
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width, baseImage.Height);
        }
        #endregion
    }
}
