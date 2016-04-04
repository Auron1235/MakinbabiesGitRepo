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
    class Gameplay
    {
        #region Declarations
        private ContentManager Content;
        private KeyboardState oldKeyState;

        private List<Conveyor> belt;
        private List<Baby> babies;

        private Rectangle lockBox1;
        private Rectangle lockBox2;
        private Rectangle lockBox3;
        private Rectangle finishBox;
        private int babyTimer;
        #endregion

        #region Gets/Sets
        public List<Conveyor> Belt
        {
            get { return belt; }
            set { belt = value; }
        }
        public List<Baby> Babies
        {
            get { return babies; }
            set { babies = value; }
        }
        
        #endregion

        #region Methods
        public Gameplay(ContentManager Content)
        {
            this.Content = Content;
            oldKeyState = Keyboard.GetState();
            lockBox1 = new Rectangle(400, 700, 100, 100);
            lockBox2 = new Rectangle(750, 700, 100, 100);
            lockBox3 = new Rectangle(1100, 700, 100, 100);
            finishBox = new Rectangle(1500, 700, 100, 100);

            #region Belts
            belt = new List<Conveyor>();
            for (int i = 0; i < 78; i++)
            {
                belt.Add(new Conveyor(Content, new Vector2(20 * i - 100, 0)));
            }
            #endregion

            #region Babies
            babies = new List<Baby>();
            babies.Add(new Baby(Content));
            #endregion
        }

        public void Update()
        {
            KeyboardState newKeyState = Keyboard.GetState();
            babyTimer++;
            for (int i = 0; i < babies.Count; i++)
            {
                if (babies[i].Bounds.Intersects(finishBox))
                {
                    babies[i].IsStopped = true;
                    babies[i].IsUnderChute = true;
                }
                if (babies[i].Bounds.Intersects(lockBox1) && babies[i].MoveLock1 == true) babies[i].IsStopped = true;
                if (babies[i].Bounds.Intersects(lockBox1) && babies[i].IsStopped == true && (!oldKeyState.IsKeyDown(Keys.D1) && newKeyState.IsKeyDown(Keys.D1)))
                {
                    babies[i].MoveLock1 = false;
                    babies[i].IsStopped = false;
                }

                if (babies[i].Bounds.Intersects(lockBox2) && babies[i].MoveLock2 == true) babies[i].IsStopped = true;
                if (babies[i].Bounds.Intersects(lockBox2) && babies[i].IsStopped == true && (!oldKeyState.IsKeyDown(Keys.D1) && newKeyState.IsKeyDown(Keys.D2)))
                {
                    babies[i].MoveLock2 = false;
                    babies[i].IsStopped = false;
                }

                if (babies[i].Bounds.Intersects(lockBox3) && babies[i].MoveLock3 == true) babies[i].IsStopped = true;
                if (babies[i].Bounds.Intersects(lockBox3) && babies[i].IsStopped == true && (!oldKeyState.IsKeyDown(Keys.D1) && newKeyState.IsKeyDown(Keys.D3)))
                {
                    babies[i].MoveLock3 = false;
                    babies[i].IsStopped = false;
                }

                foreach (var otherBaby in babies)
                {
                    if (otherBaby == babies[i]) break;
                    if (babies[i].Bounds.Intersects(otherBaby.Bounds)) babies[i].IsStopped = true;
                    else if (!babies[i].Bounds.Intersects(otherBaby.Bounds)
                        && (!babies[i].Bounds.Intersects(lockBox1) && !babies[i].Bounds.Intersects(lockBox2)
                            && !babies[i].Bounds.Intersects(lockBox3))
                                && babies[i].IsUnderChute == false)
                        babies[i].IsStopped = false;
                }
                babies[i].Update();
            }
            if (babyTimer >= 350)
            {
                babyTimer = 0;
                babies.Add(new Baby(Content));
            }
            oldKeyState = newKeyState;
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (var beltPart in belt)
            {
                beltPart.Draw(sb);
            }
            foreach (var baby in babies)
            {
                baby.Draw(sb);
            }
            sb.Begin();
            sb.Draw(babies[0].BaseImage, lockBox1, Color.White);
            sb.Draw(babies[0].BaseImage, lockBox2, Color.White);
            sb.Draw(babies[0].BaseImage, lockBox3, Color.White);
            sb.Draw(babies[0].BaseImage, finishBox, Color.White);
            sb.End();
        }
        #endregion
    }
}
