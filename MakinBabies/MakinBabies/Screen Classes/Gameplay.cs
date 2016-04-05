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
        private SpriteFont qualityText;
        private KeyboardState oldKeyState;
        private int totalQuality;

        private List<Texture2D> exitChuteParts;
        private Texture2D exitChuteEntrance;
        private Texture2D screenBacking;

        private List<Conveyor> belt;
        private List<Baby> babies;
        private int babyTimer;
        private int timerCount;

        private Rectangle lockBox1;
        //private Rectangle lockBox2;
        //private Rectangle lockBox3;
        private Rectangle finishBox;
        private Rectangle killBox;

        private bool endGame;

        private PuzzleDNA firstPuzzle;

        private Options optionsSection;
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
        public bool EndGame
        {
            get { return endGame; }
            set { endGame = value; }
        }
        #endregion

        #region Methods
        public Gameplay(ContentManager Content)
        {
            this.Content = Content;
            qualityText = Content.Load<SpriteFont>("QualityText");
            oldKeyState = Keyboard.GetState();
            screenBacking = Content.Load<Texture2D>("BackgroundScreen");
            totalQuality = 200;

            endGame = false;

            #region Checkpoints
            lockBox1 = new Rectangle(750, 700, 1, 1600);
            //lockBox2 = new Rectangle(750, 700, 1, 1600);
            //lockBox3 = new Rectangle(1100, 700, 1, 1600);
            finishBox = new Rectangle(1587, 700, 1, 1600);
            killBox = new Rectangle(1500, -300, 100, 100);
            #endregion

            #region Belts
            belt = new List<Conveyor>();
            for (int i = 0; i < 15; i++)
            {
                belt.Add(new Conveyor(Content, new Vector2(126 * i, 0)));
            }
            #endregion

            #region Babies
            timerCount = 350;
            babies = new List<Baby>();
            babies.Add(new Baby(Content));
            #endregion

            #region Chute
            exitChuteParts = new List<Texture2D>();
            for (int i = 0; i < 3; i++)
            {
                exitChuteParts.Add(Content.Load<Texture2D>("VacTubeSection"));
            }
            exitChuteEntrance = Content.Load<Texture2D>("VacTubeEntrance");
            #endregion

            #region Puzzles
            firstPuzzle = new PuzzleDNA(Content);
            #endregion

            #region Options Area
            optionsSection = new Options(Content);
            #endregion
        }

        public void Update()
        {
            KeyboardState newKeyState = Keyboard.GetState();

            #region Baby Update
            babyTimer++;
            for (int i = 0; i < babies.Count; i++)
            {
                if (babies[i].Bounds.Intersects(killBox))
                {
                    totalQuality = totalQuality + babies[i].QualityBar.Quality - 100;
                    babies.RemoveAt(i);
                    break;
                }
                if (babies[i].Bounds.Intersects(finishBox))
                {
                    babies[i].IsStopped = true;
                    babies[i].IsUnderChute = true;
                    //Add points total code
                }
                if (babies[i].Bounds.Intersects(lockBox1) && babies[i].MoveLock1 == true)
                {
                    babies[i].IsStopped = true;
                }
                if (babies[i].Bounds.Intersects(lockBox1) && babies[i].IsStopped == true && firstPuzzle.Accept.IsPressed)
                {
                    if (firstPuzzle.IsPassed)
                    {
                        babies[i].QualityBar.Quality += 40;
                        babies[i].MoveLock1 = false;
                        babies[i].IsStopped = false;
                    }
                    else
                    {
                        babies[i].QualityBar.Quality -= 40;
                        babies[i].MoveLock1 = false;
                        babies[i].IsStopped = false;
                    }
                }

                //if (babies[i].Bounds.Intersects(lockBox2) && babies[i].MoveLock2 == true) babies[i].IsStopped = true;
                //if (babies[i].Bounds.Intersects(lockBox2) && babies[i].IsStopped == true && (!oldKeyState.IsKeyDown(Keys.D1) && newKeyState.IsKeyDown(Keys.D2)))
                //{
                //    babies[i].MoveLock2 = false;
                //    babies[i].IsStopped = false;
                //    //Add or remove quality
                //}

                //if (babies[i].Bounds.Intersects(lockBox3) && babies[i].MoveLock3 == true) babies[i].IsStopped = true;
                //if (babies[i].Bounds.Intersects(lockBox3) && babies[i].IsStopped == true && (!oldKeyState.IsKeyDown(Keys.D1) && newKeyState.IsKeyDown(Keys.D3)))
                //{
                //    babies[i].MoveLock3 = false;
                //    babies[i].IsStopped = false;
                //    //Add or remove quality
                //}

                foreach (var otherBaby in babies)
                {
                    if (otherBaby == babies[i]) break;
                    if (babies[i].Bounds.Intersects(otherBaby.Bounds)) babies[i].IsStopped = true;
                    else if (!babies[i].Bounds.Intersects(otherBaby.Bounds)
                        && (!babies[i].Bounds.Intersects(lockBox1)/* && !babies[i].Bounds.Intersects(lockBox2)
                            && !babies[i].Bounds.Intersects(lockBox3)*/)
                                && babies[i].IsUnderChute == false)
                        babies[i].IsStopped = false;
                }
                babies[i].Update();
            }
            if (babyTimer >= timerCount)
            {
                if (timerCount >= 100) timerCount -= 4;
                babyTimer = 0;
                babies.Add(new Baby(Content));
            }
            if (babies.Count >= 10) endGame = true;
            #endregion

            #region Puzzles Update
            firstPuzzle.Update();
            #endregion

            optionsSection.Update();

            oldKeyState = newKeyState;
        }

        public void Draw(SpriteBatch sb)
        {
            #region Puzzles Draw
            firstPuzzle.Draw(sb);
            sb.Draw(screenBacking, new Rectangle(0, 0, 1600, 900), Color.White);
            #endregion

            #region Belt Draw
            foreach (var beltPart in belt)
            {
                beltPart.Draw(sb);
            }
            #endregion

            #region Baby Draw
            foreach (var baby in babies)
            {
                baby.Draw(sb);
            }
            #endregion

            #region Chute Draw
            for (int i = 0; i < exitChuteParts.Count; i++)
            {
                sb.Draw(exitChuteParts[i], new Rectangle(1450, (exitChuteParts[i].Height * 2) * i, exitChuteParts[i].Width * 2, exitChuteParts[i].Height * 2), Color.White);
            }
            sb.Draw(exitChuteEntrance, new Rectangle(1450, 462, exitChuteEntrance.Width * 2, exitChuteEntrance.Height * 2), Color.White);
            #endregion

            sb.DrawString(qualityText, "Total: " + totalQuality, new Vector2(50, 250), Color.White);
            sb.DrawString(qualityText, "Babies: " + babies.Count, new Vector2(50, 200), Color.White);
            sb.DrawString(qualityText, "Try to keep your total", new Vector2(10, 50), Color.White);
            sb.DrawString(qualityText, "above 0 and baby count", new Vector2(10, 100), Color.White);
            sb.DrawString(qualityText, "below 10 or GAME OVER", new Vector2(10, 150), Color.White);
            optionsSection.Draw(sb);
            //>>>>>>>>>>>>>>>>>>Draw the checkpoints for testing <<<<<<<<<<<<<<<<<<<<<
            //sb.Draw(babies[0].BaseImage, lockBox1, Color.White);
            //sb.Draw(babies[0].BaseImage, lockBox2, Color.White);
            //sb.Draw(babies[0].BaseImage, lockBox3, Color.White);
            //sb.Draw(babies[0].BaseImage, finishBox, Color.White);
        }
        #endregion
    }
}
