using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakinBabies
{
    class Button : GameSprite
    {
        #region Declarations
        private MouseState oldMouseState;
        private bool isPressed;
        private bool isFlipped;
        private Color color;
        #endregion

        #region Gets/Sets
        public Texture2D BaseImage
        {
            get { return baseImage; }
            set { baseImage = value; }
        }
        public MouseState OldMouseState
        {
            get { return oldMouseState; }
            set { oldMouseState = value; }
        }
        public bool IsPressed
        {
            get { return isPressed; }
            set { isPressed = value; }
        }
        public bool IsFlipped
        {
            get { return isFlipped; }
            set { isFlipped = value; }
        }
        #endregion

        #region Methods
        public Button(ContentManager Content, string imageName, Vector2 pos)
        {
            baseImage = Content.Load<Texture2D>(imageName);
            position = pos;
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width * 2, baseImage.Height * 2);
            oldMouseState = Mouse.GetState();
            isPressed = false;
            isFlipped = false;
            color = Color.White;
        }
        public void Update()
        {
            MouseState newMouseState = Mouse.GetState();
            bounds = new Rectangle((int)position.X, (int)position.Y, baseImage.Width * 2, baseImage.Height * 2);
            if (Bounds.Contains(newMouseState.Position))
            {
                if ((oldMouseState.LeftButton != ButtonState.Pressed && newMouseState.LeftButton == ButtonState.Pressed))
                {
                    color = Color.Gray;
                    isPressed = true;
                }
                else if ((oldMouseState.RightButton != ButtonState.Pressed && newMouseState.RightButton == ButtonState.Pressed))
                {
                    color = Color.Gray;
                    isPressed = true;
                    isFlipped = true;
                }
                else
                {
                    color = Color.White;
                    isPressed = false;
                    isFlipped = false;
                }
            }
            oldMouseState = newMouseState;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(baseImage, position, color);
        }
        #endregion
    }
}
